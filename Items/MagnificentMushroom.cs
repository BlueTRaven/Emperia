using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Emperia.Bosses.Mushor;

namespace Emperia.Items
{
	
    public class MagnificentMushroom : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystical Mushroom");
			Tooltip.SetDefault("These forest shrooms may only heal you for 5, but they don't have a reset.");
		}
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            item.rare = 5;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
           player.statLife += 5;
		   player.HealEffect(5);
		   return true;
        }
    }
}
