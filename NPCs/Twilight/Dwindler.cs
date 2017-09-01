using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Emperia.NPCs.Twilight
{
    public class Dwindler : ModNPC
    {
		public int StealthTimer = 120;
		public bool Jump = false;
		public int timerJump = 0;
		int mult;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dwindler");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;
            npc.lifeMax = 232;
            npc.damage = 15;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 60;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 0, 15, 0);
            npc.npcSlots = 0f;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
			aiType = 31;
        }
		
		 public override void AI()
        {
			npc.TargetClosest(true);
			//Stealth Effects
			StealthTimer--;
			if (StealthTimer <= 0)
			{
				if (npc.alpha < 150)
					npc.alpha++;
			}
			//Done
			
			//Teleport
			if (npc.alpha == 150 && Main.rand.Next(10) == 0)
			{
				switch (Main.rand.Next(2))
				{
					case 0: 
						mult = 1;
						break;
					case 1:
						mult = -1;
						break;
				}
				
				if (Main.rand.Next(6) == 0)
				{
					for (int m = 0; m <= 10; m++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60, 0f, 0f, 0, new Color(), 1.5f);
						Main.dust[dust].noGravity = true;
					}
					npc.position.X = (Main.player[npc.target].position.X + (Main.rand.Next(90, 150) * mult));
					npc.position.Y = Main.player[npc.target].position.Y - Main.rand.Next(50, 250);
					for (int m = 0; m <= 10; m++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60, 0f, 0f, 0, new Color(), 1.5f);
						Main.dust[dust].noGravity = true;
					}
				}

			}
			// Done
			
			//jump
			timerJump++;
			if (timerJump > 30 && npc.velocity.Y == 0)
			{
				Jump = true;
				timerJump = 0;
			}
			if (Jump)
			{
				npc.velocity.Y = -3f;
				npc.velocity.Y *= 1.5f;
				npc.velocity.X *= 1.25f;
				Jump = false;
			}
			//done
			
			//fix sprite direction and make it faster over time
			if (npc.position.X > Main.player[npc.target].position.X)
			{
				npc.spriteDirection = -1;
				
				if (npc.velocity.X > -6)
					npc.velocity.X -= 0.25f;
			}
			else
			{
				npc.spriteDirection = 1;
				
				if (npc.velocity.X < 6 && npc.position.X != Main.player[npc.target].position.X)
					npc.velocity.X += 0.25f;
			}
			//done
		}
		
		public override void HitEffect(int hitDirection, double Damage)
		{
			StealthTimer = 120;
			npc.alpha = 0;
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			Player player = spawnInfo.player;
			return spawnInfo.player.GetModPlayer<MyPlayer>(mod).ZoneTwilight ? 6f : 0f;
        }
    }
}
