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

        public Vector2 Position{
            get{return position;}
            set{position = value;}
        }
        public List<Obstacle> Obstacles
        {
            get { return obstacles; }
        }
        public List<Obstacle> AvailableObstacles
        {
            get { return availObstacles; }
        }

        // Method to run at start
            // Creates all the frames, and sets up their attributes
        public void InitializeFrames()
        {
            rgen = new Random();
            availFrames = new List<Frame>(5);
        }

        // Frame Constructor
            // Grabs a random frame from the list
        public Frame(int Difficulty)
        {
            Frame rand = availFrames[rgen.Next(availFrames.Count)];
            availObstacles = rand.AvailableObstacles;
            RandomizeObstacles();
        }
        // Private Frame Constructor
            // Creates the initial frames to be used later
        private Frame(int d, string imgPath, int type, Vector2 loc)
        {
            diff = d;
            FrameType = type;
            spr = new Sprite(imgPath, loc, 0, 1024, 2048);
        }
        public void ReadFramesIn()
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
                            string str = s.Substring(6);
                            BinaryReader reader = new BinaryReader(File.Open(str, FileMode.Open));
                            string path = reader.ReadString();
                            Vector2 obsPos;
                            while ((obsPos = new Vector2(reader.ReadInt32(), reader.ReadInt32())) != null)
                            {
                                Obstacle obs = new Obstacle(0);
                                obs.Position = obsPos;
                                obsList.Add(obs);
                            }
                            Frame frm = new Frame(100, path, 0, Vector2.Zero);
                            frm.availObstacles = obsList;
                            availFrames.Add(frm);
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
            double reqObs = availObs * (diff / 100.0);
            for (int i = 0; i < reqObs; i++)
            {
                Thread.Sleep(10);
                int rand = rgen.Next(2);
                if (rand == 1)
                    obstacles.Add(availObstacles[i]);
            }
        }
    }
}
