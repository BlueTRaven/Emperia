﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	
    public class ShroomNade : ModProjectile
    {
    	private const float explodeRadius = 64;
		private int thing = 5;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomnade");
		}
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 25;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 2;
            projectile.timeLeft = 180;
            aiType = 48;
        }
        
        public override void AI()
        {
        	
            	Dust.NewDust(projectile.position, projectile.width, projectile.height, 41, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f);
           
        }
		 public override bool OnTileCollide(Vector2 oldVelocity)
        {
            thing--;
            if (thing <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -(oldVelocity.X * 2);
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -(oldVelocity.Y / 2);
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
			 for (int i = 0; i < Main.npc.Length; i++)
            {
			if (projectile.Distance(Main.npc[i].Center) < explodeRadius)
                    Main.npc[i].StrikeNPC(projectile.damage, 0f, 0, false, false, false);
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
		}
    }
}