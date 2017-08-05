using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class AgonyMask : ModNPC
    {
		
        private Vector2 targetPosition;
        private float rotate { get { return npc.ai[1]; } set { npc.ai[1] = value; } }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Agony");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 3500;
            npc.damage = 23;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 102;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = false;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }

        public override void AI()
        {
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Vector2 rotatePosition = Vector2.Transform(new Vector2(-1 * 200, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(rotate))) + player.Center;
            npc.Center = rotatePosition;

            rotate += 3f;
			
        }
    }
}

