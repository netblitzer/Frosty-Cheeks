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
    class Button:GUIObject

    {
        private Rectangle buttonRect; // rectangle for where button is
        public Rectangle ButtonRect
        {
            get { return buttonRect; }
        }
        
    }
}
