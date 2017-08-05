using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Emperia;

namespace Emperia.Buffs
{
    public class speedBoost : ModBuff
    {
        public override void SetDefaults()
        {
           DisplayName.SetDefault("Storm Charged");
			Description.SetDefault("Losing life");        
            Main.debuff[Type] = true;  
            Main.pvpBuff[Type] = true;  
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity.X *= 2;
				
        }
    }
}
