using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class EnchantedCrystal : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal");
		}
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 180;
			projectile.alpha = 255;
        }

        public override void AI()
        {
			
			projectile.velocity.Y *= 0.975f;
			projectile.velocity.X *= 0.975f;
			float spread = 30f * 0.0174f;
			double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y)- spread/2;
			double deltaAngle = spread/8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 4; i++ )
			{
			offsetAngle = (startAngle + deltaAngle * ( i + i * i ) / 2f ) + 32f * i;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( Math.Sin(offsetAngle) * 5f ), (float)( Math.Cos(offsetAngle) * 5f ), ProjectileID.CrystalVileShardHead, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( -Math.Sin(offsetAngle) * 5f ), (float)( -Math.Cos(offsetAngle) * 5f ), ProjectileID.CrystalVileShardHead, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			}
				
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	projectile.Kill();
        }
		public override void Kill(int timeLeft)
        {
			float spread = 30f * 0.0174f;
			double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y)- spread/2;
			double deltaAngle = spread/8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 4; i++ )
			{
			offsetAngle = (startAngle + deltaAngle * ( i + i * i ) / 2f ) + 32f * i;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( Math.Sin(offsetAngle) * 5f ), (float)( Math.Cos(offsetAngle) * 5f ), ProjectileID.CrystalVileShardHead, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( -Math.Sin(offsetAngle) * 5f ), (float)( -Math.Cos(offsetAngle) * 5f ), ProjectileID.CrystalVileShardHead, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			}
        	for (int dust = 0; dust <= 10; dust++)
        	{
        		Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 58, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
        	}
        }
    }
}