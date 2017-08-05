using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons {
public class MagmaticHell : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmatic Hell");
			Tooltip.SetDefault("Fires blobs of magma at nearby enemies");
		}
    public override void SetDefaults()
    {
    	item.CloneDefaults(ItemID.Kraken);
        item.damage = 107;
        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 5;
        item.channel = true;
        item.melee = true;
        item.knockBack = 3.2f;
        item.value = 500000;
        item.rare = 5;
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("MagmaYoyoProjectile");
    }
    
    public override void AddRecipes()
	{
		ModRecipe recipe = new ModRecipe(mod);
        //recipe.AddIngredient(null, "HellEssence", 6);
		recipe.AddIngredient(ItemID.Kraken, 1);
        recipe.AddTile(TileID.MythrilAnvil);
        recipe.SetResult(this);
        recipe.AddRecipe();
	}
}}