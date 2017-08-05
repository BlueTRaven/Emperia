using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia;
using Emperia.Projectiles;

namespace Emperia
{
    public class MyPlayer : ModPlayer
    {
        public bool wSpirit = false;
        public bool enchanted = false;
		public bool canSpore = true;
		public bool sporeFriend = false;
		public bool Fortress = false;
		public bool ShadowDrone = false;
        public bool spored = false;
		public bool longerInvince = false;
		public bool isBloom = false;
		public bool Scourge = false;
		public bool Storm = false;
		public bool damageAvoid = false;
        public int enchantedStacks;
		public bool ZoneTwilight = false;
		public bool doubleCrit = false;
		public int points = 0;
		public int rofIncrease = 0;
		public bool slightKnockback = false;
		public static bool theWorld = false;
		int damageCount = 0;
		int counter = 0;

        public override void ResetEffects()
        {
            wSpirit = false;
            enchanted = false;
			Fortress = false;
			Storm = false;
			sporeFriend = false;
			longerInvince = false;
			Scourge = false;
			ShadowDrone = false;
            enchantedStacks = 0;
			rofIncrease = 0;
			slightKnockback = false;
            spored = false;
			//player.slowFall = true;
			doubleCrit = false;
			damageAvoid = false;
			theWorld = false;
        }

        public override void PostUpdate()
        {
            if (enchanted)
            {
                for (int i = 0; i < Main.rand.Next(enchantedStacks) + 1; i++)
                {
                    float x = Main.rand.NextFloat() * player.Hitbox.Width;
                    float y = Main.rand.NextFloat() * player.Hitbox.Height;
                    Dust.NewDust(new Vector2(player.Hitbox.Location.X + x, player.Hitbox.Location.Y + y), 4, 4, 20);
                }
            }
			if (player.controlUp)
				player.slowFall = true;
            if (spored)
            {
                player.jump = 0;
                //player.velocity.Y = Math.Abs(player.velocity.Y);
            }
			if (theWorld)
			{
				for (int x = 0; x <= 100; x++)
				{
					Main.npc[x].velocity.X = 0;
					Main.npc[x].velocity.Y = 0;
					Main.projectile[x].velocity.X = 0;
					Main.projectile[x].velocity.Y = 0;
				}
				
				
			}
			damageCount++;
        }
		public override void UpdateBiomes()
		{
			ZoneTwilight = (EmperialWorld.twilightTiles > 50);
		}
		public override void UpdateBiomeVisuals()
		{
			if (ZoneTwilight)
				player.ManageSpecialBiomeVisuals("Emperia:Twilight", true, player.Center);
			else
				player.ManageSpecialBiomeVisuals("Emperia:Twilight", false, player.Center);
			//if (isBloom)
				//player.ManageSpecialBiomeVisuals("Emperia:Bloom", true, player.Center);

		}
		
		public override void PreUpdate()
		{
			if (Scourge)
			{
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (Main.npc[i].lifeRegen <= 0)
					{
						Main.npc[i].lifeRegen = (int)(Main.npc[i].lifeRegen * 1.5);
					}
				}
			}
			if (theWorld)
			{
				for (int x = 0; x <= 200; x++)
				{
					float j = Main.projectile[x].position.Y;
					Main.npc[x].velocity.X = 0;
					Main.npc[x].velocity.Y = 0;
					Main.npc[x].damage = 0;
					Main.projectile[x].velocity.X = 0;
					Main.projectile[x].velocity.Y = 0;
					Main.projectile[x].position.Y = j;
					Main.projectile[x].timeLeft = 60;
				}
				
				
			}
		}
		
       

        public override void UpdateBadLifeRegen()
        {
            if (spored)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 4;
            }
        }
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			
			damageCount = 0;
			canSpore = true;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
				if (Main.projectile[i].type == mod.ProjectileType("Spore"))
				{
					canSpore = true;
				}
			}
			if (sporeFriend) {
                    if(canSpore)
					{
						if(Main.rand.Next(5) == 0)
						{
			            for (int i = 0; i < 10; i++)
                        {
							Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("Spore"), 14, 0, player.whoAmI, ai1: 36 * i);
                        }
						}
					}
			}
			if (longerInvince == true)
			{
				player.immuneTime = (int)(player.immuneTime * 1.3);
			}
			
			if (Fortress == true)
			{
				player.AddBuff(mod.BuffType("Slag_Skin"), 240, false);
			}
		}
		public override void ModifyHitNPC (Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			if (crit == true && doubleCrit == true)
			{	
				damage *= 2;
			}
			if (slightKnockback)
			{
				knockback *= 1.1f;
			}
		}
		public override bool PreHurt(bool pvp,bool quiet,ref int damage,ref int hitDirection,ref bool crit,ref bool customDamage,ref bool playSound,ref bool genGore,ref PlayerDeathReason damageSource)
		{
			if (damageCount > 600 && damageAvoid)
			{
				damageCount = 0;
				damage /= 2;
				return true;
			}
			return true;
		}
		public override void ModifyHitNPCWithProj (Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (crit == true && doubleCrit == true)
			{	
				damage *= 2;
			}
			if (slightKnockback)
			{
				knockback *= 1.1f;
			}
		}
    }
}