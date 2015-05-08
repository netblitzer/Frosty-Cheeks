using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Frosty_Cheeks
{
    /*
     * Author: Ethan Nicholas
     */
    class Sprite
    {
        // attributes and properties
        private Texture2D spriteTexture; // texture object used to draw sprite
        public Texture2D SpriteTexture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        private Vector2 spriteLocation; // location of sprite
        public Vector2 SpriteLocation
        {
            get { return spriteLocation; }
            set { spriteLocation = value; }
        }
        private Rectangle spriteRect; // rectangle used to contain sprite object
        public Rectangle SpriteRect
        {
            get { return spriteRect; }
            set { spriteRect = value; }
        }
        private int frame; // frame of animation that sprite animation is currently on
        public int Frame
        {
            get { return frame; }
            set { frame = value; }
        }
        private double timePerFrame; // time each frame of animation is displayed for
        public double TimePerFrame
        {
            get { return timePerFrame; }
        }
        private int numFrames; // number of frames in sprite's animation cycle
        public int NumFrames
        {
            get { return numFrames; }
        }
        private int framesElapsed; //frames elapsed since last checked for frames
        public int FramesElapsed
        {
            get { return framesElapsed; }
            set { framesElapsed = value; }
        }
        private int sprite_Y; // starting height of sprite
        public int Sprite_Y
        {
            get { return sprite_Y; }
        }
        private int spriteHeight; // height of sprite/ sprite's rectangle
        public int SpriteHeight
        {
            get { return spriteHeight; }
        }
       /* public int SpriteHeight
        {
            get { return spriteHeight; }
        }*/
        private int spriteWidth; // width of sprite/ sprite's rectangle
        public int SpriteWidth
        {
            get { return spriteWidth; }
        }
        private int spriteOffset; // allows sprite to mirror properly (if needed)
        public int SpriteOffset
        {
            get { return spriteOffset; }
        }
        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
        }

        // constructor
        public Sprite(string img, Vector2 loc, Rectangle rec, int frm, double tpf, int nf, int elaps, int sprty, int hght, int wdth, int offst) // sprite with animation
        {
            imagePath = img;
            spriteLocation = loc;
            spriteRect = rec;
            frame = frm;
            timePerFrame = tpf;
            numFrames = nf;
            framesElapsed = elaps;
            sprite_Y = sprty;
            spriteHeight = hght;
            spriteWidth = wdth;
            spriteOffset = offst;
            
        }

        public Sprite(string img, Vector2 loc, int sprty, int hght, int wdth) // sprite without animation
        {
            imagePath = img;
            spriteLocation = loc;
            sprite_Y = sprty;
            spriteHeight = hght;
            spriteWidth = wdth;
            spriteRect = new Rectangle(0, 0, spriteWidth, spriteHeight);
        }

        

       public void Draw(GameTime gametime, SpriteBatch spriteBatch) // placeholder for overwritten draw
        {
            // draw image from sprite sheet
            spriteBatch.Draw(
                spriteTexture, // spritesheet
                spriteLocation, // where it appears
                spriteRect, // part of spritesheet drawn
                Color.White, // dont change color
                0, // no rotation
                Vector2.Zero, // no center of rotation
                1, // not scaled
                SpriteEffects.None, // no sprite effects
                0 // no depth setting
                );
        }

       public void DrawScale(GameTime gametime, SpriteBatch spriteBatch) // placeholder for overwritten draw with a scale method thingy
       {
           // draw image from sprite sheet
           spriteBatch.Draw(
               spriteTexture, // spritesheet
               spriteLocation, // where it appears
               spriteRect, // part of spritesheet drawn
               Color.White, // dont change color
               0, // no rotation
               Vector2.Zero, // no center of rotation

               // Change this part later
               new Vector2((float)480 / spriteWidth, (float)480 / spriteHeight),
               // Change this part later

               SpriteEffects.None, // no sprite effects
               0 // no depth setting
               );
       }
       public void DrawScale(GameTime gametime, SpriteBatch spriteBatch, int scaleX, int scaleY) // placeholder for overwritten draw with a scale method thingy
       {
           // draw image from sprite sheet
           spriteBatch.Draw(
               spriteTexture, // spritesheet
               spriteLocation, // where it appears
               spriteRect, // part of spritesheet drawn
               Color.White, // dont change color
               0, // no rotation
               Vector2.Zero, // no center of rotation

               // Change this part later
               new Vector2((float)scaleX / spriteWidth, (float)scaleY / spriteHeight),
               // Change this part later

               SpriteEffects.None, // no sprite effects
               0 // no depth setting
               );
       }
    }
}
