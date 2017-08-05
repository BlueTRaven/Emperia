using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia
{
	public class StormRuneSummon : GlobalProjectile
	{
		public override void AI(Projectile projectile)
		{
			Player player = Main.player[projectile.owner];
			Mod mod = ModLoader.GetMod("Emperia");
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.Storm == true && projectile.minion == true && Main.rand.Next(180) == 0)
			{
				int[] numArray = new int[10];
				int maxValue = 0;
				int num2 = 700;
				int num3 = 20;
				for (int index2 = 0; index2 < 200; ++index2)
				{
				  if (Main.npc[index2].CanBeChasedBy((object) this, false))
				  {
					float num4 = (projectile.Center - Main.npc[index2].Center).Length();
					if ((double) num4 > (double) num3 && (double) num4 < (double) num2 && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[index2].Center, 1, 1))
					{
					  numArray[maxValue] = index2;
					  ++maxValue;
					  //if (maxValue >= 9)
						//break;
					}
				  }
				}
				if (maxValue > 0)
				{
				  int index2 = Main.rand.Next(maxValue);
				  Vector2 vector2 = Main.npc[numArray[index2]].Center - projectile.Center;
				  float num4 = projectile.velocity.Length();
				  vector2.Normalize();
				  int p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X * 4, vector2.Y * 4, mod.ProjectileType("StormBolt"), (int)(projectile.damage / 4), projectile.knockBack, projectile.owner, 0, 0);
				  ProjectileID.Sets.MinionShot[Main.projectile[p].type] = true;
				}
			}
		}
	}
}
