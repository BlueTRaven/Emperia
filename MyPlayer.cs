using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Emperia;
using Emperia.Projectiles;

namespace Emperia
{
    public class MyPlayer : ModPlayer
    {
		public bool SunSeal = false;
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
		public bool ZoneCanyon = false;
		public bool doubleCrit = false;
		public bool incCrit = false;
		public bool incCrit2 = false;
		public int points = 0;
		public int rofIncrease = 0;
		public bool slightKnockback = false;
		public static bool theWorld = false;
		public bool skullLightPet = false;
		public bool mystiqueSetBonus = false;
		public bool Dominion = false;
		public bool forbiddenOath = false;
		public int noDeathTimer = 0;
		public int dominionCooldown = 0;
		public int OathCooldown = 480;
		int damageCount = 0;
		int counter = 0;

        public override void ResetEffects()
        {
			SunSeal = false;
			incCrit2 = false;
			incCrit = false;
            wSpirit = false;
			skullLightPet = false;
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
			mystiqueSetBonus = false;
			forbiddenOath = false;
        }

        public override void PostUpdate()
        {
			int playerLifeThreshold = player.statLifeMax2 / 5;
			dominionCooldown--;
			if (forbiddenOath && player.statLife <= playerLifeThreshold)
			{
				OathCooldown--;
				Main.NewText(playerLifeThreshold);
			}
			if (OathCooldown <= 0)
			{
				player.HealEffect(10);
				player.statLife += 10;
				OathCooldown = 480;
			}
			noDeathTimer--;
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
			ZoneCanyon = (EmperialWorld.CanyonTiles > 100);
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
		public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Dominion)
            {
                if (Emperia.AccessoryKey.JustPressed)
                {
					if (dominionCooldown > 0)
					{
						Main.NewText("This ability is on cooldown! Usable again in " + (dominionCooldown / 60) + " seconds.");
					}
					else
					{
						noDeathTimer = 360;
						dominionCooldown = 3600;
					}
				}
			}
		}
		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
			if (noDeathTimer > 0)
			{
				return false;
			}
			return true;
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
			if (crit == true && incCrit2 == true)
			{	
				damage = 2;
			}
			else if (crit == true && incCrit == true)
			{
				
				damage += damage / 2;
			}				
			if (slightKnockback)
			{
				knockback *= 1.1f;
			}
		}
		public override void OnHitNPC (Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (mystiqueSetBonus)
			{
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, mod.ProjectileType("HealingProjectile"), 14, 0, player.whoAmI, ai1: 36);
			}
			if (SunSeal && Main.dayTime)
			{
				Vector2 placePosition = player.Center + new Vector2(0, -600);
				Vector2 direction = target.Center - placePosition;
				direction.Normalize();
				Projectile.NewProjectile(player.Center.X, player.Center.Y - 600, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("SolarBlast"), 50, 1, Main.myPlayer, 0, 0);
			}
		}
		public override void OnHitNPCWithProj (Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (mystiqueSetBonus && projectile.magic)
			{
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, mod.ProjectileType("HealingProjectile"), 14, 0, player.whoAmI, ai1: 36);
			}
			if (mystiqueSetBonus && projectile.melee)
			{
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, mod.ProjectileType("HealingProjectile"), 14, 0, player.whoAmI, ai1: 36);
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