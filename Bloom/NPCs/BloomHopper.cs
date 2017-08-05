using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bloom.NPCs
{
    public class BloomHopper : ModNPC
    {
	
		public bool Jump = false;
		public int timerJump = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloom Hopper");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;
            npc.lifeMax = 1899;
            npc.damage = 43;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 48;
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
			if (npc.velocity.Y == 0)
			{
				npc.velocity.X = 0;
			}
			timerJump++;
			if (timerJump > 30 && npc.velocity.Y == 0)
			{
				Jump = true;
				timerJump = 0;
			}
			if (Jump)
			{
				npc.velocity.Y = -7f;
				npc.velocity.Y *= 1.5f;
				npc.velocity.X *= 1.25f;
				Jump = false;
			}
			if (npc.position.X > Main.player[npc.target].position.X)
			{
				npc.spriteDirection = 1;
				
	
			}
			else
			{
				npc.spriteDirection = -1;
				
				
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				BloomPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<BloomPlayer>(mod);
				if (BloomWorld.TheBloom)
				{
					BloomWorld.bloomPoints1 += 1;
				}
			}

		}
		 public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (BloomWorld.TheBloom)
                return 10f;

            return 0;
        }
    }
}
