using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class ShroomFlask : ModProjectile
    {
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomy Flask");
		}
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 25;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 2;
            projectile.timeLeft = 180;
            aiType = 48;
        }
        
        public override void AI()
        {
        	if (Main.rand.Next(5) == 0)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 41, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f);
            }
        }
        
        public override void Kill(int timeLeft)
        {
        	Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107); //change
        	int randomDust = Main.rand.Next(2);
			if (randomDust == 0)
			{
				randomDust = 41;
			}
			else
			{
				randomDust = 20;
			}
        	for (int k = 0; k < 10; k++)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, randomDust, projectile.oldVelocity.X, projectile.oldVelocity.Y);
            }
        
			float spread = 90f;
			double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
			double deltaAngle = spread / 4f;
			double offsetAngle;
			int i;
			for (i = 0; i < 2; i++) 
			{
				offsetAngle = 90f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)(Math.Sin(offsetAngle) * 4f), 0, mod.ProjectileType("ShroomGas"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)( -Math.Sin(offsetAngle) * 4f ), 0, mod.ProjectileType("ShroomGas"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
			}
        }
 
    }
}