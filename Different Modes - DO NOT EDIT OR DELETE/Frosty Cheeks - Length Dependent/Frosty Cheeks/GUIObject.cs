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
    abstract class GUIObject
    {
        // attributes
        private Vector2 position; // position of the gui object on screen
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        private Sprite guiSprite; // image for GUI object
        public Sprite GuiSprite
        {
            get { return guiSprite; }
            set { guiSprite = value; }
        }

        // constructor
        public GUIObject(Vector2 pos, Sprite sprite)
        {
            position = pos; // position of object on screen
            guiSprite = sprite; // sprite/image of the object that's drawn to the screen
        }

    }
}
