using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;

namespace Frosty_Cheeks
{
    /*AUTHOR: Super Shorts Luke
     3-22-15*/
    class Frame
    {
        #region Variable Declarations
        private static List<Frame> availFrames; // List of all the available frames to draw
        private List<Obstacle> availObstacles; // Each available frames list of available obstacles
        private int diff; // The frame's own difficulty setting
        private int FrameType; // 0 for normal, 1 for windy, 2 for indoors
        private List<Obstacle> obstacles; // Each unique (being drawn) frames actual obstacles
        private Sprite spr; // Unique (being drawn) frame's image sprite
        private Vector2 position; // Where the frame is located
        private static Random rgen; // Random generator for grabbing and customizing frames
        #endregion

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public List<Obstacle> Obstacles
        {
            get { return obstacles; }
        }
        public List<Obstacle> AvailableObstacles
        {
            get { return availObstacles; }
        }
        public Sprite FrameSprite
        {
            get { return spr; }
        }

        // Method to run at start
        // Creates all the frames, and sets up their attributes
        public static void InitializeFrames()
        {
            rgen = new Random();
            availFrames = new List<Frame>();
            ReadFramesIn();
        }

        // Frame Constructor
        // Grabs a random frame from the list
        public Frame(int Difficulty)
        {
            Frame rand = availFrames[rgen.Next(availFrames.Count)];
            availObstacles = new List<Obstacle>();
            foreach (Obstacle obs in rand.availObstacles)
            {
                Obstacle o = new Obstacle(obs.Speed);
                o.Position = obs.Position;
                o.SpriteObj = new Sprite(obs.SpriteObj.ImagePath, new Vector2(obs.SpriteObj.SpriteLocation.X, obs.SpriteObj.SpriteLocation.Y), 0, obs.SpriteObj.SpriteHeight, obs.SpriteObj.SpriteWidth);
                availObstacles.Add(o);
            }
            // Test value
            diff = 100;

            obstacles = new List<Obstacle>();
            RandomizeObstacles();
            spr = new Sprite(rand.FrameSprite.ImagePath, rand.FrameSprite.SpriteLocation, 0, rand.FrameSprite.SpriteHeight, rand.FrameSprite.SpriteWidth);
        }
        // Private Frame Constructor
        // Creates the initial frames to be used later
        private Frame(int d, string imgPath, int type, Vector2 loc)
        {
            // Test value
            diff = 100;
            FrameType = type;
            spr = new Sprite(imgPath, loc, 0, 1024, 1024);
        }
        public static void ReadFramesIn()
        {
            try
            {
                if (Directory.Exists("Frames"))
                {
                    string[] files = Directory.GetFiles("Frames");
                    foreach (string s in files)
                    {
                        if (s.EndsWith(".dat"))
                        {
                            List<Obstacle> obsList = new List<Obstacle>();
                            //string str = s.Substring(8);
                            BinaryReader reader = new BinaryReader(File.Open(s, FileMode.Open));
                            string path = reader.ReadString();
                            Vector2 obsPos;
                            try
                            {
                                while ((obsPos = new Vector2(reader.ReadInt32(), reader.ReadInt32())) != null)
                                {
                                    Obstacle obs = new Obstacle(0);
                                    obs.Position = obsPos;
                                    obs.SpriteObj = new Sprite("toiler.png", obsPos, (int)obsPos.Y, 184, 141);
                                    obsList.Add(obs);
                                }
                            }
                            catch (IOException ioe)
                            {
                                Frame frm = new Frame(100, path, 0, Vector2.Zero);
                                frm.availObstacles = obsList;
                                availFrames.Add(frm);
                            }
                        }
                    }
                }
            }
            catch (IOException ioe)
            {

            }
        }
        private void RandomizeObstacles()
        {
            int availObs = availObstacles.Count;
            double reqObs = Math.Ceiling(availObs * (diff / 100.0));
            for (int i = 0; i < reqObs; i++)
            {
                Thread.Sleep(10);
                int rand = rgen.Next(2);
                Obstacle ob = availObstacles[i];
                Obstacle o = new Obstacle(ob.Speed);
                o.Position = ob.Position;
                o.SpriteObj = new Sprite(ob.SpriteObj.ImagePath, new Vector2(ob.SpriteObj.SpriteLocation.X, ob.SpriteObj.SpriteLocation.Y), 0, ob.SpriteObj.SpriteHeight, ob.SpriteObj.SpriteWidth);
                obstacles.Add(o);
            }
        }
    }
}
