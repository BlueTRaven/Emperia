using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bloom.NPCs
{
    public class BloomHoverer : ModNPC
    {
		int moveSpeed = 0;
		int moveSpeedY = 0;
		int counter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Winged Amalgam");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 44;
            aiType = NPCID.FlyingAntlion;
            npc.lifeMax = 1432;
            npc.damage = 43;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 78;
            npc.height = 88;
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
			counter++;
				if (counter >= 60)
				{
					Vector2 direction =   Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("Petal"), 40, 1, Main.myPlayer, 0, 0);
					counter = 0;
				}
				npc.spriteDirection = -npc.direction;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				BloomPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<BloomPlayer>(mod);
				if (BloomWorld.TheBloom)
				{
					BloomWorld.bloomPoints1 += 2;
				}
			}

		}
		 public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (BloomWorld.TheBloom)
                return 8f;

            return 0;
        }
    }
}
