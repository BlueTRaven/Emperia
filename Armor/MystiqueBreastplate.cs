using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
	[AutoloadEquip(EquipType.Body)]
public class MystiqueBreastplate : ModItem
{
  
	 public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Breastplate");
			Tooltip.SetDefault("+10% increased melee and magic critical strike chance \n +25 max mana");
		}
    public override void SetDefaults()
    {
        item.width = 18;
        item.height = 18;
        item.value = 65000;
        item.rare = 3;
        item.defense = 17; //15
    }

    public override void UpdateEquip(Player player)
    {
        player.meleeCrit += 10;
		player.magicCrit += 10;
		player.statManaMax2 += 25;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
       // recipe.AddIngredient(null, "MystiqueBar", 18);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}