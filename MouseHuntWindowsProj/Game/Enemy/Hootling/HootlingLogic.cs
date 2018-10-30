using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;


namespace MouseHunt
{
    public class HootlingLogic
    {
        public bool spawnState = true;

        public Timer spawnWarningTimer;

        public HootlingLogic()
        {
            spawnWarningTimer = new Timer(0.5f,true);
        }

        public IStartBoundry getRandomBoundryStarts()
        {
            var rand = Globals.Random.Next(0, 4);

            switch (rand)
            {
                case 0:
                    return new Top();
                case 1:
                    return new Bottom();
                case 2:
                    return new Left();
                case 3:
                    return new Right();
                default:
                    return new Top();
            }
        }

    }
}
