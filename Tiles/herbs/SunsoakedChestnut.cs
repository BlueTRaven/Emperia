using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;


namespace Emperia.Tiles.herbs
{
	public class SunsoakedChestnut : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileNoFail[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);

			TileObjectData.newTile.AnchorValidTiles = new int[]
			{
				mod.TileType("TwilightGrass")
			};

			TileObjectData.newTile.AnchorAlternateTiles = new int[]
			{
				78, //ClayPot
				TileID.PlanterBox
			};

			TileObjectData.addTile(Type);
		}

		public override bool Drop(int i, int j)
		{
			int stage = Main.tile[i, j].frameX / 18;
			if (stage == 2)
			{
				//Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Items.ChestnutSeeds>(), Main.rand.Next(1, 3));
				Item.NewItem(i * 16, j * 16, 0, 0, mod.ItemType<Items.SunsoakedChestnut>());
			}
			return false;
		}

		public override void RandomUpdate(int i, int j)
		{
			if (Main.tile[i, j].frameX == 0)
			{
				Main.tile[i, j].frameX += 16;
			}
			else if (Main.tile[i, j].frameX == 16)
			{
				Main.tile[i, j].frameX += 16;
			}
		}
	}
}
