using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class ShardOfPossesion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shard of Possesion");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 4;
		}
	}
}