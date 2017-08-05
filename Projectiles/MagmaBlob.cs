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
    public class MagmaBlob : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Blob");
		}
        private const float explodeRadius = 90;
        //private int rotside { get { return (int)projectile.ai[0]; } set { projectile.ai[0] = value; } }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
         

            for (int i = 0; i < 360; i++)
            {
                Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));

                Dust.NewDust(projectile.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 6);

                if (i % 2 == 0)
                {
                    vec.Normalize();
                    Dust.NewDust(projectile.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 6, vec.X * 2, vec.Y * 2);
                }
            }

            Main.PlaySound(SoundID.Item, projectile.Center, 14);    //bomb explosion sound

            return true;
        }
		 public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			 for (int i = 0; i < 360; i++)
            {
                Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));

                Dust.NewDust(projectile.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 6);

                if (i % 2 == 0)
                {
                    vec.Normalize();
                    Dust.NewDust(projectile.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 6, vec.X * 2, vec.Y * 2);
                }
            }

            Main.PlaySound(SoundID.Item, projectile.Center, 14);    //bomb explosion sound
            projectile.Kill();

		}
    }
}
