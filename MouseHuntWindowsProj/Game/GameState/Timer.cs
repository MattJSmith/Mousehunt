using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace MouseHunt
{

    //Timer that starts instantly
    public class Timer
    {
        private float startTime;
        private float timerDuration;

        public Timer(float seconds, bool start)
        {
            timerDuration = seconds;

            startTime = GameTimeTracker.GetTimeSnapShot();

            if (!start) startTime += seconds;
        }

        public void Reset()
        {
            startTime = GameTimeTracker.GetTimeSnapShot();
        }

        public void Start()
        {
            Reset();
        }

        public bool HasFinished()
        {
            var timeElapsed = GameTimeTracker.GetTimeDifference(startTime);

            return timeElapsed >= timerDuration;
        }

    }
}
