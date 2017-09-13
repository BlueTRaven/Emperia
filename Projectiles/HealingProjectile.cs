using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class HealingProjectile: ModProjectile
    {
    
		private Vector2 direction;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healing Bolt");
		}
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            direction = player.Center - projectile.Center;
			direction.Normalize();
			projectile.velocity = direction * 12f;
			int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;
            if (projectile.position.X > player.position.X - 20 && projectile.position.X < player.position.X + 20 && projectile.position.Y > player.position.Y - 20 && projectile.position.Y < player.position.Y + 20)
			{
				int jim = Main.rand.Next(1, 3);
				player.HealEffect(jim);
				player.statLife += jim;
				projectile.Kill();
			}
			
        }
        
    }
}