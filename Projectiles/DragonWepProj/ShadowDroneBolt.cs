using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.DragonWepProj
{
	public class ShadowDroneBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser");
		}
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 3;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 173, 0f, 0f);
			Main.dust[dust].scale = 0.75f;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Consuming_Darkness"), 180, false);
		}
	}
}