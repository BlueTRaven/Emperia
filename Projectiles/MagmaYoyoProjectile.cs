using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class MagmaYoyoProjectile : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmatic Hell");
		}
        public override void SetDefaults()
        {
        	projectile.CloneDefaults(ProjectileID.Kraken);
            projectile.width = 16;
            projectile.scale = 0.9f;
            projectile.height = 16;
            projectile.penetrate = 8;
            aiType = 546;
        }
        
        public override void AI()
        {
        	
        	int[] array = new int[20];
			int thingy = 0;
			float thingy2 = 300f;
			bool dotarget = false;
			for (int npcFinder = 0; npcFinder < 200; npcFinder++)
			{
				if (Main.npc[npcFinder].CanBeChasedBy(projectile, false))
				{
					float pos1 = Main.npc[npcFinder].position.X + (float)(Main.npc[npcFinder].width / 2);
					float pos2 = Main.npc[npcFinder].position.Y + (float)(Main.npc[npcFinder].height / 2);
					float pos3 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - pos1) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - pos2);
					if (pos3 < thingy2 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[npcFinder].Center, 1, 1))
					{
						if (thingy < 20)
						{
							array[thingy] = npcFinder;
							thingy++;
						}
						dotarget = true;
					}
				}
			}
			if (dotarget)
			{
				int thingyrand = Main.rand.Next(thingy);
				thingyrand = array[thingyrand];
				float variable = Main.npc[thingyrand].position.X + (float)(Main.npc[thingyrand].width / 2);
				float variable2 = Main.npc[thingyrand].position.Y + (float)(Main.npc[thingyrand].height / 2);
				projectile.localAI[0] += 1f;
				if (projectile.localAI[0] > 8f)
				{
					projectile.localAI[0] = 0f;
					float sixef = 6f;
					Vector2 value10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					value10 += projectile.velocity * 4f;
					float vectoryvectoryvoo = variable - value10.X;
					float seventeenchildren = variable2 - value10.Y;
					float nineteenchildren = (float)Math.Sqrt((double)(vectoryvectoryvoo * vectoryvectoryvoo + seventeenchildren * seventeenchildren));
					nineteenchildren = sixef / nineteenchildren;
					vectoryvectoryvoo *= nineteenchildren;
					seventeenchildren *= nineteenchildren;
					if (Main.rand.Next(5) == 0)
					{
						Projectile.NewProjectile(value10.X, value10.Y, vectoryvectoryvoo, seventeenchildren, mod.ProjectileType("MagmaBlob"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					}
					return;
				}
			}
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 100);
        }
    }
}