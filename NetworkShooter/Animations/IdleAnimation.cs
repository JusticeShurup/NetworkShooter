using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.Animations
{
    public class IdleAnimation : Animation
    {
        public IdleAnimation(ContentManager manager) 
            : base(manager)
        {
            AnimationSheet = manager.Load<Texture2D>("SoldierSheet");
            _countFrames = 1;

            int frameWidth = 311;
            int frameHeight = AnimationSheet.Height;
            for (int i = 0; i < _countFrames; i++)
            {
                AnimationFrames.Add(new AnimationFrame(new Rectangle(frameWidth * i, 0, frameWidth, frameHeight)));
            }
        }


    }
}
