using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frosty_Cheeks
{
    class Player : MoveableGamePiece
    {
        private float tempurature;//The player's tempurate. 0 - coldest, 100 - hottest. Coorelate to hypothermia meter.
        public float Tempurature
        {
            get { return tempurature; }
            set { tempurature = value; }
        }

        private float shortsLength;//The lenght of the player's shorts. Influcenced by power ups
        public float ShortsLength
        {
            get { return shortsLength; }
            set { shortsLength = value; }
        }
    }
}
