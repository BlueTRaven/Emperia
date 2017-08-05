using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Emperia.Buffs
{
    public class Slag_Skin : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Slag Skin");
			Description.SetDefault("+25% movement speed and damage resistance");
            Main.buffNoSave[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.25f;
			player.moveSpeed += 0.25f;
        }
    }
}
