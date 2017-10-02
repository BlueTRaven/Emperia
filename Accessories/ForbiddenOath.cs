using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Emperia;
using Terraria.ModLoader;

namespace Emperia.Accessories
{
    public class ForbiddenOath : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Oath");
			Tooltip.SetDefault("While under 20% max life, you will recieve 10 life every 8 seconds");
		}
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.rare = 5;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<MyPlayer>(mod).forbiddenOath = true;
		
        }
    }
}
