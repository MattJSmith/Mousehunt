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
    public class Background
    {
        Sprite backgroundOne;
        Sprite backgroundTwo;
        Sprite backgroundThree;
        Sprite backgroundFour;
        float backgroundTransparency;
  
        bool finalBackgroundFlag = false;

        Texture2D eye;
        Texture2D eyeOpen;
        Texture2D eyeLeftPupil;
        Texture2D eyeRightPupil;

        Vector2 eyeLeftPos;
        Vector2 eyeRightPos;

        bool showPupils = false;

        Vector2 eyeLeftPupilPos;
        Vector2 eyeRightPupilPos;

        int currentBackgroundNumber = 1;

        public Background(ContentManager content)
        {
            SetUpBackgroundImages(content);

            eye = content.Load<Texture2D>(ContentLocations.BackGroundEyes + "EyeClosed");
            eyeOpen = content.Load<Texture2D>(ContentLocations.BackGroundEyes + "OpenEye");
            eyeLeftPupil = content.Load<Texture2D>(ContentLocations.BackGroundEyes + "EyePupil");
            eyeRightPupil = content.Load<Texture2D>(ContentLocations.BackGroundEyes + "EyePupil");

            eyeLeftPos = new Vector2(100,150);

            eyeRightPos = new Vector2(525, 150);
        }

        private void SetUpBackgroundImages(ContentManager content)
        {
            backgroundTransparency = 0;

            var background = content.Load<Texture2D>(ContentLocations.BackGround + "background1");
            backgroundOne = new Sprite(background);

            background = content.Load<Texture2D>(ContentLocations.BackGround + "background2");
            backgroundTwo = new Sprite(background);

            background = content.Load<Texture2D>(ContentLocations.BackGround + "background3");
            backgroundThree = new Sprite(background);

            background = content.Load<Texture2D>(ContentLocations.BackGround + "background4");
            backgroundFour = new Sprite(background);
        }

        public void BackgroundImageUpdate()
        {
            if (currentBackgroundNumber == 1)
            {
                if (backgroundTransparency < 1) { 
                    backgroundTransparency += 0.0001f;
                    backgroundTwo.setSpriteColour(Color.White * backgroundTransparency);
                }
                else { 
                    backgroundTransparency = 0;
                    currentBackgroundNumber=2;
                }
                return;
            }
            else if (currentBackgroundNumber == 2)
            {
                if (backgroundTransparency < 1) { backgroundTransparency += 0.001f; 
                backgroundThree.setSpriteColour(Color.White * backgroundTransparency);
                }
                else
                {
                    backgroundTransparency = 0;
                    currentBackgroundNumber = 3;
                }
                return;
            }
            else
            {
                //3 and 4

                //one becomes visible, once visible other is not visible.

                if (finalBackgroundFlag)
                {
                    if (backgroundTransparency <= 1)
                    {
                        backgroundTransparency += 0.001f;
                        backgroundFour.setSpriteColour(Color.White * backgroundTransparency);
                    }
                    else
                    {
                        finalBackgroundFlag = false;

                        SpriteFlipper(backgroundThree);
                    }
                }
                else 
                {
                    if (backgroundTransparency >= 0)
                    {
                        backgroundTransparency -= 0.001f;
                        backgroundFour.setSpriteColour(Color.White * backgroundTransparency);
                    }
                    else
                    {
                        finalBackgroundFlag = true;
                        SpriteFlipper(backgroundFour);
                    }
                }       
            }
        }

        public void SpriteFlipper(Sprite sprite)
        {
            if (sprite.getSpriteEffect() == SpriteEffects.FlipVertically) sprite.setSpriteEffect(SpriteEffects.FlipHorizontally);
            else if (sprite.getSpriteEffect() == SpriteEffects.FlipHorizontally) sprite.setSpriteEffect(SpriteEffects.None);
            else
            {
                sprite.setSpriteEffect(SpriteEffects.FlipVertically);
            }
        }


        public void update(gameInput input)
        {

            BackgroundImageUpdate();

            var mousePosition = input.getMousePos();

            Vector2 leftPupilAdjustment;
            Vector2 rightPupilAdjustment;

            leftPupilAdjustment.X = mousePosition.X - eyeLeftPos.X;
            leftPupilAdjustment.Y = mousePosition.Y - eyeLeftPos.Y;

            rightPupilAdjustment.X = mousePosition.X - eyeRightPos.X;
            rightPupilAdjustment.Y = mousePosition.Y - eyeRightPos.Y;

            leftPupilAdjustment.Normalize();
            rightPupilAdjustment.Normalize();

            leftPupilAdjustment *= 8;
            rightPupilAdjustment *= 8;
    
            eyeLeftPupilPos.X = (eyeLeftPos.X + eyeOpen.Width /2 - eyeLeftPupil.Width/2) + leftPupilAdjustment.X;
            eyeLeftPupilPos.Y = (eyeLeftPos.Y + eyeOpen.Height / 2 - eyeLeftPupil.Height / 2) + leftPupilAdjustment.Y;

            eyeRightPupilPos.X = (eyeRightPos.X + eyeOpen.Width / 2 - eyeRightPupil.Width / 2) + rightPupilAdjustment.X;
            eyeRightPupilPos.Y = (eyeRightPos.Y + eyeOpen.Height / 2 - eyeRightPupil.Height / 2) + rightPupilAdjustment.Y;
        }

        public void changeEye()
        {
            eye = eyeOpen;
            showPupils = true;
        }

        private void DrawBackgrounds(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (currentBackgroundNumber == 1)
            {       
                backgroundOne.Draw(gameTime, spriteBatch, new Vector2(0, 0), SpriteEffects.None);
                backgroundTwo.Draw(gameTime, spriteBatch, new Vector2(0, 0), SpriteEffects.None);
            }

            if (currentBackgroundNumber == 2)
            {  
                backgroundTwo.Draw(gameTime, spriteBatch, new Vector2(0, 0), SpriteEffects.None);
                backgroundThree.Draw(gameTime, spriteBatch, new Vector2(0, 0), SpriteEffects.None);
            }
            if (currentBackgroundNumber == 3)
            {
                backgroundThree.Draw(gameTime, spriteBatch, new Vector2(0, 0), SpriteEffects.None);
                backgroundFour.Draw(gameTime, spriteBatch, new Vector2(0, 0), SpriteEffects.None);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawBackgrounds(spriteBatch, gameTime);

            var colour = Color.White;

            colour.A = 175;

            spriteBatch.Draw(eye, eyeLeftPos, null, colour, 0, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            spriteBatch.Draw(eye, eyeRightPos, null, colour, 0, new Vector2(0, 0), 1, SpriteEffects.FlipHorizontally, 1);

            if (showPupils)
            {

                spriteBatch.Draw(eyeLeftPupil, eyeLeftPupilPos, colour);
                spriteBatch.Draw(eyeRightPupil, eyeRightPupilPos, colour);
            }
        }


    }
}
