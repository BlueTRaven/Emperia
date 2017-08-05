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
    public class BerylBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Beryl Brutalism");
			Description.SetDefault("30% increased melee Speed");
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeSpeed += 0.3f;
        }
    }
}
