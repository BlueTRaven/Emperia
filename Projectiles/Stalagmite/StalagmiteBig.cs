using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.Stalagmite
{

    public class StalagmiteBig : ModProjectile
    {
		private const float explodeRadius = 24;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stalagmite");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.ranged = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 1;      //how many npc will penetrate
            projectile.timeLeft = 200;   //how many time this projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //this make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

        }
		public override void Kill(int timeLeft)
        {
			 for (int i = 0; i < Main.npc.Length; i++)
            {
			if (projectile.Distance(Main.npc[i].Center) < explodeRadius)
                    Main.npc[i].StrikeNPC(projectile.damage, 0f, 0, false, false, false);
			}
        	 for (int i = 0; i < 360; i += 10)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 4, 0f, 0f, 4, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *2f);
				}

            Main.PlaySound(SoundID.Item, projectile.Center, 14);    //bomb explosion sound
            Main.PlaySound(SoundID.Item, projectile.Center, 21);    //swishy sound
		}
    }
}