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
			Description.SetDefault("Defense increased by 10\n 6% increased crit chance\n Crits deal double damage");
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			MyPlayer p = player.GetModPlayer<MyPlayer>(mod);
			p.doubleCrit = true;
			player.statDefense += 10;
			player.meleeCrit += 6;
			player.rangedCrit += 6;
			player.magicCrit += 6;
			player.thrownCrit += 6;
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 20, 20, 158);
			}
        }
    }
}
