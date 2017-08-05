using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia.Armor {
	[AutoloadEquip(EquipType.Legs)]
public class EbonFireGrieves : ModItem
{
  
    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonfire Greaves");
			Tooltip.SetDefault("8% increased movement speed and rate of fire, 4% increased ranged damage");
		}
    public override void SetDefaults()
    {
        item.width = 18;
        item.height = 18;
        item.value = 57500;
        item.rare = 3;
        item.defense = 14; //15
    }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.08f;
		 Mod mod = ModLoader.GetMod("Emperia");
		MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
		modPlayer.rofIncrease += 8;
		  player.rangedDamage *= 1.04f;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "EvilTwig", 20);
		recipe.AddIngredient(ItemID.CursedFlames, 28);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}