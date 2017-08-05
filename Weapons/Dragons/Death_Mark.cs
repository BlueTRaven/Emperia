using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Dragons
{
	public class Death_Mark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Mark");
		}
		public override void SetDefaults()
		{
			item.damage = 145;
			item.ranged = true;
			item.width = 58;
			item.height = 36;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useStyle = 5;
			item.crit = 6;
			item.noMelee = true;
			item.knockBack = 4.5f;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 3;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Arrow;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX, speedY, mod.ProjectileType("VoidSpike"), (int)(200 * player.rangedDamage), knockBack, Main.myPlayer, 0, 0);
            return true;
		}
	}
}
