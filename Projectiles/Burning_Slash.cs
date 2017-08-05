using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	public class Burning_Slash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Slash");
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
			projectile.timeLeft = 15;
			projectile.light = 0.5f;
			projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 5;
		}
		
		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 5;
			} 
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Immolate"), 180, false);
			target.immune[projectile.owner] = 0;
		}
	}
}