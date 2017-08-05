using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Items
{
    public class ZaWarudo : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dio's World");
			Tooltip.SetDefault("");
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
            MyPlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();
		    if (!MyPlayer.theWorld)
				MyPlayer.theWorld = true;
			else
				MyPlayer.theWorld = false;
            return true;
        }
		public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GlowingMushroom, 10);
				recipe.AddIngredient(null, "Fungoo", 12);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}
