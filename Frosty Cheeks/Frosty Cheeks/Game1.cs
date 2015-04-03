#region Using Statements
using System;
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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // needed things
        KeyboardState kState; // key state for input
        Player player; // player obj
        List<Frame> frames; // Frames list
        List<Obstacle> obstacles;
        Meter hypoMeter; // hypothermia meter
        Texture2D thermo;
        SpriteFont distanceFont;
        float distanceScore;

        //temp pic
        Texture2D framePic;
        Texture2D obstaclePic;

        #region Newton Things
        Texture2D spriteSheet; // sprite sheet to load
        Vector2 newtonLoc; // location of character
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
        #endregion

        #region Test Shit
        Obstacle pebble;
        Texture2D toilerFace;
        Texture2D pebblePic;
        float hypoChange;
        #endregion


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            #region Newton Initialize
            newtonLoc = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);
            jumping = false;
            jumpspeed = 0;
            startY = Window.ClientBounds.Height / 2;
            #endregion

            Frame.InitializeFrames();
            player = new Player(1, 1, 1, 1);
            frames = new List<Frame>();
            hypoMeter = new Meter(new Vector2(625, 20), new Sprite("thermometer.png", Vector2.Zero, 0, 64, 128));
            hypoMeter.ColdMeter = 0;
            hypoChange = 0.25f;

            //add frames
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));

            for (int i = 0; i < frames.Count; i++)
            {
                frames[i].FrameSprite.SpriteLocation = new Vector2((1024 * i), frames[i].FrameSprite.SpriteLocation.Y);
                //Obstacle obs = new Obstacle(0);
                //obs.Position = new Vector2(1000, 700);
                //obs.SpriteObj = new Sprite("pebble.png", obs.Position, (int)obs.Position.Y, 66, 100);
                //frames[i].Obstacles.Add(obs);
            }

            #region Test Shit
            #endregion

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Load in textures here - who has the textures?
            spriteSheet = Content.Load<Texture2D>("newton.png"); // LOAD IN CHARACTER SPRITESHEET HERE
            thermo = Content.Load<Texture2D>("thermometer.png"); // thermometer
            distanceFont = Content.Load<SpriteFont>("font");
            foreach (Frame frameLoad in frames)
            {
                frameLoad.FrameSprite.SpriteTexture = Content.Load<Texture2D>(frameLoad.FrameSprite.ImagePath);
                foreach (Obstacle obstacle in frameLoad.Obstacles)
                {
                    obstacle.SpriteObj.SpriteTexture = Content.Load<Texture2D>("toiler.png");
                }

                //frameLoad.Obstacles[0].SpriteObj.SpriteTexture = Content.Load<Texture2D>("toiler.png");
                //frameLoad.Obstacles[1].SpriteObj.SpriteTexture = Content.Load<Texture2D>("pebble.png");
            }

            //temp fix
            framePic = Content.Load<Texture2D>(frames[0].FrameSprite.ImagePath);
            pebblePic = Content.Load<Texture2D>("pebble.png");
            obstaclePic = Content.Load<Texture2D>("toiler.png");

            #region Test Shit
            toilerFace = Content.Load<Texture2D>("toiler.png");
            #endregion
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //distanceScore += .005f;
            
            foreach (Frame frameUpdate in frames)
            {
                frameUpdate.FrameSprite.SpriteLocation = new Vector2(frameUpdate.FrameSprite.SpriteLocation.X - 3f, 0);
                
                foreach (Obstacle obstacle in frameUpdate.Obstacles)
                {
                    // Scales the location of stuff to the viewport for now
                    obstacle.SpriteObj.SpriteLocation = new Vector2(obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, obstacle.Position.Y / (1024 / GraphicsDevice.Viewport.Height));
                    if ((obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - newtonLoc.X <= 2 && (obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - newtonLoc.X >= 0)
                    {
                        distanceScore++;
                    }
                }

                // Frame code is working now
                /*
                frameUpdate.Obstacles[0].SpriteObj.SpriteLocation = new Vector2(frameUpdate.Obstacles[0].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, 150);
                frameUpdate.Obstacles[1].SpriteObj.SpriteLocation = new Vector2(frameUpdate.Obstacles[1].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, 300);
                if ((frameUpdate.Obstacles[0].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - newtonLoc.X <= 2 && (frameUpdate.Obstacles[0].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - newtonLoc.X >= 0)
                {
                    distanceScore++;
                }
                */
            }

            if (frames[0].FrameSprite.SpriteLocation.X <= -1024)
            {
                frames.RemoveAt(0);
                frames.Add(new Frame(1));
                frames[frames.Count - 1].FrameSprite.SpriteLocation = new Vector2(frames[frames.Count - 2].FrameSprite.SpriteLocation.X + 1024, frames[frames.Count - 1].FrameSprite.SpriteLocation.Y);
                frames[frames.Count - 1].FrameSprite.SpriteTexture = Content.Load<Texture2D>(frames[frames.Count - 1].FrameSprite.ImagePath);
                // Setting all the new obstacles images to toiler
                foreach (Obstacle obs in frames[frames.Count - 1].Obstacles)
                {
                    obs.SpriteObj.SpriteTexture = Content.Load<Texture2D>("toiler.png");
                }
                //frames[frames.Count - 1].Obstacles[0].SpriteObj.SpriteTexture = Content.Load<Texture2D>("toiler.png");

                //test crap
                //Obstacle obs = new Obstacle(0);
                //obs.Position = new Vector2(1000, 500);
                //obs.SpriteObj = new Sprite("pebble.png", obs.Position, (int)obs.Position.Y, 66, 100);
                //frames[frames.Count - 1].Obstacles.Add(obs);
                //frames[frames.Count - 1].Obstacles[1].SpriteObj.SpriteTexture = Content.Load<Texture2D>("pebble.png");
            }

            #region Newton Jumps
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame); // check to see the total amount of frames so far
            frame = framesElapsed % numFrames + 1; // frame your on is the total number of frames since launch modulated by how many frames there are +1
            kState = Keyboard.GetState();
            if (jumping)
            {
                newtonLoc.Y += jumpspeed;
                jumpspeed += 0.5f;
                if (newtonLoc.Y >= startY)
                {
                    newtonLoc.Y = startY;
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
            #region Test Shit
            hypoMeter.ColdMeter = (int)(hypoMeter.ColdMeter + hypoChange);
            if (hypoMeter.ColdMeter >= 100) hypoChange = -0.25f;
            if (hypoMeter.ColdMeter <= 0) hypoChange = 0.25f;
            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();

            foreach (Frame frameDraw in frames)
            {
                frameDraw.FrameSprite.DrawScale(gameTime, spriteBatch);
                foreach (Obstacle obstacle in frameDraw.Obstacles)
                {
                    obstacle.SpriteObj.Draw(gameTime, spriteBatch);
                }

            }
            spriteBatch.Draw(spriteSheet, newtonLoc, new Rectangle(NEWTON_OFFSET + frame * NEWTON_WIDTH, NEWTON_Y, NEWTON_WIDTH, NEWTON_HEIGHT), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(thermo, new Vector2(625, 20), new Rectangle(0, 0, thermo.Width, thermo.Height), Color.Red, 0, Vector2.Zero, 0.025f, SpriteEffects.None, 0);
            spriteBatch.Draw(thermo, new Vector2(625, 20), new Rectangle(0, 0, (int)(thermo.Width * (hypoMeter.ColdMeter / 100)), thermo.Height), Color.Blue, 0, Vector2.Zero, 0.025f, SpriteEffects.None, 0);
            spriteBatch.DrawString(distanceFont, "Distance: " + (int)distanceScore + " Toilers", new Vector2(20, 20), Color.White);


            spriteBatch.End();
        }
    }
}