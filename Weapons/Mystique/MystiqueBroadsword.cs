using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia.Projectiles;

namespace Emperia.Weapons.Mystique //where is located
{
    public class MystiqueBroadsword : ModItem
    {
		private Vector2 SpawnPoint;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystique Broadsword");
		}
        public override void SetDefaults()
        {    //Sword name
            item.damage = 63;            //Sword damage
            item.melee = true;            //if it's melee
            item.width = 200;              //Sword width
            item.height = 200;             //Sword height
            item.useTime = 38;          //how fast 
            item.useAnimation = 38;     
            item.useStyle = 1;        //Style is how this item is used, 1 is the style of the sword
            item.knockBack = 7.5f;      //Sword knockback
            item.value = 100;        
            item.rare = 10;
			item.scale = 1f;
			item.UseSound = SoundID.Item18;
			item.shoot = mod.ProjectileType("Leafy");
			item.shootSpeed = 8f;
            item.autoReuse = true;   //if it's capable of autoswing.
            item.useTurn = true;             //projectile speed                 
        }
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type1, ref int damage, ref float knockBack)
		{
			int i = Main.myPlayer;
			float num72 = item.shootSpeed;
	    	Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
	    	float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
			float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
			if (player.gravDir == -1f)
			{
				num79 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
			}
			float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
			float num81 = num80;
			if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
			{
				num78 = (float)player.direction;
				num79 = 0f;
				num80 = num72;
			}
			else
			{
				num80 = num72 / num80;
			}
	    	num78 *= num80;
			num79 *= num80;
			int num112 = 3;
			for (int num113 = 0; num113 < 5; num113++) 
			{
				vector2 = new Vector2(player.position.X + (float)player.width * 0.5f + (float)(Main.rand.Next(101) * -(float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				vector2.X = (vector2.X + player.Center.X) / 2f + (float)Main.rand.Next(-100, 101);
				vector2.Y -= (float)(100 * num113);
				num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X + (float)Main.rand.Next(-40, 41) * 0.03f;
				num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
				if (num79 < 0f) 
				{
					num79 *= -1f;
				}
				if (num79 < 20f) 
				{
					num79 = 20f;
				}
				num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
				num80 = num72 / num80;
				num78 *= num80;
				num79 *= num80;
				float num114 = num78;
				float num115 = num79 + (float)Main.rand.Next(-40, 41) * 0.02f;
				int meteor;
				if (Main.rand.Next(2) == 0)
				{
					meteor = Projectile.NewProjectile(vector2.X, vector2.Y, num114 * 1.25f, num115 * 1.25f, mod.ProjectileType<Leafy>(), (int)((double)damage * 1f), 0.5f, i, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);
				}
				else
				{
					meteor = Projectile.NewProjectile(vector2.X, vector2.Y, num114 * 1.75f, num115 * 1.75f, mod.ProjectileType<Leafy>(), (int)((double)damage * 0.5f), 0.5f, i, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);
				}
				Main.projectile[meteor].magic = false;
				Main.projectile[meteor].melee = true;
			}
			return false;
		  }
    }
}