using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.DragonWepProj
{
	public class PlagueBite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Bite");
		}
		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 13;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.penetrate = 3;
			projectile.extraUpdates = 1;
			projectile.thrown = true;
			projectile.light = 0.5f;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 5;
		}
		
		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust;
				dust = Dust.NewDust(projectile.Center + projectile.velocity, 0, 0, 178, 0f, 0f);
				Main.dust[dust].scale = 0.5f;
			}
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Wandering_Plague"), 180, false);
			
			projectile.damage = (int)(projectile.damage * 1.25);
			
			int[] numArray = new int[10];
			int maxValue = 0;
			int num2 = 700;
			int num3 = 20;
			for (int index2 = 0; index2 < 200; ++index2)
			{
			  if (Main.npc[index2] != target && Main.npc[index2].CanBeChasedBy((object) this, false))
			  {
				float num4 = (projectile.Center - Main.npc[index2].Center).Length();
				if ((double) num4 > (double) num3 && (double) num4 < (double) num2 && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[index2].Center, 1, 1))
				{
				  numArray[maxValue] = index2;
				  ++maxValue;
				  if (maxValue >= 9)
					break;
				}
			  }
			}
			if (maxValue > 0)
			{
			  int index2 = Main.rand.Next(maxValue);
			  Vector2 vector2 = Main.npc[numArray[index2]].Center - projectile.Center;
			  float num4 = projectile.velocity.Length();
			  vector2.Normalize();
			  projectile.velocity = vector2 * num4;
			  projectile.netUpdate = true;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 178);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
	}
}