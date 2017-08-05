using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Emperia;

namespace Emperia.Buffs
{
    public class OnPinked : ModBuff
    {
        public override void SetDefaults()
        {
           DisplayName.SetDefault("pink");
			Description.SetDefault("Losing life");         
            Main.debuff[Type] = true;   //Tells the game if this is a buf or not.
            Main.pvpBuff[Type] = true;  //Tells the game if pvp buff or not. 
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<NPCsGlobal>(mod).customdebuff = true;    //this tells the game to use the public bool customdebuff from NPCsINFO.cs
            int num1 = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PinkFlame);    //this is the dust/flame effect that will apear on npc or player if is hit by this buff   
            Main.dust[num1].scale = 2.9f; //the dust scale , the higher is the value the large is the dust
            Main.dust[num1].velocity *= 3f; //the dust velocity
            Main.dust[num1].noGravity = true;
        }
        

    }
}
