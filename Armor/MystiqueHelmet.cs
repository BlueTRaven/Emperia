using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Armor {
	[AutoloadEquip(EquipType.Head)]
public class MystiqueHelmet : ModItem
{
    
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Helmet");
			Tooltip.SetDefault("+5% melee and magic damage \n +20 Max Mana");
		}
    public override void SetDefaults()
    {
        item.width = 18;
        item.height = 18;
        item.value = 50000;
        item.rare = 3;
        item.defense = 7; //15
    }

    public override bool IsArmorSet(Item head, Item body, Item legs)
    {
        return body.type == mod.ItemType("MystiqueBreastplate") && legs.type == mod.ItemType("MystiqueGrieves");
    }
    
  

    public override void UpdateArmorSet(Player player)
    {
        player.setBonus = "Melee and magic projectile spawn seeking healing projectiles on hit \n Upon killing an enemy using a melee or magic weapon, it will explode";
        player.GetModPlayer<MyPlayer>(mod).mystiqueSetBonus = true;
    }
    
    public override void UpdateEquip(Player player)
    {
    	player.meleeDamage *= 1.05f;
        player.magicDamage *= 1.05f;
		player.statManaMax2 += 20;
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