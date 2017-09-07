using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.WorldStuff;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace Emperia.Projectiles.Flail
{
    public class FlungusProj : ModProjectile
    {
		int timer = 10;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flungus Ball");
        }
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = -1; 
            projectile.melee = true; 
        }


        public override bool PreAI()
        {
            pextra.FlailAI(projectile.whoAmI);
            return true;
        }
		 public override void AI()
        {
            timer--;
			if (timer <= 0)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("Spore2"), 15, 1, Main.myPlayer, 0, 0);
				timer = 10;
			}
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return pextra.FlailTileCollide(projectile.whoAmI, oldVelocity);
			return true;
        }
        
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            pextra.DrawChain(projectile.whoAmI, Main.player[projectile.owner].MountedCenter,
                "Emperia/Projectiles/Flail/FlungusChain");
            pextra.DrawAroundOrigin(projectile.whoAmI, lightColor);
            return false;
        }
    }
}