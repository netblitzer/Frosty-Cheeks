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
        private int frameType; // 0 for normal, 1 for windy, 2 for indoors
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
        public int FrameType
        {
            get { return frameType; }
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
                o.ObsType = obs.ObsType;
                availObstacles.Add(o);
            }
            // Test value
            diff = Difficulty;
            frameType = rand.FrameType;
            obstacles = new List<Obstacle>();
            RandomizeObstacles();
            spr = new Sprite("bg.png", Vector2.Zero, 0, 1024, 1024);
        }
        // Private Frame Constructor
        // Creates the initial frames to be used later
        private Frame(int d, int type, Vector2 loc)
        {
            // Test value
            diff = 0;
            frameType = type;
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
                            int frameTypeLoad = reader.ReadInt32();
                            int obsType = 0;
                            Vector2 obsPos;
                            try
                            {
                                while ((obsType = reader.ReadInt32()) != null)
                                {
                                    obsPos = new Vector2(reader.ReadInt32() + 100, reader.ReadInt32() + 115);
                                    Obstacle obs = null;
                                    switch (obsType)
                                    {
                                        case 0:
                                            obs = new Obstacle(reader.ReadInt32());
                                            obs.SpriteObj = new Sprite("DevObstacle1.png", obsPos, (int)obsPos.Y, 64, 64);
                                            obs.ObsType = 1;
                                            break;
                                        case 1:
                                            obs = new Obstacle(reader.ReadInt32());
                                            obs.SpriteObj = new Sprite("DevObstacle3.png", obsPos, (int)obsPos.Y, 195, 195);
                                            obs.ObsType = 3;
                                            break;
                                        case 2:
                                            obs = new Obstacle(reader.ReadInt32());
                                            obs.SpriteObj = new Sprite("DevObstacle4.png", obsPos, (int)obsPos.Y, 260, 260);
                                            obs.ObsType = 4;
                                            break;
                                        case 3:
                                            obs = new Obstacle(reader.ReadInt32());
                                            obs.SpriteObj = new Sprite("DevObstacle2.png", obsPos, (int)obsPos.Y, 260, 130);
                                            obs.ObsType = 2;
                                            break;
                                        default:
                                            obs = new Obstacle(reader.ReadInt32());
                                            obs.SpriteObj = new Sprite("DevObstacle1.png", obsPos, (int)obsPos.Y, 130, 130);
                                            obs.ObsType = 1;
                                            break;
                                    }
                                    obs.Position = obsPos;
                                    obsList.Add(obs);
                                }
                            }
                            catch (IOException ioe)
                            {
                                Frame frm = new Frame(100, 0, Vector2.Zero);
                                frm.frameType = frameTypeLoad;
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
            int reqObs = (int)Math.Round(diff / 5.0);
            int i = 0;
            while (i < reqObs)
            {
                Thread.Sleep(10);
                int rand = rgen.Next(8);
                if (rand > 2)
                {
                    Obstacle ob = availObstacles[i];
                    Obstacle o = new Obstacle(ob.Speed);
                    o.Position = ob.Position;
                    o.SpriteObj = new Sprite(ob.SpriteObj.ImagePath, new Vector2(ob.SpriteObj.SpriteLocation.X, ob.SpriteObj.SpriteLocation.Y), 0, ob.SpriteObj.SpriteHeight, ob.SpriteObj.SpriteWidth);
                    o.ObsType = ob.ObsType;
                    obstacles.Add(o);
                }
                i++;

                if (i == availObs)
                    break;
            }
        }
    }
}
