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
    public class ExplodeMushroom : ModProjectile
    {
        private const float explodeRadius = 128;
        //private int rotside { get { return (int)projectile.ai[0]; } set { projectile.ai[0] = value; } }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exploding Mushroom");
		}
        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 50;
            projectile.friendly = true;
            //projectile.hostile = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            projectile.velocity.Y += .15f;

            if (projectile.velocity.Y > 4)
                projectile.velocity.Y = 4;

            projectile.rotation += (projectile.velocity.X > 0 ? .08f : -.08f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (projectile.Distance(Main.player[i].Center) < explodeRadius)
                    Main.player[i].Hurt(Terraria.DataStructures.PlayerDeathReason.ByProjectile(Main.player[i].whoAmI, projectile.whoAmI), projectile.damage, 0);
            }

            for (int i = 0; i < 360; i++)
            {
                Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));

                if (i % 8 == 0)
                {   //odd
                    Dust.NewDust(projectile.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20);
                }

                if (i % 9 == 0)
                {   //even
                    vec.Normalize();
                    Dust.NewDust(projectile.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, vec.X * 2, vec.Y * 2);
                }
            }

            Main.PlaySound(SoundID.Item, projectile.Center, 14);    //bomb explosion sound
            Main.PlaySound(SoundID.Item, projectile.Center, 21);    //swishy sound

            return true;
        }
    }
}
