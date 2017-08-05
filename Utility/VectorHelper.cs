using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Emperia.Utility
{
    public static class VectorHelper
    {
        public static float Cross(Vector2 vec1, Vector2 vec2)
        {
            return ((vec1.X - vec2.X) * (vec2.Y - vec1.Y)) - ((vec1.Y - vec2.Y) * (vec2.X - vec1.X));
        }

        /// <summary>
        /// Gets the normalized perpendicular of the given vector.
        /// </summary>
        /// <param name="vector">The vector to get the perpendicular from.</param>
        /// <param name="left">Whether or not to get the perpendicular to the left or the right.</param>
        /// <returns>The normalized perpendicular vector.</returns>
        public static Vector2 GetPerpendicular(Vector2 vector, bool left = true)
        {
            if (left)
            {
                return Vector2.Normalize(new Vector2(vector.Y, -vector.X));
            }
            else return Vector2.Normalize(new Vector2(-vector.Y, vector.X));
        }

        /// <param name="degrees">The rotation of the vector to return.</param>
        /// <returns>A normalized vector rotated to the specified degree.</returns>
        public static Vector2 GetVectorAtAngle(float degrees)
        {
            return Vector2.Normalize(Vector2.Transform(new Vector2(-1, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(degrees))));
        }

        /// <summary>
        /// Gets the angle of a given vector, relative to 0,0.
        /// </summary>
        /// <returns>The angle in degrees.</returns>
        public static float GetVectorAngle(this Vector2 normVec)
        {
            if (normVec != Vector2.Zero)
            {
                float angle = GetAngleBetweenPoints(Vector2.Zero, Vector2.Normalize(normVec));
                if (angle < 0)
                    angle += 360;
                else if (angle > 360)
                    angle -= 360;
                return angle;
            }
            else return -1;
        }

        public static float GetAngleBetweenPoints(Vector2 A, Vector2 B)
        {
            return MathHelper.ToDegrees((float)Math.Atan2(A.Y - B.Y, A.X - B.X));
        }

        public static VertexPositionColor ToVertexPositionColor(this Vector2 vector, Color color)
        {
            return new VertexPositionColor(new Vector3(vector, 0), color);
        }

        public static Vector2 Floor(this Vector2 vector)
        {
            return new Vector2((float)Math.Floor(vector.X), (float)Math.Floor(vector.Y));
        }

        public static float GetPolygonArea(Vector2[] vertices)
        {
            int vertCount = vertices.Count();
            Vector2[] points = new Vector2[vertCount + 1];
            vertices.CopyTo(points, 0);
            points[vertCount] = points[0];

            float area = 0;
            for (int i = 0; i < vertCount; i++)
            {
                area +=
                    (points[i + 1].X - points[i].X) *
                    (points[i + 1].Y + points[i].Y) / 2;
            }

            return area;
        }
    }
}
