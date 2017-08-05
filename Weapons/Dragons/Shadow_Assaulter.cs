using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Dragons
{
	public class Shadow_Assaulter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Assaulter");
		}
		public override void SetDefaults()
		{
			item.damage = 77;
			item.ranged = true;
			item.width = 58;
			item.height = 36;
			item.useAnimation = 12;
			item.useTime = 12;
			item.useStyle = 5;
			item.crit = 9;
			item.noMelee = true;
			item.knockBack = 4.5f;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Bullet;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int k = 0; k < 5; k++)
			{
				int spread = -6 + (3 * k);
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(spread));
				
				int p = Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
				
			}
            return false;
		}
		
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, -8);
		}
		
		public override void HoldItem(Player player)
        {
			if (player.ownedProjectileCounts[mod.ProjectileType("ShadowDrone")] < 1)
			{
				Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, mod.ProjectileType("ShadowDrone"), 130, 1f, player.whoAmI, 0f, 0f);
			}
			MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
			modPlayer.ShadowDrone = true;
		}
	}
}
