using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Weapons.Relics.EmpArc
{
    public class EmpArc1 : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empyrean Arc");
			Tooltip.SetDefault("A gift from the heavens\nThis bow is forged of the sky");
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine line = new TooltipLine(mod, "EmpArc1", "Relic");
			line.overrideColor = new Color(212, 175, 55);
			tooltips.Add(line);
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
				}
			}
		}
        public override void SetDefaults()
        {
            item.damage = 14;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 27;
            item.useAnimation = 3;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = ItemID.WoodenArrow;
            item.knockBack = 1;
            item.value = 1000;
            item.rare = 1;
            item.autoReuse = true;
            item.shootSpeed = 10f;

        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}
    }
}