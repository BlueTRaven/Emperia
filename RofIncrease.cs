using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia
{
	public class RofIncrease : GlobalItem
	{
		public virtual void SetDefaults(Item item)
		{
			Player player = Main.LocalPlayer;
			Mod mod = ModLoader.GetMod("Emperia");
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (item.ranged && modPlayer.rofIncrease > 0)
			{
				item.useTime = 3;
				item.useAnimation = 3;
			}
		}
	}
}