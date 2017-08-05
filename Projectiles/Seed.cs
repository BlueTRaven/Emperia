using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Emperia.Projectiles {
public class Seed : ModProjectile
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seed");
		}
	public override void SetDefaults()
	{
		projectile.width = 14;
		projectile.height = 14;
		projectile.aiStyle = 14;
		projectile.penetrate = 1;
        projectile.timeLeft = 200;
		projectile.magic = true;
		projectile.friendly = true;
	}
	
	public override void AI()
	{
		if (Main.rand.Next(3) == 0)
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 265, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}
	}
	 public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		 public override void Kill(int timeLeft)
        {
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 265, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 10, projectile.velocity.Y - 3, mod.ProjectileType("Seed2"), 25, projectile.knockBack, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -10, projectile.velocity.Y - 3, mod.ProjectileType("Seed2"), 25, projectile.knockBack, projectile.owner, 0f, 0f);
		}
}
}	