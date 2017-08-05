using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Tiles
{
	public class AbyssalStone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileValue[Type] = 805;
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("AbyssalStone");
			AddMapEntry(new Color(73, 64, 64));
			mineResist = 5f;
			minPick = 209;
			soundType = 21;
			Main.tileSpelunker[Type] = true;
		}
		
		public override bool CanExplode(int i, int j)
		{
			return true;
		}


	}
}