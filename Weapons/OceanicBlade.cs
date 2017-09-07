using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons   //where is located
{
    public class OceanicBlade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oceanic Blade");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 98;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 200;              //Sword width
            item.height = 200;             //Sword height
            item.useTime = 23;          //how fast 
            item.useAnimation = 23;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 7.5f;      //Sword knockback
            item.value = 100;        
            item.rare = 10;
			item.scale = 1f;
			item.shoot = mod.ProjectileType("OceanWave");
			item.shootSpeed = 8f;
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed     
item.UseSound = SoundID.Item1;             
        }
		public override void AddRecipes()
		{
			
			ModRecipe recipe = new ModRecipe(mod);
		    recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			//recipe.AddIngredient(null, "OceanEssence", 10);
			recipe.AddIngredient(ItemID.Seashell, 5);
			recipe.AddIngredient(ItemID.Coral, 5);

			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}