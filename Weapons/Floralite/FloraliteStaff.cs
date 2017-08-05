using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
namespace Emperia.Weapons.Floralite
{
    public class FloraliteStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floralite Staff");
		}


        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = 2;
            item.crit = 4;
            item.mana = 9;
            item.damage = 53;
            item.knockBack = 3;
            item.useStyle = 5;
            item.useTime = 32;
            item.useAnimation = 32;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            Item.staff[item.type] = true;
            item.shoot = mod.ProjectileType("PinkFloralBlast");
            item.shootSpeed = 8f;
            item.UseSound = SoundID.Item20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "Floralis", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			

				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, mod.ProjectileType("GreenFloralBlast"), damage, knockBack, player.whoAmI);
		
			return false;
		}
    }
}