using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Emperia.Projectiles {
public class MartianBlast : ModProjectile
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MartianBlast");
		}
	public override void SetDefaults()
	{
		projectile.CloneDefaults(ProjectileID.BulletHighVelocity);
		projectile.alpha = 0;
		
	}
	 public override void AI()           //this make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(3) == 0)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 252, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
		}
	public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{

		target.AddBuff(BuffID.Electrified, 60);
		
	}
	public virtual void OnHitPlayer(Player target, int damage, float knockback, bool crit)
	{

		target.AddBuff(BuffID.Electrified, 60);
		
	}
}
}	