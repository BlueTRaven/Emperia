using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Wooden
{
	public class LeafDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shrubbed Dagger");
		}
		public override void SetDefaults()
		{
			item.damage = 8;
			item.thrown = true;
			item.width = 58;
			item.height = 36;
			item.useAnimation = 43;
			item.useTime = 43;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 1f;
			item.value = 10;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("LeafDagger");
			item.shootSpeed = 12f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int k = 0; k < 2; k++)
			{
				int spread = -5 + (5 * k);
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(spread));
				
				int p = Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
				
			}
            return false;
		}
	}
}
