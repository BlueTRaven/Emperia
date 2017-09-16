using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class ShardOfAnimation : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shard of Animation");
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