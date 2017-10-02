using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{

    public class Cerith : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cerith Shell");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = true;      //make that the projectile will not damage you
            projectile.magic = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = -1;      //how many npc will penetrate
            projectile.timeLeft = 200;   //how many time projectile projectile has before disepire
            projectile.light = 0.75f;    // projectile light
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()           //projectile make that the projectile will face the corect way
        {                                                           // |
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			 /*Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 231, 0.0f, 0.0f, 0, new Color(), 1f)];
			dust.position = projectile.Center;
			dust.velocity = Vector2.Zero;
			dust.noGravity = true;*/
			for (int index4 = 0; index4 < 2; ++index4)
            {
              int index5 = Dust.NewDust(new Vector2(projectile.position.X, (float) ((double) projectile.position.Y + (double) projectile.height - 16.0)), projectile.width, 16, 228, 0.0f, 0.0f, 0, new Color(), 1f);
              Main.dust[index5].noGravity = true;
              Main.dust[index5].velocity *= 0.5f;
              Main.dust[index5].velocity.X -= (float) index4 - (float) ((double) projectile.velocity.X * 2.0 / 3.0);
              Main.dust[index5].scale = 2.8f;
            }
        }
		public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.Wet, 500);
			 target.AddBuff(mod.BuffType("Drowning"), 600);
		}
        
    }
}