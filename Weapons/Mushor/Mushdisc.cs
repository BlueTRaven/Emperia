using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;


namespace Emperia.Weapons.Mushor
{
    public class Mushdisc : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mush-Disc");
		}
        public override void SetDefaults()
        {
            item.damage = 42; 
            item.thrown = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 3.5f;
            item.value = 100;
            item.rare = 3;
            item.scale = 1f;
			item.consumable = true;
			item.noUseGraphic = true;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useTurn = true;    //turns the player to face mouse direction
            item.noMelee = true;
            item.maxStack = 990;
            item.shoot = mod.ProjectileType("MushDisc");
            item.shootSpeed = 9f;
        }
    }
}
