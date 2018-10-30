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
    public class DebugTools
    {
        public void DebugRectangle(SpriteBatch spriteBatch, Rectangle position)
        {
            #if DEBUG
            var rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.White });
            spriteBatch.Draw(rect, position, Color.White);
            #endif
        }
    }
}
