using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Player(float jump, float shorts, float temp, float _speed) : base(_speed)
        {

        }
        public void Jump()
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
