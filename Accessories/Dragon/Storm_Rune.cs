using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Emperia.Accessories.Dragon
{
	public class Storm_Rune : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Rune");
			Tooltip.SetDefault("Increases summon damage and magic damage by 11% \nIncreases mana by 20 \nMagic weapons and minions have a chance to fire a lightning bolt");
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
            player.minionDamage += 0.11f;
			player.magicDamage += 0.11f;
			player.statManaMax2 += 20;
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).Storm = true;
        }
	}
}