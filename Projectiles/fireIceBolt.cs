using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Emperia.Projectiles {
public class fireIceBolt : ModProjectile
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thermal Bolt");
		}
	public override void SetDefaults()
	{
		projectile.CloneDefaults(ProjectileID.IceBolt);
		projectile.alpha = 255;
		
	}
	 public override void AI()           //this make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(1) == 0)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 67, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
			float num472 = projectile.Center.X;
			float num473 = projectile.Center.Y;
			float num474 = 500f;
			bool flag17 = false;
			for (int num475 = 0; num475 < 200; num475++)
			{
				if (Main.npc[num475].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num475].Center, 1, 1))
				{
					float num476 = Main.npc[num475].position.X + (float)(Main.npc[num475].width / 2);
					float num477 = Main.npc[num475].position.Y + (float)(Main.npc[num475].height / 2);
					float num478 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num476) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num477);
					if (num478 < num474)
					{
						num474 = num478;
						num472 = num476;
						num473 = num477;
						flag17 = true;
					}
				}
			}
			if (flag17)
			{
				float num483 = Main.rand.Next(30, 43);
				Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num484 = num472 - vector35.X;
				float num485 = num473 - vector35.Y;
				float num486 = (float)Math.Sqrt((double)(num484 * num484 + num485 * num485));
				num486 = num483 / num486;
				num484 *= num486;
				num485 *= num486;
				projectile.velocity.X = (projectile.velocity.X * 20f + num484) / 25f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + num485) / 25f;
				return;
			}
		}
	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit) {

		target.AddBuff(BuffID.OnFire, 50);
		
	}
}
}	