using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MouseHuntWindowsProj.Game.Enemy;

namespace MouseHunt
{
    public class EnemyGenerator
    {
        private readonly List<IEnemy> enemies;
        private int nextSpawnTimer;

        private readonly ContentManager Content;
        private readonly SoundManager _soundManager;
        private Random random = new Random();

       public EnemyGenerator(ContentManager content, SoundManager soundManager)
        {
            _soundManager = soundManager;
            Content = content;

            enemies = new List<IEnemy>(); 

            nextSpawnTimer = 100;
        }

        public void Update(gameInput input, Player player)
        {
            if (nextSpawnTimer <= 0)
            {
                var enemy = GetRandomEnemy();

                enemies.Add(enemy);

                nextSpawnTimer = new Random().Next(10, 200);
            }

            nextSpawnTimer--;
            var allEnemies = enemies.Clone();

            foreach (var enemy in allEnemies)
            {
                enemy.Update(input, player);

                if (enemy.HasDied) enemies.Remove(enemy);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(var bird in enemies)
            {
                bird.Draw(spriteBatch, gameTime);
            }
        }

        private IEnemy GetRandomEnemy()
        {
            var randomEnemy = random.Next(0,2);
            if(randomEnemy == 0) return new Hootling(Content, _soundManager);

            return new Sssnake(Content,_soundManager);
        }
    }
}
