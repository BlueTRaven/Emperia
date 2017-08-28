using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
	public class CursedSkull : ModProjectile
	{
		 private float rotate { get { return projectile.ai[1]; } set { projectile.ai[1] = value; } }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CursedSkull");
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.timeLeft *= 5;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.scale = 0.8f;
			projectile.tileCollide = false;
		}

		const int fadeInTicks = 30;
		const int fullBrightTicks = 200;
		const int fadeOutTicks = 30;
		const int range = 500;
		int rangeHypoteneus = (int)Math.Sqrt(range * range + range * range);

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			} 
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (!player.active)
			{
				projectile.active = false;
				return;
			}
			if (player.dead)
			{
				modPlayer.skullLightPet = false;
			}
			if (modPlayer.skullLightPet)
			{
				projectile.timeLeft = 2;
			}
			projectile.ai[1]++;
			
			
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.2f) / 255f, ((255 - projectile.alpha) * 0.7f) / 255f, ((255 - projectile.alpha) * 0.9f) / 255f);
           Vector2 rotatePosition = Vector2.Transform(new Vector2(-1 * 50, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(rotate))) + player.Center;
            projectile.Center = rotatePosition;

            rotate += .5f;
		}
	}
}