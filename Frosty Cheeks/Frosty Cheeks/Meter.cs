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
    class Meter:GUIObject
    {
        private float coldMeter; // how cold they are, blue meter
        public float ColdMeter
        {
            get { return coldMeter; }
            set 
            {
                coldMeter = value;
            }
        }
        private const float METER_MAX = 100;
        public float Meter_Max
        {
            get { return METER_MAX; }
        }
    }
}
