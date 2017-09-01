using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace Emperia.Projectiles
{
	
    public class GreenFloralBlast2 : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("bepis");
		}
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 25;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 2;
            projectile.timeLeft = 180;
			projectile.alpha = 255;
            aiType = 48;
        }
        
        public override void AI()
        {
			for (int index1 = 0; index1 < 3; ++index1)
          {
            int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 74, projectile.velocity.X, projectile.velocity.Y, 74, new Color(), 1.2f);
            Main.dust[index2].position = (Main.dust[index2].position + projectile.Center) / 2f;
            Main.dust[index2].noGravity = true;
            Main.dust[index2].velocity *= 0.5f;
			Main.dust[index2].scale *= 0.5f;
          }
          /*for (int index1 = 0; index1 < 2; ++index1)
          {
            int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, (int) byte.MaxValue, projectile.velocity.X, projectile.velocity.Y, 256, new Color(), 0.4f);
            if (index1 == 0)
              Main.dust[index2].position = (Main.dust[index2].position + projectile.Center * 5f) / 6f;
            else if (index1 == 1)
              Main.dust[index2].position = (Main.dust[index2].position + (projectile.Center + projectile.velocity / 2f) * 5f) / 6f;
            Main.dust[index2].velocity *= 0.1f;
            Main.dust[index2].noGravity = true;
            Main.dust[index2].fadeIn = 1f;
          }*/
           
        }
		public override void Kill(int timeLeft)
        {
			
		
        }
    }
}