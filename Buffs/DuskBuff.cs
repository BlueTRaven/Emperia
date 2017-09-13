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
    public class DuskBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("IndigoInfirmary");
			Description.SetDefault("Melee damage increased by 12%\n Increased Armor penetration by 4\n Increased Life regen");
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			MyPlayer p = player.GetModPlayer<MyPlayer>(mod);
			
			player.meleeDamage *= 1.1f;
			player.armorPenetration += 4;
			player.lifeRegen += 5;
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 20, 20, 21);
			}
        }
    }
}
