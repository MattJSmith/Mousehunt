﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Framework;

namespace MouseHunt
{
    public class Bottom : IStartBoundry
    {

        public Vector2 GetStartPosition()
        {
            var xPosition = Globals.Random.Next(Globals.ScreenBoundry.X, Globals.ScreenBoundry.Right);

            return new Vector2(xPosition, Globals.ScreenBoundry.Bottom);
        }

        public float GetStartRotation()
        {
            return 0f;
        }

        public Vector2 MoveFromBoundryToOppositeBoundry()
        {
            return new Direction().MoveFromEdgeToOppositeEdge(DirectionMultiplier.MoveSame, DirectionMultiplier.MoveUp, true);
        }
    }
}
