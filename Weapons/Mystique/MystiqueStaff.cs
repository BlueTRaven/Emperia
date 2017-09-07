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
namespace Emperia.Weapons.Mystique
{
    public class MystiqueStaff : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Staff");
		}


        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = 5;
            item.crit = 4;
            item.mana = 9;
            item.damage = 68;
            item.knockBack = 3;
            item.useStyle = 5;
            item.useTime = 25;
            item.useAnimation = 25;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            Item.staff[item.type] = true;
            item.shoot = mod.ProjectileType("MystiqueProj");
            item.shootSpeed = 8f;
            item.UseSound = SoundID.Item20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "MystiqueBar", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return true;
		}
    }
}