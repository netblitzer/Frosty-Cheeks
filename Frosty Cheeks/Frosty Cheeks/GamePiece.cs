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
    /*AUTHOR: JOH of the JUNGLE
     3-15-15*/
    class GamePiece
    {
        private Vector2 globalPosition;//Position in realtion to the game world
        public Vector2 Globalosition
        {
            get { return globalPosition; }
            set { globalPosition = value; }
        }
        private Vector2 localPosition;//Position in realtion to frame that owns this GamePiece (Not sure if we'll need this)
        /*TODO: Will implement when Sprite class is in place
        private Sprite sprite;
        public SpriteObj
        {
            get { return sprite; }
            set { sprite = value; }
        }*/
        public GamePiece(Vector2 pos)
        {
            globalPosition = pos;
        }
        public GamePiece()
        {
            globalPosition = Vector2.Zero;
        }
    }
}
