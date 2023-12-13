using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShooter.GameObjects
{
    public abstract class PlayerState
    {
        protected Player player;


        public PlayerState(Player player)
        {

        }

        public abstract void Update();

        

    }
}
