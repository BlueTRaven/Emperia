using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Emperia.Weapons.Dragons
{
	public class Ember_Tear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ember Shred");
		}
		public override void SetDefaults()
		{
			item.damage = 83;
			item.melee = true;
			item.width = 68;
			item.height = 72;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 1000000;
			item.rare = 11;
			item.useTurn = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("Immolate"), 180, false);
			Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("Burning_Slash"), (int)(damage/2), knockback, player.whoAmI, 0f, 0f);
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 158);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.75f;
				Main.dust[dust].fadeIn = 1.3f;
				Main.dust[dust].scale = 0.7f;
			}
		}
	}
}
