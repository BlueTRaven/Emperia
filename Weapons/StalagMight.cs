using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Emperia.Weapons
{
	public class StalagMight : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Right click to fire an innacurate spread of stalagmites\n Left click to fire an explosive high-damage dealing bolt");
		}

		public override void SetDefaults()
		{
			item.damage = 42;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StalagmiteBig"); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				
				item.shoot = mod.ProjectileType("StalagmiteSmall");
			}
			else
			{
				item.shoot = mod.ProjectileType("StalagmiteBig");
			}
			return base.CanUseItem(player);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
			damage = 20;
			int numberProjectiles = 3 + Main.rand.Next(2); 
			type = mod.ProjectileType("StalagmiteSmall");
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; 
			}
			else
			{
			return true;
			}
		}
	}
}
