using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Emperia.WorldStuff;

namespace Emperia
{
    public class EmperialWorld : ModWorld
    {
	//6
	//13
	/*
	This code is full of cancer because i went tile by tile for most of it, and so its bad.
	if you read it you may die
	That was a warning
	so dont sue me
	the formatting is bad too
	pls be careful
	*/
		public static bool downedMushor = false;
		public static int twilightTiles = 0;
		public override void Initialize()
		{
			downedMushor = false;

		}
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedMushor;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedMushor = flags[0];
		}
		public override void ResetNearbyTileEffects()
		{
			MyPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>(mod);
			twilightTiles = 0;
		}
		public override void TileCountsAvailable(int[] tileCounts)
		{
			twilightTiles = tileCounts[mod.TileType("TwilightGrass")];
		}
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
			tasks.Insert(genIndex + 1, new PassLegacy("Twilight Forest", delegate (GenerationProgress progress)
			{
				int x2;
				int y2;
				for (int x1 = 0; x1 < 20; ++x1)
				{
					x2 = WorldGen.genRand.Next(1000, Main.maxTilesX - 1000);
					y2 = Main.maxTilesY / 10;
					WorldGen.TileRunner(x2, y2, (double)5, 1, mod.TileType("Aetherium"), true, 0f, 0f, true, true);
				}
				int x = WorldGen.genRand.Next(300, Main.maxTilesX - 1000);
                int y = Main.maxTilesY / 9;
			    for (int x3 = x; x3 < x + 350; x3++)
			    {
				    WorldGen.TileRunner(x3, y, (double)20, 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				    if (Main.rand.Next(25) == 0)
				    {
					    WorldGen.TileRunner(x3, y - 5, (double)20, 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				    }
					if (Main.rand.Next(5) == 0)
				    {
					    WorldGen.TileRunner(x3, y + 7, (double)20, 1, mod.TileType("TwilightGrass"), true, 0f, 0f, true, true);
				    }
				}
			
				for (int x4 = x - 2; x4 < x + 352; x4++)
				{
					for (int y3 = y + 12; y3 > y - 14; y3--)
					{
						if (y3 == y - 13)
						{
							if (Main.rand.Next(2) == 0)
							{
							WorldGen.KillWall(x4, y3);
							WorldGen.PlaceWall(x4, y3, 65);
							}
						}
						else if (y3 == y - 14)
						{
							if (Main.rand.Next(2) == 0 && Main.tile[x4, y3 + 1].wall != 0)
							{
								WorldGen.KillWall(x4, y3);
								WorldGen.PlaceWall(x4, y3, 65);
							}
						}
						else
						{
							WorldGen.KillWall(x4, y3);
							WorldGen.PlaceWall(x4, y3, 65);
						}
						if (Main.tile[x4, y3 - 1].type != mod.TileType("TwilightGrass") && Main.rand.Next(7) == 0)
						{
							WorldGen.PlaceObject(x4,y3-1,mod.TileType("TwilightTreeSap"));
							WorldGen.GrowTree(x4, y3 - 1);
						}
			
						
						
					}
				}
		    }));
		}

        public override void PostWorldGen()
        {   //mostly copied from examplemod
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36) //2 * 36 == locked dungeon chest
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {   //first empty inventory slot
                            if (Main.rand.Next(4) == 0)
                                chest.item[inventoryIndex].SetDefaults(mod.ItemType<Items.RottenMushroom>());
                            break;
                        }
                    }
                }
            }
        }
    }

}	