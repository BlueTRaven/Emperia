using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Mushor
{
    public class Fungon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Flungus");
			Tooltip.SetDefault("The Flungus leaves behind damaging spores to deal additional damage");
		}


        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = 3;
            item.noMelee = true;
            item.useStyle = 5; 
            item.useAnimation = 27; 
            item.useTime = 27;
            item.knockBack = 7;
			item.value = 2000;
            item.damage = 35;
            item.noUseGraphic = true; 
            item.shoot = mod.ProjectileType("FlungusProj");
            item.shootSpeed = 16f;
            item.UseSound = SoundID.Item1;
            item.melee = true; 
            item.channel = true; 
        }

    }
}