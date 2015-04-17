#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

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
        public SuperSaiyan(float _speed, Texture2D texture) : base(_speed, texture)
        {

        }
    }
}
