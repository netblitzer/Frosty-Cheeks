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
        #region Variable Declaration
        private int hover;
        private int click;
        private int normal;
        private List<System.Windows.Forms.PictureBox> obstacles;
        private List<int> obsSpeeds;
        //private System.ComponentModel.ComponentResourceManager resources;
        private short obs1Box, obs2Box, obs3Box, obs4Box, delBox, prevBox, nextBox;
        private int prevCount;
        private bool saved;
        private int selectedObstacle;
        private int type;
        #endregion

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
            obsSpeeds = new List<int>();
            rgen = new Random();
            obs1Box = obs2Box = obs3Box = obs4Box = delBox = prevBox = nextBox = 0;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pulseTimer.Interval = 50;
            pulseTimer.Start();
            prevCount = obstacles.Count;
            saved = false;
            selectedObstacle = 0;
            type = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                Stream myStream;

                saveFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "dat";
                saveFileDialog.InitialDirectory = "..//Frames"; ;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        BinaryWriter output = new BinaryWriter(myStream);
                        output.Write(type);
                        for (int i = 0; i < obstacles.Count; i++)
                        {
                            string name = obstacles[i].Name;
                            debugTextBox.Text += "Saved ";
                            if (name.Contains("normal"))
                            {
                                debugTextBox.Text += "normal ";
                                output.Write(0);
                            }
                            else if (name.Contains("tall"))
                            {
                                debugTextBox.Text += "medium ";
                                output.Write(1);
                            }
                            else if (name.Contains("huge"))
                            {
                                debugTextBox.Text += "huge ";
                                output.Write(2);
                            }
                            else if (name.Contains("moving"))
                            {
                                debugTextBox.Text += "moving ";
                                output.Write(3);
                            }
                            debugTextBox.Text += "obstacle at: " + obstacles[i].Location + " with speed: " + obsSpeeds[i] + Environment.NewLine;
                            output.Write(obstacles[i].Location.X * (1024 / 400));
                            output.Write(obstacles[i].Location.Y * (1024 / 400));
                            output.Write(obsSpeeds[i]);
                        }
                        output.Close();
                        myStream.Close();
                        saved = true;
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prevCount = 0;
            while(obstacles.Count>0)
            {
                obstacles[0].Visible = false;
                obstacles[0] = null;
                obstacles.RemoveAt(0);
            }
            obstacles = new List<PictureBox>();
            obsSpeeds = new List<int>();
            rgen = new Random();
            obs1Box = obs2Box = obs3Box = obs4Box = delBox = prevBox = nextBox = 0;
            saved = true;
            selectedObstacle = 0;
            type = 0;
            speedLabel.Text = "";
            xPosLabel.Text = "";
            speedInputBox.Text = "";
            xPosInputBox.Text = "";
            debugTextBox.Text += "Making a new frame..." + Environment.NewLine;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saved = false;

            prevCount = 0;
            while (obstacles.Count > 0)
            {
                obstacles[0].Visible = false;
                obstacles[0] = null;
                obstacles.RemoveAt(0);
            }
            obstacles = new List<PictureBox>();
            obsSpeeds = new List<int>();
            rgen = new Random();
            selectedObstacle = 0;

            Stream reader = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Data files (*.dat)|*.dat|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((reader = openFileDialog.OpenFile()) != null)
                    {
                        debugTextBox.Text += "Opening file: " + openFileDialog.FileName + Environment.NewLine;

                        BinaryReader input = new BinaryReader(reader);
                        switch (input.ReadInt32())
                        {
                            case 0:
                                normalRadioButton.Checked = true;
                                windyRadioButton.Checked = false;
                                warmRadioButton.Checked = false;
                                type = 0;
                                break;
                            case 1:
                                normalRadioButton.Checked = false;
                                windyRadioButton.Checked = true;
                                warmRadioButton.Checked = false;
                                type = 1;
                                break;
                            case 2:
                                normalRadioButton.Checked = false;
                                windyRadioButton.Checked = false;
                                warmRadioButton.Checked = true;
                                type = 2;
                                break;
                        }

                        int obstype;
                        try
                        {
                            while ((obstype = input.ReadInt32()) != null)
                            {
                                PictureBox obs = new PictureBox();
                                obs.Location = new System.Drawing.Point(input.ReadInt32() / (1024 / 400), input.ReadInt32() / (1024 / 400));

                                switch (obstype)
                                {
                                    case 0:
                                        obs.Size = new System.Drawing.Size(32, 32);
                                        obs.MaximumSize = new System.Drawing.Size(32, 32);
                                        obs.MinimumSize = new System.Drawing.Size(32, 32);
                                        obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon1.png");
                                        obs.Name = "obstacle" + obstacles.Count + "normal";
                                        break;
                                    case 1:
                                        obs.Size = new System.Drawing.Size(48, 48);
                                        obs.MaximumSize = new System.Drawing.Size(48, 48);
                                        obs.MinimumSize = new System.Drawing.Size(48, 48);
                                        obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon3.png");
                                        obs.Name = "obstacle" + obstacles.Count + "tall";
                                        break;
                                    case 2:
                                        obs.Size = new System.Drawing.Size(64, 64);
                                        obs.MaximumSize = new System.Drawing.Size(64, 64);
                                        obs.MinimumSize = new System.Drawing.Size(64, 64);
                                        obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon4.png");
                                        obs.Name = "obstacle" + obstacles.Count + "huge";
                                        break;
                                    case 3:
                                        obs.Size = new System.Drawing.Size(64, 32);
                                        obs.MaximumSize = new System.Drawing.Size(64, 32);
                                        obs.MinimumSize = new System.Drawing.Size(64, 32);
                                        obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon2.png");
                                        obs.Name = "obstacle" + obstacles.Count + "moving";
                                        break;
                                }

                                ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
                                obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                                obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

                                obsSpeeds.Add(input.ReadInt32());
                                obstacles.Add(obs);

                            }
                        }
                        catch (Exception E)
                        {
                            speedLabel.Text = "" + obsSpeeds[0];
                            xPosLabel.Text = "" + obstacles[0].Location.X;
                            speedInputBox.Text = "" + obsSpeeds[0];
                            xPosInputBox.Text = "" + obstacles[0].Location.X;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
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
                    output.Write(type);
                    for(int i = 0; i < obstacles.Count; i++)
                    {
                        string name = obstacles[i].Name;
                        debugTextBox.Text += "Saved ";
                        if (name.Contains("normal"))
                        {
                            debugTextBox.Text += "normal ";
                            output.Write(0);
                        }
                        else if (name.Contains("tall"))
                        {
                            debugTextBox.Text += "medium ";
                            output.Write(1);
                        }
                        else if (name.Contains("huge"))
                        {
                            debugTextBox.Text += "huge ";
                            output.Write(2);
                        }
                        else if (name.Contains("moving"))
                        {
                            debugTextBox.Text += "moving ";
                            output.Write(3);
                        }
                        debugTextBox.Text += "obstacle at: " + obstacles[i].Location + " with speed: " + obsSpeeds[i] + Environment.NewLine;
                        output.Write(obstacles[i].Location.X * (1024 / 400));
                        output.Write(obstacles[i].Location.Y * (1024 / 400));
                        output.Write(obsSpeeds[i]);
                    }
                    output.Close();
                    myStream.Close();
                    saved = true;
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
            saved = false;
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 368), 300);
            obs.Size = new System.Drawing.Size(32, 32);
            obs.MaximumSize = new System.Drawing.Size(32, 32);
            obs.MinimumSize = new System.Drawing.Size(32, 32);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon1.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "normal";
            obsSpeeds.Add(0);
            obstacles.Add(obs);

            if (obstacles.Count == 1)
            {
                speedLabel.Text = "" + obsSpeeds[0];
                xPosLabel.Text = "" + obstacles[0].Location.X;
                speedInputBox.Text = "" + obsSpeeds[0];
                xPosInputBox.Text = "" + obstacles[0].Location.X;
            }
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
            saved = false;
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 336), 300);
            obs.Size = new System.Drawing.Size(64, 32);
            obs.MaximumSize = new System.Drawing.Size(64, 32);
            obs.MinimumSize = new System.Drawing.Size(64, 32);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon2.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "moving";
            obsSpeeds.Add(10);
            obstacles.Add(obs);

            if (obstacles.Count == 1)
            {
                speedLabel.Text = "" + obsSpeeds[0];
                xPosLabel.Text = "" + obstacles[0].Location.X;
                speedInputBox.Text = "" + obsSpeeds[0];
                xPosInputBox.Text = "" + obstacles[0].Location.X;
            }
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
            saved = false;
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 356), 284);
            obs.Size = new System.Drawing.Size(48, 48);
            obs.MaximumSize = new System.Drawing.Size(48, 48);
            obs.MinimumSize = new System.Drawing.Size(48, 48);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon3.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "tall";
            obsSpeeds.Add(0);
            obstacles.Add(obs);

            if (obstacles.Count == 1)
            {
                speedLabel.Text = "" + obsSpeeds[0];
                xPosLabel.Text = "" + obstacles[0].Location.X;
                speedInputBox.Text = "" + obsSpeeds[0];
                xPosInputBox.Text = "" + obstacles[0].Location.X;
            }
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
            saved = false;
            PictureBox obs = new PictureBox();
            obs.Location = new System.Drawing.Point(rgen.Next(0, 336), 268);
            obs.Size = new System.Drawing.Size(64, 64);
            obs.MaximumSize = new System.Drawing.Size(64, 64);
            obs.MinimumSize = new System.Drawing.Size(64, 64);

            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon4.png");
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;

            obs.Name = "obstacle" + obstacles.Count + "huge";
            obsSpeeds.Add(0);
            obstacles.Add(obs);

            if (obstacles.Count == 1)
            {
                speedLabel.Text = "" + obsSpeeds[0];
                xPosLabel.Text = "" + obstacles[0].Location.X;
                speedInputBox.Text = "" + obsSpeeds[0];
                xPosInputBox.Text = "" + obstacles[0].Location.X;
            }
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
            if(obstacles.Count>0)
            {
                saved = false;
                obstacles[selectedObstacle].Visible = false;
                obstacles.RemoveAt(selectedObstacle);
                obsSpeeds.RemoveAt(selectedObstacle);
                selectedObstacle = Clamp(selectedObstacle - 1, 0, obstacles.Count);
                prevCount--;
                if (obstacles.Count > 0)
                {
                    speedLabel.Text = "" + obsSpeeds[selectedObstacle];
                    xPosLabel.Text = "" + obstacles[selectedObstacle].Location.X;
                    speedInputBox.Text = "" + obsSpeeds[selectedObstacle];
                    xPosInputBox.Text = "" + obstacles[selectedObstacle].Location.X;
                }
            }
        }

        private void deleteButton_MouseMove(object sender, MouseEventArgs e)
        {
            delBox = 1;
        }
        #endregion

        #region Next Obstacle Button
        private void nextButton_MouseEnter(object sender, EventArgs e)
        {
            nextBox = 1;
        }

        private void nextButton_MouseLeave(object sender, EventArgs e)
        {
            nextBox = 0;
        }

        private void nextButton_MouseDown(object sender, MouseEventArgs e)
        {
            nextBox = 2;
            if (obstacles.Count > 0)
            {
                selectedObstacle++;
                if (selectedObstacle >= obstacles.Count)
                    selectedObstacle %= obstacles.Count;
                speedLabel.Text = "" + obsSpeeds[selectedObstacle];
                xPosLabel.Text = "" + obstacles[selectedObstacle].Location.X;
                speedInputBox.Text = "" + obsSpeeds[selectedObstacle];
                xPosInputBox.Text = "" + obstacles[selectedObstacle].Location.X;
            }
        }

        private void nextButton_MouseMove(object sender, MouseEventArgs e)
        {
            nextBox = 1;
        }
        #endregion

        #region Previous Obstacle Button
        private void previousButton_MouseEnter(object sender, EventArgs e)
        {
            prevBox = 1;
        }

        private void previousButton_MouseLeave(object sender, EventArgs e)
        {
            prevBox = 0;
        }

        private void previousButton_MouseDown(object sender, MouseEventArgs e)
        {
            prevBox = 2;
            if (obstacles.Count > 0)
            {
                selectedObstacle--;
                if (selectedObstacle < 0)
                    selectedObstacle += obstacles.Count;
                speedLabel.Text = "" + obsSpeeds[selectedObstacle];
                xPosLabel.Text = "" + obstacles[selectedObstacle].Location.X;
                speedInputBox.Text = "" + obsSpeeds[selectedObstacle];
                xPosInputBox.Text = "" + obstacles[selectedObstacle].Location.X;
            }
        }

        private void previousButton_MouseMove(object sender, MouseEventArgs e)
        {
            prevBox = 1;
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
            if(obstacles.Count>prevCount)
                AddNewObs();
            ButtonColorer(obstacle1Panel, obs1Box);
            ButtonColorer(obstacle2Panel, obs2Box);
            ButtonColorer(obstacle3Panel, obs3Box);
            ButtonColorer(obstacle4Panel, obs4Box);
            ButtonColorer(deleteButton, delBox);
            ButtonColorer(nextButton, nextBox);
            ButtonColorer(previousButton, prevBox);

            if (normalRadioButton.Checked)
                type = 0;
            else if (windyRadioButton.Checked)
                type = 1;
            else
                type = 2;

            if (obstacles.Count > 0)
            {
                numberLabel.Text = "Number: " + (selectedObstacle + 1);
                speedLabel.Text = "" + obsSpeeds[selectedObstacle];
                xPosLabel.Text = "" + obstacles[selectedObstacle].Location.X;
                string name = obstacles[selectedObstacle].Name;
                if (name.Contains("normal"))
                {
                    typeLabel.Text = "Normal";
                    obstaclePreviewPic.Image = System.Drawing.Image.FromFile("DevObstacleIcon1.png");
                    obstaclePreviewPic.Size = new System.Drawing.Size(32, 32);
                    obstaclePreviewPic.Location = new Point(19, 19);
                    if (xPosInputBox != null)
                    {
                        int x = 0;
                        int.TryParse(xPosInputBox.Text, out x);
                        x = Clamp(x, 0, 356);
                        obstacles[selectedObstacle].Location = new Point(x, obstacles[selectedObstacle].Location.Y);
                    }
                }
                if (name.Contains("tall"))
                {
                    typeLabel.Text = "Medium";
                    obstaclePreviewPic.Image = System.Drawing.Image.FromFile("DevObstacleIcon3.png");
                    obstaclePreviewPic.Size = new System.Drawing.Size(48, 48);
                    obstaclePreviewPic.Location = new Point(13, 9);
                    if (xPosInputBox != null)
                    {
                        int x = 0;
                        int.TryParse(xPosInputBox.Text, out x);
                        x = Clamp(x, 0, 356);
                        obstacles[selectedObstacle].Location = new Point(x, obstacles[selectedObstacle].Location.Y);
                    }
                }
                if (name.Contains("huge"))
                {
                    typeLabel.Text = "Huge";
                    obstaclePreviewPic.Image = System.Drawing.Image.FromFile("DevObstacleIcon4.png");
                    obstaclePreviewPic.Size = new System.Drawing.Size(64, 64);
                    obstaclePreviewPic.Location = new Point(3, 3);
                    if (xPosInputBox != null)
                    {
                        int x = 0;
                        int.TryParse(xPosInputBox.Text, out x);
                        x = Clamp(x, 0, 336);
                        obstacles[selectedObstacle].Location = new Point(x,obstacles[selectedObstacle].Location.Y);
                    }
                }
                if (name.Contains("moving"))
                {
                    typeLabel.Text = "Moving";
                    obstaclePreviewPic.Image = System.Drawing.Image.FromFile("DevObstacleIcon2.png");
                    obstaclePreviewPic.Size = new System.Drawing.Size(64, 32);
                    obstaclePreviewPic.Location = new Point(3, 19);
                    if (xPosInputBox != null)
                    {
                        int x = 0;
                        int.TryParse(xPosInputBox.Text, out x);
                        x = Clamp(x, 0, 336);
                        obstacles[selectedObstacle].Location = new Point(x, obstacles[selectedObstacle].Location.Y);
                    }
                    if (speedInputBox != null)
                    {
                        int s = 0;
                        int.TryParse(speedInputBox.Text, out s);
                        s = Clamp(s, -50, 50);
                        obsSpeeds[selectedObstacle] = s;
                    }
                }
            }
            else
            {
                typeLabel.Text = "";
                numberLabel.Text = "Number: ";
                speedLabel.Text = "";
                xPosLabel.Text = "";
                obstaclePreviewPic.Image = null;
            }
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
                debugTextBox.Text += "Added obstacle at: " + obstacles[prevCount].Location + Environment.NewLine;
                prevCount++;
            }
        }
    }
}
