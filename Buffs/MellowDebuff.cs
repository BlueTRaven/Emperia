using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia;

namespace Emperia.Buffs
{
    public class MellowDebuff : ModBuff
    {
        public override void SetDefaults()
        {
           DisplayName.SetDefault("Lime Liability");
			Description.SetDefault("Decreased Defense based on speed");         
            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
             npc.GetGlobalNPC<NPCsGlobal>(mod).mellowed = true;
        }
        

    }
}
