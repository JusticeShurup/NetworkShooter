using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace NetworkShooter.GameObjects
{
    public class Bullet : GameObject
    {
        public Vector2 Direction { get; private set; }
        public float BulletSpeed { get; private set; }

        public Bullet(Game game, SpriteBatch spriteBatch, Vector2 position, Vector2 direction) 
            : base(game, spriteBatch)
        {
            Position = position;
            Direction = direction;
            direction.Normalize();
            BulletSpeed = 0.25f;

        }

        ~Bullet() 
        {
            Console.WriteLine("I am done");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Game.Components.FirstOrDefault(this) != null)
                {
                    Game.Components.Remove(this);
                }
            }
            base.Dispose(disposing);
        }

        public override void Initialize()
        {
            _texture = Game.Content.Load<Texture2D>("Bullet");

            base.Initialize();
            DrawOrder = 101;
        }


        public override void Update(GameTime gameTime)
        {
            Position += Direction * (float)gameTime.ElapsedGameTime.TotalMilliseconds * BulletSpeed;

            if (Math.Abs(Position.X) >= 10000 || Math.Abs(Position.Y) >= 10000)
            {
                Dispose(true);
                return;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin(transformMatrix: Camera.Transform);
            _spriteBatch.Draw(_texture, Position, new Rectangle(0, 0, _texture.Width, _texture.Height), Color.White, 0, Vector2.Zero, 0.25f, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
