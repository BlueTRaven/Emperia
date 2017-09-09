using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Tools.Mystique {
public class MystiqueHammer : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Hammer");
		}
    public override void SetDefaults()
    {
        item.damage = 12;
        item.melee = true;
        item.width = 64;
        item.height = 64;
        item.useTime = 17;
        item.useAnimation = 17;
        item.useTurn = true;
		item.hammer = 65;
        item.useStyle = 1;
        item.knockBack = 2f;
        item.value = 2340;
        item.rare = 3;
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