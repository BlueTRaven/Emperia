using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Emperia.NPCs.Twilight
{
    public class Podling : ModNPC
    {
		int direction = 1;
		bool friendly = true;
		int timer = 60;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Podling");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 432;
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
        }
		
		 public override void AI()
        {
			npc.TargetClosest(true);
			timer--;
			if (timer <= 0)
			{
				direction = Main.rand.Next(1, 2);
				timer = 100;
				if (!friendly)
				{
					Vector2 pPosition = Main.player[npc.target].Center + new Vector2(0, -100);
					Vector2 direction1 = pPosition - npc.Center;
					direction1.Normalize();
					npc.velocity.X = 0;
					npc.velocity.X = direction1.X * 10f;
					npc.velocity.Y = direction1.Y * 10f;
				}
			}
			//fix sprite direction and make it faster over time
			if (npc.position.X > Main.player[npc.target].position.X )
			{
				npc.spriteDirection = -1;
				
				if (npc.velocity.X > -3 && !friendly)
					npc.velocity.X -= 0.25f;
			}
			else
			{
				npc.spriteDirection = 1;
				
				if (npc.velocity.X < 3 && npc.position.X != Main.player[npc.target].position.X && !friendly)
					npc.velocity.X += 0.25f;
			}
			//done
			if (timer >= 0 && friendly)
			{
				if (direction == 1)
					npc.velocity.X = 1;
				else if (direction == 2)
					npc.velocity.X = -1;
				else
					npc.velocity.X = 0;
			}
		}
		
		public override void HitEffect(int hitDirection, double Damage)
		{
			friendly = false;
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			Player player = spawnInfo.player;
			return spawnInfo.player.GetModPlayer<MyPlayer>(mod).ZoneTwilight ? 9f : 0f;
        }
    }
}
