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
    public class MellowBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Lime Legerity");
			Description.SetDefault("33% Increased movement speed and melee speed\n Increased jump height / flight time");
            Main.buffNoSave[Type] = true;
            //Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			MyPlayer p = player.GetModPlayer<MyPlayer>(mod);
			
			player.moveSpeed += 33f;
			player.meleeSpeed += 33f;
			//player.jumpHeight *= 1.1f;
			player.wingTime *= 1.1f;
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 20, 20, 75);
			}
        }
    }
}
