using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NetworkShooter.Animator;
using System;

namespace NetworkShooter.GameObjects
{
    public class Player : GameObject
    {
        private readonly float fireCooldown = 100f;
        private float fireCooldownTimer = 0;

        private Animation _animation;

        public Player(Game game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch) 
            : base(game, spriteBatch)
        {
         
        }

        private float CalculateBulletPosition()
        {
            return (float)Math.Sqrt(Math.Pow(_texture.Width / 17, 2) + Math.Pow(_texture.Height, 2));
        }

        private void HandleInput(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && fireCooldownTimer >= fireCooldown)
            {

                
                fireCooldownTimer = 0;
                Vector2 mousePosition = Camera.ScreenToWorldSpace(Mouse.GetState().Position.ToVector2());
                Vector2 direction = mousePosition - Position;

                Vector2 centeredPoint = Position + new Vector2(42.5f, -205) - Position;

                Vector2 rotatedPoint = new Vector2(
                    centeredPoint.X * (float)Math.Cos(Rotation) - centeredPoint.Y * (float)Math.Sin(Rotation),
                    centeredPoint.X * (float)Math.Sin(Rotation) + centeredPoint.Y * (float)Math.Cos(Rotation)
                );

                Vector2 finalPoint = rotatedPoint + Position;

                direction.Normalize();
                Game.Components.Add(new Bullet(Game, _spriteBatch, finalPoint, direction));
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.D))
            {

                Vector2 newPosition = Vector2.Zero;
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    newPosition.Y += 1f * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    newPosition.Y -= 1f * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    newPosition.X -= 1f * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    newPosition.X += 1f * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }

                newPosition.Normalize();
                newPosition *= 10f;

                Position += newPosition;
            }
        }

        private void RotatePlayer()
        {
            Vector2 mousePosition = Camera.ScreenToWorldSpace(Mouse.GetState().Position.ToVector2());
            Vector2 direction = mousePosition - Position;
            direction.Normalize();
            float rotationAngle = (float)Math.Atan2(direction.Y, direction.X) + 1.57f;
            Rotation = rotationAngle;

        }


        public override void Initialize()
        {

            Position = new Vector2(100, 100);
            _texture = Game.Content.Load<Texture2D>("SoldierSheet");
            _animation = new WalkAnimation(_texture, 17, 2000);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            fireCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            HandleInput(gameTime);
            RotatePlayer();

            Camera.Rotation = (float)Rotation;
            Camera.Update(Position);

            _animation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(transformMatrix: Camera.Transform);
            _spriteBatch.Draw(_texture, Position, _animation.CurrentAnimationFrame.Rectangle, Color.White, (float)Rotation, new Vector2(_texture.Width / 17 / 2, _texture.Height / 2), 1, SpriteEffects.None, 0);
            _spriteBatch.End();
        }


    }
}
