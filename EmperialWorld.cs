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
        public static int canyonTiles = 0;

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
            canyonTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            twilightTiles = tileCounts[mod.TileType("TwilightGrass")];
            canyonTiles = tileCounts[mod.TileType("CanyonRock")];
        }

        private static bool CanGenerateCanyon(int x, int y)
        {
            if (x > ((Main.maxTilesX / 2) - 200) && x < ((Main.maxTilesX / 2) + 200))
            {
                return false;
            }
            if (x < 500 || x > Main.maxTilesX - 500)
            {
                return false;
            }
            for (int i = x - 32; i < x + 32; i++)
            {
                for (int j = y - 32; j < y + 32; j++)
                {
                    int[] TileArray = { TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick, TileID.Cloud, TileID.RainCloud, 147, 60, 40, 199, 23, 25, 203 };
                    for (int ohgodilovememes = 0; ohgodilovememes < TileArray.Length - 1; ohgodilovememes++)
                    {
                        if (Main.tile[i, j].type == (ushort)TileArray[ohgodilovememes])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceCanyon(int x, int y)
        {
            int canyonRockTile = mod.TileType<Tiles.CanyonRock>();
            WorldMethods.TileRunner(x, y, (double)200, 1, mod.TileType("CanyonRock"), false, 0f, 0f, true, true); //improve basic shape later

            WorldMethods.RoundHole(x, y - 20, 60, 30, 10, true);

            for (int i = 0; i < 3; i++)
            {
                int Ex = Main.rand.Next(-35, 35);
                int height = Main.rand.Next(30, 80);
                int BaseWidth = Main.rand.Next(60, 80);
                int Sway = 0;
                for (int j = 15; j < height; j++)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            Sway -= 1;
                        }
                        else
                        {
                            Sway += 1;
                        }
                    }
                    WorldMethods.TileRunner((x + Ex) + Sway, (y + 10) + j, (double)25 + (BaseWidth / Math.Sqrt(j)), 1, mod.TileType("CanyonRock"), false, 0f, 0f, true, true); //improve basic shape later
                    WorldGen.digTunnel((x + Ex) + Sway, (y + 10) + j, 0, 0, 3, (int)(BaseWidth / Math.Sqrt(j)), false);
                    /*for (int h = -10; h < 10; h++)
					{
						WorldGen.KillWall((x + Ex) + Sway + h, (y + 10) + j);
								
					}*/
                }
            }
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            tasks.Insert(genIndex + 1, new PassLegacy("Twilight Forest", delegate (GenerationProgress progress)
            {

                progress.Message = "Twilight Forest";
                int XTILE = WorldGen.genRand.Next(125, Main.maxTilesX - 350);
                int yAxis = Main.maxTilesY / 13;
                int num = Main.rand.Next(20, 30);
                for (int g = 0; g <= num; g++)
                {
                    WorldMethods.Island(XTILE + Main.rand.Next(-350, 350), yAxis + Main.rand.Next(-20, 55), Main.rand.Next(26, 35), (float)(Main.rand.Next(11, 25) / 10), (ushort)mod.TileType("TwilightGrass"));
                }

                WorldMethods.Island(XTILE, yAxis, Main.rand.Next(60, 75), (float)(Main.rand.Next(6, 17) / 10), (ushort)mod.TileType("TwilightGrass"));
                for (int trees = 0; trees < 5000; trees++)
                {
                    int E = XTILE + Main.rand.Next(-350, 350);
                    int F = yAxis + Main.rand.Next(-20, 55);
                    Tile tile = Framing.GetTileSafely(E, F);
                    if (tile.type == mod.TileType("TwilightGrass"))
                    {
                        WorldGen.GrowTree(E, F);
                    }
                }

                int x;
                int y;
                int maxTries = 20000;
                int tries = 0;
                int successes = 0;


                while (tries < maxTries && successes < 10)
                {
                    x = XTILE + Main.rand.Next(-350, 350);
                    y = yAxis + Main.rand.Next(-20, 55);
                    if (WorldGen.PlaceChest(x, y, (ushort)mod.TileType<Tiles.TwiChest>(), false, 0) != -1)
                    {
                        successes++;
                    }
                    tries++;
                }
            }));

            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (ShiniesIndex == -1)
            {
                // Shinies pass removed by some other mod.
                return;
            }

            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Canyon", delegate (GenerationProgress progress)
            {
                progress.Message = "Carving canyons";
                int X = 1;
                int Y = 1;
                float widthScale = (Main.maxTilesX / 4200f);
                int numberToGenerate = 2;
                for (int k = 0; k < numberToGenerate; k++)
                {
                    bool placement = false;
                    bool placed = false;
                    while (!placed)
                    {
                        bool success = false;
                        int attempts = 0;
                        while (!success)
                        {
                            attempts++;
                            if (attempts > 1000)
                            {
                                success = true;
                                continue;
                            }
                            int i = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                            if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50)
                            {
                                int j = 0;
                                while (!Main.tile[i, j].active() && (double)j < Main.worldSurface)
                                {
                                    j++;
                                }
                                if (Main.tile[i, j].type == 53 || Main.tile[i, j].type == 0)
                                {
                                    j--;
                                    if (j > 150)
                                    {
                                        placement = CanGenerateCanyon(i, j);
                                        if (placement)
                                        {
                                            X = i;
                                            //	progress.Message = "BAZINGA";
                                            Y = j;
                                            PlaceCanyon(i, j);
                                            success = true;
                                            placed = true;
                                            continue;
                                        }
                                    }
                                }
                            }
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