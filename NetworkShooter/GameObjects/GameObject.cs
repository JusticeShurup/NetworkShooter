using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.Enum;
using System;

namespace NetworkShooter.GameObjects
{
    public class GameObject : DrawableGameComponent
    {
        protected SpriteBatch _spriteBatch;

        protected Texture2D _texture;
        public Vector2 Position { get; protected set; }
        public double Rotation { get; protected set; }



        public GameObject(Game game, SpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
            Initialize();
        }

        public override void Initialize() 
        {
            DrawOrder = 100;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
