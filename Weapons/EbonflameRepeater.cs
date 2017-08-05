using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons
{
	public class EbonflameRepeater : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonflame Repeater");
			Tooltip.SetDefault("30% chance to not consume ammo & transforms musket balls into cursed bullets");
		}
		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useAnimation = 16;
			item.useTime = 4;
			item.reuseDelay = 20;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() > .30f && !(player.itemAnimation < item.useAnimation - 3);
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.CursedBullet; // or ProjectileID.FireArrow;
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		
	}
}
