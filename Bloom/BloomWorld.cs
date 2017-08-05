using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Emperia.Bloom
{
	public class BloomWorld : ModWorld
	{
		private const int savevers = 0;
		public static int bloomPoints = 0;
		public static int bloomPoints1;
		public static bool TheBloom;
		
		public override void Initialize()
		{
			bloomPoints1=0;
			TheBloom=false;
		}
		public override TagCompound Save()
		{
			TagCompound save_data=new TagCompound();
			save_data.Add("TheBloom", TheBloom);
			save_data.Add("bloomPoints1", bloomPoints1);
			return save_data;
		}
		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(TheBloom);
			writer.Write(bloomPoints1);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags=reader.ReadByte();
			flags[0]=TheBloom;
			bloomPoints1=reader.ReadInt32();
		}
		public override void Load(TagCompound tag)
		{
			TheBloom=tag.GetBool("TheBloom");
			bloomPoints1=tag.GetInt("bloomPoints1");
		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				TheBloom = flags[0];
				bloomPoints1 = reader.ReadInt32();
			}
		}
	}
}
