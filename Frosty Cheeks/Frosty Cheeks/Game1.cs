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

        #region Newton Things
        Texture2D spriteSheet; // sprite sheet to load
        Vector2 newtonLoc; // location of character
        int frame; // frame of animation that is currently on
        double timePerFrame = 100; // set 100 ms per frame
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
        Obstacle toiler;
        Texture2D toilerFace;
        #endregion


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Player(1, 1, 1, 1);
            frames = new List<Frame>();
            frames.Add(new Frame(1));

            #region Test Shit
            toiler = new Obstacle(0);
            toiler.Position = new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height / 2);
            #endregion
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
            #region Newton Jumps
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame); // check to see the total amount of frames so far
            frame = framesElapsed % numFrames + 1; // frame your on is the total number of frames since launch modulated by how many frames there are +1
            kState = Keyboard.GetState();
            if (jumping)
            {
                newtonLoc.Y += jumpspeed;
                jumpspeed += 1;
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
            toiler.Position = new Vector2(toiler.Position.X - 1f, Window.ClientBounds.Height / 2);
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

            spriteBatch.Draw(spriteSheet, newtonLoc, new Rectangle(NEWTON_OFFSET + frame * NEWTON_WIDTH, NEWTON_Y, NEWTON_WIDTH, NEWTON_HEIGHT), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(toilerFace, toiler.Position, Color.White);

            spriteBatch.End();
        }
    }
}