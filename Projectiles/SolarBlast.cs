using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{

    public class SolarBlast : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cerith Shell");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 1;      //how many npc will penetrate
            projectile.timeLeft = 200;   //how many time projectile projectile has before disepire
            projectile.light = 0.75f;    // projectile light
			projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //projectile make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			 Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 158, 0.0f, 0.0f, 0, new Color(), 3f)];
			dust.position = projectile.Center;
			dust.velocity = Vector2.Zero;
			dust.noGravity = true;
        }
		public override void Kill(int timeLeft)
        {

        	 for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 158, 0f, 0f, 158, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}

		}
        
    }
}