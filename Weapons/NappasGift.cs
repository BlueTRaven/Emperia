using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Emperia.Projectiles.Info;

namespace Emperia.Weapons
{
    public class NappasGift : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nappas Gift");
			Tooltip.SetDefault("Shoots a spread of 4 or 5 arrows, which rain stars down from the sky on enemy hits");
		}
        public override void SetDefaults()
        {
            item.damage = 95;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("NappasArrow");
            item.useAmmo = ItemID.WoodenArrow;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 10;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 4 + Main.rand.Next(2);//4, or 5 shots
			float rotation = MathHelper.ToRadians(25);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				int proj = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 4, perturbedSpeed.Y * 4, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 30);
			recipe.AddIngredient(ItemID.FragmentVortex, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.PineTreeBlock, 40);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}