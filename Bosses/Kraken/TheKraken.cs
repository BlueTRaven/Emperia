using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Kraken
{
    public class TheKraken : ModNPC
    {
		int counter = 60;
		float angleShot;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Kraken");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 6500;
            npc.damage = 23;
            npc.defense = 10;
            npc.knockBackResist = 0f;
            npc.width = 108;
            npc.height = 272;
            npc.alpha = 0;
			npc.boss = true;
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
		public override void AI()
        {
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
            if (player.dead)
            {
                npc.TargetClosest(false);
				npc.velocity.Y = 20f;
            }
			if (npc.ai[2] == 0)
			{
				npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f;
			}
			
		}
		private void WatchPlayer()
		{
			Vector2 look = Main.player[npc.target].Center - npc.Center;
			LookAt(look);
		}
		private void LookAt(Vector2 look)
		{
			float angle = 0.5f * (float)Math.PI;
			if (look.X != 0f)
			{
				angle = (float)Math.Atan(look.Y / look.X);
			}
			else if (look.Y < 0f)
			{
				angle += (float)Math.PI;
			}
			if (look.X < 0f)
			{
				angle += (float)Math.PI;
			}
			npc.rotation = angle += 90f;
		}
    }
}
