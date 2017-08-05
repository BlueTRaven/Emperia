using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.DragonWepProj
{
	public class StormBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Bolt");
		}
		public override void SetDefaults()
		{
			projectile.width = 58;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.penetrate = 3;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 360;
			projectile.light = 0.5f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 5;
		}
		
		public override void AI()
		{
			int dust;
			dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 226, 0f, 0f);
			Main.dust[dust].scale = 0.65f;
			Main.dust[dust].noGravity = true;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Storm_Charged"), 180, false);
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93);
		}
	}
}