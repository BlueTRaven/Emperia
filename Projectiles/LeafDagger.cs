using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{

    public class LeafDagger : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leafy Dagger");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.melee = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 1;      //how many npc will penetrate
            projectile.timeLeft = 200;   //how many time this projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //this make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			if (Main.rand.Next(2)==0)
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 3, projectile.oldVelocity.X, projectile.oldVelocity.Y);
            
        }
		public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Wet, 500);
			 target.AddBuff(mod.BuffType("Drowning"), 600);
		}
        
    }
}