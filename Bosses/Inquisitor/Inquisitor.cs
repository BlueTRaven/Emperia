using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.Utility;

namespace Emperia.Bosses.Inquisitor
{
    public class Inquisitor : ModNPC
    {
        private enum Move
        {
            Teleporting,
            AfterTeleport,
            LaserFiring,
			LaserDuring,
            BoltFire,
            PhaseTransitionStart,
            Floating
        }

        private Move move { get { return (Move)npc.ai[0]; } set { npc.ai[0] = (int)value; } }
        private Move prevMove;
		
	private int counter;

	private Vector2 targetPosition;
	
	private int laserSweep = 60;
	private int animationFps = 60 / 10; //first value is tickrate, second is the fps that you want

        private bool phaseStart;
        private bool phaseEnd;
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Inquisitor");
		Main.npcFrameCount[npc.type] = 6;
	}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 10000;
            npc.damage = 150;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 94;
            npc.height = 101;
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
			npc.ai[3] = 0; //phase: 0 is creation, 1 is first, 2 is second
			npc.frameCounter = 0;
			
            npc.netAlways = true;

        }

        public override void FindFrame(int frameHeight)
        {
			npc.frameCounter++;
			if (npc.frameCounter > (animationFps * (Main.npcFrameCount[npc.type] - 1))) {
				npc.frameCounter = 0;
			} else if ((npc.frameCounter % animationFps) == 0) {
				npc.frame.Y = ((int)npc.frameCounter / Main.npcFrameCount[npc.type]) * frameHeight;
			}
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
				npc.TargetClosest(true);
				player = Main.player[npc.target];
			}
		
            if (npc.ai[3] == 0)
            {
                NPC.NewNPC((int)npc.Center.X - 20, (int)npc.Center.Y, mod.NPCType<SorrowMask>(), ai0: player.whoAmI);
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, mod.NPCType<AgonyMask>(), ai0: player.whoAmI);
                npc.ai[3] = 0;
            }

			else if (npc.ai[3] == 1)
			{
				if (move == Move.Floating)
				{
					counter--;
					if (counter <= 0)
					{
						SetMove(Move.Teleporting, 0);
					}
				}
				if (move == Move.Teleporting)
				{
					counter--;
					npc.position = player.Center + new Vector2(Main.rand.Next(-512, 512), Main.rand.Next(-512, -100));
					
					SetMove(Move.AfterTeleport, 60);
				}
				if (move == Move.AfterTeleport)
				{
					counter--;
					
					if (counter <= 0)
					{
						//if (Main.rand.Next(2) == 0)
						//{ 
						//	SetMove(Move.LaserFiring, 60);
						//}
						//else {
                           SetMove(Move.BoltFire, 0);
                        //}
					}
				}
				if (move == Move.BoltFire)
				{
					counter--;
					Vector2 vec = Vector2.Normalize(player.Center - npc.Center) * 6;
					Vector2 vecu = Vector2.Transform(vec, Matrix.CreateRotationZ(MathHelper.ToRadians(-8)));
					Vector2 vecd = Vector2.Transform(vec, Matrix.CreateRotationZ(MathHelper.ToRadians(8)));
					Emperia.CreateProjectile<Projectiles.FearBolt>(mod, npc.Center, vec, 5, 0);
					Emperia.CreateProjectile<Projectiles.FearBolt>(mod, npc.Center, vecu, 5, 0);
					Emperia.CreateProjectile<Projectiles.FearBolt>(mod, npc.Center, vecd, 5, 0);
					
					SetMove(Move.Floating, Main.rand.Next(90, 120));
				}
				if (move == Move.LaserDuring)
				{
					counter--;

					//for (int l = -laserSweep; l <= laserSweep; l++)
					//{
						if (counter == 0)
						{
							Projectile.NewProjectile(npc.Center, player.Center, mod.ProjectileType("FearLaser"), 200, 10f, npc.whoAmI, ai0: player.whoAmI);
						}
					//}

					if (counter <= 0)
					{
						SetMove(Move.Teleporting, 0);// move = Move.Teleporting;
					}
				}
				//if (npc.life <= npc.lifeMax * .5f)
				//{
				//	npc.ai[3] = 1;    <second phase stuff
				//}
			}
			//else if (npc.ai[3] == 2)
			//{
			//	
			//}
            
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

        private void SetMove(Move move, int counter)
        {
            this.prevMove = this.move;
            this.move = move;
			this.counter = counter;
        }

        private bool IsInPhaseTwo()
        {
            return npc.life <= npc.lifeMax * .5;    //50% hp
        }
    }
}
