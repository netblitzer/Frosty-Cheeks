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
        int numFrames = 15; // # frames in whole animation
        int framesElapsed; // frames elapsed since last checked for frames
        const int PLAYER_Y = 0; // how far down the sprite starts
        const int PLAYER_HEIGHT = 128; // how high the sprite box will be
        const int PLAYER_WIDTH = 128; // how wide the sprite box will be
        const int PLAYER_OFFSET = -10; // allows sprite to mirror properly

        const int SHORTS_WIDTH = 128;
        const int SHORTS_HEIGHT = 128;
        const int SHORTS_OFFSET = 0;
        bool jumping;
        float jumpspeed;
        float startY;
        float totalAliveTime;
        float frameTimer;

        private Sprite shortsSprite;

        private int shortsLength;

        public int ShortsLength
        {
            get { return shortsLength; }
            set { shortsLength = value; }
        }
        private double maxSpeed;
        private const double MIN_SPEED = 2;
        
        public Color collideColor = Color.Blue;
        private Color drawColor = Color.White;
        KeyboardState kState; // key state for input
        
        float shorterPowerupStrength = -0.2f;
        float longerPowerupStrength = 0.2f;

        float tempChange = -0.02f;
        float originalTemp;

        private float jumpHeight;
        public float JumpHeight
        {
            get { return jumpHeight; }
            set { jumpHeight = value; }
        }
        private float tempurature = 100;//The player's tempurate. 0 - coldest, 100 - hottest. Coorelate to hypothermia meter.
        public float Tempurature
        {
            get { return tempurature; }
            set { tempurature = value; }
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

        public bool godmode = true;
        public Player(float jump, float shorts, float temp, float _speed, Texture2D spriteSheet, Texture2D shortsSpriteSheet, Vector2 origPos)
            : base(2)
        {

            shortsLength = 6;
            maxSpeed = shortsLength * 2;

            originalTemp = Tempurature = 100;
            totalAliveTime = totalAliveTime = 0;
            #region Init player drawing
            //The player will slow down by 20% on hitting an obstacle
            /*string img, Vector2 loc, Rectangle rec, int frm, double tpf, int nf, int elaps, int sprty, int hght, int wdth, int offst*/
            SpriteObj = new Sprite("", Position, new Rectangle((frame % 4) * PLAYER_WIDTH, PLAYER_HEIGHT * (int)(frame / 4), PLAYER_WIDTH, PLAYER_HEIGHT), frame, timePerFrame, numFrames, framesElapsed, (int)originalPosition.Y, PLAYER_HEIGHT, PLAYER_WIDTH, PLAYER_OFFSET);
            SpriteObj.SpriteLocation = originalPosition = origPos;
            SpriteObj.SpriteTexture = spriteSheet;
            #endregion

            #region Init shorts drawing
            shortsSprite = new Sprite("", Position, new Rectangle(SHORTS_WIDTH * frame, shortsLength * (2048 - SHORTS_HEIGHT), SHORTS_WIDTH, SHORTS_HEIGHT), frame, timePerFrame, numFrames, framesElapsed, (int)originalPosition.Y, SHORTS_HEIGHT, SHORTS_WIDTH, SHORTS_OFFSET);
            shortsSprite.SpriteLocation = originalPosition = origPos;
            shortsSprite.SpriteTexture = shortsSpriteSheet;
            #endregion
        }
        private void AmbientTempuratureChange() {
            if (Tempurature > 0)
            {
                Tempurature += tempChange;
            }
        }
        private void CalculateSpeed(GameTime gameTime)//Will change the player's runnning speed based on his tempurater. Colder = slower, warmer = faster
        {
            Speed += (float)shortsLength * gameTime.ElapsedGameTime.Milliseconds / 2500;
            maxSpeed = shortsLength * 2;
            if (Speed > maxSpeed)
            {
                Speed = (float)maxSpeed;
            }
            if (Speed < MIN_SPEED)
            {
                Speed = (float)MIN_SPEED;
            }

        }
        public void PlayerUpdate(GameTime gameTime)
        {
            #region speed and temperature
            AmbientTempuratureChange();
            CalculateSpeed(gameTime);
            #endregion

            #region jumping
            //framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame); // check to see the total amount of frames so far
            //frame = framesElapsed % numFrames + 1; // frame your on is the total number of frames since launch modulated by how many frames there are +1

            // Test stuff
            frameTimer += gameTime.ElapsedGameTime.Milliseconds;
            while (frameTimer > timePerFrame)
            {
                frameTimer -= (float)timePerFrame;
                framesElapsed++;
            }
            frame = framesElapsed % numFrames + 1;


            kState = Keyboard.GetState();
            if (jumping)
            {
                SpriteObj.SpriteLocation = new Vector2(SpriteObj.SpriteLocation.X, SpriteObj.SpriteLocation.Y + jumpspeed);
                jumpspeed += 0.5f;
                if (SpriteObj.SpriteLocation.Y >= originalPosition.Y)
                {
                    SpriteObj.SpriteLocation = new Vector2(SpriteObj.SpriteLocation.X, originalPosition.Y);
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
            #endregion 

            // dev kill
            //Commented out so we dont forget to remove it later
            /*if (kState.IsKeyDown(Keys.Q))
            {
                tempurature = 0;
            }*/
            timePerFrame = 500 / Speed;
        }
        public void Draw(SpriteBatch sb) // sprite with animation
        {
            sb.Draw(SpriteObj.SpriteTexture, SpriteObj.SpriteLocation, new Rectangle((frame % 4) * PLAYER_WIDTH, PLAYER_HEIGHT * (int)(frame / 4), PLAYER_WIDTH, PLAYER_HEIGHT), drawColor, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            sb.Draw(shortsSprite.SpriteTexture, SpriteObj.SpriteLocation, new Rectangle(frame * SHORTS_WIDTH,(2048 - (shortsLength * SHORTS_HEIGHT)),SHORTS_WIDTH,SHORTS_HEIGHT), drawColor, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
        public void HitObstacle(Obstacle obs)
        {
            if(!obs.Destroyed){
                //Originally decremented temperature by 1/4 of the current temp but that led to obstacles doing very little damage near the end of the player's life
                Speed -= Speed / 2;
                Tempurature -= originalTemp / 5;
                obs.Destroyed = true;
            }
        }  
        public void HitPowerup(Powerup powerup)  
        {
                if(powerup is ShorterPowerup){
                    tempChange += (shorterPowerupStrength * tempChange);//Takes a percentage of the current temp and takes it away from temperature
                    shortsLength += 1;
                }else if(powerup is LongerPowerup){
                    tempChange -= (longerPowerupStrength * tempChange);
                    shortsLength -= 1;
                }else if(powerup is SuperSaiyan){
                    //Expand for a surprise...
                    #region Kammmeeeeee..
                    /*
                     *          _
              -._ \'.
               \ '.\_\_
            _.--'  _   '.---.
           /._   _<_)/)/ .-'
           _.-'- ([d,p]? _.-       .;
            '--.'-\ _ /-'--      .:'
              __  )'-'(  __    .:'
           .-/  ]' -Y- '[ /\ _:'
           /\|  | -----/ | ,r |
          |  ,\  \'= /'  .:\ "(
          | / /\; \,/  .:'  |_|
          \ _ )<   /  :' \ /__|
           '__\ {---:'-/  \(  )
           \_ _|/_:'-__]   '-'
             ) .:'    \ \
            (L:/  ;      \
           .:~'   |  .   7
         .:'  /   \   ' /\
       .;'    |\ . |;     )
      ;'      | '  |\'. _/|
              /'.' (\\..  |
             ( \. ,|\ '   /
             |\_  / \ ': /\
             \  //| |\  __/
             |\   )  \,___>
             <-'-/    \'  |
             |_ /      |=j|
          _.-' /       \  (
         '-----'        \  \
                         '-'
                     */
                    #endregion
                }
            powerup.Destroyed = true;
        }
        public bool IsColliding(GamePiece other)
        {
            if(godmode && other is Powerup){
                //Gets bounding box info from another GamePiece's sprite and uses MonoGame's built in method to check for a collision
                bool collide = false;
                Rectangle otherBoundingBox = other.GetBoundingBox();
                //GetBoundingBox().Intersects(ref otherBoundingBox, out collide);

                BoundingBox = new Rectangle((int)SpriteObj.SpriteLocation.X + 45, (int)SpriteObj.SpriteLocation.Y + 15, PLAYER_WIDTH - 95, PLAYER_HEIGHT - 20);
                return BoundingBox.Intersects(otherBoundingBox);

                //return collide;
            }else{
                return false;
            }
        }
        /*Write text to the debug console for testing stuffs*/
    }
}
