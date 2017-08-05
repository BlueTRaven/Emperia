using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class Fungoo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungoo");
			Tooltip.SetDefault("You don't want to know what this is");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}
	}
}