using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Dragons
{
	public class Fang_Of_Illness : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fangs of Illness");
		}
		public override void SetDefaults()
		{
			item.damage = 91;
			item.thrown = true;
			item.width = 58;
			item.height = 36;
			item.useAnimation = 8;
			item.useTime = 8;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 1f;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("IllnessFang");
			item.shootSpeed = 12f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int k = 0; k < 3; k++)
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
