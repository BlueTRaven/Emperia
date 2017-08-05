using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Pandora
{
    public class Xalaneth : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xalaneth");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 90000;
            npc.damage = 200;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 396;
            npc.height = 306;
            npc.alpha = 0;
            npc.value = Item.buyPrice(0, 20, 0, 0);
            npc.npcSlots = 1f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }
    }
}
