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
    public class Storm_Charged : ModBuff
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
            npc.GetGlobalNPC<NPCsGlobal>(mod).StormCharge = true;    
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 226);    
            Main.dust[num1].scale = 2f; 
            Main.dust[num1].velocity *= 3f; 
            Main.dust[num1].noGravity = true;
				
        }
    }
}
