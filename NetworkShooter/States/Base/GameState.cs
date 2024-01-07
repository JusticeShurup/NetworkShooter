using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.GameObjects;

namespace NetworkShooter.States.Base
{
    public abstract class GameState
    {
        protected MainGame game;
        protected readonly SpriteBatch _spriteBatch;

        public GameState(MainGame game, SpriteBatch spriteBatch)
        {
            this.game = game;
            _spriteBatch = spriteBatch;
        }

        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        public abstract void AddBullet(Bullet bullet);
        public abstract void RemoveBullet(Bullet bullet);
    }
}
