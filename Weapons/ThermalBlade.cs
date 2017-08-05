using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons  //where is located
{
    public class ThermalBlade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thermal Blade");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 43;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 200;              //Sword width
            item.height = 200;             //Sword height
            item.useTime = 32;          //how fast 
            item.useAnimation = 32;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 7.5f;      //Sword knockback
            item.value = 100;        
            item.rare = 10;
			item.scale = 1f;
			item.shoot = mod.ProjectileType("fireIceBolt");
			item.shootSpeed = 8f;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		 public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IceBlade, 1);
				recipe.AddIngredient(null, "FireBlade", 1);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}