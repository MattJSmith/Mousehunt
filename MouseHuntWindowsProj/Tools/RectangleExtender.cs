using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;
using MonoGame.Framework.Content;
using MonoGame.Framework.Graphics;
using MonoGame.Framework.Input;
using MonoGame.Framework.Storage;

namespace MouseHunt
{
    public static class RectangleExtender
    {
        public static Vector2 XY(this Rectangle rectangle)
        { 
            return new Vector2(rectangle.X, rectangle.Y);
        }

        public static Vector2 Center(this Rectangle rectangle)
        {
            var horizontal = rectangle.X + (rectangle.Width / 2);

            var verticle = rectangle.Y + (rectangle.Height / 2);

            return new Vector2(horizontal, verticle);
        }
    }
   
}
