using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frosty_Cheeks
{
    /*AUTHOR: JOH of the JUNGLE
     3-15-15*/
    class Obstacle : MoveableGamePiece
    {
        bool destroyed = false;//When the player runs into an obstacle, this bool turns true so that we don't keep lowering the player's speed every update cycle
        public bool Destroyed
        {
            get { return destroyed; }
            set {destroyed = value; }
        }
        public Obstacle(float _speed)
            : base(_speed)
        {

        }
    }
}
