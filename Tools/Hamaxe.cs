using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Tools {
public class Hamaxe : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seashell Hamaxe");
		}
    public override void SetDefaults()
    {
        item.damage = 7;
        item.melee = true;
        item.width = 46;
        item.height = 46;
        item.useTime = 26;
        item.useAnimation = 26;
        item.useTurn = true;
        item.axe = 11;
		item.hammer = 55;
		item.scale = 1.25f;
        item.useStyle = 1;
        item.knockBack = 2f;
        item.value = 1770;
        item.rare = 4;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "MarbleBar", 7);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}