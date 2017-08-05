using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace Emperia
{
	public class FishPlayer : ModPlayer
	{
		public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
		{
			if(player.ZoneBeach)
			{
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("ShellHamaxe");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("ShellPick");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("ShellBow");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("SeashellBlade");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("SeashellTome");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("SeashellLeggings");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("SeashellChestplate");
				}
				if(Main.rand.Next(20) == 0)
				{
					caughtType = mod.ItemType("SeashellVisor");
				}
				
			}
		}	
	}
}