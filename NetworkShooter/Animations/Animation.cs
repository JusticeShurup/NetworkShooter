using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace NetworkShooter.Animations
{
    public abstract class Animation 
    {
        public Texture2D AnimationSheet { get; protected set; }
        public List<AnimationFrame> AnimationFrames { get; protected set; } = new List<AnimationFrame>();

        protected double _animationDuration = 2000;
        protected int _countFrames;

        public AnimationFrame CurrentAnimationFrame
        {
            get
            {
                return AnimationFrames[_currentFrameIndex];
            }

            protected set 
            {
                AnimationFrames[_currentFrameIndex] = value;
            }
        }

        protected int _currentFrameIndex;
        protected double _timer;

        public Animation(ContentManager manager) {}

        public virtual void Update(GameTime gameTime)
        {
            _timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_timer >= _animationDuration / _countFrames)
            {
                _timer = 0;
                _currentFrameIndex++;
                if (_currentFrameIndex >= _countFrames)
                {
                    _currentFrameIndex = 0;
                }
            }
        }


    }
}
