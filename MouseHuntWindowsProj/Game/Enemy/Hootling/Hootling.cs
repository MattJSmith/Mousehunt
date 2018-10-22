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

    public class Hootling
    {
        private SoundManager _soundManager;

        private HootlingLogic logic = new HootlingLogic();

        private CollisionSprite sprite;
        private Vector2 position;
        private Vector2 velocity;
        private int imageRotation;
        private Texture2D enemyImage;
        private bool enemyIsVisible = false;
   
        private IStartBoundry startBoundry;
        private bool HasSpawned;

        public bool HasDied;

        public Hootling(ContentManager content, SoundManager soundManager)
        {
            startBoundry = logic.getRandomBoundryStarts();

            var enemyWarningImage = content.Load<Texture2D>(ContentLocations.Enemy+ "HootlingStart");
            enemyImage = content.Load<Texture2D>(ContentLocations.Enemy + "HootlingSwoop");

            position = startBoundry.GetStartPosition();
            var startRotation = startBoundry.GetStartRotation();

            sprite = new CollisionSprite(enemyImage, enemyImage.Bounds, position);
            sprite.sprite.setRotation(startRotation);
            sprite.sprite.tiledImage = enemyWarningImage;
            velocity = startBoundry.MoveFromBoundryToOppositeBoundry() * 5;

            _soundManager = soundManager;
        }

        public void Update(gameInput input, Player player)
        {
            if (!logic.spawnWarningTimer.HasFinished() || HasDied) return;
    
            if (!HasSpawned)
            {
                HasSpawned = true;
                sprite.sprite.tiledImage = enemyImage;
                _soundManager.HootlingAppears();     
            }

            position.X += velocity.X;
            position.Y += velocity.Y;

            if (!IsOnScreen()) { 
                HasDied = true;
                return; }

           sprite.UpdateByNewPosition(position);

           if (sprite.boundingBoxIntersection(player.playerSprite)) {
               HasDied = true;

               player.TakeDamage();
           }    
        }

        public bool IsOnScreen()
        {
            if (position.X > Globals.ScreenBoundry.Left && position.X < Globals.ScreenBoundry.Right &&
                position.Y > Globals.ScreenBoundry.Top && position.Y < Globals.ScreenBoundry.Bottom) return true;

            return false;
        }

        public void Draw(SpriteBatch spriteBatch,GameTime gameTime)
        {
            new DebugTools().DebugRectangle(spriteBatch, sprite.bounds);

            sprite.draw(spriteBatch,gameTime);
        }
    }
   
}
