using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MouseHunt;

namespace MouseHuntWindowsProj.Game.Enemy
{
    interface IEnemy
    { 
        bool HasDied { get;}
        void Update(gameInput input, Player player);
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
