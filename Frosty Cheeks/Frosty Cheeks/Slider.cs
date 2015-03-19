using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frosty_Cheeks
{
    class Slider
    {
        private int currentPosition; // current position of slider
        public int CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }

        private const int NUMBER_POSITIONS = 3; // number of positions the slider has
        public int Number_Positions
        {
            get { return NUMBER_POSITIONS; }
        }
    }
}
