using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles.Info
{
	public class ProjInfo : GlobalProjectile
	{
		public bool Stars = false;
		public bool givesEnchanted = false;
        public bool givesMinorEnchanted = false;
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (Stars == true)
			{
				float sX = (float)Main.rand.Next(-60, 61) * 0.06f;
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 500, sX, 15, 12, (int)(damage / 3), 5f, projectile.owner);
			}
		}
		
		public override bool InstancePerEntity {get{return true;}}
	}
}
