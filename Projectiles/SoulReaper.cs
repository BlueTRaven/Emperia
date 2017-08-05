using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class SoulReaper : ModProjectile
    {
		public int counter = 0;
		private Vector2 direction;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaper's Scythe");
		}
        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 400;
        }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			counter++;
            if (counter <= 120)
			{
				projectile.velocity.X *= .97f;
				projectile.velocity.Y *= .97f;
			}
			if (counter > 120)
			{
				direction = player.Center - projectile.Center ;
				direction.Normalize();
				projectile.velocity = direction * 10f;
			}
			
			if (projectile.position.X > player.position.X - 20 && projectile.position.X < player.position.X + 20 && projectile.position.Y > player.position.Y - 20 && projectile.position.Y < player.position.Y + 20 && counter > 120)
			{
				projectile.Kill();
			}
			
            projectile.rotation += 0.25f;
        }
		
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("PumpkinSlash"), 50, 5f, projectile.owner);
			Main.projectile[p].rotation = Main.rand.Next(360);
        }
    }
}