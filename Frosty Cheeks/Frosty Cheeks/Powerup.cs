using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frosty_Cheeks
{
    class Powerup : MoveableGamePiece
    {
        private float strength;
        public float Strength
        {
            get { return strength; }
            set { strength = value; }
        }
    }
}
