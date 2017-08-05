using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class NursePuppet : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nurse Puppet");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 3;
			aiType = 31;
            npc.lifeMax = 5000;
            npc.damage = 150;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 24;
            npc.height = 38;
            npc.alpha = 0;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.lavaImmune = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }
    }
}
