using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Emperia.Projectiles.DragonWepProj
{
	public class ShadowDrone : HoverShooter
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Drone");
		}
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 9;
			projectile.height = 8;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.ranged = true;
			projectile.minionSlots = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			inertia = 20f;
			shootCool = 35f;
			shoot = mod.ProjectileType("ShadowDroneBolt");
			shootSpeed = 10f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (player.dead)
			{
				modPlayer.ShadowDrone = false;
			}
			if (modPlayer.ShadowDrone)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}