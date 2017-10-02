using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Inquisitor
{
    public class SorrowMask : ModNPC
    {
        private int counter = -1;

        private Vector2 targetPosition;
        private float rotate { get { return npc.ai[1]; } set { npc.ai[1] = value; } }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorrow");
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
            Player player = Main.player[(int)npc.ai[0]];
			int num250 = Dust.NewDust(new Vector2(npc.position.X - npc.velocity.X, npc.position.Y - npc.velocity.Y), npc.width, npc.height, 5, (float)(npc.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
			Main.dust[num250].noGravity = true;
			Main.dust[num250].velocity *= 0f;
            if (counter == -1)
            {
                Vector2 targetPosition = new Vector2(player.position.X + Main.rand.Next(-512, 512), player.position.Y + Main.rand.Next(100, 512));
                SmoothMoveToPosition(targetPosition, 250, 1000);
                counter++;
            } else if (counter % 60 == 0)
            {
                Projectile.NewProjectile(npc.Center, player.position, 389, 15, 2f);
                counter++;
            } else if (counter > 300) {
                counter = -1;
            } else { counter++; 
        }

        private void SmoothMoveToPosition(Vector2 toPosition, float addSpeed, float maxSpeed, float slowRange = 64, float slowBy = .95f)
        {
            if (Math.Abs((toPosition - npc.Center).Length()) >= slowRange)
            {
                npc.velocity += Vector2.Normalize((toPosition - npc.Center) * addSpeed);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxSpeed, maxSpeed);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -maxSpeed, maxSpeed);
            }
            else
            {
                npc.velocity *= slowBy;
            }
        }
    }
}

