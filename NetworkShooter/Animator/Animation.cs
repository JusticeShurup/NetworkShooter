using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.Animator
{
    public class Animation
    {
        private Texture2D _animationSheet;
        private List<AnimationFrame> animationFrames = new List<AnimationFrame>();


        private double _animationDuration = 2000;

        private int _countFrames;
        public AnimationFrame CurrentAnimationFrame
        {
            get
            {
                return animationFrames[_currentFrameIndex];
            }
        }

        private int _currentFrameIndex;

        private double _timer;

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

        public void Update(GameTime gameTime)
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
