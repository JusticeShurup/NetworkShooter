using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.Animator
{
    public class AnimationFrame
    {
        public Rectangle Rectangle { get; private set; }

        public AnimationFrame(Rectangle rectangle) 
        {
            Rectangle = rectangle;
        }
    }
}
