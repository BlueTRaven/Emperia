using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Emperia.Weapons
{
    public class AntlionBow : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Bow");
			Tooltip.SetDefault("Occasionally shoots a ball of sand along with regular arrows");
		}
        public override void SetDefaults()
        {
            item.damage = 11;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = ItemID.WoodenArrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 6;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(5) == 0) {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.SandBallGun, damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return true; //Makes sure to not fire the original projectile
			}
			else {
				return true;
				
			}
        }
		public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Cactus, 15);
				recipe.AddIngredient(ItemID.DesertFossil, 5);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}