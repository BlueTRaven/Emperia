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
            npc.width = 40;
            npc.height = 40;
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
            int num250 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X, npc.position.Y - npc.velocity.Y), npc.width, npc.height, 5, (float)(npc.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
			Main.dust[num250].noGravity = true;
			Main.dust[num250].velocity *= 0f;
			if (npc.position.Y > Main.player[npc.target].position.Y)
			{
				if (npc.velocity.Y > -1f)
					npc.velocity.Y = npc.velocity.X - 0.75f;
				if (npc.velocity.Y > -5f && npc.velocity.Y < 0f)
				{
					npc.velocity.Y *= 1.03f;
				}
			}
			if (npc.position.Y < Main.player[npc.target].position.Y)
			{
				if (npc.velocity.Y < 1f)
					npc.velocity.Y = npc.velocity.Y + 0.75f;
				if (npc.velocity.Y < 5f && npc.velocity.Y > 0f)
				{
					npc.velocity.Y *= 1.03f;
				}
			}
			if (npc.position.X > Main.player[npc.target].position.X)
			{
				if (npc.velocity.X > -1f)
					npc.velocity.X = npc.velocity.X - 0.75f;
				if (npc.velocity.X > -5f && npc.velocity.X < 0f)
				{
					npc.velocity.X *= 1.03f;
				}
			}
			if (npc.position.X < Main.player[npc.target].position.X)
			{
				if (npc.velocity.X < 1f)
					npc.velocity.X = npc.velocity.X + 0.75f;
				if (npc.velocity.X < 5f && npc.velocity.X > 0f)
				{
					npc.velocity.X *= 1.03f;
				}
			}
			
        }
    }
}

