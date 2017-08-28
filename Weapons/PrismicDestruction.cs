using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Weapons        
{
    public class PrismicDestruction : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prismic Destruction");
			Tooltip.SetDefault("Killing enemies will give a short buff, increasing your movement speed a firing stronger rockets");
		}
        public override void SetDefaults()
        {  
            item.damage = 27;  
            item.ranged = true;    
            item.width = 42; 
            item.height = 16;    
            item.useTime = 40;   
            item.useAnimation = 40;     
            item.useStyle = 5;  
            item.noMelee = true; 
            item.knockBack = 3.25f; 
            item.UseSound = SoundID.Item34; 
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 6;   
            item.autoReuse = true;  
            item.shoot = mod.ProjectileType("RocketI");   
            item.shootSpeed = 10f; 
            //item.useAmmo = mod.ItemType("Rocket");
        }
 
        public override bool ConsumeAmmo(Player player) 
        {
            return Main.rand.NextFloat() > .1f;
        }
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
    }
}