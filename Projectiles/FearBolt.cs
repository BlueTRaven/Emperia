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
    public class FearBolt : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fear Bolt");
		}
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = false;
            projectile.melee = true;
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
            projectile.velocity.Y += .025f;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Dust.NewDust(projectile.Center, 2, 2, 58, projectile.velocity.X, projectile.velocity.Y);
        }
    }
}
