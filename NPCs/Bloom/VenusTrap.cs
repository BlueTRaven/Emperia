using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.NPCs.Bloom
{
    public class VenusTrap : ModNPC
    {
		private int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Venus Fly Trap");
			Main.npcFrameCount[npc.type] = 3;
		}
        public override void SetDefaults()
        {

            npc.aiStyle = -1;
            npc.lifeMax = 100;
            npc.damage = 20;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 60;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = false;
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
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
			timer++;
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			if (player.position.X > npc.position.X)
			{
				npc.spriteDirection = 1;
			}
			else 
			{
				npc.spriteDirection = -1;
			}
			if (timer % 60 == 0)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("MushSpray"), 15, 1, Main.myPlayer, 0, 0);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 400, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("PlayerTargeter"), 25, 1, Main.myPlayer, 0, 0);
			}
		}
    }
    
}
