using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        public int SpriteHeight
        {
            get { return spriteHeight; }
        }
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

        // constructor
        public Sprite(Texture2D img, Vector2 loc, Rectangle rec, int frm, double tpf, int nf, int elaps, int sprty, int hght, int wdth, int offst)
        {
            spriteTexture = img;
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

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch) // placeholder for overwritten draw
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

    }
}
