using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NetworkShooter.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.Animations
{
    public class Animator : DrawableGameComponent
    {
        public Animation _animation;
        private readonly Player _player;
        public float _animationSpeed;

        private float _animationChangeTimer = 0;

        private readonly Microsoft.Xna.Framework.Game _game;

        public Animator(Microsoft.Xna.Framework.Game game, Player player) : base(game)
        {
            _game = game;


            _animation = new ReloadAnimation(game.Content);
            _player = player;
        }

        public override void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);

            _animationChangeTimer += (float) gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_player.playerState == PlayerState.RELOAD )
            {
                if (_animation.GetType() == typeof(ReloadAnimation)) return;
                _animation = new ReloadAnimation(_game.Content);
            }


            if (_player.playerState == PlayerState.IDLE && _animation.GetType() != typeof(IdleAnimation) && _animationChangeTimer > 150)
            {
                _animation = new IdleAnimation(_game.Content);
            }
            else if (_player.playerState == PlayerState.WALK && _animation.GetType() != typeof(WalkAnimation))
            {
                _animation = new WalkAnimation(_game.Content);
            }
            else if (_player.playerState == PlayerState.WALK)
            {
                _animationChangeTimer = 0;
            }

            



            base.Update(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, float rotation)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_animation.AnimationSheet, new Vector2(1920f / 2, 1080f / 2), _animation.CurrentAnimationFrame.Rectangle, Color.White, rotation, new Vector2(311 / 2, _animation.AnimationSheet.Height / 2), 0.5f ,SpriteEffects.None, 1); 
            spriteBatch.End();

        }
    }
}
