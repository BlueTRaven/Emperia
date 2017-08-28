using Terraria.ModLoader;

namespace Emperia.Items
{
	public class Rocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boomer I");
		}
		public override void SetDefaults()
		{
			item.damage = 12;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 6;
            item.value = 100;
            item.rare = 2;
            item.shoot = mod.ProjectileType("RocketI");
            item.shootSpeed = 0.6f;
		}
	}
}