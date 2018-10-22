using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Media;

namespace MouseHunt
{
    public class FlockOfHootlings
    {
        List<Hootling> flock;
        private int nextSpawnTimer;

        ContentManager Content;
        SoundManager _soundManager
            ;
       public  FlockOfHootlings(ContentManager content, SoundManager soundManager)
        {
            _soundManager = soundManager;

            flock = new List<Hootling>();
            Content = content;
            flock.Add(new Hootling(content, _soundManager));
            nextSpawnTimer = 100;
        }

        public void Update(gameInput input, Player player)
        {
            if (nextSpawnTimer <= 0)
            {
                flock.Add(new Hootling(Content, _soundManager));

                nextSpawnTimer = new Random().Next(10, 200);
            }

            nextSpawnTimer--;
            var allBirds = flock.Clone();

            foreach (var bird in allBirds)
            {
                bird.Update(input, player);

                if (bird.HasDied) flock.Remove(bird);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(var bird in flock)
            {
                bird.Draw(spriteBatch, gameTime);
            }
        }

    }
}
