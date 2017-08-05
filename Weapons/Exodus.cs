using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons  //where is located
{
    public class Exodus : ModItem
    {
		 private const float explodeRadius = 64;
		 public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exodus");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 347;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 200;              //Sword width
            item.height = 200;             //Sword height
            item.useTime = 28;          //how fast 
            item.useAnimation = 28;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 8f;      //Sword knockback
            item.value = 100;        
            item.rare = 10;
			item.scale = 1f;
			item.shootSpeed = 8f;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //player speed                 
        }
		 public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 20);
				recipe.AddIngredient(ItemID.Amethyst, 20);
				recipe.AddIngredient(ItemID.FragmentSolar, 15);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			  for (int i = 0; i < Main.npc.Length; i++)
            {
                if (player.Distance(Main.npc[i].Center) < explodeRadius)
                    Main.npc[i].StrikeNPC(damage *2, 0f, 0, false, false, false);
            }

           
              

                /*if (i % 8 == 0)
                {   //odd
                    Dust.NewDust(player.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 10);
					Dust.NewDust(player.Center + vec, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 62);
                }

                if (i % 9 == 0)
                {   //even
                    vec.Normalize();
                    Dust.NewDust(player.Center, Main.rand.Next(1, 7), Main.rand.Next(1, 7), 10, vec.X * 2, vec.Y * 2);
                }
            }
*/
			
				for (int i = 0; i < 360; i += 5)
				{
				Vector2 vec = Vector2.Transform(new Vector2(-explodeRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
				vec.Normalize();
				int num622 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), player.width, player.height, 62, 0f, 0f, 62, new Color(53f, 67f, 253f), 2f);
				Main.dust[num622].velocity += (vec *5f);
				}

			
			
            Main.PlaySound(SoundID.Item, player.Center, 14);    //bomb explosion sound
            Main.PlaySound(SoundID.Item, player.Center, 21);    //swishy sound

  
        
		}
      }
	  }
