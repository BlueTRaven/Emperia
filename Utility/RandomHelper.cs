using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Terraria;

using Microsoft.Xna.Framework;

namespace Emperia.Utility
{
    public static class RandomHelper
    {
        public static Vector2 RandomPointInside(this Rectangle rectangle)
        {
            return new Vector2(Main.rand.Next(rectangle.X, rectangle.X + rectangle.Width), Main.rand.Next(rectangle.Y, rectangle.Y + rectangle.Height));
        }
    }
}
