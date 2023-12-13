using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace NetworkShooter.Animator
{
    public abstract class Animation
    {
        protected Texture2D _animationSheet;
        protected List<AnimationFrame> animationFrames = new List<AnimationFrame>();
        protected double _animationDuration = 2000;
        protected int _countFrames;

        public AnimationFrame CurrentAnimationFrame
        {
            get
            {
                return animationFrames[_currentFrameIndex];
            }

            protected set 
            {
                animationFrames[_currentFrameIndex] = value;
            }
        }

        protected int _currentFrameIndex;

        protected double _timer;

        public Animation(Texture2D animationSpriteSheet, int framesCount, double animationDuration)
        {
            _animationSheet = animationSpriteSheet;
            _countFrames = framesCount;
            _animationDuration = animationDuration;

            int frameWidth = _animationSheet.Width / _countFrames;
            int frameHeight = _animationSheet.Height;
            for (int i = 0; i < _countFrames; i++)
            {
                animationFrames.Add(new AnimationFrame(new Rectangle(frameWidth * i, 0, frameWidth, frameHeight)));
            }
        }

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
