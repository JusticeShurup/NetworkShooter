using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NetworkShooter;
using NetworkShooter.Animations;
using System;

namespace NetworkShooter.GameObjects
{
    public class Player : GameObject
    {

        private Animator animator;

        private readonly float fireCooldown = 100f;
        private float fireCooldownTimer = 0;
        private float reloadAnimationTimer = 0;
        public int Bullets { get; private set; } = 30;
        public PlayerState playerState { get; private set; } = PlayerState.IDLE;

        public Player(MainGame game, SpriteBatch spriteBatch) 
            : base(game, spriteBatch)
        {
            animator = new Animator(game, this);
        }

        private float CalculateBulletPosition()
        {
            return (float)Math.Sqrt(Math.Pow(_texture.Width / 17, 2) + Math.Pow(_texture.Height, 2));
        }

        private void HandleInput(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && fireCooldownTimer >= fireCooldown && playerState != PlayerState.RELOAD && Bullets > 0)
            {   
                fireCooldownTimer = 0;
                Vector2 mousePosition = Camera.ScreenToWorldSpace(Mouse.GetState().Position.ToVector2());
                Vector2 direction = mousePosition - Position;

                Vector2 centeredPoint = Position + new Vector2(42.5f / 2, -205 / 2) - Position;

                Vector2 rotatedPoint = new Vector2(
                    centeredPoint.X * (float)Math.Cos(Rotation) - centeredPoint.Y * (float)Math.Sin(Rotation),
                    centeredPoint.X * (float)Math.Sin(Rotation) + centeredPoint.Y * (float)Math.Cos(Rotation)
                );

                Vector2 finalPoint = rotatedPoint + Position;

                direction.Normalize();
                var bullet = new Bullet(game, _spriteBatch, finalPoint, direction);
                game.AddBullet(bullet);
                Bullets -= 1;
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.D)) && playerState != PlayerState.RELOAD)
            {
                playerState = PlayerState.WALK;
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

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                playerState = PlayerState.RELOAD;
                reloadAnimationTimer = 0;
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
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (reloadAnimationTimer >= 1200)
            {
                if (playerState == PlayerState.RELOAD) Bullets = 30;
                playerState = PlayerState.IDLE;
            }
            fireCooldownTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            reloadAnimationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            HandleInput(gameTime);
            RotatePlayer();

            Camera.Update(Position, (float) Rotation);

            animator.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            animator.Draw(gameTime, _spriteBatch, (float)Rotation);
        }


    }
}
