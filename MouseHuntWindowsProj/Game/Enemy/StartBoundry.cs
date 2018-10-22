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
    public interface IStartBoundry
    {

        Vector2 GetStartPosition();

        float GetStartRotation();

        Vector2 MoveFromBoundryToOppositeBoundry();

    }
}
