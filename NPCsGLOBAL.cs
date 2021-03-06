﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia;
namespace Emperia
{
    public class NPCsGlobal: GlobalNPC
    {
		public bool customdebuff = false;
		public bool customdebuff2 = false;
		public bool duskDebuff = false;
		public bool ConsumeDark = false;
		public bool Plague = false;
		public bool Immolate = false;
		public bool StormCharge = false;
		public bool mellowed = false;
		public int HitTimer = 0;
        public override void ResetEffects(NPC npc)
        {
            customdebuff = false;
			customdebuff2 = false;
			ConsumeDark = false;
			Plague = false;
			mellowed = false;
			Immolate = false;
			StormCharge = false;
        } 
		
		public override bool InstancePerEntity {get{return true;}}
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Dryad)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.ChestnutSeeds>());
				nextSlot++;

			}
		}
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (customdebuff2)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 50;      //this make so the npc lose life, the highter is the value the faster the npc lose life
                if (damage < 2)
                {
                    damage = 6;  // this is the damage dealt when the npc lose health
                }
            }
			if (customdebuff)  //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            {
                npc.lifeRegen -= 50;      //this make so the npc lose life, the highter is the value the faster the npc lose life

                    damage = 1;  // this is the damage dealt when the npc lose health
      
            }
			if (duskDebuff)
			{
				 npc.lifeRegen -= 50;  
				 damage = MyPlayer.playerHealthFrac;
			}
			if (ConsumeDark)
            {
                npc.lifeRegen -= 25;
				if (damage < 2)
                {
                    damage = 5;
				}
				
				if (npc.boss == false)
				{
					npc.velocity *= 0.75f;
				}
            }
			
			if (Plague)
            {
                npc.lifeRegen -= 25;
				if (damage < 2)
                {
                    damage = 5;
				}
            }
			
			if (StormCharge)
            {
				if (npc.velocity.X != 0 || npc.velocity.Y != 0)
				{
					npc.lifeRegen -= 50;
					if (damage < 2)
					{
						damage = 10;
					}
				}
				
				else
				{
					npc.lifeRegen -= 25;
					if (damage < 2)
					{
						damage = 5;
					}
				}
            }
			
			if (Immolate)
            {
                npc.lifeRegen -= 25;
				if (damage < 2)
                {
                    damage = 5;
				}
				npc.defense = (int)(npc.defense * 0.75);
            }
        }
		public override void PostAI(NPC npc)
		{
			
			if (mellowed)
			{
				HitTimer++;
				
				if (HitTimer >= 300)
				{
					int jim = npc.lifeMax / 4;
					int damage = 0;
					if (jim >= 150)
					{
						damage = 150;
					}
					else
					{
						damage = jim;
						
					}
					Main.NewText(damage + " verifying", 39, 86, 134, true);
					//npc.HitEffect(damage);
					npc.life -= damage;
					HitTimer = 0;
				}
			}
			
			
		}
		public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
		{
			HitTimer = 0;
		}
    }
}