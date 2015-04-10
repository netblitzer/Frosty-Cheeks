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
    class Player : MoveableGamePiece
    {
        int frame; // frame of animation that is currently on
        double timePerFrame = 70; // set 100 ms per frame
        int numFrames = 6; // # frames in whole animation
        int framesElapsed; // frames elapsed since last checked for frames
        const int NEWTON_Y = 0; // how far down the sprite starts
        const int NEWTON_HEIGHT = 128; // how high the sprite box will be
        const int NEWTON_WIDTH = 150; // how wide the sprite box will be
        const int NEWTON_OFFSET = -10; // allows sprite to mirror properly
        bool jumping;
        float jumpspeed;
        float startY;
        public Color collideColor = Color.Blue;
        private Color drawColor = Color.White;
        KeyboardState kState; // key state for input
        #region temp collision testing vars
        float lastCollisionTime = 0;
        float rewarmWait = 0.5f;
        #endregion

        private float jumpHeight;
        public float JumpHeight
        {
            get { return jumpHeight; }
            set { jumpHeight = value; }
        }
        private float tempurature;//The player's tempurate. 0 - coldest, 100 - hottest. Coorelate to hypothermia meter.
        public float Tempurature
        {
            get { return tempurature; }
            set { tempurature = value; }
        }

        private float shortsLength;//The length of the player's shorts. Influcenced by power ups
        public float ShortsLength
        {
            get { return shortsLength; }
            set { shortsLength = value; }
        }
        private float obstacleSlowDown;

        public float ObstacleSlowDown
        {
            get { return obstacleSlowDown; }
            set { obstacleSlowDown = value; }
        }
        private Vector2 originalPosition;
        private bool inJump = false;
        private bool inFreefall = false;
        private float fallRate;
        private int verticalDirection;//0 = falling, 1 = jumping
        public bool invunderable = false;

        public Player(float jump, float shorts, float temp, float _speed, Texture2D spriteSheet, Vector2 origPos)
            : base(_speed)
        {

            Position = originalPosition = origPos;
           
            /*string img, Vector2 loc, Rectangle rec, int frm, double tpf, int nf, int elaps, int sprty, int hght, int wdth, int offst*/
            SpriteObj = new Sprite("", Position, new Rectangle(NEWTON_OFFSET + frame * NEWTON_WIDTH, NEWTON_Y, NEWTON_WIDTH, NEWTON_HEIGHT), frame, timePerFrame, numFrames, framesElapsed, (int)originalPosition.Y, NEWTON_HEIGHT, NEWTON_WIDTH, NEWTON_OFFSET);
            SpriteObj.SpriteTexture = spriteSheet;
        }
        public void PlayerUpdate(GameTime gameTime){
            
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame); // check to see the total amount of frames so far
            frame = framesElapsed % numFrames + 1; // frame your on is the total number of frames since launch modulated by how many frames there are +1
            kState = Keyboard.GetState();
            if (jumping)
            {
                Position = new Vector2(Position.X, Position.Y + jumpspeed);
                jumpspeed += 0.5f;
                if (Position.Y >= originalPosition.Y)
                {
                    Position = new Vector2(Position.X, originalPosition.Y);
                    jumping = false;
                }
            }
            else
            {
                if (kState.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpspeed = -14; // upward thrust
                }
            }
            //Check to see if the player should turn un-blue. Temporary until shorts level and cold is implemented
            if(invunderable){
                if(gameTime.TotalGameTime.Seconds < (lastCollisionTime + rewarmWait) ){//If the current time is greater than the last time we hit + the time we wait to un turn blue...
                    drawColor = Color.White;
                    invunderable = false;
                }
            }
        }
        public void Draw(SpriteBatch sb) // sprite with animation
        {
            sb.Draw(SpriteObj.SpriteTexture, Position, new Rectangle(NEWTON_OFFSET + frame * NEWTON_WIDTH, NEWTON_Y, NEWTON_WIDTH, NEWTON_HEIGHT), drawColor, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
        public void HitObstacle(GameTime gT)
        {
            if(!invunderable){
                lastCollisionTime = gT.TotalGameTime.Seconds;
                Speed -= obstacleSlowDown;
                drawColor = collideColor;
                invunderable = true;
                //Program.WriteLine("hit");
            }
        }
        public bool IsColliding(GamePiece other)
        {
            //Gets bounding box info from another GamePiece's sprite and uses MonoGame's built in method to check for a collision
            bool collide = false;
            Rectangle otherBoundingBox = other.GetBoundingBox();
            GetBoundingBox().Intersects(ref otherBoundingBox, out collide);
            return collide;
        }
        /*Write text to the debug console for testing stuffs*/
    }
}
