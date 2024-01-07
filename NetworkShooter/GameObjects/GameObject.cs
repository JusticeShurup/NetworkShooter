using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.Enum;
using System;
using System.Security.Cryptography.X509Certificates;

namespace NetworkShooter.GameObjects
{
    public class GameObject : DrawableGameComponent
    {
        protected readonly MainGame game;

        protected SpriteBatch _spriteBatch;
        protected Texture2D _texture;
        public Vector2 Position { get; protected set; }
        public double Rotation { get; protected set; }

        public float HitboxRadius { get; protected set; } = 5f;

        public GameObject(MainGame game, SpriteBatch spriteBatch) : base(game)
        {
            this.game = game;
            Position = new Vector2(0, 0);
            _spriteBatch = spriteBatch;
            Initialize();
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public bool Collision(GameObject other)
        {
            double distance = Math.Sqrt(Math.Pow(Position.X - other.Position.X, 2) + Math.Pow(Position.Y - other.Position.Y, 2));
            return distance <= HitboxRadius + other.HitboxRadius;
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
