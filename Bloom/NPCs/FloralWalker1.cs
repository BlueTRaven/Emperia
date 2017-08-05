using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bloom.NPCs
{
    public class FloralWalker1 : ModNPC
    {
		public int DashTimerReset = 240;
		public int WaitToDash = 30;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("FloralWalker1");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;
            npc.lifeMax = 1432;
            npc.damage = 43;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 70;
            npc.height = 48;
            npc.value = Item.buyPrice(0, 0, 15, 0);
            npc.npcSlots = 0f;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
			aiType = NPCID.AnomuraFungus;
        }
		
		 public override void AI()
        {
			npc.TargetClosest(true);
			DashTimerReset--;
			if (DashTimerReset <= 0)
			{
				//shoot
			}
			if (Main.player[npc.target].position.X > npc.position.X)
			{
				npc.spriteDirection = 1;
			}
			else
			{
				npc.spriteDirection = 2;
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				BloomPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<BloomPlayer>(mod);
				if (BloomWorld.TheBloom && Main.rand.Next(2) == 1)
				{
					BloomWorld.bloomPoints1 += 1;
				}
			}

		}
		 public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (BloomWorld.TheBloom)
                return 14f;

            return 0;
        }
    }
}
