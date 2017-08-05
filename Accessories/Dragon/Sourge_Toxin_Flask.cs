using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class Sourge_Toxin_Flask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scourge Toxin Flask");
			Tooltip.SetDefault("Increases throwing damage and velocity by 8%\nDamage over time debuffs are more effective");
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
            player.thrownDamage += 0.08f;
			player.thrownVelocity += 0.08f;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Scourge = true;
        }
	}
}