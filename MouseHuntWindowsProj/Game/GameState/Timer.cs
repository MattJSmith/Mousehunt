using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Framework;
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
