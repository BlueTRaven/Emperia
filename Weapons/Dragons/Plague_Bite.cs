using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Dragons
{
	public class Plauge_Bite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plague Bite");
		}
		public override void SetDefaults()
		{
			item.damage = 103;
			item.thrown = true;
			item.width = 58;
			item.height = 36;
			item.useAnimation = 12;
			item.useTime = 12;
			item.useStyle = 1;
			item.crit = 11;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 5f;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PlagueBite");
			item.shootSpeed = 18f;
		}
	}
}
