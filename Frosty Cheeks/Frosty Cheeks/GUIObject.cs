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
    abstract class GUIObject
    {
        // attributes
        private Vector2 position; // position of the gui object on screen
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Texture2D guiTexture; // image for GUI object
        public Texture2D ButtonTexture
        {
            get { return guiTexture; }
            set { guiTexture = value; }
        }

    }
}
