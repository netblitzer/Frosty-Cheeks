#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Frosty_Cheeks
{
    /*AUTHOR: JOH of the JUNGLE
     3-15-15*/
    class Powerup : MoveableGamePiece
    {
        private bool destroyed = false;
        //private int speed;
        private float strength;
        public float Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public Powerup(float _speed, Texture2D texture, float spawnX)
            : base(_speed)
        {

            Position = new Vector2(spawnX, 280);
            SpriteObj = new Sprite("", Position, (int)Position.Y, texture.Height, texture.Width);
            SpriteObj.SpriteTexture = texture;
        }
        public void Update(GameTime gameTime)
        {
           Position = new Vector2(Position.X - Speed, Position.Y);
        }
        public void Draw(SpriteBatch sb) // sprite with animation
        {
            sb.Draw(SpriteObj.SpriteTexture, Position, new Rectangle(0,0,SpriteObj.SpriteWidth, SpriteObj.SpriteHeight), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
