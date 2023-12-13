using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.Animator
{
    public class WalkAnimation : Animation
    {
        public WalkAnimation(Texture2D animationSpriteSheet, int framesCount, double animationDuration)
                : base(animationSpriteSheet, framesCount, animationDuration)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
