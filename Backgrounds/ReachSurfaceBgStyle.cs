using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Emperia.Backgrounds
{
	public class CanyonSurfaceBgStyle : ModSurfaceBgStyle
	{
        public override bool ChooseBgStyle()
        {
            return !Main.gameMenu && (Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(mod).ZoneCanyon);
        }

        // Use this to keep far Backgrounds like the mountains.
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseFarTexture()
		{
			return mod.GetBackgroundSlot("Backgrounds/CanyonBiomeSurfaceFar");
		}

		public override int ChooseMiddleTexture()
		{
				return mod.GetBackgroundSlot("Backgrounds/CanyonBiomeSurfaceMid");
		}

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
			return mod.GetBackgroundSlot("Backgrounds/CanyonBiomeSurfaceMid");
		}
	}
}