using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.DragonWepProj
{
	public class IllnessFang : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Illness Fang");
		}
		public override void SetDefaults()
		{
			projectile.width = 19;
			projectile.height = 7;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.thrown = true;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
			projectile.scale = 1.2f;
		}
		
		public override void AI()
		{
			
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 178, 0f, 0f);
				Main.dust[dust].scale = 0.5f;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
			
						
			Vector2 targetPos = projectile.Center;
            float targetDist = 150f;
            bool targetAcquired = false;
			for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(projectile) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
                {
                    float dist = projectile.Distance(Main.npc[i].Center);
                    if (dist < targetDist)
                    {
                        targetDist = dist;
                        targetPos = Main.npc[i].Center;
                        targetAcquired = true;
                    }
                }
            }

            if (targetAcquired)
            {
                float homingSpeedFactor = 9f;
                Vector2 homingVect = targetPos - projectile.Center;
                float dist = projectile.Distance(targetPos);
                dist = homingSpeedFactor / dist;
                homingVect *= dist;
				projectile.tileCollide = false;
                projectile.velocity = (projectile.velocity * 20 + homingVect) / 21f;
            }
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Wandering_Plague"), 180, false);
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 178);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}