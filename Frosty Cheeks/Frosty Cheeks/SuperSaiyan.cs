using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frosty_Cheeks
{
    /*AUTHOR: JOH of the JUNGLE
     3-15-15*/
    //Collectable powerup that inceases the player's speed and make him invincible for a period of time
    class SuperSaiyan : Powerup
    {
        float saiyanTime;//How long does the period of speed and invincibility last?
        public float SaiyanTime
        {
            get { return saiyanTime; }
            set { saiyanTime = value; }
        }

    }
}
