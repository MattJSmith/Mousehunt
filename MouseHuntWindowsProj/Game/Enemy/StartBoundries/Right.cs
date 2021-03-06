﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Framework;

namespace MouseHunt
{

    public class Right : IStartBoundry
    {
        public Vector2 GetStartPosition()
        {
            var yPosition = Globals.Random.Next(Globals.ScreenBoundry.Y, Globals.ScreenBoundry.Height);

            return new Vector2(Globals.ScreenBoundry.Right, yPosition);
        }

        public float GetStartRotation()
        {
            return (float) (3 * Math.PI) / 2;
        }

        public Vector2 MoveFromBoundryToOppositeBoundry()
        {
            return new Direction().MoveFromEdgeToOppositeEdge(DirectionMultiplier.MoveLeft, DirectionMultiplier.MoveSame, true);
        }
    }
}
