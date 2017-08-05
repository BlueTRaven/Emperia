using Terraria.ModLoader;

namespace Emperia.Items
{
	public class TFWood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = false;			
			item.rare = 4;
			item.createTile = mod.TileType("TFWood");
			item.placeStyle = 0;
		}
	}
}