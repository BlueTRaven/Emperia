using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

using Emperia.Buffs;
using Emperia.Projectiles;

namespace Emperia.Weapons
{
    public class Space_Machinegun : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Space Machinegun");
		}
        public override void SetDefaults()
        {
            item.damage = 35; 
            item.magic = true;
            item.width = 54;
            item.height = 34;
            item.useTime = 6;
            item.useAnimation = 6;
            item.useStyle = 5;
            item.knockBack = 3.5f;
            item.value = 100000;
            item.rare = 5;
            item.scale = 1f;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.noMelee = true;

            item.shoot = 20;
            item.shootSpeed = 16f;
            item.mana = 5;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 vector2 = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-10, 10)));
			
			switch (Main.rand.Next(2))
			{
				case 0:
					type = mod.ProjectileType("LaserGreen");
					break;
				case 1:
					type = mod.ProjectileType("LaserPurple");
					break;
			}
			
			Projectile.NewProjectile(player.Center.X, player.Center.Y, vector2.X, vector2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			
            return false;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, -4);
		}
		
		 public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SpaceGun, 1);
				recipe.AddIngredient(ItemID.SoulofFright, 5);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
    }
}
