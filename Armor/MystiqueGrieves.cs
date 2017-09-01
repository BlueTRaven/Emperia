using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
	[AutoloadEquip(EquipType.Legs)]
public class MystiqueGrieves : ModItem
{

    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Greaves");
			Tooltip.SetDefault("10% increased movement and 4% increased melee speed \n +20 Max Health");
		}
    public override void SetDefaults()
    {
        item.width = 18;
        item.height = 18;
        item.value = 57500;
        item.rare = 3;
        item.defense = 5; //15
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.1f;
		player.meleeSpeed += 0.04f;
		player.statLifeMax2 += 20;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        //recipe.AddIngredient(null, "MystiqueBar", 13);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}