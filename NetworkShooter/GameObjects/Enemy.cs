using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.GameObjects
{
    public class Enemy
        : GameObject
    {

        private readonly ContentManager _contentManager;
        private readonly Player _player;

        private int x = 10;

        public Enemy(MainGame game, SpriteBatch spriteBatch, Player player) 
            : base(game, spriteBatch)
        {
            HitboxRadius = 50f;
            _player = player;
            _contentManager = game.Content;
            _texture = _contentManager.Load<Texture2D>("zombie");
        }


        public override void Update(GameTime gameTime)
        {
            var target = _player.Position;
            
            var adjucentLeg = Math.Abs(target.X - Position.X);
            var opposingLeg = Math.Abs(target.Y - Position.Y);

            double tgAlpha = 0;

            if (adjucentLeg != 0)
            {
                tgAlpha = opposingLeg / adjucentLeg;
            }
            else
            {
                return;
            }
            float alpha = (float)Math.Atan(tgAlpha);
            
            float stepX = (float)Math.Cos(alpha) * Math.Sign(target.X - Position.X) * gameTime.ElapsedGameTime.Milliseconds / 10;
            float stepY = (float)Math.Sin(alpha) * Math.Sign(target.Y - Position.Y) * gameTime.ElapsedGameTime.Milliseconds / 10;


            Position += new Vector2(stepX, stepY);


            Vector2 direction = _player.Position - Position;
            direction.Normalize();
            float rotationAngle = (float)Math.Atan2(direction.Y, direction.X) + 1.57f;
            Rotation = rotationAngle;

        }

        protected override void LoadContent()
        {
        
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(transformMatrix: Camera.Translation);
            _spriteBatch.Draw(_texture, Position, new Rectangle(0, 0, _texture.Width, _texture.Height), Color.White, (float)Rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), 1f, SpriteEffects.None, 1);
            _spriteBatch.End();
        }

    }
}
