using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace Emperia.Bosses.Pandora
{
    public class PandorasBoxOpening : ModNPC
    {
        private const int frameTimer = 5, frameTimerSlow = 10;

        bool drawBeams = false, drawMain = true;    //since all this stuff is done clientside, as it is visual, I can use bools and not the ai arrays.
        int openTimer;
        const int openTimerMax = 55;
        const int circleSides = 64;
        int circleRadius = 128;
        int doneTimer;
        const int doneTimerMax = 240;

        #region colors
        Color leftColor = new Color()
        {
            R = 100,
            G = 172,
            B = 20
        };

        Color topColor = new Color()
        {
            R = 24,
            G = 208,
            B = 220
        };

        Color rightColor = new Color()
        {
            R = 174,
            G = 40,
            B = 18
        };

        Color bottomColor = new Color()
        {
            R = 154,
            G = 0,
            B = 154
        };
        #endregion
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora's Box");
			Main.npcFrameCount[npc.type] = 18;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 250;
            npc.damage = 0;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 104;
            npc.height = 88;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.dontTakeDamage = true;

            npc.netAlways = true;
        }

        public override void AI()
        {
            Lighting.AddLight(npc.Center + new Vector2(-64, 0), leftColor.ToVector3() / 255);
            Lighting.AddLight(npc.Center + new Vector2(0, -64), topColor.ToVector3() / 255);
            Lighting.AddLight(npc.Center + new Vector2(64, 0), rightColor.ToVector3() / 255);
            Lighting.AddLight(npc.Center + new Vector2(0, 64), bottomColor.ToVector3() / 255);

            if (drawBeams)
                if (openTimer < openTimerMax)
                    openTimer++;
            if (!drawMain && doneTimer != -1)
            {
                if (circleRadius >= 2048)
                {
                    doneTimer++;

                    if (doneTimer >= doneTimerMax)
                    {
                       

                            Main.NewText("You Have Damned Reality...");

                        doneTimer = -1;
                        npc.life = 0;
                    }
                }
                else circleRadius += 80;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;

            if (npc.frame.Y <= frameHeight * 5)
            {   //first 6 frames
                if (npc.frameCounter > frameTimer)
                {
                    npc.frame.Y += frameHeight;
                    npc.frameCounter = 0;
                }
            }
            else if (npc.frame.Y > frameHeight * 5 && npc.frame.Y <= frameHeight * 9)
            {   //next 4 frames
                drawBeams = true;
                if (npc.frameCounter > frameTimerSlow)
                {
                    npc.frame.Y += frameHeight;
                    npc.frameCounter = 0;
                }
            }
            else
            {
                if (npc.frameCounter > frameTimer)
                {
                    npc.frame.Y += frameHeight;
                    npc.frameCounter = 0;
                }
            }

            if (npc.frame.Y >= 17 * frameHeight)
                drawMain = false;

            /*npc.frame.Y = frameHeight * (int)(npc.frameCounter / frameTimer);

            if (npc.frameCounter >= 6 * frameTimer)
                drawBeams = true;

            if (npc.frameCounter >= 17 * frameTimer)
                drawMain = false;*/
        }

        public override bool PreDraw(SpriteBatch batch, Color drawColor)
        {
            if (drawBeams && drawMain)
            {
                batch.End();
                batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

                Emperia.basicEffect.CurrentTechnique.Passes[0].Apply();

                float endDistance = MathHelper.Lerp(12, 256, (float)openTimer / (float)openTimerMax);
                Vector3 s = new Vector3(Main.screenPosition, 0);
                //left
                VertexPositionColorTexture boxTop = new VertexPositionColorTexture(new Vector3(npc.Center.X, npc.Center.Y - 8, 0) - s, leftColor, Vector2.Zero);
                VertexPositionColorTexture boxBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X, npc.Center.Y + 8, 0) - s, leftColor, Vector2.Zero);
                VertexPositionColorTexture outTop = new VertexPositionColorTexture(new Vector3(npc.Center.X - 2048, npc.Center.Y - endDistance, 0) - s, leftColor, Vector2.Zero);
                VertexPositionColorTexture outBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X - 2048, npc.Center.Y + endDistance, 0) - s, leftColor, Vector2.Zero);
                batch.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, new VertexPositionColorTexture[] { boxTop, boxBottom, outTop, outBottom }, 0, 4, new short[] { 0, 1, 2, 2, 1, 3 }, 0, 2);
                //top
                boxTop = new VertexPositionColorTexture(new Vector3(npc.Center.X - 8, npc.Center.Y, 0) - s, topColor, Vector2.Zero);
                boxBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X + 8, npc.Center.Y, 0) - s, topColor, Vector2.Zero);
                outTop = new VertexPositionColorTexture(new Vector3(npc.Center.X - endDistance, npc.Center.Y - 2048, 0) - s, topColor, Vector2.Zero);
                outBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X + endDistance, npc.Center.Y - 2048, 0) - s, topColor, Vector2.Zero);
                batch.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, new VertexPositionColorTexture[] { boxTop, boxBottom, outTop, outBottom }, 0, 4, new short[] { 3, 1, 2, 2, 1, 0 }, 0, 2);
                //right
                boxTop = new VertexPositionColorTexture(new Vector3(npc.Center.X, npc.Center.Y - 8, 0) - s, rightColor, Vector2.Zero);
                boxBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X, npc.Center.Y + 8, 0) - s, rightColor, Vector2.Zero);
                outTop = new VertexPositionColorTexture(new Vector3(npc.Center.X + 2048, npc.Center.Y - endDistance, 0) - s, rightColor, Vector2.Zero);
                outBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X + 2048, npc.Center.Y + endDistance, 0) - s, rightColor, Vector2.Zero); //3, 1, 2, 2, 1, 0
                batch.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, new VertexPositionColorTexture[] { boxTop, boxBottom, outTop, outBottom }, 0, 4, new short[] { 3, 1, 2, 2, 1, 0 }, 0, 2);
                //bottom
                boxTop = new VertexPositionColorTexture(new Vector3(npc.Center.X - 8, npc.Center.Y, 0) - s, bottomColor, Vector2.Zero);
                boxBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X + 8, npc.Center.Y, 0) - s, bottomColor, Vector2.Zero);
                outTop = new VertexPositionColorTexture(new Vector3(npc.Center.X - endDistance, npc.Center.Y + 2048, 0) - s, bottomColor, Vector2.Zero);
                outBottom = new VertexPositionColorTexture(new Vector3(npc.Center.X + endDistance, npc.Center.Y + 2048, 0) - s, bottomColor, Vector2.Zero);
                batch.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, new VertexPositionColorTexture[] { boxTop, boxBottom, outTop, outBottom }, 0, 4, new short[] { 0, 1, 2, 2, 1, 3 }, 0, 2);

                batch.End();
                batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            }
            if (!drawMain)
            {
                batch.End();
                batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

                Emperia.basicEffect.CurrentTechnique.Passes[0].Apply();

                VertexPositionColorTexture[] vertices = new VertexPositionColorTexture[circleSides];
                int[] indices = new int[circleSides];

                Vector3 s = new Vector3(Main.screenPosition, 0);

                for (int i = 1; i <= circleSides; i++)
                {
                    Vector2 pos = Vector2.Transform(new Vector2(-circleRadius, 0), Matrix.CreateRotationZ(MathHelper.ToRadians((360 / (float) circleSides) * i)));
                    vertices[i - 1] = new VertexPositionColorTexture(new Vector3(pos + npc.Center, 0) - s, Color.Lerp(Color.White, Color.Transparent, (float)doneTimer / (float)doneTimerMax), Vector2.Zero);
                }

                for (int i = 1; i <= vertices.Length - 2; i++)
                {
                    batch.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, new VertexPositionColorTexture[] { vertices[0], vertices[i], vertices[i + 1] }, 0, 3, new short[] { 0, 1, 2 }, 0, 1);
                }

                batch.End();
                batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            }
            return drawMain;
        }

        public override bool CheckActive()
        {
            return false;   //ALWAYS active.
        }
    }
}
