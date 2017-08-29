using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	public class MellowSlice : ModProjectile
	{
		int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mellow Slice");
		}
		public override void SetDefaults()
		{
			projectile.width = 42;
			projectile.height = 64;
			//drawOffsetX = 40; 
            //drawOriginOffsetY = -10; 
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 30;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			Main.projFrames[projectile.type] = 9;
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 5;
			} 
			count ++;
			if (count >= 10)
			{
				projectile.alpha = 0;
				projectile.velocity.X = 0;
				projectile.velocity.Y = 0;
				projectile.damage = 28;
			}
			else
			{
				projectile.damage = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("MellowDebuff"), 1200, false);
		}
	}
}