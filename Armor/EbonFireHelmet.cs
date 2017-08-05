using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Armor {
	[AutoloadEquip(EquipType.Head)]
public class EbonFireHelmet : ModItem
{
   
	 public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonfire Mask");
			Tooltip.SetDefault("8% increased ranged damage and crit, 6% increased rate of fire");
		}
    public override void SetDefaults()
    {
 
        item.width = 18;
        item.height = 18;
        item.value = 50000;
        item.rare = 3;
        item.defense = 10; //15
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == mod.ItemType("EbonFireChestplate") && legs.type == mod.ItemType("EbonFireGreaves");
    }
    
  

    public override void UpdateArmorSet(Player player)
    {
		
        player.setBonus = "Spawns cursed cinders on enemy hits if they are afflicted with 'Cursed inferno'";
        
    }
    
    public override void UpdateEquip(Player player)
    {
		  Mod mod = ModLoader.GetMod("Emperia");
		MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
		modPlayer.rofIncrease += 6;
        player.rangedDamage *= 1.08f;
		player.rangedCrit += 8;

    }
    
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
         recipe.AddIngredient(null, "EvilTwig", 18);
		recipe.AddIngredient(ItemID.CursedFlames, 24);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}