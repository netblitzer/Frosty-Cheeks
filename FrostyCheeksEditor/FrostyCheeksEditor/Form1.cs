using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

// Luke Miller

namespace FrostyCheeksEditor
{
    public partial class Form1 : Form
    {
        // Variable Declaration
        private int hover;
        private int click;
        private int normal;
        private List<System.Windows.Forms.PictureBox> obstacles;
        private System.ComponentModel.ComponentResourceManager resources;
        private short obs1Box, obs2Box, obs3Box, obs4Box, delBox;
        private int prevCount;

        // REMOVE LATER
        private Random rgen;
        public Form1()
        {
            InitializeComponent();
            #region Test Stuff
            /*
            BinaryWriter output = new BinaryWriter(File.OpenWrite("frame1.dat"));
            output.Write("bg.png");
            output.Write(1000);
            output.Write(500);
			output.Write(1000);
            output.Write(500);
            */
            #endregion
            // Button Stuffs
            hover = 50;
            click = 20;
            normal = 30;
            // Other Stuffs
            obstacles = new List<PictureBox>();
            rgen = new Random();
            obs1Box = obs2Box = obs3Box = obs4Box = delBox = 0;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pulseTimer.Interval = 50;
            pulseTimer.Start();
            prevCount = obstacles.Count;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;

            saveFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.InitialDirectory = "..//Frames";;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    BinaryWriter output = new BinaryWriter(myStream);
                    output.Write("bg.png");
                    foreach (PictureBox obs in obstacles)
                    {
                        output.Write(obs.Location.X * (1024 / 400));
                        output.Write(obs.Location.Y * (1024 / 400));
                    }
                    output.Close();
                    myStream.Close();
                }
            }
        }

        #region Normal Obstacle Button
        private void obstacle1Panel_MouseEnter(object sender, EventArgs e)
        {
            obs1Box = 1;
        }

        private void obstacle1Panel_MouseLeave(object sender, EventArgs e)
        {
            obs1Box = 0;
        }

        private void obstacle1Panel_MouseDown(object sender, MouseEventArgs e)
        {
            #region Adding New Obstacles
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 368), 220);
            obs.Size = new System.Drawing.Size(32, 32);
            obs.MaximumSize = new System.Drawing.Size(32, 32);
            obs.MinimumSize = new System.Drawing.Size(32, 32);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon1.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "normal";
            obstacles.Add(obs);
            #endregion
            obs1Box = 2;
        }

        private void obstacle1Panel_MouseMove(object sender, MouseEventArgs e)
        {
            obs1Box = 1;
        }
        #endregion


        #region Moving Obstacle Button
        private void obstacle2Panel_MouseEnter(object sender, EventArgs e)
        {
            obs2Box = 1;
        }

        private void obstacle2Panel_MouseLeave(object sender, EventArgs e)
        {
            obs2Box = 0;
        }

        private void obstacle2Panel_MouseDown(object sender, MouseEventArgs e)
        {
            #region Adding New Obstacles
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 368), 220);
            obs.Size = new System.Drawing.Size(32, 32);
            obs.MaximumSize = new System.Drawing.Size(32, 32);
            obs.MinimumSize = new System.Drawing.Size(32, 32);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon2.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "moving";
            obstacles.Add(obs);
            #endregion
            obs2Box = 2;
        }

        private void obstacle2Panel_MouseMove(object sender, MouseEventArgs e)
        {
            obs2Box = 1;
        }
        #endregion

        #region Tall Obstacle Button
        private void obstacle3Panel_MouseEnter(object sender, EventArgs e)
        {
            obs3Box = 1;
        }

        private void obstacle3Panel_MouseLeave(object sender, EventArgs e)
        {
            obs3Box = 0;
        }

        private void obstacle3Panel_MouseDown(object sender, MouseEventArgs e)
        {
            obs3Box = 2;
            #region Adding New Obstacles
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 368), 188);
            obs.Size = new System.Drawing.Size(32, 64);
            obs.MaximumSize = new System.Drawing.Size(32, 64);
            obs.MinimumSize = new System.Drawing.Size(32, 64);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon3.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "tall";
            obstacles.Add(obs);
            #endregion
        }

        private void obstacle3Panel_MouseMove(object sender, MouseEventArgs e)
        {
            obs3Box = 1;
        }
        #endregion

        #region Huge Obstacle Button
        private void obstacle4Panel_MouseEnter(object sender, EventArgs e)
        {
            obs4Box = 1;
        }

        private void obstacle4Panel_MouseLeave(object sender, EventArgs e)
        {
            obs4Box = 0;
        }

        private void obstacle4Panel_MouseDown(object sender, MouseEventArgs e)
        {
            obs4Box = 2;
            #region Adding New Obstacles
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 336), 188);
            obs.Size = new System.Drawing.Size(64, 64);
            obs.MaximumSize = new System.Drawing.Size(64, 64);
            obs.MinimumSize = new System.Drawing.Size(64, 64);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon4.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "huge";
            obstacles.Add(obs);
            #endregion
        }

        private void obstacle4Panel_MouseMove(object sender, MouseEventArgs e)
        {
            obs4Box = 1;
        }
        #endregion

        #region Delete Obstacle Button
        private void deleteButton_MouseEnter(object sender, EventArgs e)
        {
            delBox = 1;
        }

        private void deleteButton_MouseLeave(object sender, EventArgs e)
        {
            delBox = 0;
        }

        private void deleteButton_MouseDown(object sender, MouseEventArgs e)
        {
            delBox = 2;
        }

        private void deleteButton_MouseMove(object sender, MouseEventArgs e)
        {
            delBox = 1;
        }
        #endregion


        private void ButtonColorer(Panel p, int t)
        {
            int c = p.BackColor.R;
            if (t == 2)
            {
                if (c > click)
                    c = Clamp(c - 8, 20, 50);
            }
            else if (t == 1)
            {
                if (c < hover)
                    c = Clamp(c + 4, 20, 50);
            }
            else
            {
                if (c < normal)
                    c = Clamp(c + 4, 0, 30);
                else if (c > normal)
                    c = Clamp(c - 4, 30, 50);
            }

            p.BackColor = Color.FromArgb(c, c, c);
        }

        private void pulseTimer_Tick(object sender, EventArgs e)
        {
            if(obstacles.Count!=prevCount)
                AddNewObs();
            ButtonColorer(obstacle1Panel, obs1Box);
            debugTextBox.Text += "\n" + obs2Box;
            ButtonColorer(obstacle2Panel, obs2Box);
            ButtonColorer(obstacle3Panel, obs3Box);
            ButtonColorer(obstacle4Panel, obs4Box);
            ButtonColorer(deleteButton, delBox);
        }

        private int Clamp(int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            else
                return val;
        }

        private void AddNewObs()
        {
            while (prevCount != obstacles.Count)
            {
                previewBox.Controls.Add(obstacles[prevCount]);
                prevCount++;
            }
        }
    }
}
