using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	
    public class CursedFireball: ModProjectile
    {
		private NPC parent { get { return Main.npc[(int)projectile.ai[0]]; } set { projectile.ai[0] = value.whoAmI; } }
        private float rotate { get { return projectile.ai[1]; } set { projectile.ai[1] = value; } }
		private Vector2 direction;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Fireball");
		}
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 25;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.timeLeft = 180;
        }
        
        public override void AI()
        {
			projectile.ai[3] --;
        	int index = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 75, projectile.velocity.X, projectile.velocity.Y, 100, new Color(), 3f * projectile.scale);
			Main.dust[index].noGravity = true;
			if (projectile.ai[3] >= 0)
			{
			 Vector2 rotatePosition = Vector2.Transform(new Vector2(-1 * 128, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(rotate))) + parent.Center;
            projectile.Center = rotatePosition;

            rotate += .5f;
			direction = Main.player[parent.target].Center - projectile.Center;
			direction.Normalize();
			}
			else
			{
				projectile.velocity = direction;
					
			}
        }
        
    }
}