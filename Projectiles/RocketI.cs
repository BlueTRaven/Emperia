using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{

    public class RocketI : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boomer");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.melee = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 1;      //how many npc will penetrate
            projectile.timeLeft = 200;   //how many time projectile projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //projectile make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			 Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Orange"), 0.0f, 0.0f, 0, new Color(), 1f)];
			dust.position = projectile.Center;
			dust.velocity = Vector2.Zero;
			dust.noGravity = true;
			Dust dust1 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Blue"), 0.0f, 0.0f, 0, new Color(), 1f)];
			dust1.position = projectile.Center;
			dust1.velocity = Vector2.Zero;
			dust1.noGravity = true;
			Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Green"), 0.0f, 0.0f, 0, new Color(), 0.8f)];
			dust2.position = projectile.Center;
			dust2.velocity = Vector2.Zero;
			dust2.noGravity = true;
			Dust dust3 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Pink"), 0.0f, 0.0f, 0, new Color(), 1f)];
			dust3.position = projectile.Center;
			dust3.velocity = Vector2.Zero;
			dust3.noGravity = true;
        }
		public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (target.life <= 0)
			{
				
			}
		}
        public override void Kill(int timeLeft)
        {
			int x = Main.rand.Next(4);
			if (x == 0)
			{
        	 for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Orange"), 0f, 0f, 158, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}
			}
			else if (x == 1)
			{
					for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Blue"), 0f, 0f, 158, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}
			}
			else if (x == 2)
			{
					for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Green"), 0f, 0f, 158, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}
			}
			else if (x == 3)
			{
					for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("Pink"), 0f, 0f, 158, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}
			}

		}
    }
}