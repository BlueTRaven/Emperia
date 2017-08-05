using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons   //where is located
{
    public class DesertStaff : ModItem
	
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstorm Staff");
		}
        public override void SetDefaults()
        {   //Sword name
            item.damage = 23;            //Sword damage
            item.magic = true;
            item.noMelee = true;          //if it's melee
            item.width = 32;              //Sword width
            item.height = 32;             //Sword height //Item Description
            item.useTime = 32;          //how fast 
            item.useAnimation = 32;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 5;      //Sword knockback
            item.value = 100;        
            item.rare = 10;
			item.shoot = mod.ProjectileType("TestyCool"); // the tornado when its ready
			item.shootSpeed = 8f;
            item.autoReuse = false;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
    }
}