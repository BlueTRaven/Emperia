using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Emperia.Weapons.Mushor
{
	public class MushorBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("Mushor");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			if (Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("MushorMask"));
			}
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Shroomer"));
			}
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Mushdisc"), Main.rand.Next(150, 250));
			}
			if (Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Shroomflask"));
			}
			player.QuickSpawnItem(mod.ItemType("MycelialShield"));
			
		}
	}
}