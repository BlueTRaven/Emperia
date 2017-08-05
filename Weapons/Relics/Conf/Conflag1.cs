using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Relics.Conf   //where is located
{
    public class Conflag1 : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Conflagration");
			Tooltip.SetDefault("A staff more powerful than any other \nBorn of flame");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 34;            
            item.magic = true;
            item.noMelee = true;          
            item.width = 32;              
            item.height = 32;             
			Item.staff[item.type] = true;
            item.useTime = 32;         
            item.useAnimation = 32;     
            item.useStyle = 5;    
            item.mana = 17;			
            item.knockBack = 5;      
            item.value = 100;        
            item.rare = 10;
			item.shoot = mod.ProjectileType("ConflagrationProj"); 
			item.shootSpeed = 8f;
            item.autoReuse = false;   
            item.useTurn = true;                           
        }
    }
}