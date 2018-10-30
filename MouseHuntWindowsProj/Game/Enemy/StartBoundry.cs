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
    public interface IStartBoundry
    {

        Vector2 GetStartPosition();

        float GetStartRotation();

        Vector2 MoveFromBoundryToOppositeBoundry();

    }
}
