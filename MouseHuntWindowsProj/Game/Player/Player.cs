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
    public class Player
    {
        private PlayerIndex index;
        private Vector2 mousePosition;
        private Texture2D playerPic;
   
        private int timer = 0;
        private Vector2 imagePosition; //This is position - half of image centre

        private bool playerBeenHit;
        private Timer invincibleTimer; //invisible for a second after hit

        private SoundManager _soundManager;

        public CollisionSprite playerSprite;

        public Player(ContentManager content, SoundManager soundManager)
        {
            invincibleTimer = new Timer(1, false);

            playerBeenHit = false;

            mousePosition = Vector2.Zero;
            playerPic = content.Load<Texture2D>(ContentLocations.Player + "TiledMouse");
            playerSprite = new CollisionSprite(playerPic, playerPic.Bounds, mousePosition);
            _soundManager = soundManager;

        }

        public void TakeDamage()
        {
            if (!invincibleTimer.HasFinished())
            {
                return;
            }

            invincibleTimer.Reset();
            _soundManager.PlayerHitSoundEffect();
            playerBeenHit = true;     
            playerSprite.sprite.setSpriteColour(Color.Yellow);
   
        }

        public void update(gameInput input)
        {
            if (invincibleTimer.HasFinished())
            {
                playerSprite.sprite.setSpriteColour(Color.White);
            }


            mousePosition = input.getMousePos();

            imagePosition.X = mousePosition.X - playerPic.Width / 2;
            imagePosition.Y = mousePosition.Y - playerPic.Width / 2;

            playerSprite.UpdateByNewPosition(imagePosition);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            new DebugTools().DebugRectangle(spriteBatch, playerSprite.bounds);

            playerSprite.draw(spriteBatch,gameTime);
        }
    }
   
}
