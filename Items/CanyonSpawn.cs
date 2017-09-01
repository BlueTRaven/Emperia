using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Items
{
	public class CanyonSpawn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Canyon Spawn");
			Tooltip.SetDefault("Grows a canyon.");
		}
		public override void SetDefaults()
		{
			item.value = 10000;
			item.width = 22;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 8;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.UseSound = SoundID.Item81;
			item.consumable = true;
		}

	
		// Note that this item does not work in Multiplayer, but serves as a learning tool for other things.
		public override bool UseItem(Player player)
		{
			int x = (int)(player.position.X / 16);
			int y = (int)(player.position.Y / 16) + 3;
			WorldMethods.TileRunner(x, y, (double)200, 1, mod.TileType("CanyonRock"), false, 0f, 0f, true, true); //improve basic shape later
			
			WorldMethods.RoundHole(x, y - 20, 60, 30, 10, true);
			for (int i = 0; i < 3; i++)
			{
				int Ex = Main.rand.Next(-35,35);
				int height = Main.rand.Next(30, 80);
				int BaseWidth = Main.rand.Next(60,80);
				int Sway = 0;
				for (int j = 15; j < height; j++)
				{
					if (Main.rand.Next(4) == 0)
					{
						if (Main.rand.Next(2) == 0)
						{
							Sway -= 1;
						}
						else
						{
							Sway += 1;
						}
					}
					WorldMethods.TileRunner((x + Ex) + Sway, (y + 10) + j, (double)25+ (BaseWidth / Math.Sqrt(j)), 1, mod.TileType("CanyonRock"), false, 0f, 0f, true, true); //improve basic shape later
					WorldGen.digTunnel((x + Ex) + Sway, (y + 10) + j, 0,0, 3, (int)(BaseWidth / Math.Sqrt(j)), false);
				}
			}
			return true;
		}
	}
}
