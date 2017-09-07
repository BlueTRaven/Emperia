using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Items
{
    public class SunsoakedChestnut : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunsoaked Chestnut");
			Tooltip.SetDefault("Increases Movement speed, damage reduction and damage by 2%");
		}
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(mod.BuffType("ChestnutBuff"), 108000);
			return true;
        }
    }
}
