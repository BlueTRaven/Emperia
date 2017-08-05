using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Emperia.Bosses.Mushor
{
    public class MushorMinionShield : ModNPC
    {
        private NPC parent { get { return Main.npc[(int)npc.ai[0]]; } set { npc.ai[0] = value.whoAmI; } }
        private float rotate { get { return npc.ai[1]; } set { npc.ai[1] = value; } }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angy Unshroom");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 250;
            npc.damage = 23;
            //npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 34;
            npc.height = 54;
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

        public override void AI()
        {
            Vector2 rotatePosition = Vector2.Transform(new Vector2(-1 * 128, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(rotate))) + parent.Center;
            npc.Center = rotatePosition;

            rotate += .5f;

            if (!parent.active)
                npc.life = 0;
        }

        public override bool CheckDead()
        {
            if (npc.life <= 0)
            {
                parent.ai[3]--;
            }
            return true;
        }
    }
    
}
