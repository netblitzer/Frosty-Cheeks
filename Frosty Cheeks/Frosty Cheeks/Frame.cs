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
        enum FrameType { Standard, Windy, Interior }; // Setting of the frame
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
            
        }

        public void ReadFramesIn()
        {
            try
            {
                if (Directory.Exists(".../Frames/"))
                {
                    Console.WriteLine("Exists");
                }
            }
            catch (IOException ioe)
            {

            }
        }

        private Frame RandomizeFrame(int Difficulty)
        {
            Frame output = availFrames[rgen.Next(availFrames.Count)];
            output.RandomizeObstacles(Difficulty);
            return output;
        }
        private void RandomizeObstacles(int Difficulty)
        {
            int availObs = availObstacles.Count;
            double reqObs = availObs * (Difficulty / 100.0);
            for (int i = 0; i < reqObs; i++)
            {

            }
        }
    }
}
