﻿#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        #region Attributes that we don't need to see
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // needed things
        private Player player; // player obj
        private List<Frame> frames; // Frames list
        private Meter hypoMeter; // hypothermia meter
        private SpriteFont distanceFont;
        private float distanceScore;
        private Vector2 startLoc;
        private bool gameOver;
        private PowerupSpawner pSpawner;
        private List<Sprite> skyList;
        private List<Sprite> backList;
        private List<Sprite> foreList;
        private List<Sprite> roadList;
        private bool contentLoaded;
        private float elapsedSeconds;

        //Powerup Textures
        private Texture2D shorterPowerupTex;
        private Texture2D longerPowerupTex;
        private Texture2D rainbowPowerupTex;

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
        private Texture2D creditsBg; // credits background
        private Texture2D startBg; // start screen background
        private Texture2D howtoplayBg; // how to play background
        private Texture2D gameLogo; // main game logo
        private Texture2D studioLogo; // studio logo

        // score screen attributes
        private int[] score = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int readInScore = 0;
        private int numOfScores = 0;
        private int scoreLocationY = 100;
        private int scoreLocationX = 0;
        private BinaryReader reader;
        private BinaryWriter writer;

        // Frame and Obstacle Textures - Currently unable to implement ~ Jordan
        private List<Texture2D> normalFrameTextures;
        private List<Texture2D> windTunnelFrameTextures;
        private List<Texture2D> warmZoneFrameTextures;
        private List<Texture2D> skyTextureList;
        private List<Texture2D> backTextureList;
        private List<Texture2D> foreTextureList;
        private Texture2D roadTexture;

        private List<Texture2D> normalObstacleTextures;
        private List<Texture2D> mediumObstacleTextures;
        private List<Texture2D> largeObstacleTextures;
        private List<Texture2D> movingObstacleTextures;

        private Random rgenFrame;
        private Random rgenObstacleNormal;
        private Random rgenObstacleMedium;
        private Random rgenObstacleLarge;
        private Random rgenObstacleMoving;

        // enumeration
        private enum GameState { StartMenu, HowToPlay, Credits, Exit, Game, ScoreScreen };
        private GameState gameState;

        //Player Textures
        Texture2D spriteSheet; // sprite sheet to load
        Texture2D shortsSpriteSheet;

        int startY;
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
        /// 

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameOver = false;

            #region Score Stuff
            // scores
            try
            {
                // score setup, leave here, since I would have to recreate the 
                reader = new BinaryReader(File.Open("highscores.dat", FileMode.Open));
                readInScore = 0;
                numOfScores = 0;
                scoreLocationY = 20;
                scoreLocationX = 100;

                bool firstPlay = reader.ReadBoolean();

                // read in the scores from the file - handle the special case of playing for the first time, where the first entry will be 0
                if (firstPlay == true)
                {

                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        readInScore = reader.ReadInt32();
                        score[numOfScores] = readInScore;
                        numOfScores++;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                reader.Close();
            }
            #endregion

            #region Initialize Texture Lists
            normalFrameTextures = new List<Texture2D>();
            windTunnelFrameTextures = new List<Texture2D>();
            warmZoneFrameTextures = new List<Texture2D>();

            normalObstacleTextures = new List<Texture2D>();
            mediumObstacleTextures = new List<Texture2D>();
            largeObstacleTextures = new List<Texture2D>();
            movingObstacleTextures = new List<Texture2D>();

            rgenFrame = new Random();
            rgenObstacleNormal = new Random();
            rgenObstacleMedium = new Random();
            rgenObstacleLarge = new Random();
            rgenObstacleMoving = new Random();
            #endregion

            // start location for player
            startLoc = new Vector2(Window.ClientBounds.Width / 4, Window.ClientBounds.Height * 2 / 3 - 20);
            elapsedSeconds = 0;

            Frame.InitializeFrames();

            frames = new List<Frame>();
            skyList = new List<Sprite>();
            backList = new List<Sprite>();
            foreList = new List<Sprite>();
            roadList = new List<Sprite>();

            //initialize the hypometer
            hypoMeter = new Meter(new Vector2(625, 20), new Sprite("thermometer.png", Vector2.Zero, 0, 64, 128));

            //add frames
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));
            frames.Add(new Frame(1));

            for (int i = 0; i < frames.Count; i++)
            {
                if (i == 0)
                    frames[i].FrameSprite.SpriteLocation = new Vector2(2048, frames[i].FrameSprite.SpriteLocation.Y);
                else
                    frames[i].FrameSprite.SpriteLocation = new Vector2((frames[i-1].FrameSprite.SpriteLocation.X + 1024 * i + rgenFrame.Next(1024)), frames[i].FrameSprite.SpriteLocation.Y);
            }

            for (int i = 0; i < 3; i++)
            {
                skyList.Add(new Sprite("", new Vector2(1920 * i, 0), 0, 1536, 4096));
                backList.Add(new Sprite("", new Vector2(480 * i, 0), 0, 1024, 1024));
                foreList.Add(new Sprite("", new Vector2(1920 * i, 0), 0, 1024, 4096));
                roadList.Add(new Sprite("", new Vector2(480 * i, 0), 0, 1024, 1024));
            }

            #region Menu Shit
            // enable mouse pointer
            IsMouseVisible = true;
            startPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 225);
            // for a fourth button backPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 350);
            htpPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 300);
            creditPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 375);
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

            #region Frame Texture Shit
            if (contentLoaded == false)
            {
                // load in textures to the lists
                // first clear files inside Content
                string[] filesInContent = Directory.GetFiles("Content");
                foreach (string fileName in filesInContent)
                {
                    File.Delete(fileName);
                }

                // bring back the nedded textures
                string[] neededTextures = Directory.GetFiles("Content\\Needed Textures");
                foreach (string fileName in neededTextures)
                {
                    File.Copy(fileName, "Content\\" + fileName.Substring(23));
                }

                // normal frames
                string[] normalFrameTexturesToLoad = Directory.GetFiles("Content\\Normal Frames");
                foreach (string fileName in normalFrameTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(22));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(22));
                        normalFrameTextures.Add(temp);
                    }
                }

                // wind tunnel frames
                string[] windTunnelFrameTexturesToLoad = Directory.GetFiles("Content\\Wind Tunnel Frames");
                foreach (string fileName in windTunnelFrameTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(26));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(27));
                        windTunnelFrameTextures.Add(temp);
                    }
                }

                // warm zone frames
                string[] warmZoneFrameTexturesToLoad = Directory.GetFiles("Content\\Warm Zone Frames");
                foreach (string fileName in warmZoneFrameTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(25));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(25));
                        warmZoneFrameTextures.Add(temp);
                    }
                }

                // normal obstacle frames
                string[] normalObstacleTexturesToLoad = Directory.GetFiles("Content\\Normal Obstacles");
                foreach (string fileName in normalObstacleTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(24));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(25));
                        normalObstacleTextures.Add(temp);
                    }
                }

                // medium obstacle frames
                string[] mediumObstacleTexturesToLoad = Directory.GetFiles("Content\\Medium Obstacles");
                foreach (string fileName in mediumObstacleTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(24));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(25));
                        mediumObstacleTextures.Add(temp);
                    }
                }

                // large obstacle frames
                string[] largeObstacleTexturesToLoad = Directory.GetFiles("Content\\Large Obstacles");
                foreach (string fileName in largeObstacleTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(24));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(24));
                        largeObstacleTextures.Add(temp);
                    }
                }

                // moving obstacle frames
                string[] movingObstacleTexturesToLoad = Directory.GetFiles("Content\\Moving Obstacles");
                foreach (string fileName in movingObstacleTexturesToLoad)
                {
                    if (fileName.Contains(".png"))
                    {
                        File.Copy(fileName, "Content\\" + fileName.Substring(24));
                        Texture2D temp = Content.Load<Texture2D>(fileName.Substring(25));
                        movingObstacleTextures.Add(temp);
                    }
                }

                contentLoaded = true;
            }
            #endregion

            // TODO: Load in textures here - who has the textures?
            spriteSheet = Content.Load<Texture2D>("charspritesheet.png"); // LOAD IN CHARACTER SPRITESHEET HERE
            shortsSpriteSheet = Content.Load<Texture2D>("charshortsspritesheet.png"); 
            hypoMeter.GuiSprite.SpriteTexture = Content.Load<Texture2D>("thermometer.png"); // thermometer
            distanceFont = Content.Load<SpriteFont>("font");

            //Load powerup textures 
            //TODO: Get final art for powerups
            shorterPowerupTex = Content.Load<Texture2D>("shorterPowerupTemp.png");
            longerPowerupTex = Content.Load<Texture2D>("longerPowerupTemp.png");
            rainbowPowerupTex = Content.Load<Texture2D>("rainbowPowerupTemp.png");

            boundingBoxTex = new Texture2D(GraphicsDevice, 1, 1);
            boundingBoxTex.SetData(new[] { Color.White });

            #region Frame and Obstacle Texture Assignment Shit
            foreach (Frame frameLoad in frames)
            {
                //handle frame texture
                if (frames[frames.Count - 1].FrameType == 0)
                {
                    frameLoad.FrameSprite.SpriteTexture = normalFrameTextures[rgenFrame.Next(0, normalFrameTextures.Count)];
                }
                else if (frames[frames.Count - 1].FrameType == 1)
                {
                    frameLoad.FrameSprite.SpriteTexture = windTunnelFrameTextures[rgenFrame.Next(0, windTunnelFrameTextures.Count)];
                }
                else if (frames[frames.Count - 1].FrameType == 2)
                {
                    frameLoad.FrameSprite.SpriteTexture = warmZoneFrameTextures[rgenFrame.Next(0, warmZoneFrameTextures.Count)];
                }

                // handle obstacle textures
                foreach (Obstacle obstacle in frameLoad.Obstacles)
                {
                    if (obstacle.ObsType == 1)
                    {
                        obstacle.SpriteObj.SpriteTexture = normalObstacleTextures[rgenObstacleNormal.Next(0, normalObstacleTextures.Count)];
                    }
                    else if (obstacle.ObsType == 3)
                    {
                        obstacle.SpriteObj.SpriteTexture = mediumObstacleTextures[rgenObstacleMedium.Next(0, mediumObstacleTextures.Count)];
                    }
                    else if (obstacle.ObsType == 4)
                    {
                        obstacle.SpriteObj.SpriteTexture = largeObstacleTextures[rgenObstacleLarge.Next(0, largeObstacleTextures.Count)];
                    }
                    else if (obstacle.ObsType == 2)
                    {
                        obstacle.SpriteObj.SpriteTexture = movingObstacleTextures[rgenObstacleMoving.Next(0, movingObstacleTextures.Count)];
                    }
                    else
                    {
                        obstacle.SpriteObj.SpriteTexture = normalObstacleTextures[rgenObstacleNormal.Next(0, normalObstacleTextures.Count)];
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                skyList[i].SpriteTexture = Content.Load<Texture2D>("skybackdrop");
                backList[i].SpriteTexture = Content.Load<Texture2D>("treebacklayer");
                foreList[i].SpriteTexture = Content.Load<Texture2D>("treeforelayer");
                roadList[i].SpriteTexture = Content.Load<Texture2D>("roadforelayer");
            }
            #endregion

            #region Menu Shit
            // load button textures
            start = Content.Load<Texture2D>("start.png");
            howtoplay = Content.Load<Texture2D>("howtoplay.png");
            credits = Content.Load<Texture2D>("credits.png");
            exit = Content.Load<Texture2D>("exit.png");
            back = Content.Load<Texture2D>("back.png");
            playAgain = Content.Load<Texture2D>("playagain.png");
            creditsBg = Content.Load<Texture2D>("creditscreen.png"); // credits background screen
            startBg = Content.Load<Texture2D>("start screen.png");
            howtoplayBg = Content.Load<Texture2D>("howtoplayscreen.png");
            gameLogo = Content.Load<Texture2D>("FrostyCheeksLogo.png");
            studioLogo = Content.Load<Texture2D>("PowerShortsStudiosLogo");
            #endregion

            SpawnPlayer();
            InitPowerupSpawner();
        }
        void InitPowerupSpawner()
        {
            powerups = new ArrayList();
            pSpawner = new PowerupSpawner(10, shorterPowerupTex, longerPowerupTex, rainbowPowerupTex, Window.ClientBounds.Width + (Window.ClientBounds.Width / 3));
        }
        void SpawnPlayer()
        {
            player = new Player(1, 1, 1, 3, spriteSheet, shortsSpriteSheet, startLoc); // This needs to be after we load in the spritesheet. Here just to be sure

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
                // check if current score takes over a highscore
                CheckScore((int)distanceScore / (1024 / 6), 0);

                gameOver = true;
                gameState = GameState.ScoreScreen;
                // gameOver = false;
            }

            // only run this update stuff if game is not in GameState.ScoreScreen
            if (gameState == GameState.Game)
            {
                // Add to the elapsed game time for difficulty purposes
                elapsedSeconds += gameTime.ElapsedGameTime.Milliseconds / 1000f;

                for (int i = 0; i < 3; i++)
                {
                    skyList[i].SpriteLocation = new Vector2(skyList[i].SpriteLocation.X - (player.Speed / 10), 0);
                    if (skyList[i].SpriteLocation.X <= -1920)
                        skyList[i].SpriteLocation = new Vector2(skyList[i].SpriteLocation.X + 5760, 0);

                    backList[i].SpriteLocation = new Vector2(backList[i].SpriteLocation.X - (player.Speed / 6), 54);
                    if (backList[i].SpriteLocation.X <= -480)
                        backList[i].SpriteLocation = new Vector2(backList[i].SpriteLocation.X + 1440, 54);

                    foreList[i].SpriteLocation = new Vector2(foreList[i].SpriteLocation.X - (player.Speed / 2), 0);
                    if (foreList[i].SpriteLocation.X <= -1920)
                        foreList[i].SpriteLocation = new Vector2(foreList[i].SpriteLocation.X + 5760 + rgenFrame.Next(960), 0);
                    
                    roadList[i].SpriteLocation = new Vector2(roadList[i].SpriteLocation.X - player.Speed, 96);
                    if (roadList[i].SpriteLocation.X <= -480)
                        roadList[i].SpriteLocation = new Vector2(roadList[i].SpriteLocation.X + 1440, 96);
                }
                foreach (Frame frameUpdate in frames)
                {
                    frameUpdate.FrameSprite.SpriteLocation = new Vector2(frameUpdate.FrameSprite.SpriteLocation.X - player.Speed, 0);

                    foreach (Obstacle obstacle in frameUpdate.Obstacles)
                    {
                        // Scales the location of stuff to the viewport for now
                        obstacle.SpriteObj.SpriteLocation = new Vector2(obstacle.Position.X + frameUpdate.FrameSprite.SpriteLocation.X - 200, obstacle.Position.Y / (1024 / GraphicsDevice.Viewport.Height));
                    }
                }

                if (frames[0].FrameSprite.SpriteLocation.X <= -1024)
                {
                    frames.RemoveAt(0);
                    frames.Add(new Frame((int)(elapsedSeconds / 1)));
                    frames[frames.Count - 1].FrameSprite.SpriteLocation = new Vector2(frames[frames.Count - 2].FrameSprite.SpriteLocation.X + 1024 + rgenFrame.Next((int)(1024 * (1.0 + player.Speed / 6.0))), frames[frames.Count - 1].FrameSprite.SpriteLocation.Y);

                    #region Assign New Frame and Obstacle Textures
                    //handle frame texture
                    if (frames[frames.Count - 1].FrameType == 0)
                    {
                        frames[frames.Count - 1].FrameSprite.SpriteTexture = normalFrameTextures[rgenFrame.Next(0, normalFrameTextures.Count)];
                    }
                    else if (frames[frames.Count - 1].FrameType == 1)
                    {
                        frames[frames.Count - 1].FrameSprite.SpriteTexture = windTunnelFrameTextures[rgenFrame.Next(0, windTunnelFrameTextures.Count)];
                    }
                    else if (frames[frames.Count - 1].FrameType == 2)
                    {
                        frames[frames.Count - 1].FrameSprite.SpriteTexture = warmZoneFrameTextures[rgenFrame.Next(0, warmZoneFrameTextures.Count)];
                    }

                    // handle obstacle textures
                    foreach (Obstacle obstacle in frames[frames.Count - 1].Obstacles)
                    {
                        if (obstacle.ObsType == 1)
                        {
                            obstacle.SpriteObj.SpriteTexture = normalObstacleTextures[rgenObstacleNormal.Next(0, normalObstacleTextures.Count)];
                        }
                        else if (obstacle.ObsType == 3)
                        {
                            obstacle.SpriteObj.SpriteTexture = mediumObstacleTextures[rgenObstacleMedium.Next(0, mediumObstacleTextures.Count)];
                        }
                        else if (obstacle.ObsType == 4)
                        {
                            obstacle.SpriteObj.SpriteTexture = largeObstacleTextures[rgenObstacleLarge.Next(0, largeObstacleTextures.Count)];
                        }
                        else if (obstacle.ObsType == 2)
                        {
                            obstacle.SpriteObj.SpriteTexture = movingObstacleTextures[rgenObstacleMoving.Next(0, movingObstacleTextures.Count)];
                        }
                        else
                        {
                            obstacle.SpriteObj.SpriteTexture = normalObstacleTextures[rgenObstacleNormal.Next(0, normalObstacleTextures.Count)];
                        }
                    }
                    #endregion
                }


                pSpawner.Update(gameTime, (int)player.Speed);//Basically just updates the time so that IsTimeToSpawn has the correct elapsed time

                if (pSpawner.IsTimeToSpawn())
                {
                    //Checks to see if enough time has passed for the spawner to create another powerup
                    //if(powerups.Count < 6)
                    //{
                    Powerup pwr = pSpawner.TrySpawn();
                    if (pwr != null){
                        powerups.Add(pwr);
                    }

                }
                //Call update on all the powerups to move them
                if (powerups.Count > 0)
                {
                    foreach (Powerup p in powerups)//Check all powerups and call update if they havnt already been hit by the player
                    {
                        if (p != null)
                        {
                            if (!p.Destroyed)
                            {
                                p.Update(gameTime,(int) player.Speed);
                            }
                        }
                    }
                }

                player.PlayerUpdate(gameTime);
                distanceScore = distanceScore + player.Speed;
            }
            if (gameState == GameState.ScoreScreen || gameState == GameState.StartMenu)
            {
                if (gameState == GameState.StartMenu)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Q))
                        Exit();
                }
                if(Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    this.GameReset();
                    gameState = GameState.Game;
                }
            }

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
                spriteBatch.Draw(startBg, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(gameLogo, new Rectangle((int)startPos.X - 200, 10, 200, 200), Color.SkyBlue);
                spriteBatch.Draw(studioLogo, new Rectangle(GraphicsDevice.Viewport.Width - 100, 380, 100, 100), Color.White);
                spriteBatch.Draw(start, startPos, Color.White);
                spriteBatch.Draw(howtoplay, htpPos, Color.White);
                spriteBatch.Draw(credits, creditPos, Color.White);
                spriteBatch.Draw(exit, exitPos, Color.White);
            }
            if (gameState == GameState.HowToPlay)
            {
                spriteBatch.Draw(howtoplayBg, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(back, exitPos, Color.White);
            }
            if (gameState == GameState.Credits)
            {
                spriteBatch.Draw(creditsBg, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(back, exitPos, Color.White);
                spriteBatch.Draw(studioLogo, new Rectangle(GraphicsDevice.Viewport.Width - 100, 380, 100, 100), Color.White);
            }
            if (gameState == GameState.Exit)
            {

            }
            if (gameState == GameState.ScoreScreen)
            {
                spriteBatch.Draw(exit, exitPos, Color.White);
                spriteBatch.Draw(playAgain, playAgainPos, Color.White);

                // scores
                scoreLocationY = 20;
                scoreLocationX = 100;

                spriteBatch.DrawString(distanceFont, "Your Score:", new Vector2(scoreLocationX + 300, scoreLocationY), Color.Black);
                spriteBatch.DrawString(distanceFont, "" + (int)distanceScore / (1024 / 6), new Vector2(scoreLocationX + 300, scoreLocationY + 20), Color.Black);
                spriteBatch.DrawString(distanceFont, "High Scores:", new Vector2(scoreLocationX, scoreLocationY), Color.Black);

                scoreLocationY = 40;

                // display the highscores
                for (int i = 0; i < 10; i++)
                {
                    spriteBatch.DrawString(distanceFont, "" + score[i], new Vector2(scoreLocationX, scoreLocationY), Color.Black);
                    scoreLocationY += 20;
                }
            }
            #endregion

            if (gameState == GameState.Game)
            {
                #region background drawing
                for (int i = 0; i < 3; i++)
                {
                    skyList[i].DrawScale(gameTime, spriteBatch, 1920, 480);
                }
                for (int i = 0; i < 3; i++)
                {
                    backList[i].DrawScale(gameTime, spriteBatch);
                }
                for (int i = 0; i < 3; i++)
                {
                    foreList[i].DrawScale(gameTime, spriteBatch, 1680, 420);
                }
                #endregion
                    foreach (Frame frameDraw in frames)
                    {
                        frameDraw.FrameSprite.DrawScale(gameTime, spriteBatch);
                    }

                #region coldMeter
                hypoMeter.ColdMeter = 100 - player.Tempurature;

                spriteBatch.Draw(hypoMeter.GuiSprite.SpriteTexture, hypoMeter.Position, new Rectangle(0, 0, hypoMeter.GuiSprite.SpriteTexture.Width, hypoMeter.GuiSprite.SpriteTexture.Height), Color.Red, 0, Vector2.Zero, 0.025f, SpriteEffects.None, 0);
                spriteBatch.Draw(hypoMeter.GuiSprite.SpriteTexture, hypoMeter.Position, new Rectangle(0, 0, (int)(hypoMeter.GuiSprite.SpriteTexture.Width * (hypoMeter.ColdMeter / 100)), hypoMeter.GuiSprite.SpriteTexture.Height), Color.Blue, 0, Vector2.Zero, 0.025f, SpriteEffects.None, 0);
                #endregion

                for (int i = 0; i < 3; i++)
                {
                    roadList[i].DrawScale(gameTime, spriteBatch);
                }

                foreach (Frame frameDraw in frames)
                {
                    foreach (Obstacle obstacle in frameDraw.Obstacles)
                    {
                        obstacle.SpriteObj.Draw(gameTime, spriteBatch);
                        //obstacle.DrawBoundingBox(spriteBatch, boundingBoxTex);//Draw the bounding box for testing
                    }

                }
                #region powerup drawing
                foreach (Powerup p in powerups)
                {//Loop through all spawned powerups 
                    if (!p.Destroyed)
                    {//Make sure the player hasnt alread hit it
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
                //spriteBatch.DrawString(distanceFont, "Speed: " + (int)player.Speed, new Vector2(20, 60), Color.White);
                //spriteBatch.DrawString(distanceFont, "ShortsLength: " + player.ShortsLength, new Vector2(20, 100), Color.White);

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
                

            }
            if (gameState == GameState.Credits)
            {
                if (clickRect.Intersects(backRect))
                {
                    gameState = GameState.StartMenu;
                }
                
            }
            if (gameState == GameState.ScoreScreen)
            {
                // export the updated scores to the file
                writer = new BinaryWriter(File.Open("highscores.dat", FileMode.Create));

                // send a 0 for check purposes
                writer.Write(false);

                for (int i = 0; i < 10; i++)
                {
                    writer.Write(score[i]);
                }

                writer.Close();

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
            distanceScore = 0;
            elapsedSeconds = 0;

            // start location for player
            startLoc = new Vector2(Window.ClientBounds.Width / 3, Window.ClientBounds.Height * 2 / 3 - 20);
            player = new Player(1, 1, 1, 3, spriteSheet, shortsSpriteSheet, startLoc); // This needs to be after we load in the spritesheet. Here just to be sure

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
                if (i == 0)
                    frames[i].FrameSprite.SpriteLocation = new Vector2(2048, frames[i].FrameSprite.SpriteLocation.Y);
                else
                    frames[i].FrameSprite.SpriteLocation = new Vector2((frames[i - 1].FrameSprite.SpriteLocation.X + 1024 * i + rgenFrame.Next(1024)), frames[i].FrameSprite.SpriteLocation.Y);
            }

            #region Menu Shit
            startPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 225);
            // for a fourth button backPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 350);
            htpPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 300);
            creditPos = new Vector2((GraphicsDevice.Viewport.Width / 2) - 75, 375);
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
                            player.HitPowerup(p,gameTime);//..then do stuff!!
                        }
                    }
                }
            }
            #endregion
        }

        #region Check Score Method
        // checks the current score against highscore
        public void CheckScore(int scoreToCheck, int index)
        {
            //check if at the end of the array
            if (index == 10)
            {
                // not a new highscore or matches the lowest
            }
            else if (scoreToCheck >= score[index])
            {
                // go again, edit the remainder of the array
                CheckScore(score[index], index + 1);
                score[index] = scoreToCheck;
            }
            else if (scoreToCheck < score[index])
            {
                CheckScore(scoreToCheck, index + 1);
            }
        }
        #endregion
    }
}