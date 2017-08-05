using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
	[AutoloadBossHead]
    public class Mushor : ModNPC
    {
        private enum Move
        {
            Centering,
            Spores,
            Adds,
            Bombing,
            Shielding,
            P2Animating
        }

        private int counter { get { return (int)npc.ai[0]; } set { npc.ai[0] = value; } }

        private Move move { get { return (Move)npc.ai[1]; } set { npc.ai[1] = (int)value; } }
        private Move prevMove;
        private Vector2 targetPosition;

        private int side { get { return (int)npc.ai[2]; } set { npc.ai[2] = value; } }

        private bool p2AnimationStart = false, p2AnimationDone = false;

        private int p2AnimationPhaseLength = 300;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushor");
			Main.npcFrameCount[npc.type] = 2;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 6500;
            npc.damage = 50;
            npc.defense = 13;
            npc.knockBackResist = 0f;
            npc.width = 128;
            npc.height = 128;
            npc.value = Item.buyPrice(0, 8, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            Main.npcFrameCount[npc.type] = 2;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/MUSHOR");
            npc.netAlways = true;
        }
      
        public override void FindFrame(int frameHeight)
        {
            if (p2AnimationDone)
            {
                npc.frame.Y = frameHeight;
            }
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 9000;
            npc.damage = 60;
        }

        public override void AI()
        {
            if (npc.ai[3] > 0)
                npc.dontTakeDamage = true;
            else npc.dontTakeDamage = false;

            Player player = Main.player[npc.target];
            
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = -20;
				
				if (npc.timeLeft > 10)
					{
						npc.timeLeft = 10;
					}
			}

            if (IsBelowPhaseTwoThreshhold() && !p2AnimationStart)
            {
                SetMove(Move.P2Animating, p2AnimationPhaseLength);
                p2AnimationStart = true;
            }

            if (move == Move.P2Animating)
            {
                counter--;
                npc.velocity *= .95f;   //velocity is 95% of what it was last frame

                float amt = Math.Abs(counter - p2AnimationPhaseLength) / 80;

                for (int i = 1; i <= (int)amt; i++)
                {
                    float x = Main.rand.NextFloat() * npc.Hitbox.Width;
                    float y = Main.rand.NextFloat() * npc.Hitbox.Height;

                    Dust.NewDust(new Vector2(npc.Hitbox.X + x, npc.Hitbox.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);
                }

                if (counter <= 0)
                {
                    //for (int i = 4; i < Main.rand.Next(4, 9); i++);
                    //Gore.NewGore(npc.position, new Vector2(npc.velocity.X + (Main.rand.NextFloat() -.5f), -1), mod.GetGoreSlot("Gores/Rotten_Mushroom"));
                    Main.PlaySound(SoundID.Roar, npc.Center, 0);    //for maximum noisyness
                    Main.PlaySound(SoundID.Item, npc.Center, 14);   //bomb explosion sound
                    Main.PlaySound(SoundID.Item, npc.Center, 21);   //swishy sound

                    float explodeRadius = 128;
                    for (int i = 0; i < 360; i++)
                    {
                        Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));

                        if (i % 8 == 0)
                        {   //odd
                            Dust.NewDust(npc.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);
                        }

                        if (i % 9 == 0)
                        {   //even
                            vec.Normalize();
                            Dust.NewDust(npc.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, vec.X * 2, vec.Y * 2);
                        }
                    }

                    SetMove(Move.Shielding, 0);

                    p2AnimationDone = true;
                }
                return;
            }

            if (move == Move.Centering)
            {
                targetPosition = player.Center + new Vector2(0, -196);

                SmoothMoveToPosition(player.Center + new Vector2(0, -196), .2f, 4);

                if (npc.Distance(targetPosition) < 64)
                {   //Move order: Spores, adds, bombs, (if <= half hp) shielding, then back to spores. With Centering between each move, excepting between bombing and shielding.
                    if (prevMove == Move.Centering || prevMove == Move.Shielding || prevMove == Move.Bombing || prevMove == Move.P2Animating)
                    {
                        SetMove(Move.Spores, 240);
                    }
                    else if (prevMove == Move.Spores)
                    {
                        SetMove(Move.Adds, 600);
                    }
                    else if (prevMove == Move.Adds)
                    {
                        SetMove(Move.Bombing, 600);

                        side = Main.rand.Next(2); 
                    }
                }
            }
            else if (move == Move.Spores)
            {
                counter--;
                npc.velocity *= .95f;   //velocity is 95% of what it was last frame

                if (counter <= 190)
                {   //give it a 50 tick delay so it's not instantly giving you the debuff unless you're not careful
                    Rectangle rect = new Rectangle((int)npc.Center.X - 80, (int)npc.position.Y + npc.height, 160, 512);

                    if (rect.Contains(player.Center.ToPoint()))
                    {
                        player.AddBuff(mod.BuffType<Buffs.Spored>(), 1800); //30 sec
                    }

                    float x = Main.rand.NextFloat() * rect.Width;
                    float y = Main.rand.NextFloat() * rect.Height;

                    Tile atTile = Framing.GetTileSafely((int)((rect.X + x) / 16), (int)((rect.Y + y) / 16));

                    if (!atTile.active())
                        Dust.NewDust(new Vector2(rect.X + x, rect.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);
                }

                if (counter <= 0)
                {
                    SetMove(Move.Centering, 0);
                }
            }
            else if (move == Move.Adds)
            {
                counter--;

                targetPosition = player.Center + new Vector2(side == 0 ? -256 : 256, -196);

                SmoothMoveToPosition(player.Center + new Vector2(side == 0 ? -256 : 256, -196), .2f, 4, 64);
				if (p2AnimationDone)
				{
					if (counter % 20 == 0)
					{   //every 16 ticks
						if (npc.ai[3] > 0)
						{
						Vector2 placePosition = npc.Center + new Vector2(0, -400);
						Vector2 direction = Main.player[npc.target].Center - placePosition;
						direction.Normalize();
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 400, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("MushShot"), 25, 1, Main.myPlayer, 0, 0);
						}
						else if (Main.netMode != 1)
						{
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Main.rand.Next(4) == 0 ?
                        mod.NPCType<MushorMinionExplode>() : mod.NPCType<MushMinionShootNoExplosionTest1>());
						}
					}
				}
                else if (counter % 30 == 0)
                {   //every 16 ticks
                    if (Main.netMode != 1)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Main.rand.Next(4) == 0 ?
                            mod.NPCType<MushorMinionExplode>() : mod.NPCType<MushMinionShootNoExplosionTest1>());
                    }
                }

                if (counter <= 0)
                {
                    SetMove(Move.Centering, 0);
                }
            }
            else if (move == Move.Bombing)
            {
                counter--;

                targetPosition = player.Center + new Vector2(0, 0);

                SmoothMoveToPosition(player.Center, .1f, 1.5f);

                if (counter % 30 == 0)
                {
                    if (Main.netMode != 1)
                    {
                        float x = 0;
                        x = (Main.rand.NextFloat() * 4 - 6) + 4;    //between 4 and 6
                        x *= Main.rand.Next(2) == 0 ? -1 : 1;
                        Projectile.NewProjectile(npc.Center, new Vector2(x, -8), mod.ProjectileType<Projectiles.ExplodeMushroom>(), 20, 0);
                    }
                }

                if (counter <= 0)
                {
                    if (IsBelowPhaseTwoThreshhold())
                        SetMove(Move.Shielding, 150);
                    else
                        SetMove(Move.Centering, 0);
                }
            }
            else if (move == Move.Shielding)
            {
                if (counter == 150 && npc.ai[3] <= 0)
                {
                    if (Main.netMode != 1)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<MushorMinionShield>(), ai0: npc.whoAmI, ai1: 45 * i);
                            npc.ai[3]++;
                        }
                    }
                }
                counter--;
                npc.velocity *= .95f;   //velocity is 95% of what it was last frame
                
                if (counter <= 0)
                {
                    SetMove(Move.Centering, 0);
                }
            }
        }

        public override void PostDraw(SpriteBatch batch, Color drawColor)
        {
            if (p2AnimationDone)
                batch.Draw(mod.GetTexture("Bosses/Mushor/MushorGlow"), new Rectangle(npc.Hitbox.X - (int)Main.screenPosition.X, (npc.Hitbox.Y - (int)Main.screenPosition.Y) + 8, npc.width, npc.height), Color.White);    //GLOWY STUFF
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

        private bool IsBelowPhaseTwoThreshhold()
        {
            return npc.life <= npc.lifeMax / 2;     //if at half hp, return true.
        }

        private void SetMove(Move toMove, int counter)
        {
            prevMove = move;
            move = toMove;
            this.counter = counter;
        }
		public override void NPCLoot()
		{
			if (!EmperialWorld.downedMushor)
			{
            			Main.NewText("The guardian of the mushroom biome has fallen...", 0, 75, 161, false);
				EmperialWorld.downedMushor = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushorTrophy"));
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shroomer"));
				}
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shroomflask"));
				}
				
				if (Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MushorMask"));
				}
				if (Main.rand.Next(3) == 0)
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mushdisc"), Main.rand.Next(100, 200));
				}
			}
		}
    }
}
