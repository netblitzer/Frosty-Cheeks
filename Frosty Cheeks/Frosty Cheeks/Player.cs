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
    class Player : MoveableGamePiece
    {
        private float jumpHeight;
        public float JumpHeight
        {
            get { return jumpHeight; }
            set { jumpHeight = value; }
        }
        private float tempurature;//The player's tempurate. 0 - coldest, 100 - hottest. Coorelate to hypothermia meter.
        public float Tempurature
        {
            get { return tempurature; }
            set { tempurature = value; }
        }

        private float shortsLength;//The length of the player's shorts. Influcenced by power ups
        public float ShortsLength
        {
            get { return shortsLength; }
            set { shortsLength = value; }
        }
        private float obstacleSlowDown;

        public float ObstacleSlowDown
        {
            get { return obstacleSlowDown; }
            set { obstacleSlowDown = value; }
        }
        private Vector2 originalPosition;
        private bool inJump = false;
        private bool inFreefall = false;
        private float fallRate;
        private int verticalDirection;//0 = falling, 1 = jumping

        public Player(float jump, float shorts, float temp, float _speed)
            : base(_speed)
        {

        }

        public void HitObstacle()
        {

            Speed -= obstacleSlowDown;
        }
        public void PlayAnimation()
        {

        }
    }
}
