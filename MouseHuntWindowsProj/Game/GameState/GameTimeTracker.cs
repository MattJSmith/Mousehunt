using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Framework;
using MonoGame.Framework.Content;
using MonoGame.Framework.Graphics;
using MonoGame.Framework.Input;
using MonoGame.Framework.Storage;

namespace MouseHunt
{
    public static class GameTimeTracker
    {
        private static float GameElapsedTime = 0f;

        public static void Update(GameTime gameTime){
              GameElapsedTime = (float) gameTime.TotalGameTime.TotalSeconds;
        }

        public static float GetTimeSnapShot()
        {
            return GameElapsedTime;
        }

        public static float GetTimeDifference(float gameTime)
        {
            return GameElapsedTime - gameTime;
        }

    }
}
