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

// Ethan Nicholas

namespace Frosty_Cheeks
{
    class Meter:GUIObject
    {
        private float coldMeter; // how cold they are, blue meter
        public float ColdMeter
        {
            get { return coldMeter; }
            set { coldMeter = value; }
        }
        private const int METER_MAX = 100; // maximum of meter
        public int Meter_Max
        {
            get { return METER_MAX; }
        }

        public Meter(Vector2 pos, Sprite sprite)
            : base(pos, sprite)
        {
            coldMeter = 0; // start the cold meter at zero
        } 
    }
}
