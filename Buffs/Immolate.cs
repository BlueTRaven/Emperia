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
    public class Immolate : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Immolate");        
            Main.debuff[Type] = true;  
            Main.pvpBuff[Type] = true;  
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<NPCsGlobal>(mod).Immolate = true;    
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 158);    
            Main.dust[num1].scale = 2.5f; 
            Main.dust[num1].velocity *= 3f; 
            Main.dust[num1].noGravity = true;
				
        }
    }
}
