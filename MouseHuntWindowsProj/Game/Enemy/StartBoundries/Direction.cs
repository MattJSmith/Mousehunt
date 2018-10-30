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
    public class Direction
    {
        public Vector2 MoveFromEdgeToOppositeEdge(int firstDirection, int secondDirection, bool addRandomAngleTweak)
        {
            var vector2 = new Vector2(firstDirection, secondDirection);

            if (addRandomAngleTweak) vector2 = AddRandomAngleTweak(vector2);

            return vector2;
        }

        public Vector2 AddRandomAngleTweak(Vector2 vector2)
        {
            var tweak = Globals.Random.NextDouble() - 0.5f;

            if (vector2.X == 0) vector2.X += (float)tweak;

            if (vector2.Y == 0) vector2.Y += (float)tweak;

            return vector2;
        }

    }
}
