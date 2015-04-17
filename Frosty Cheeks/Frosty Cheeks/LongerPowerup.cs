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
    //Collectable powerup that increases the length of player's shorts. Decreaes cold
    class LongerPowerup : Powerup
    {
        public LongerPowerup(float _speed, Texture2D texture) : base(_speed, texture)
        {

        }
    }
}
