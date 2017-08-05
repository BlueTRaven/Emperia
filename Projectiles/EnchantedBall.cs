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
    public class EnchantedBall : ModProjectile
    {
        private Point tileCoordPos { get { return new Point((int)(projectile.position.X / 16), (int)(projectile.position.Y / 16)); } }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Ball");
		}
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.light = 0.75f;
			projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }

   

        public override bool PreKill(int timeLeft)
        {   //make dusts when dying
            for (int i = 0; i < Main.rand.Next(6, 12); i++)
            {
                float x = Main.rand.NextFloat() * projectile.width;
                float y = Main.rand.NextFloat() * projectile.height;

                Vector2 random = new Vector2(-5, 0).RotatedByRandom(MathHelper.ToRadians(360));
                Dust.NewDust(new Vector2(projectile.Hitbox.X + x, projectile.Hitbox.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, random.X, random.Y);
            }
            return true;
        }

        public override void AI()
        {   //make less dusts when just moving
            for (int i = 0; i < Main.rand.Next(4); i++)
            {
                float x = Main.rand.NextFloat() * projectile.width;
                float y = Main.rand.NextFloat() * projectile.height;

                Vector2 vel = Vector2.Normalize(-projectile.velocity) * 2;

                Dust.NewDust(new Vector2(projectile.Hitbox.X + x, projectile.Hitbox.Y + y), Main.rand.Next(1, 7), Main.rand.Next(1, 7), 20, vel.X, vel.Y);
            }

            projectile.velocity.Y = 0;
            bool foundbelow = false;
            for (int i = 0; i < 16; i++)
            {
                Tile below = Framing.GetTileSafely(tileCoordPos.X, tileCoordPos.Y + i);

                if (below.active() && below.collisionType > 0)
                {
                    if (i == 0) //if it's inside the tile
                    {
                        bool foundabove = false;
                        for (int j = 1; j <= 3; j++)
                        {
                            Tile above = Framing.GetTileSafely(tileCoordPos.X, tileCoordPos.Y - j);

                            if (!above.active())
                            {
                                projectile.position.Y = (tileCoordPos.Y - j) * 16;
                                foundabove = true;
                                break;
                            }
                        }

                        if (!foundabove)
                            projectile.Kill();
                        //else break; //we can safely break since if foundabove == true it'll already be above tiles.
                    }
                    else
                    {
                        projectile.position.Y = (tileCoordPos.Y + i - 1) * 16;
                        foundbelow = true;
                        break;
                    }
                }
            }
            if (!foundbelow)    //this will only be the case if it's inside a tile.
                projectile.Kill();
        }

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.life <= 0)
            {   //this might not work too well
                Main.player[projectile.owner].AddBuff(mod.BuffType<Buffs.Enchanted>(), Buffs.Enchanted.stackDuration);
            }
        }*/

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //TODO draw crystals
            return false;
        }
    }
}
