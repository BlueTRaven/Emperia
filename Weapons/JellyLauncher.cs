using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;


namespace Emperia.Weapons
{
    public class JellyLauncher : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jelly Cannon");
		}
        public override void SetDefaults()
        {
            item.damage = 42; 
            item.ranged = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.knockBack = 3.5f;
            item.value = 100;
            item.rare = 3;
            item.scale = 1f;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useTurn = true;  
            item.noMelee = true;

            item.shoot = mod.ProjectileType("Jelly");
            item.shootSpeed = 10f;
        }
		 public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 30);
			recipe.AddIngredient(mod.ItemType("Shroomer"), 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
