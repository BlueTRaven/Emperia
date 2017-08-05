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
    public class Magmad : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("magma");
			Description.SetDefault("Losing life");        
            Main.debuff[Type] = true;  
            Main.pvpBuff[Type] = true;  
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<NPCsGlobal>(mod).customdebuff2 = true;    
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, 258);    
            Main.dust[num1].scale = 2.9f; 
            Main.dust[num1].velocity *= 3f; 
            Main.dust[num1].noGravity = true;
			float maxHomeDistance = 400f;
			int buffTime = npc.buffTime[buffIndex];
			 for (int npcFinder = 0; npcFinder < 200; ++npcFinder)
                {
                    
                        float num12 = Main.npc[npcFinder].position.X + (float)(Main.npc[npcFinder].width / 2);
                        float num22 = Main.npc[npcFinder].position.Y + (float)(Main.npc[npcFinder].height / 2);
                        float num32 = Math.Abs(npc.position.X + (float)(npc.width / 2) - num12) + Math.Abs(npc.position.Y + (float)(npc.height / 2) - num22);
                        if (num32 < maxHomeDistance)
                        {
                            maxHomeDistance = num32;

                            Main.npc[npcFinder].AddBuff(mod.BuffType("Magmad"), buffTime);
                        }
                   
                }
				
        }
         public virtual bool ReApply(int type, NPC npc, int time, int buffIndex)
        {
			return false;
		}
    }
}
