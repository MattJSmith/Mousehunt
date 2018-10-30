using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoGame.Framework;
using MonoGame.Framework.Content;
using MonoGame.Framework.Graphics;
using MonoGame.Framework.Input;
using MonoGame.Framework.Storage;

using MonoGame.Framework.Audio;
using MonoGame.Framework.Media;


namespace MouseHunt
{
    public class SoundManager
    {
        private SoundEffect playerHit;
        private SoundEffect hootlingAppears;
        public SoundManager(ContentManager Content)
        {
            playerHit = Content.Load<SoundEffect>(ContentLocations.Player + "MouseHit");
            hootlingAppears = Content.Load<SoundEffect>(ContentLocations.Enemy + "Hoot");
        }

        public void PlayerHitSoundEffect()
        {
            PlaySound(playerHit, 0.8f);
        }

        public void HootlingAppears()
        {
            PlaySound(hootlingAppears, 0.8f);
        }

        private void PlaySound(SoundEffect soundEffect, float volumne = 1, bool loop = false)
        {
            var instance = soundEffect.CreateInstance();

            instance.Volume = volumne;

            instance.IsLooped = loop;

            instance.Play();
        }
    }
}
