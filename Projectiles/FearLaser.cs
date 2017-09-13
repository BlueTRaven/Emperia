using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Emperia.Projectiles
{
    public class FearLaser : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fear Laser");
		}
        public override void SetDefaults()
        {
            projectile.width = 150;
            projectile.height = 25;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
            projectile.hostile = true;
        }

        public override void AI()
        {	
			Player player = Main.player[projectile.owner];
            Vector2 direction = player.Center - projectile.Center;
			direction.Normalize();
			projectile.velocity = direction * 4f;
			float change = 1f / 60f;
			float targetDir = (float)Math.Atan((float)(player.position.Y - projectile.Center.Y) / (float)(player.position.X - projectile.Center.X));
			if (projectile.rotation != targetDir)
			{
				if (Math.Abs(projectile.rotation - targetDir) < change)
				{
					projectile.rotation = targetDir;
				} else {
					if (targetDir < projectile.rotation)
					{
						targetDir += 360;
					}
					if ((targetDir - projectile.rotation) > 180)
					{
						projectile.rotation -= change;
					} else {
						projectile.rotation += change;
					}
				}
			}
            Dust.NewDust(projectile.Center, 2, 2, 58, projectile.velocity.X, projectile.velocity.Y);
			Rectangle projRect = new Rectangle((int) projectile.position.X, (int) projectile.position.Y, projectile.width, projectile.height);
			Rectangle playerRect = new Rectangle((int) player.position.X, (int) player.position.Y, player.width, player.height);
			if (projRect.Intersects(playerRect))
			{
				projectile.Kill();
			}
        }
    }
}