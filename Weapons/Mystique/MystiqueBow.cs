using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Emperia.Weapons.Mystique
{
    public class MystiqueBow : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Bow");
			Tooltip.SetDefault("Shoots a stream of concentrated leaves \n 80% chance to not consume ammo");
		}
        public override void SetDefaults()
        {
            item.damage = 43;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 5;
            item.useAnimation = 4;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("Leafy");
            item.useAmmo = ItemID.WoodenArrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 1;
            item.autoReuse = true;
            item.shootSpeed = 10f;
			item.UseSound = SoundID.Item5; 
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("LeafyRanged"), damage, knockBack, player.whoAmI, 0f, 0f); //This is spawning a projectile of type FrostburnArrow using the original stats
            return false;
        }
		 public override bool ConsumeAmmo(Player player) 
        {
            return Main.rand.NextFloat() > .8f;
        }
        public override void AddRecipes()
		{
        ModRecipe recipe = new ModRecipe(mod);
        //recipe.AddIngredient(null, "MystiqueBar", 8);
        recipe.AddTile(TileID.Anvils);
        recipe.SetResult(this);
        recipe.AddRecipe();
		}
    }
}