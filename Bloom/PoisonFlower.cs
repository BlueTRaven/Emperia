using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Emperia.Bosses.Mushor;

namespace Emperia.Bloom
{
    public class PoisonFlower : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wilting Orchid");
			Tooltip.SetDefault("To be used in the Jungle");
		}
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            item.rare = 5;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            //return NPC.downedBoss3;
            return player.ZoneJungle;
        }

        public override bool UseItem(Player player)
        {
            Mod mod = ModLoader.GetMod("Emperia");
			if (BloomWorld.TheBloom)
				return false;
			BloomWorld.TheBloom = true;
			return true;
        }
    }
}
