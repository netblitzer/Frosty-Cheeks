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
    //Collectable power up that decreases the lenght of player's shorts. Increaes cold
    class ShorterPowerup : Powerup
    {
        public ShorterPowerup(float _speed, Texture2D texture) : base(_speed, texture)
        {

        }
    }
}
