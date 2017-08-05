using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Emperia.Projectiles
{
    public class PlayerTargeter : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Bomb");
		}
        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 50;
            projectile.friendly = false;
            //projectile.hostile = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

            projectile.aiStyle = -1;
        }

        public override void AI()
		{
			projectile.timeLeft += 200;
			Player player = Main.LocalPlayer;
			Vector2 direction = player.Center - projectile.Center;
			direction.Normalize();
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("MushShot"), 25, 1, Main.myPlayer, 0, 0);

        }

		
			
		
    }
}
