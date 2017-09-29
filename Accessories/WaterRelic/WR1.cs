using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Emperia;
using Terraria.ModLoader;

namespace Emperia.Accessories.WaterRelic
{
    public class WaterRelic : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shard of Dominion");
			Tooltip.SetDefault("Pressing a hotkey will allow you to prolong death \nFor the next 6 seconds you will take normal damage but not die. \n Cooldown of one minute");
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
			player.GetModPlayer<MyPlayer>(mod).Dominion = true;
		
        }
    }
}
