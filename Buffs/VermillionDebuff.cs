using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia;

namespace Emperia.Buffs
{
    public class VermillionDebuff : ModBuff
    {
        public override void SetDefaults()
        {
           DisplayName.SetDefault("Vermillion Venom");
			Description.SetDefault("Decreased Damage");         
            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.damage = (int)(npc.damage * 0.8f);
        }
        

    }
}
