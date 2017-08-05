using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Town
{
	
	public class Weaponsmith : ModNPC
	{
		public override string Texture
		{
			get
			{
				return "Emperia/Town/Weaponsmith";
			}
		}


		public override bool Autoload(ref string name)
		{
			name = "Weaponsmith";
			return mod.Properties.Autoload;
		}

		public bool QuestActive = false;
		public int currentQuest = 0;
		public bool[] possibleQuests = new bool[15];public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Weaponsmith");
			Main.npcFrameCount[npc.type] = 25;
		}
		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			NPCID.Sets.ExtraFramesCount[npc.type] = 25;
			NPCID.Sets.AttackFrameCount[npc.type] = 2;
			NPCID.Sets.DangerDetectRange[npc.type] = 500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			animationType = NPCID.Dryad;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
            //if (NPC.downedBoss2)
           // {
            //    return true;
            //}
            for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == ItemID.Shuriken)
						{
							return true;
						}
					}
				}
			}
			return true;
		}


		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Smith";
				case 1:
					return "Sigmund";
				case 2:
					return "Brett";
                case 3:
                    return "Frank";
                case 4:
                    return "Edmund";
                default:
                    return "Smith";
			}
		}

		public override string GetChat()
		{
			
			switch (Main.rand.Next(3))
			{
				case 0:
					return "Hello fine Sir! Would you like some fine weapons?";
				case 1:
					return "I've heard of this one rare monster. Oh, i want it's head!";
				default:
					return "Oh, the tales they tell of my fine steel.";
			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{

			button = "Quest";

			
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				if (!QuestActive)
				{
					GetQuests();
					currentQuest = ChooseQuest();
					if (currentQuest == 1)
					{
					Main.npcChatText = "I've heard that there is a demon eye that is very scary. Kill it and bring me a lens";
					}
					if (currentQuest == 2)
					{
					Main.npcChatText = "I've heard that there is a poop that is very scary. Kill it and bring me a green";
					}
					if (currentQuest == 3)
					{
					Main.npcChatText = "I've heard that there is a zombie that is very scary. Kill it and bring me an arm";
					}
					
					QuestActive = true;
				}
				else
				{
					for (int k = 0; k < Main.player.Length; k++)
					{
						Player player = Main.player[k];
						if (player.active)
						{
							for (int j = 0; j < player.inventory.Length; j++)
							{
								if (currentQuest == 1)
								{
								if (player.inventory[j].type == ItemID.Lens)
								{
									Main.npcChatText = "Thank you! Here, have a reward!";
									Item a = new Item();
									a.SetDefaults(0);
									player.inventory[j] = a;
									Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Shroomflask"));
									QuestActive = false;
								}
								}
							}
						}
					}
					if (QuestActive)
					{
						Main.npcChatText = "Back so soon? I'm sorry, i can't give you another quest until you've completed the last one.";
					}
					
				}
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            shop.item[nextSlot].SetDefaults(3380); //sturdy fossil
			nextSlot++;
			if (NPC.downedMoonlord)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("DeepspaceSigil"));
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 14;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 13;
			randExtraCooldown = 1;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = 3379;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 15f;
			randomOffset = 2f;
		}
		public void GetQuests ()
		{
			possibleQuests[1] = true;
			possibleQuests[2] = true;
			possibleQuests[3] = true;
			if (NPC.downedBoss1)
			{
				possibleQuests[4] = true;
			}
			if (NPC.downedBoss2)
			{
				possibleQuests[5] = true;
			}
			if (NPC.downedQueenBee)
			{	
				possibleQuests[6] = true;
			}
			if (Main.hardMode)
			{	
				possibleQuests[7] = true;
				possibleQuests[8] = true;
				possibleQuests[9] = true;
				possibleQuests[10] = true;
			}
			if (NPC.downedMechBoss1)
			{	
				possibleQuests[11] = true;
			}
			
		}
		public int ChooseQuest ()
		{
			bool chosenQuest = false;
			while (!chosenQuest)
			{
				switch (Main.rand.Next(3))
				{
					case 0:
						if (possibleQuests[1])
						{
							return 1;
							chosenQuest = true;
						}
						else
							break;
					case 1:
						if (possibleQuests[2])
						{
							return 2;
							chosenQuest = true;
						}
						else
							break;
					case 2:
						if (possibleQuests[3])
						{
							return 3;
							chosenQuest = true;
						}
						else
							break;
					default:
						if (possibleQuests[4])
						{
							return 4;
							chosenQuest = true;
						}
						else
							break;
						
					
					
				}
				
			}
			return 1;
		}
	}
}