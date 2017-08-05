using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class Cloak_of_Concealment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak of Concealment");
			Tooltip.SetDefault("Increased movement speed and immunity time\nGrants stealth while not moving or taking damage");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 48;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += 0.2f;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).longerInvince = true;
			player.shroomiteStealth = true;
        }
	}
}