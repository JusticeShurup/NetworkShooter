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
    public class ReloadAnimation : Animation
    {
        public ReloadAnimation(ContentManager manager) 
            : base(manager)
        {
            AnimationSheet = manager.Load<Texture2D>("PerezaryadSheet");

            _countFrames = 12;

            int frameWidth = AnimationSheet.Width / 12;
            int frameHeight = AnimationSheet.Height;
            for (int i = 0; i < _countFrames; i++)
            {
                AnimationFrames.Add(new AnimationFrame(new Rectangle(frameWidth * i, 0, frameWidth, frameHeight)));
            }

        }
    }
}
