using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Frosty_Cheeks
{
    /*AUTHOR: JOH of the JUNGLE
     3-15-15*/
    class MoveableGamePiece : GamePiece
    {
        private float speed;//How fast the is Moveable moving. Negative numbers are moving left, positive are moving right.
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public MoveableGamePiece(float _speed) : base()
        {
            speed = _speed;
        }
    }
}
