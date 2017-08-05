using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Emperia.Bosses.SeaSerpent
{
    public class SerpentHead : ModNPC
    {
		private int counter = 50;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sea Serpent");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
           
            npc.lifeMax = 3676;        
            npc.damage = 35;    
            npc.defense = 17;         
            npc.knockBackResist = 0f;
            npc.width = 26; 
            npc.height = 36; 
            npc.boss = false;
            npc.lavaImmune = true;       
            npc.noGravity = true;           
            npc.noTileCollide = true;       
            npc.behindTiles = true;
            npc.value = Item.buyPrice(0, 0, 2, 10);
            npc.npcSlots = 1f;
            npc.netAlways = true;
        }

        public override bool PreAI()
        {
            /*if (Main.netMode != 1)
            {
                if (npc.ai[0] == 0)
                {
                    npc.realLife = npc.whoAmI;
                    int latestNPC = npc.whoAmI;
 
                    int randomWormLength = Main.rand.Next(2, 3);
                    for (int i = 0; i < randomWormLength; ++i)
                    {
                        latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AbyssWorm2"), npc.whoAmI, 0, latestNPC);
                        Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                        Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
                    }
                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AbyssWorm3"), npc.whoAmI, 0, latestNPC);
                    Main.npc[(int)latestNPC].realLife = npc.whoAmI;
                    Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
 
                    npc.ai[0] = 1;
                    npc.netUpdate = true;
                }
            }*/
            return true;
        }
        public override void AI()
		{
			Player player = Main.player[npc.target];
			bool expertMode = Main.expertMode;
			npc.TargetClosest(true);
			// roatation
			if (player.Center.X > npc.Center.X) 
			{
				npc.spriteDirection = 1;
				npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
			}
			else  
			{
				npc.spriteDirection = 2;
				npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;
			}
			// player dead
			if (player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = npc.velocity.Y + 10f;
				if ((double)npc.position.Y > Main.worldSurface * 16.0)
				{
					npc.velocity.Y = npc.velocity.Y + 10f;
				}
				if ((double)npc.position.Y > Main.rockLayer * 16.0)
				{	
					npc.active = false;
				}
			}
			// Moveing
			float num1 = expertMode ? 0.25f : 0.2f;
			if (npc.ai[2] == 0)
			{
				counter--;
				if (player.Center.X > npc.Center.X) 
				{
					npc.velocity.X += num1;
				}
				else  
				{
					npc.velocity.X -= num1;
				}
				if (counter <= 0)
				{
					npc.ai[2] = 0;
					counter = 30;
					Main.PlaySound(SoundID.Roar, npc.position, 10);
				}
			}
			if (npc.ai[2] == 1)
			{
				counter--;
				npc.velocity += Vector2.Normalize((player.Center - npc.Center) * 2f);
				npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -10, 10);
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -10, 10);
				if (counter <= 0)
				{
					npc.ai[2] = 0;
					counter = 120;
					npc.velocity.X = 0f;
					npc.velocity.Y = 0f;
				}
			}
		}
        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
            return false;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1f;  
            return null;
        }
    }
}