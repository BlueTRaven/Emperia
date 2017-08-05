using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Weapons
{
    public class EnchantedChakram : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Chakram");
			Tooltip.SetDefault("Shimmer with crystal light");
		}
        public override void SetDefaults()
        {       
            item.melee = true;
            item.width = 30;
			item.damage = 50;
            item.height = 30;
            item.useTime = 25;
            item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 8;
            item.rare = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType ("EnchantedChakram");
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CrystalShard, 15);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}