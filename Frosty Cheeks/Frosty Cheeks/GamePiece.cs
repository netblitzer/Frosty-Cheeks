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
       /* private whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
        private whiteRectangle.SetData(new[] { Color.White });*/
        private Vector2 position;//Position in realtion to the game world
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
                
        private Sprite spriteObj;
        public Sprite SpriteObj
        {
            get { return spriteObj; }
            set { spriteObj = value; }
        }
        private Rectangle boundingBox;

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }

        public GamePiece(Vector2 pos)
        {
            position = pos;
        }
        public GamePiece()
        {
            position = Vector2.Zero;
        }
        public Rectangle GetBoundingBox(){
            Rectangle box = new Rectangle((int)spriteObj.SpriteLocation.X, (int)spriteObj.SpriteLocation.Y, spriteObj.SpriteWidth, spriteObj.SpriteWidth);
            
            boundingBox = box;
            return box;
            //Added this method because MonoGame's Rectangle.Intersects doesn't let you use a property as the other Rectangle's param. See IsColliding()
        }
        public void DrawBoundingBox(SpriteBatch spriteBatch, Texture2D boundingBoxTex)
        {
            spriteBatch.Draw(boundingBoxTex, boundingBox, Color.Red);
        }
    }
}
