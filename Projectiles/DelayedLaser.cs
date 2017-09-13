using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

using Emperia.Utility;

namespace Emperia.Projectiles
{
    public class DelayedLaser : ModProjectile
    {
        Vector2 npcCenter { get { return (projectile.hostile && !projectile.friendly) ? Main.npc[(int)projectile.ai[0]].Center : Main.player[(int)projectile.ai[0]].Center; } set { } }
        float rotation { get { return projectile.ai[1]; } set { projectile.ai[1] = value; } }

        private int delayTimerMax;
        private int delayTimer;
        private bool doneDelay = false;

        private float thickness, maxThickness, halfThick;

        private Color topColor, middleColor, bottomColor;

        private bool created;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Beams");
		}
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.timeLeft = 120;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.hide = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }



        public override void AI()
        {
            try
            {
                if (!created)
                    throw new Exception(String.Format("Projectile {0} at index {1} was not created properly!", this.DisplayName, projectile.whoAmI));
            }
            catch (Exception e)
            {
                ErrorLogger.Log(e.ToString());
            }
            if (!doneDelay)
            {
                if (delayTimer == delayTimerMax)
                    Main.PlaySound(SoundID.Item, npcCenter, 6);  //Other candidates: Item13
                if (delayTimer == 1)
                    Main.PlaySound(SoundID.Item44, npcCenter);  //Other candidates: Item33, Item44, Item25, Item12

                delayTimer--;

                if (delayTimer <= 0)
                {
                    thickness = maxThickness;
                    doneDelay = true;
                }
            }
            else
            {
                halfThick = MathHelper.Lerp(halfThick, maxThickness / 2, .2f); //.2 20% every frame
            }
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            try
            {
                if (doneDelay)
                {
                    float point = 0f;
                    Vector2 endPoint = (VectorHelper.GetVectorAtAngle(rotation) * 2048);
                    bool colliding = Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), npcCenter, npcCenter + endPoint, maxThickness, ref point);
                    if (colliding)
                    {
                        Vector2 spawn = (Vector2.Normalize(endPoint) * point) + npcCenter;

                        for (int i = 0; i < Main.rand.Next(1, 16); i++)
                            Dust.NewDust(spawn, 4, 4, 6);
                    }
                    return colliding;
                }
                return false;
            }
            catch (Exception e)
            {
                Main.NewTextMultiline(e.ToString());
                return null;
            }
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            // Add this projectile to the list of projectiles that will be drawn BEFORE tiles and NPC are drawn. This makes the projectile appear to be BEHIND the tiles and NPC.
            drawCacheProjsBehindNPCsAndTiles.Add(index);
        }

        public override bool PreDraw(SpriteBatch batch, Color lightColor)
        {
            try
            {
                Vector2 endPoint = npcCenter + (VectorHelper.GetVectorAtAngle(rotation) * 2048);//Vector2.Transform(new Vector2(-1, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(projectile.ai[1]))) * 1024;
                batch.End();
                batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);

                //BlueRavenMod.basicEffect.World = BlueRavenMod.worldMatrix;
                Emperia.basicEffect.CurrentTechnique.Passes[0].Apply();
                Vector2 perpLeft = VectorHelper.GetPerpendicular(endPoint - npcCenter, true);
                Vector2 perpRight = VectorHelper.GetPerpendicular(endPoint - npcCenter, false);

                //float halfThick = thickness / 2;

                //top       original color: DarkRed
                VertexPositionColorTexture topEnd = new VertexPositionColorTexture(new Vector3((endPoint + perpLeft * halfThick) - Main.screenPosition, 0), topColor, Vector2.Zero);
                VertexPositionColorTexture topStart = new VertexPositionColorTexture(new Vector3((npcCenter + perpLeft * halfThick) - Main.screenPosition, 0), topColor, Vector2.Zero);
                //middle    original color: Red
                VertexPositionColorTexture middleEnd = new VertexPositionColorTexture(new Vector3(endPoint - Main.screenPosition, 0), middleColor, Vector2.Zero);
                VertexPositionColorTexture middleStart = new VertexPositionColorTexture(new Vector3(npcCenter - Main.screenPosition, 0), middleColor, Vector2.Zero);
                //bottom    original color: DarkRed
                VertexPositionColorTexture bottomEnd = new VertexPositionColorTexture(new Vector3((endPoint + perpRight * halfThick) - Main.screenPosition, 0), bottomColor, Vector2.Zero);
                VertexPositionColorTexture bottomStart = new VertexPositionColorTexture(new Vector3((npcCenter + perpRight * halfThick) - Main.screenPosition, 0), bottomColor, Vector2.Zero);

                //batch.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColorTexture>(PrimitiveType.TriangleList, new VertexPositionColorTexture[] { topEnd, middleEnd, middleStart, topStart }, 0, 4, new short[] { 0, 1, 2, 2, 3, 0 }, 0, 2);
                batch.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColorTexture>(PrimitiveType.TriangleList,
                    new VertexPositionColorTexture[] { middleEnd, topEnd, topStart, middleStart, bottomStart, bottomEnd }, 0, 6,
                    new short[] { 0, 5, 4, 4, 3, 0, 0, 3, 2, 2, 1, 0 }, 0, 4);
                //0, 1, 2, 2, 3, 0, 2, 3, 4, 4, 5, 0
                //0, 5, 4, 4, 3, 2, 0, 3, 2, 2, 1, 0

                batch.End();
                batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                return false;
            }
            catch (Exception e)
            {
                Main.NewTextMultiline(e.ToString());
                return false;
            }
			
        }
        /// <summary>
        /// note that timeleft is set to duration + delayTime, so duration is how long it lasts AFTER the delay.
        /// </summary>
        public Projectile Create(int duration, int delayTime, float thickness, float maxThickness, Color topColor, Color middleColor, Color bottomColor, bool player = false)
        {
            this.projectile.timeLeft = duration + delayTime;
            this.delayTimer = delayTime;
            this.delayTimerMax = delayTime;

            this.thickness = thickness;
            this.maxThickness = maxThickness;

            this.halfThick = thickness / 2;

            this.topColor = topColor;
            this.middleColor = middleColor;
            this.bottomColor = bottomColor;

            created = true;

            if (player)
            {
                projectile.hostile = false;
                projectile.friendly = true;
            }

            return projectile;
        }
    }
}