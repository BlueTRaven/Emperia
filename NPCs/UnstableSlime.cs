using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.NPCs
{
    public class UnstableSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unstable Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		int mult;
		public override void SetDefaults()
		{
			npc.lifeMax = 60;
			npc.damage = 17;
			npc.defense = 5;
			npc.width = 34;
			npc.height = 28;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 81;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = Item.buyPrice(0, 0, 7, 8);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = Convert.ToInt32(npc.lifeMax * 1.4);
			npc.damage = Convert.ToInt32(npc.damage * 1.4);
		}
		public override void HitEffect(int hitDirection, double Damage)
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
				for (int m = 0; m <= 10; m++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 58, 0f, 0f, 0, new Color(), 1.5f);
						Main.dust[dust].noGravity = true;
					}
					npc.position.X = (Main.player[npc.target].position.X + (Main.rand.Next(90, 150) * mult));
					npc.position.Y = Main.player[npc.target].position.Y - Main.rand.Next(50, 250);
					for (int m = 0; m <= 10; m++)
					{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 58, 0f, 0f, 0, new Color(), 1.5f);
						Main.dust[dust].noGravity = true;
					}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return Main.dayTime ? 0.80f : 0;
		}
		
		
	}
}