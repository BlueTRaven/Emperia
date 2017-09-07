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
    public class VermillionBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Vermillion Valor");
			Description.SetDefault("Defense increased by 4\n 4% increased crit chance\n Crits deal 50% increased damage");
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			MyPlayer p = player.GetModPlayer<MyPlayer>(mod);
			p.incCrit2 = true;
			player.statDefense += 8;
			player.meleeCrit += 4;
			player.rangedCrit += 4;
			player.magicCrit += 4;
			player.thrownCrit += 4;
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 20, 20, 158);
			}
        }
    }
}
