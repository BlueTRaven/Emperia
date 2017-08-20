using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.WorldStuff;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Emperia.Bloom;

namespace Emperia.Weapons   
{
    public class DesertStaff : ModItem
	
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstorm Staff");
		}
        public override void SetDefaults()
        {  
            item.damage = 23;            
            item.magic = true;
            item.noMelee = true;          
            item.width = 32;              
            item.height = 32;             
            item.useTime = 32;          
            item.useAnimation = 32;     
            item.useStyle = 1;       
            item.knockBack = 5;      
            item.value = 100;        
            item.rare = 10;
			item.shoot = mod.ProjectileType("TestyCool"); 
			item.shootSpeed = 8f;
            item.autoReuse = false;   
            item.useTurn = true;                            
        }
		public override bool PreDrawInInventory (SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 Origin, float scale)
		{
			Texture2D dayIcon = Emperia.instance.GetTexture("Weapons/SwordDay");
			if (Main.dayTime)
			{

				spriteBatch.Draw(dayIcon, frame, Color.White);
			}
			return false;
		}
    }
}