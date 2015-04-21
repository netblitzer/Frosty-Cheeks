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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // needed things
        Player player; // player obj
        List<Frame> frames; // Frames list
        Meter hypoMeter; // hypothermia meter
        SpriteFont distanceFont;
        float distanceScore;
        Vector2 startLoc;
        Texture2D toilerFace;
        bool gameOver;
        PowerupSpawner pSpawner;

        //Powerup Textures
        private Texture2D shorterPowerupTex;
        private Texture2D longerPowerupTex;
        //Array to hold powerups. No more than 5 powerups in game at a time. Powerup is created in update but PowerupSpawner
        private ArrayList powerups;

        // menu attributes
        private Texture2D start;
        private Texture2D howtoplay;
        private Texture2D credits;
        private Texture2D exit;
        private Texture2D back;
        private Texture2D playAgain;
        private Vector2 startPos;
        private Vector2 htpPos;
        private Vector2 creditPos;
        private Vector2 backPos;
        private Vector2 exitPos;
        private Vector2 playAgainPos;
        private MouseState mouseState;
        private MouseState prevState;
        private Texture2D boundingBoxTex;//Test to draw borders on bounding boxes

        // enumeration
        enum GameState { StartMenu, HowToPlay, Credits, Exit, Game, ScoreScreen };
        private GameState gameState;

        #region Newton Things
        Texture2D spriteSheet; // sprite sheet to load
        int startY;
        #endregion

        #region Test Shit
        
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
            gameOver = false;

            // start location for player
            startLoc = new Vector2(Window.ClientBounds.Width / 3, Window.ClientBounds.Height / 2);

            Frame.InitializeFrames();
            
            frames = new List<Frame>();

            //initialize the hypometer
            hypoMeter = new Meter(new Vector2(625, 20), new Sprite("thermometer.png", Vector2.Zero, 0, 64, 128));
            

            //add frames
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));

            for (int i = 0; i < frames.Count; i++)
            {
                frames[i].FrameSprite.SpriteLocation = new Vector2((1024 * i), frames[i].FrameSprite.SpriteLocation.Y);

                #region Commented out
                //Obstacle obs = new Obstacle(0);
                //obs.Position = new Vector2(1000, 700);
                //obs.SpriteObj = new Sprite("pebble.png", obs.Position, (int)obs.Position.Y, 66, 100);
                //frames[i].Obstacles.Add(obs);
                #endregion
            }
           
            #region Test Shit

            #endregion

            #region Menu Shit
            // enable mouse pointer
            IsMouseVisible = true;
            startPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 50);
            // for a fourth button backPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 350);
            htpPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 150);
            creditPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 250);
            exitPos = new Vector2(20, GraphicsDevice.Viewport.Height - 75);
            playAgainPos = new Vector2(GraphicsDevice.Viewport.Width - 220, GraphicsDevice.Viewport.Height - 75);
            backPos = exitPos;
            gameState = GameState.StartMenu;
            mouseState = Mouse.GetState();
            prevState = mouseState;
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
            hypoMeter.GuiSprite.SpriteTexture = Content.Load<Texture2D>("thermometer.png"); // thermometer
            distanceFont = Content.Load<SpriteFont>("font");

            //change this to obstacle list load
            toilerFace = Content.Load<Texture2D>("toiler.png");

            //Load powerup textures 
            //TODO: Get final art for powerups
            shorterPowerupTex = Content.Load<Texture2D>("shorterPowerupTemp.png");
            longerPowerupTex = Content.Load<Texture2D>("longerPowerupTemp.png");

            boundingBoxTex = new Texture2D(GraphicsDevice, 1, 1);
            boundingBoxTex.SetData(new[] { Color.White });
            
            //Instantiating these here so we KNOW that the content has been loade before we try to use it
            powerups = new ArrayList();
            pSpawner = new PowerupSpawner(5, shorterPowerupTex, longerPowerupTex, Window.ClientBounds.Width + (Window.ClientBounds.Width / 3));
            
            player = new Player(1, 1, 1, 3, spriteSheet, startLoc); // This needs to be after we load in the spritesheet. Here just to be sure

            foreach (Frame frameLoad in frames)
            {
                frameLoad.FrameSprite.SpriteTexture = Content.Load<Texture2D>(frameLoad.FrameSprite.ImagePath);
                foreach (Obstacle obstacle in frameLoad.Obstacles)
                {
                    obstacle.SpriteObj.SpriteTexture = Content.Load<Texture2D>("toiler.png");
                }
            }

            #region Test Shit
            
            #endregion

            #region Menu Shit
            // load button textures
            start = Content.Load<Texture2D>("start.png");
            howtoplay = Content.Load<Texture2D>("howtoplay.png");
            credits = Content.Load<Texture2D>("credits.png");
            exit = Content.Load<Texture2D>("exit.png");
            back = Content.Load<Texture2D>("back.png");
            playAgain = Content.Load<Texture2D>("start.png");
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
            #region Mouse/Menu Shit
            mouseState = Mouse.GetState();
            if (prevState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
            prevState = mouseState;
            #endregion
            
            // check for end game
            if (hypoMeter.ColdMeter >= 100 && gameOver == false)  
            {
               gameOver = true;
               gameState = GameState.ScoreScreen;
               // gameOver = false;
            }
            
            // only run this update stuff if game is not in GameState.ScoreScreen
            if (gameState == GameState.Game)
            {
                foreach (Frame frameUpdate in frames)
                {
                    frameUpdate.FrameSprite.SpriteLocation = new Vector2(frameUpdate.FrameSprite.SpriteLocation.X - player.Speed, 0);

                    foreach (Obstacle obstacle in frameUpdate.Obstacles)
                    {
                        // Scales the location of stuff to the viewport for now
                        obstacle.SpriteObj.SpriteLocation = new Vector2(obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, obstacle.Position.Y / (1024 / GraphicsDevice.Viewport.Height));
                        
                        /*if ((obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - player.Position.X <= 2 && (obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - player.Position.X >= 0)
                        {
                            distanceScore++;
                        }*/
                    }

                    #region Commented out
                    // Frame code is working now
                    /*
                    frameUpdate.Obstacles[0].SpriteObj.SpriteLocation = new Vector2(frameUpdate.Obstacles[0].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, 150);
                    frameUpdate.Obstacles[1].SpriteObj.SpriteLocation = new Vector2(frameUpdate.Obstacles[1].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, 300);
                    if ((frameUpdate.Obstacles[0].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - newtonLoc.X <= 2 && (frameUpdate.Obstacles[0].Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200) - newtonLoc.X >= 0)
                    {
                        distanceScore++;
                    }
                    */
                    #endregion
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
                        obs.SpriteObj.SpriteTexture = toilerFace;
                    }
                    #region Commented out
                    //frames[frames.Count - 1].Obstacles[0].SpriteObj.SpriteTexture = Content.Load<Texture2D>("toiler.png");

                    //test crap
                    //Obstacle obs = new Obstacle(0);
                    //obs.Position = new Vector2(1000, 500);
                    //obs.SpriteObj = new Sprite("pebble.png", obs.Position, (int)obs.Position.Y, 66, 100);
                    //frames[frames.Count - 1].Obstacles.Add(obs);
                    //frames[frames.Count - 1].Obstacles[1].SpriteObj.SpriteTexture = Content.Load<Texture2D>("pebble.png");
                    #endregion
                }


                pSpawner.Update(gameTime, (int)player.Speed);//Basically just updates the time so that IsTimeToSpawn has the correct elapsed time

                if (pSpawner.IsTimeToSpawn())
                {//Checks to see if enough time has passed for the spawner to create another powerup
                    if(powerups.Count < 6){
                        powerups.Add(pSpawner.Spawn());
                    }

                }
                //Call update on all the powerups to move them
                if(powerups.Count > 0){
                    foreach (Powerup p in powerups)//Check all powerups and call update if they havnt already been hit by the player
                    {
                        if(p != null){
                            if(!p.Destroyed){
                                p.Update(gameTime);
                            }
                        }
                    }
                }
                player.PlayerUpdate(gameTime);
                distanceScore = distanceScore + player.Speed;
            }

            #region Test Shit

            #endregion
            CollisionUpdate(gameTime);
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
            #region Menu Shit
            if (gameState == GameState.StartMenu)
            {
                spriteBatch.Draw(start, startPos, Color.White);
                spriteBatch.Draw(howtoplay, htpPos, Color.White);
                spriteBatch.Draw(credits, creditPos, Color.White);
                spriteBatch.Draw(exit, exitPos, Color.White);
            }
            if (gameState == GameState.HowToPlay)
            {
                spriteBatch.Draw(back, exitPos, Color.White);
            }
            if (gameState == GameState.Credits)
            {
                spriteBatch.Draw(back, exitPos, Color.White);
            }
            if (gameState == GameState.Exit)
            {

            }
            if (gameState == GameState.ScoreScreen)
            {
                spriteBatch.Draw(exit, exitPos, Color.White);
                spriteBatch.Draw(playAgain, playAgainPos, Color.White);
            }
            #endregion
            if (gameState == GameState.Game)
            {
                foreach (Frame frameDraw in frames)
                {
                    frameDraw.FrameSprite.DrawScale(gameTime, spriteBatch);
                    foreach (Obstacle obstacle in frameDraw.Obstacles)
                    {
                        obstacle.SpriteObj.Draw(gameTime, spriteBatch);
                        //obstacle.DrawBoundingBox(spriteBatch, boundingBoxTex);//Draw the bounding box for testing
                    }

                }
                #region coldMeter
                hypoMeter.ColdMeter = 100 - player.Tempurature;

                spriteBatch.Draw(hypoMeter.GuiSprite.SpriteTexture, hypoMeter.Position, new Rectangle(0, 0, hypoMeter.GuiSprite.SpriteTexture.Width, hypoMeter.GuiSprite.SpriteTexture.Height), Color.Red, 0, Vector2.Zero, 0.025f, SpriteEffects.None, 0);
                spriteBatch.Draw(hypoMeter.GuiSprite.SpriteTexture, hypoMeter.Position, new Rectangle(0, 0, (int)(hypoMeter.GuiSprite.SpriteTexture.Width * (hypoMeter.ColdMeter / 100)), hypoMeter.GuiSprite.SpriteTexture.Height), Color.Blue, 0, Vector2.Zero, 0.025f, SpriteEffects.None, 0);
                #endregion

                #region powerup drawing
                foreach(Powerup p in powerups){//Loop through all spawned powerups 
                    if(!p.Destroyed){//Make sure the player hasnt alread hit it
                       // p.DrawBoundingBox(spriteBatch, boundingBoxTex);//Draw the bounding box for testing
                        p.Draw(spriteBatch);//..and draw it
                    }
                }
                #endregion

                #region player drawing
                //player.DrawBoundingBox(spriteBatch, boundingBoxTex);//Fills in bounding box for testing
                player.Draw(spriteBatch);
                #endregion

                spriteBatch.DrawString(distanceFont, "Distance: " + (int)distanceScore / (1024 / 6) + " Meters", new Vector2(20, 20), Color.White);
            }
            spriteBatch.End();
        }
        #region Mouse Click Method
        public void MouseClicked(int x, int y)
        {
            // create rectangle where mouse is clicked
            Rectangle clickRect = new Rectangle(x, y, 10, 10);
            // check startmenu
            Rectangle startRect = new Rectangle((int)startPos.X, (int)startPos.Y, 200, 50);
            Rectangle playAgainRect = new Rectangle((int)playAgainPos.X, (int)playAgainPos.Y, 200, 50); // ***currently using the "Start" texture
            Rectangle exitRect = new Rectangle((int)exitPos.X, (int)exitPos.Y, 200, 50);
            Rectangle htpRect = new Rectangle((int)htpPos.X, (int)htpPos.Y, 200, 50);
            Rectangle creditRect = new Rectangle((int)creditPos.X, (int)creditPos.Y, 200, 50);
            Rectangle backRect = new Rectangle((int)backPos.X, (int)backPos.Y, 200, 50);
            if (gameState == GameState.StartMenu)
            {
                if (clickRect.Intersects(startRect))
                {
                    gameState = GameState.Game;
                }
                if (clickRect.Intersects(htpRect))
                {
                    gameState = GameState.HowToPlay;
                }
                if (clickRect.Intersects(creditRect))
                {
                    gameState = GameState.Credits;
                }
                if (clickRect.Intersects(exitRect))
                {
                    Exit();
                }
            }
            if (gameState == GameState.HowToPlay)
            {
                if (clickRect.Intersects(backRect))
                {
                    gameState = GameState.StartMenu;
                }
                if (clickRect.Intersects(playAgainRect))
                {
                    gameState = GameState.ScoreScreen;
                }

            }
            if (gameState == GameState.Credits)
            {
                if (clickRect.Intersects(backRect))
                {
                    gameState = GameState.StartMenu;
                }
                if (clickRect.Intersects(playAgainRect))
                {
                    gameState = GameState.StartMenu;
                }
            }
            if (gameState == GameState.ScoreScreen)
            {
                 if (clickRect.Intersects(playAgainRect))
                {
                    gameState = GameState.StartMenu;
                    this.GameReset();
                }
                if (clickRect.Intersects(exitRect))
                {
                    Exit();
                }
            }
        }
        #endregion

        #region Game Reset Method
        // resets the game variables
        public void GameReset()
        {
            // TODO: Add your initialization logic here
            gameOver = false;

            // start location for player
            startLoc = new Vector2(Window.ClientBounds.Width / 3, Window.ClientBounds.Height / 2);

            frames = new List<Frame>();

            //initialize the hypometer
            hypoMeter = new Meter(new Vector2(625, 20), new Sprite("thermometer.png", Vector2.Zero, 0, 64, 128));


            //add frames
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));

            for (int i = 0; i < frames.Count; i++)
            {
                frames[i].FrameSprite.SpriteLocation = new Vector2((1024 * i), frames[i].FrameSprite.SpriteLocation.Y);

                #region Commented out
                //Obstacle obs = new Obstacle(0);
                //obs.Position = new Vector2(1000, 700);
                //obs.SpriteObj = new Sprite("pebble.png", obs.Position, (int)obs.Position.Y, 66, 100);
                //frames[i].Obstacles.Add(obs);
                #endregion
            }

            #region Test Shit

            #endregion

            #region Menu Shit
            startPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 50);
            // for a fourth button backPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 350);
            htpPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 150);
            creditPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 250);
            exitPos = new Vector2(20, GraphicsDevice.Viewport.Height - 75);
            playAgainPos = new Vector2(GraphicsDevice.Viewport.Width - 220, GraphicsDevice.Viewport.Height - 75);
            backPos = exitPos;
            gameState = GameState.StartMenu;
            mouseState = Mouse.GetState();
            prevState = mouseState;
            #endregion

            this.LoadContent();
        }
        #endregion
        public void CollisionUpdate(GameTime gameTime)
        {
            #region collisions!
            //3 second grace period at beginning of game
            if (gameTime.TotalGameTime.TotalSeconds > 1)
            {
                foreach (Frame frameDraw in frames)//Look through every frame that's in the game..
                {
                    foreach (Obstacle obstacle in frameDraw.Obstacles)//And look through every osbtacle in every frame..
                    {
                        if (player.IsColliding(obstacle))//..and if the player is hitting it
                        {
                            player.HitObstacle(obstacle);//..then do stuff!!
                        }
                    }
                }
                foreach (Powerup p in powerups)
                {
                    if (!p.Destroyed)
                    {
                        if (player.IsColliding(p))//..and if the player is hitting it
                        {
                            player.HitPowerup(p);//..then do stuff!!
                        }
                    }
                }
            }
            #endregion
        }
    }
}