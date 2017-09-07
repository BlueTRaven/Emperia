using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories
{
	public class SealSun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seal of the Sun");
			Tooltip.SetDefault("During the daytime, attacks will rain down damage inflicting solar blasts");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).SunSeal = true;
        }
	}
}