﻿using System;
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
        private int coldMeter; // how cold they are, blue meter
        public int ColdMeter
        {
            get { return coldMeter; }
            set { coldMeter = value; }
        }
        private const int METER_MAX = 100;
        public int Meter_Max
        {
            get { return METER_MAX; }
        }
    }
}
