using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
namespace Emperia.Projectiles
{
    public class NappasArrow : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nappas Arrow");
		}
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 38;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            projectile.light = 0.5f;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.WoodenArrowFriendly;
        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }
    }
}
