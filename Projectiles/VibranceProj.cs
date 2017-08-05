using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{

    public class VibranceProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vermillion Blade");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.melee = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = -1;      //how many npc will penetrate
            projectile.timeLeft = 60;   //how many time this projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //this make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
			if(Main.rand.Next(2) == 0)
			{
            int num250 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X, projectile.position.Y - projectile.velocity.Y), projectile.width, projectile.height, 158, (float)(projectile.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
					Main.dust[num250].noGravity = true;
					Main.dust[num250].velocity *= 0f;
			}
			if (projectile.position.X > Main.player[projectile.owner].position.X)
			{
				projectile.spriteDirection = 1;
				
			}
			else
			{
				projectile.spriteDirection = 2;
			}
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			 target.AddBuff(mod.BuffType("VermillionDebuff"), 120);

		}
		public override void Kill(int timeLeft)
        {

        	 for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-20, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 158, 0f, 0f, 158, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}

		}
    }
}