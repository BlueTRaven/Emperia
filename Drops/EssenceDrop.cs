using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Drops
{
	public class EssenceDrop : GlobalNPC
	{
		public int UpdatePoints(int points)
		{
			return (points+=5);
		}
		 public override void NPCLoot(NPC npc)  
        {
			//ZoneUnderworldHeight
			Player player = Main.LocalPlayer;
			 if(player.ZoneBeach)
                {
                   if (Main.rand.Next(4) == 0) {
                     // Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OceanEssence"), 1); 
				   }
				}
				if(player.ZoneUnderworldHeight)
                {
                   if (Main.rand.Next(4) == 0) {
                      //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HellEssence"), 1); 
				   }
				}
				if(npc.type == 257 || npc.type == 258 || npc.type == 259 || npc.type == 260 || npc.type == 261)
				{
					 if (Main.rand.Next(4) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Fungoo"), Main.rand.Next(1, 5)); 
					 }
				}
				if(npc.type == 231 || npc.type == 233 || npc.type == 236)
				{
				
				}
				if(npc.type >= 381 && npc.type <= 392)
				{
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CosmicObliterator"), 1);
					}
				}
				if(npc.type == 84 && !Main.expertMode)
				{
					 if (Main.rand.Next(10) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardOfAnimation")); 
					 }
				}
				if(npc.type == 84 && Main.expertMode)
				{
					 if (Main.rand.Next(8) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardOfAnimation")); 
					 }
				}
				if(npc.type == 140 && !Main.expertMode)
				{
					 if (Main.rand.Next(100) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardOfPossesion")); 
					 }
				}
				if(npc.type == 84 && Main.expertMode)
				{
					 if (Main.rand.Next(65) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardOfPossesion")); 
					 }
				}
				if(!Main.expertMode && npc.type == 53 || npc.type == 536 || npc.type == 489 || npc.type == 490 || npc.type == 47 || npc.type == 464 || npc.type == 57 || npc.type == 465 || npc.type == 189 || npc.type == 470 || npc.type == 109)
				{
					 if (Main.rand.Next(100) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForbiddenOath")); 
					 }
				}
				if(Main.expertMode && npc.type == 53 || npc.type == 536 || npc.type == 489 || npc.type == 490 || npc.type == 47 || npc.type == 464 || npc.type == 57 || npc.type == 465 || npc.type == 189 || npc.type == 470 || npc.type == 109)
				{
					 if (Main.rand.Next(65) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ForbiddenOath")); 
					 }
				}
				if (npc.type == mod.NPCType("Dwindler") && Main.rand.Next(100) == 0 && !Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MaskoftheDecrepit")); 
				}
				if (npc.type == mod.NPCType("Dwindler") && Main.rand.Next(50) == 0 && Main.expertMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MaskoftheDecrepit")); 
				}

        }
	}
}