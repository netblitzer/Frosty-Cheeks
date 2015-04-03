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
    class Slider:GUIObject
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

        // constructor
        public Slider(Vector2 pos, Sprite sprite)
            : base(pos, sprite)
        {
            currentPosition = 0;
        }
    }
}
