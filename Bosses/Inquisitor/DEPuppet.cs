using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class DEPuppet : ModNPC
    {
		public bool hasSpawned = false;
		private Vector2 travelToPosition;
		private int counter = 120;
		private Vector2 shootToPosition;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demolitions Expert Puppet");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;
            npc.lifeMax = 1000;
            npc.damage = 20;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 24;
            npc.height = 38;
            npc.alpha = 0;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
			aiType = 31;
            npc.netAlways = true;
        }
		public override void AI()
        {
			Player player = Main.player[npc.target];
			npc.TargetClosest(true);

				counter--;
				if (counter <= 0)
				{
					npc.ai[2] = 2;
					counter = 60;
					Vector2 position = Main.player[npc.target].Center - npc.Center;
					position.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, position.X * 10f, position.Y * 10f, 102, 12, 1, Main.myPlayer, 0, 0);
				}
				if (npc.position.X > Main.player[npc.target].position.X)
			{
				npc.spriteDirection = 1;
				
				if (npc.velocity.X > -6)
					npc.velocity.X -= 0.25f;
			}
			else
			{
				npc.spriteDirection = -1;
				
				if (npc.velocity.X < 6 && npc.position.X != Main.player[npc.target].position.X)
					npc.velocity.X += 0.25f;
			}
			//npc.AddBuff(mod.BuffType("speedBoost"), 120);
			
		}
    }
}
