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
        private float maxSpeed;
        private float maxSpeedDelta;
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
        private bool rainbowMode = false;
        private int rainbowStartTime;
        private int rainbowModeLength = 5000;

        private Color shortsColor = Color.Blue;
        private Color[] shortsColors;
        private int randoColorIndex = 0;

        public bool godmode = false;
        private Random randoCalrission;
        public Player(float jump, float shorts, float temp, float _speed, Texture2D spriteSheet, Texture2D shortsSpriteSheet, Vector2 origPos)
            : base(2)
        {
            randoCalrission = new Random();

            shortsLength = 6;
            maxSpeed = shortsLength * 2;
            maxSpeedDelta = 0;

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
            Color red = Color.Red;

            shortsColors = new Color[]{Color.Purple, Color.Lime, Color.LightGreen, Color.MediumSlateBlue, Color.LightGoldenrodYellow};
            #endregion
        }
        private void AmbientTempuratureChange() {
            if(!godmode)
                Tempurature = Clamp(Tempurature + ((3 - shortsLength) / 300f), 0f, 100f);
        }
        private void CalculateSpeed(GameTime gameTime)//Will change the player's runnning speed based on his tempurater. Colder = slower, warmer = faster
        {
            if (shortsLength > 12)
            {
                shortsLength = 12; // limit max shorts length
            }
            if (shortsLength < 1)
            {
                shortsLength = 1; // limit min shorts length
            }
            //While we're in normal mode
            if(!rainbowMode){
                maxSpeedDelta += gameTime.ElapsedGameTime.Milliseconds / 12000f;
                maxSpeed = Clamp(shortsLength * 1.5f + maxSpeedDelta, 2f, 100f);
                Speed += (float)shortsLength * gameTime.ElapsedGameTime.Milliseconds / 2500;
                Speed = Clamp(Speed, 2f, maxSpeed);
            }
            else
            {
                //If we've been in rainbow mode for a few seconds, leave it
                if((gameTime.TotalGameTime.TotalMilliseconds - rainbowStartTime) > rainbowModeLength){
                    LeaveRainbowMode();
                }
                else
                {
                    //Raise all stats by 2 while in rainbow mode
                    maxSpeedDelta += 1.3f * (gameTime.ElapsedGameTime.Milliseconds / 12000f);
                    maxSpeed = 1.3f * (Clamp(shortsLength * 2f + maxSpeedDelta, 2f, 100f));
                    Speed += 1.3f * ((float)shortsLength * gameTime.ElapsedGameTime.Milliseconds / 2500);
                    Speed = 1.3f * (Clamp(Speed, 2f, maxSpeed));
                }
            }
        }
        public void PlayerUpdate(GameTime gameTime)
        {
            // Back up stuff to make sure we don't freak out with speed
            shortsLength = Clamp(shortsLength, 1, 12);
            if (shortsLength > 12)
                shortsLength = 12;
            else if (shortsLength < 1)
                shortsLength = 1;

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
                    jumpspeed = -10.5f; // upward thrust
                }
            }
            #endregion 

            // dev kill
            //Commented out so we dont forget to remove it later
            if (kState.IsKeyDown(Keys.Q))
            {
                tempurature = 0;
            }
            if (kState.IsKeyDown(Keys.G))
                godmode = !godmode;
            timePerFrame = 500 / Speed;

            if (rainbowMode)
            {   
                randoColorIndex++;
                if((randoColorIndex) >= shortsColors.Length - 1){
                    randoColorIndex = 0;
                }
            }
        }
        public void Draw(SpriteBatch sb) // sprite with animation
        {
            sb.Draw(SpriteObj.SpriteTexture, SpriteObj.SpriteLocation, new Rectangle((frame % 4) * PLAYER_WIDTH, PLAYER_HEIGHT * (int)(frame / 4), PLAYER_WIDTH, PLAYER_HEIGHT), drawColor, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            if(rainbowMode){
                sb.Draw(shortsSprite.SpriteTexture, SpriteObj.SpriteLocation, new Rectangle(frame * SHORTS_WIDTH,(2048 - (shortsLength * SHORTS_HEIGHT)),SHORTS_WIDTH,SHORTS_HEIGHT), shortsColors[Clamp(((frame / 3) * randoColorIndex), 0, shortsColors.Length - 1)], 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }else{
                sb.Draw(shortsSprite.SpriteTexture, SpriteObj.SpriteLocation, new Rectangle(frame * SHORTS_WIDTH, (2048 - (shortsLength * SHORTS_HEIGHT)), SHORTS_WIDTH, SHORTS_HEIGHT), shortsColors[0], 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
        }
        public void HitObstacle(Obstacle obs)
        {
            if(!obs.Destroyed && !invunderable){
                //Originally decremented temperature by 1/4 of the current temp but that led to obstacles doing very little damage near the end of the player's life
                Speed -= Speed / 2;
                Tempurature -= originalTemp / 5;
                obs.Destroyed = true;
            }
        }  
        public void HitPowerup(Powerup powerup, GameTime gameTime)  
        {
            // tempchange stuff is no longer needed. Temperature change is done based on shorts now
            if(powerup is ShorterPowerup)
            {
                //tempChange += (shorterPowerupStrength * tempChange);//Takes a percentage of the current temp and takes it away from temperature
                shortsLength = Clamp(shortsLength + 1, 1, 12);
            }
            else if(powerup is LongerPowerup)
            {
                //tempChange -= (longerPowerupStrength * tempChange);
                shortsLength = Clamp(shortsLength - 1, 1, 12);
            }
            else if(powerup is RainbowPowerup)
            {
                //Expand for a surprise...
                EnterRainbowMode(gameTime);
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
        private void EnterRainbowMode(GameTime gameTime)
        {
            rainbowMode = true;
            rainbowStartTime = (int)gameTime.TotalGameTime.TotalMilliseconds;
            invunderable = true;
            shortsColor = Color.Pink;
        }
        private void LeaveRainbowMode()
        {
            rainbowMode = false;
            invunderable = false;
            shortsColor = Color.Blue;
        }

        public bool IsColliding(GamePiece other)
        {
            //Gets bounding box info from another GamePiece's sprite and uses MonoGame's built in method to check for a collision
            bool collide = false;
            Rectangle otherBoundingBox = other.GetBoundingBox();
            //GetBoundingBox().Intersects(ref otherBoundingBox, out collide);

            BoundingBox = new Rectangle((int)SpriteObj.SpriteLocation.X + 45, (int)SpriteObj.SpriteLocation.Y + 15, PLAYER_WIDTH - 95, PLAYER_HEIGHT - 20);
            return BoundingBox.Intersects(otherBoundingBox);

            //return collide;
        }
        private int Clamp(int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;

            return val;
        }

        private float Clamp(float val, float min, float max)
        {
            if (val <= min)
                return min;
            else if (val >= max)
                return max;

            return val;
        }
    }
}
