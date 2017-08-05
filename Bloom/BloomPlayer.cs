using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Emperia.Bloom
{
	public class BloomPlayer : ModPlayer
	{
		public override void UpdateDead()
		{

		}

		public override void PostUpdate()
		{
			bool First = true;
			const int xof = 600;
			const int yof = 600;

			BloomPlayer modPlayer = player.GetModPlayer<BloomPlayer>(mod);
			if (!BloomWorld.TheBloom)
			{
				BloomWorld.bloomPoints1 = 0;
			}
			if (BloomWorld.TheBloom)
			{
				
				
			}

			BloomWorld.bloomPoints = BloomWorld.bloomPoints1;


			

			if (BloomWorld.bloomPoints1 >= 100)
			{
				Main.NewText("The Bloom's floral monsters have momentarily been vanquished", 39, 86, 134);
				BloomWorld.bloomPoints1 = 0;
				BloomWorld.TheBloom = false;
			}
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			return true;
		}

	}
}
