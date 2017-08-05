using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Materials
{
	public class GraniteBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Bar");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}

	public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 1);
			recipe.AddIngredient(ItemID.Granite, 10);
			recipe.AddTile(TileID.Furnaces);  
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 1);
			recipe.AddIngredient(ItemID.Granite, 10);
			recipe.AddTile(TileID.Furnaces);  
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}