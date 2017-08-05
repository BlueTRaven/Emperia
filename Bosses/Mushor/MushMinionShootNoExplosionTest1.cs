using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
    public class MushMinionShootNoExplosionTest1 : ModNPC
    {
        public bool hasSpawned = false;
		public int timerP2 = 0;
		public bool shotYet = false;
		public int timerthing = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angry Mushroom");
			Main.npcFrameCount[npc.type] = 15;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 30;
            npc.damage = 23;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 102;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = false;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }

        public override void AI()
        {
			npc.TargetClosest(true);
			/*
			 About the ai for people editing it	
			 the move patterns are stored in npc.ai[2]
			add other stuff later
			*/
		     Player player = Main.player[npc.target];
            if (!hasSpawned)
            {
                npc.ai[0] = 0;
                hasSpawned = true;
            }
            //These are not 100% set yet, im defining variables.
            float speed = 4f;

            // sets targeting
			double npcFlyToY = player.Center.Y - 150;
            double npcFlyToX = player.Center.X;
	        if (!player.active || player.dead)
            {
               npc.TargetClosest(false);
               player = Main.player[npc.target];
            }
         
            
            if (npc.ai[0] == 0)
            {
                //reserved
                npc.ai[0] = 1;
                npc.ai[2] = 1; //attack pattern stuff
            }
			 if (npc.ai[2] == 2)
            {
                timerP2++;
            }
			if (npc.ai[2] == 1)
			{
			    timerthing++;	
			} 
            npc.velocity.X = 0f;
            npc.velocity.Y = 0f;
			// tests if its flown to the correct place
            if ((double)npc.Center.X > (double)player.Center.X - 50)
			{
				if ((double)npc.Center.X < (double)player.Center.X + 50)
			    {
				    if ((double)npc.Center.Y < (double)player.Center.Y + 50)
			        {
				        if ((double)npc.Center.Y > (double)player.Center.Y - 200)
			            {
							Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("MushSpray"), 15, 1, Main.myPlayer, 0, 0);
							
						}
						if ((double)npc.Center.Y > (double)player.Center.Y - 50)
			            {
							if (npc.ai[2] == 1)
							{
					            npc.ai[2] = 2;
							}
							else if (npc.ai[2] == 4)
							{
							    npc.ai[2] = 5;
							}
			            }		
			        }	
			    }	
			}
				
            if (npc.ai[2] == 1) //normal movement pattern
            {
              Vector2 direction = Main.player[npc.target].Center - npc.Center;
			  direction.Normalize();
			  npc.velocity.Y = direction.Y *5f;
			  npc.velocity.X = direction.X *5f;
			  
            }
			if (timerthing > 120) {
				npc.ai[2] = 2;
			}
			if (npc.ai[2] == 2) // speeds up and heads up actually and does a move
			{
				timerthing = 0;
				if (!shotYet)
				{
					
				}
				if (timerP2 > 120)
				{
					npc.ai[2] = 1;
					timerP2 = 0;
				}
				
				
			}
			if (npc.ai[2] == 3) //a move
		    {
				
			}
        }
    }
}

