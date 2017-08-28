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
    public class ChestnutBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Sunsoaked");
			Description.SetDefault("Increases damage reduction, regeneration, and movement speed");
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.endurance += 0.05f;
			player.moveSpeed += 0.10f;
			 player.lifeRegen += 3;
        }
    }
}
