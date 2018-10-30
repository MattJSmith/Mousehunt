using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MouseHunt
{

    public class Left : IStartBoundry
    {
        public Vector2 GetStartPosition()
        {
            var yPosition = Globals.Random.Next(Globals.ScreenBoundry.Y, Globals.ScreenBoundry.Height);

            return new Vector2(Globals.ScreenBoundry.Left, yPosition);
        }

        public float GetStartRotation()
        {
            return (float) Math.PI / 2;
        }

        public Vector2 MoveFromBoundryToOppositeBoundry()
        {
            return new Direction().MoveFromEdgeToOppositeEdge(DirectionMultiplier.MoveRight, DirectionMultiplier.MoveSame, true);
        }
    }
}
