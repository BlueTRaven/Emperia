using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{

    public class MystiqueProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blast");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.magic = true;         // 
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
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 100, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].scale = 3f;
            Main.dust[dust].noGravity = true;
        }
		public override void Kill(int timeLeft)
        {
			int i;
			float spread = 30f * 0.0174f;
			double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y)- spread/2;
				double deltaAngle = spread/8f;
				double offsetAngle;
				
			for (i = 0; i < 3; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * ( i + i * i ) / 2f ) + 32f * i;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( Math.Sin(offsetAngle) * 5f ), (float)( Math.Cos(offsetAngle) * 5f ), mod.ProjectileType("Leafy"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( -Math.Sin(offsetAngle) * 5f ), (float)( -Math.Cos(offsetAngle) * 5f ), mod.ProjectileType("Leafy"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
        	 for (i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 100, 0f, 0f, 100, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}

		}
        
    }
}