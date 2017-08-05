using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Projectiles       //We need projectile to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class EbonFire : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonflames");
		}
        public override void SetDefaults()
        { //Name of the projectile, only shows projectile if you get killed by it
            projectile.width = 12;  //Set the hitbox width
            projectile.height = 12; //Set the hitbox height
            projectile.friendly = false; 
			projectile.aiStyle = 14;
            projectile.hostile = true;			//Tells the game whether it is friendly to players/friendly projectiles or not
            projectile.ignoreWater = true;  //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;  //Tells the game whether it is a ranged projectile or not
            projectile.penetrate = -1; //Tells the game how many enemies it can hit before being destroyed, -1 infinity
            projectile.timeLeft = 125;  //The amount of time the projectile is alive for  
            projectile.extraUpdates = 3;
			projectile.alpha = 255;
        }
 
        public override void AI()
        {
            if (projectile.wet)
            projectile.Kill();
          if ((double) projectile.ai[1] == 0.0 && projectile.type >= 326 && projectile.type <= 328)
          {
            projectile.ai[1] = 1f;
            Main.PlaySound(SoundID.Item13, projectile.position);
          }
          int index1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0.0f, 0.0f, 75, new Color(), 1f);
          Main.dust[index1].position.X -= 2f;
          Main.dust[index1].position.Y += 2f;
          Main.dust[index1].scale += (float) Main.rand.Next(50) * 0.01f;
          Main.dust[index1].noGravity = true;
          Main.dust[index1].velocity.Y -= 2f;
          if (Main.rand.Next(2) == 0)
          {
            int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0.0f, 0.0f, 75, new Color(), 1f);
            Main.dust[index2].position.X -= 2f;
            Main.dust[index2].position.Y += 2f;
            Main.dust[index2].scale += (float) (0.300000011920929 + (double) Main.rand.Next(50) * 0.00999999977648258);
            Main.dust[index2].noGravity = true;
            Main.dust[index2].velocity *= 0.1f;
          }
          if ((double) projectile.velocity.Y < 0.25 && (double) projectile.velocity.Y > 0.15)
            projectile.velocity.X *= 0.8f;
          projectile.rotation = (float) (-(double) projectile.velocity.X * 0.0500000007450581);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}