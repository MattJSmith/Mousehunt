using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Framework;

namespace MouseHunt
{
    public interface IStartBoundry
    {

        Vector2 GetStartPosition();

        float GetStartRotation();

        Vector2 MoveFromBoundryToOppositeBoundry();

    }
}
