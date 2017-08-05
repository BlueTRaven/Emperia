using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{   //coded by BlueRaven
    public class MushorMinionExplode : ModNPC
    {
        private enum Phase
        {
            Drifting,
            Focusing,
            Exploding,
            Done
        }

        private Phase phase { get { return (Phase)npc.ai[0]; } set { npc.ai[0] = (int)value; } }
        private int counter { get { return (int)npc.ai[1]; } set { npc.ai[1] = value; } }

        private const float speedMax = 8, speedMaxExpert = 12.5f;
        private const float speedUpFocus = 2, speedUpFocusExpert = 3.5f;

        private float usingSpeedMax = speedMax, usingSpeedUpFocus = speedUpFocus;

        private const int frameTimer = 4;

        private bool created;

        private const int driftTimer = 120;
        private const int focusTimer = 240;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angery Mushroom");
			Main.npcFrameCount[npc.type] = 15;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 250;
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

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            usingSpeedMax = speedMaxExpert;
            usingSpeedUpFocus = speedUpFocusExpert;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            npc.frame.Y = frameHeight * (int)(npc.frameCounter / frameTimer);

            if (npc.frameCounter > 13 * frameTimer)
                npc.frameCounter = 0;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
            }

            if (!created)
            {
                npc.velocity = new Vector2(-1, 0).RotatedByRandom(MathHelper.ToRadians(360)) * .8f;   //float in a random direction
                phase = Phase.Drifting;
                counter = driftTimer;
                created = true;
            }

            if (phase == Phase.Drifting)
            {
                counter--;

                if (counter <= 0)
                {
                    SetFocusing();
                }

                if (npc.Distance(player.Center) < 64 || npc.life <= 2)   //if really close to the enemy or dying
                {
                    SetExploding();
                }
            }
            else if (phase == Phase.Focusing)
            {
                counter--;

                npc.velocity += Vector2.Normalize((player.Center - npc.Center) * usingSpeedUpFocus);
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -usingSpeedMax, usingSpeedMax);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -usingSpeedMax, usingSpeedMax);
                if (npc.Distance(player.Center) < 64 || npc.life <= 1 || counter <= 0)   //if really close to the enemy or dying or the counter is 0
                {
                    SetExploding();
                }
            }
            if (phase == Phase.Done)
            {
                npc.life = 0;
            }
        }

        private void SetFocusing()
        {
            counter = focusTimer;
            phase = Phase.Focusing;
        }

        private void SetExploding()
        {
            //counter = 60;
            phase = Phase.Done;

            npc.velocity = npc.velocity *= .15f;
            NPC n = Main.npc[NPC.NewNPC(0, 0, mod.NPCType<MushorMinionExplodeDummy>(), ai0: 20, ai1: npc.velocity.X, ai2: npc.velocity.Y)];

            n.Center = npc.Center;
        }

        public override bool CheckDead()
        {
            if (npc.life <= 0)
            {
                npc.velocity = npc.velocity *= .15f;
                NPC n = Main.npc[NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<MushorMinionExplodeDummy>(), ai0: 20, ai1: npc.velocity.X, ai2: npc.velocity.Y)];

                n.Center = npc.Center;
                n.dontTakeDamage = true;
            }
            return true;
        }
    }
}
