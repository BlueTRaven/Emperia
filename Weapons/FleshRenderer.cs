using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Emperia.Weapons
{
    public class FleshRenderer : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Life's Fate");
		}
        public override void SetDefaults()
        {
            item.damage = 44;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = 10000;
            item.rare = 5;
			item.scale = 1.3f;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1; 

        }
        public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.Muramasa);
		recipe.AddIngredient(ItemID.BloodButcherer);
		recipe.AddIngredient(ItemID.BladeofGrass);
		recipe.AddIngredient(ItemID.FieryGreatsword);
        recipe.AddTile(TileID.DemonAltar);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
    }
}