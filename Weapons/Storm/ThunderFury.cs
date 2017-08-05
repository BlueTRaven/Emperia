using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Storm  //where is located
{
    public class ThunderFury : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunder's Fury");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 73;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 200;              //Sword width
            item.height = 200;             //Sword height
            item.useTime = 12;          //how fast 
            item.useAnimation = 12;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 7.5f;      //Sword knockback
            item.value = 100;        
            item.rare = 6;
			item.scale = 1f;
			item.shoot = mod.ProjectileType("Lightning");
			item.shootSpeed = 8f;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		
    }
}