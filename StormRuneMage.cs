using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia
{
	public class StormRuneMage : GlobalItem
	{
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Mod mod = ModLoader.GetMod("Emperia");
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.Storm == true && item.magic == true && Main.rand.Next(2) == 0)
			{
				int p = Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, mod.ProjectileType("StormBolt"), (int)(damage / 4), knockBack, Main.myPlayer, 0, 0);
				Main.projectile[p].magic = true;
			}
			return true;
		}
	}
}