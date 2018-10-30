#region Using Statements
using System;
using System.Collections.Generic;
using MonoGame.Framework;
using MonoGame.Framework.Content;
using MonoGame.Framework.Graphics;
using MonoGame.Framework.Input;
using MonoGame.Framework.Storage;
using MonoGame.Framework.Media;
#endregion

namespace MouseHunt
{

    public class MainGame : Game
    {
        private SoundManager soundManager;

        int backgroundTimer = 0;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private gameInput input;
        private Player player;
        private FlockOfHootlings enemys;
        private Background background;


        public MainGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
         //   graphics.ToggleFullScreen();
           
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
      
        }

        protected override void LoadContent()
        {
            Globals.ScreenBoundry = graphics.GraphicsDevice.Viewport.Bounds;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            soundManager = new SoundManager(Content);
            input = new gameInput();
            player = new Player(Content, soundManager);
            background = new Background(Content);
            enemys = new FlockOfHootlings(Content, soundManager);
        
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            GameTimeTracker.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            input.Update(graphics.GraphicsDevice.DisplayMode.TitleSafeArea);

            // TODO: Add your update logic here
            player.update(input);

            background.update(input);

            enemys.Update(input, player);

            if (backgroundTimer < 200 && backgroundTimer != -1)
            {
                backgroundTimer++;
            }
            else
            {
                backgroundTimer = -1;
                background.changeEye();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
  
            background.Draw(spriteBatch, gameTime);  
            player.Draw(spriteBatch, gameTime);
            enemys.Draw(spriteBatch, gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
