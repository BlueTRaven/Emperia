using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace Emperia.Bosses.Inquisitor
{
    public class Inquisitor : ModNPC
    {
        private enum Move
        {
            Teleporting,
            AfterTeleport,
            LaserStart,
            LaserDuring,
            BoltStart,
            BoltDuring,
            PhaseTransitionStart,
            Floating
        }

        private Move move { get { return (Move)npc.ai[0]; } set { npc.ai[0] = (int)value; } }
        private Move prevMove;

        private int counter { get { return (int)npc.ai[1]; } set { npc.ai[1] = value; } }
        private int counter2 { get { return (int)npc.ai[2]; } set { npc.ai[2] = value; } }

        private Rectangle teleportBounds;

        private bool phaseStart;
        private bool phaseEnd;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Inquisitor");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 10000;
            npc.damage = 150;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 94;
            npc.height = 100;
			npc.alpha = 0;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;

            teleportBounds = new Rectangle(-256, -512, 512, 512);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 16000;
            npc.damage = 175;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
            }

            if (IsInPhaseTwo() && !phaseStart)
            {
                phaseStart = true;
                move = Move.PhaseTransitionStart;
                counter = 240;
                counter2 = 25;

                for (int x = 0; x < npc.Hitbox.Width; x++)
                {
                    for (int y = 0; y < npc.Hitbox.Width; y++)
                    {
                        Dust.NewDust(new Vector2(npc.position.X + x, npc.position.Y + y), 2, 2, 109, Main.rand.Next(-2, 2), 0);
                    }
                }
            }

            if (move == Move.PhaseTransitionStart)
            {
                counter--;
                counter2--;

                if (counter2 <= 0)
                {
                    for (int i = 0; i < 360; i++)
                    {
                        if (i % 12 == 0)
                        {
                            Vector2 vec = Vector2.Transform(new Vector2(-64, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));

                            Dust d = Main.dust[Dust.NewDust(npc.Center + vec + new Vector2(-4, -4), 2, 2, 72, 0, -1)];
                            d.velocity = Vector2.Zero;
                        }
                    }
                    counter2 = 25;
                }

                if (counter <= 0)
                {
                    phaseEnd = true;
                    move = Move.Teleporting;
                }
            }
            if (move == Move.Teleporting)
            {
                bool done = false;

                while (!done)
                {
                    float tpX = Main.rand.Next(teleportBounds.X, teleportBounds.Width);
                    float tpY = Main.rand.Next(teleportBounds.Y, teleportBounds.Height);

                    npc.Center = player.Center + new Vector2(tpX, tpY);

                    Point p = npc.Center.ToTileCoordinates();
                    if (!Main.tile[p.X, p.Y].active() && Main.tile[p.X, p.Y].liquid <= 0)    //not a liquid and inactive
                    {
                        done = true;
                    }
                }

                move = Move.AfterTeleport;
                counter = 120;

                for (int i = 0; i < Main.rand.Next(5, 20); i++)
                {
            
                }
            }
            if (move == Move.AfterTeleport)
            {
                counter--;

                if (counter <= 0)
                {
                    if (!phaseEnd)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            SetMove(Move.LaserStart, 0, 4);
                            //counter2 = 3;
                            //move = Move.LaserStart;
                        }
                        else
                        {
                            SetMove(Move.BoltStart, 0, 2);
                            //counter2 = 3;
                            //move = Move.BoltStart;
                        }
                    }
                    else
                    {
                        if (prevMove == Move.BoltDuring)
                        {
                            SetMove(Move.Floating, 120 + Main.rand.Next(0, 240));
                            //move = Move.Floating;
                            //counter = 120 + Main.rand.Next(0, 240);
                        }
                        else
                        {
                            SetMove(Move.BoltStart, 0, 3);
                            //counter2 = 3;
                            //move = Move.BoltStart;
                        }
                    }
                }
            }
            if (move == Move.LaserStart)
            {
             
                SetMove(Move.LaserDuring, 200, counter2);
                //counter = 200;
                //move = Move.LaserDuring;
            }
            if (move == Move.LaserDuring)
            {
                counter--;

                if (counter <= 0)
                {
                    counter2--;

                    if (counter2 > 0)
                        SetMove(Move.LaserStart, 0, counter2 - 1);// move = Move.LaserStart;
                    else SetMove(Move.Teleporting, 0);// move = Move.Teleporting;
                }
            }
            if (move == Move.BoltStart)
            {
                Vector2 vec = Vector2.Normalize(player.Center - npc.Center) * 6;
                Vector2 vecu = Vector2.Transform(vec, Matrix.CreateRotationZ(MathHelper.ToRadians(-8)));
                Vector2 vecd = Vector2.Transform(vec, Matrix.CreateRotationZ(MathHelper.ToRadians(8)));
                Emperia.CreateProjectile<Projectiles.FearBolt>(mod, npc.Center, vec, 5, 0);
                Emperia.CreateProjectile<Projectiles.FearBolt>(mod, npc.Center, vecu, 5, 0);
                Emperia.CreateProjectile<Projectiles.FearBolt>(mod, npc.Center, vecd, 5, 0);

                SetMove(Move.BoltDuring, 20, counter2);
                //move = Move.BoltDuring;
                //counter = 20;
            }
            if (move == Move.BoltDuring)
            {
                counter--;

                if (counter <= 0)
                {
                    if (counter2 > 0)
                        SetMove(Move.BoltStart, 0, counter2 - 1);
                    else SetMove(Move.Teleporting, 0);
                }
            }
            if (move == Move.Floating)
            {
                counter--;
                SmoothMoveToPosition(new Vector2(player.Center.X, player.Center.Y - 192), .4f, 8);

                if (counter <= 0)
                {
                    SetMove(Move.BoltStart, 0, 3);
                    counter2 = 3;
                    move = Move.BoltStart;
                }
            }
            else npc.velocity *= .95f;

            Dust d1 = Main.dust[Dust.NewDust(npc.position + new Vector2(Main.rand.Next(0, npc.width), npc.height) - new Vector2(8, 2), 20, 20, 109, Main.rand.Next(-2, 3), 0)];
            d1.velocity = new Vector2(0, -2);
        }

        private void SmoothMoveToPosition(Vector2 toPosition, float addSpeed, float maxSpeed, float slowRange = 64, float slowBy = .95f)
        {
            if (Math.Abs((toPosition - npc.Center).Length()) >= slowRange)
            {
                npc.velocity += Vector2.Normalize((toPosition - npc.Center) * addSpeed);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxSpeed, maxSpeed);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -maxSpeed, maxSpeed);
            }
            else
            {
                npc.velocity *= slowBy;
            }
        }

        private void SetMove(Move move, int counter, int counter2 = 0)
        {
            this.prevMove = this.move;
            this.move = move;
            this.counter = counter;
            this.counter2 = counter2;
        }

        private bool IsInPhaseTwo()
        {
            return npc.life <= npc.lifeMax * .4;    //40% hp
        }
    }
}
