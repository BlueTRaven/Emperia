using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Emperia;
using Terraria.ModLoader;

namespace Emperia.Accessories
{
    public class MaskoftheDecrepit : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mask of the Decrepit");
			Tooltip.SetDefault("Avoiding damage for 10 seconds will make you take half damage on the next hit");
		}
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.defense = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<MyPlayer>(mod).damageAvoid = true;
		
        }
    }
}
