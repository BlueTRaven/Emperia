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
				if(npc.type == 84)
				{
					 if (Main.rand.Next(4) == 0) 
					 {
						 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FaerieSpark"), Main.rand.Next(3, 7)); 
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