using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Emperia.Weapons
{
    public class GraniteBow : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Bow");
		}
        public override void SetDefaults()
        {
            item.damage = 9;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = ItemID.WoodenArrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 1;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
        public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "GraniteBar", 8);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
    }
}