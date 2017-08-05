using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Projectiles
{
    public class EnchantedChakram : ModProjectile
    {
    	bool returnTo = false;
		int timerLeft = 0;
		private Vector2 direction;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Chakram");
		}
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
        }

        public override void AI()
        {
            bool despawnCondition1 = false;
            bool despawnCondition2 = true;
            bool targetPlayer = false;
            float ProjCenterX = projectile.Center.X;
            float ProjCenterY = projectile.Center.Y;
            float maxHomeDistance = 700f;
            bool targetNPC = false;
            Player player = Main.player[projectile.owner];
            timerLeft++;
            if (!returnTo)
            {
                for (int npcFinder = 0; npcFinder < 200; ++npcFinder)
                {
                    if (Main.npc[npcFinder].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[npcFinder].Center, 1, 1))
                    {
                        float num1 = Main.npc[npcFinder].position.X + (float)(Main.npc[npcFinder].width / 2);
                        float num2 = Main.npc[npcFinder].position.Y + (float)(Main.npc[npcFinder].height / 2);
                        float num3 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num1) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num2);
                        if (num3 < maxHomeDistance)
                        {
                            maxHomeDistance = num3;
                            ProjCenterX = num1;
                            ProjCenterY = num2;
                            targetNPC = true;
                        }
                    }
                }
                if (targetNPC)
                {
                    float num4 = Main.rand.Next(30, 43);
                    Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num5 = ProjCenterX - vector35.X;
                    float num6 = ProjCenterY - vector35.Y;
                    float num7 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
                    num7 = num4 / num7;
                    num5 *= num7;
                    num6 *= num7;
                    projectile.velocity.X = (projectile.velocity.X * 20f + num5) / 21f;
                    projectile.velocity.Y = (projectile.velocity.Y * 20f + num6) / 21f;
                    return;
                }
                else
                {



                }
            }
            else
            {
                direction = player.Center - projectile.Center ;
				direction.Normalize();
				projectile.velocity = direction * 12f;
            }
            if (timerLeft > 120)
            {
                returnTo = true;
            }
			
            if (projectile.position.X > player.position.X - 20 && projectile.position.X < player.position.X + 20 && projectile.position.Y > player.position.Y - 20 && projectile.position.Y < player.position.Y + 20 && returnTo)
			{
				projectile.Kill();
			}
			
            projectile.rotation += 0.15f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        	returnTo = true;
        }
    }
}