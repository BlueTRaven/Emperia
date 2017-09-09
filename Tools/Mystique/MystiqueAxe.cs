using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Tools.Mystique {
public class MystiqueAxe : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Axe");
		}
    public override void SetDefaults()
    {
        item.damage = 9;
        item.melee = true;
        item.width = 70;
        item.height = 70;
        item.useTime = 14;
        item.useAnimation = 14;
        item.useTurn = true;
        item.axe = 65;
        item.useStyle = 1;
        item.knockBack = 1.5f;
        item.value = 2340;
        item.rare = 4;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.DirtBlock, 1);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}