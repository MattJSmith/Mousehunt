using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace MouseHunt
{
    public class Top : IStartBoundry
    {

        public Vector2 GetStartPosition()
        {
            var xPosition = Globals.Random.Next(Globals.ScreenBoundry.X, Globals.ScreenBoundry.Right);

            return new Vector2(xPosition, Globals.ScreenBoundry.Top);
        }

        public float GetStartRotation()
        {
            return (float)Math.PI;
        }

        public Vector2 MoveFromBoundryToOppositeBoundry()
        {
            return new Direction().MoveFromEdgeToOppositeEdge(DirectionMultiplier.MoveSame, DirectionMultiplier.MoveDown, true);
        }
    }
}
