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

namespace FrostyCheeksEditor
{
    public partial class Form1 : Form
    {
        // Variable Declaration
        private Color hover;
        private Color click;
        private Color normal;
        private List<System.Windows.Forms.PictureBox> obstacles;
        private System.ComponentModel.ComponentResourceManager resources;

        // REMOVE LATER
        private Random rgen;
        public Form1()
        {
            InitializeComponent();
            BinaryWriter output = new BinaryWriter(File.OpenWrite("frame1.dat"));
            output.Write("bg.png");
            #region Test Stuff
            output.Write(1000);
            output.Write(500);
			output.Write(1000);
            output.Write(500);
            #endregion
            // Button Stuffs
            hover = Color.FromArgb(50, 50, 50);
            click = Color.FromArgb(20, 20, 20);
            normal = Color.FromArgb(30, 30, 30);
            // Other Stuffs
            obstacles = new List<PictureBox>();
            rgen = new Random();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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

            saveFileDialog.Filter = "Data files (*.dat)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.InitialDirectory = "..//Frames";;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        #region Normal Obstacle Button
        private void obstacle1Panel_MouseEnter(object sender, EventArgs e)
        {
            obstacle1Panel.BackColor = hover;
        }

        private void obstacle1Panel_MouseLeave(object sender, EventArgs e)
        {
            obstacle1Panel.BackColor = normal;
        }

        private void obstacle1Panel_MouseDown(object sender, MouseEventArgs e)
        {
            obstacle1Panel.BackColor = click;
            #region Adding New Obstacles
            PictureBox obs = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(obs)).BeginInit();
            obs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            obs.Image = System.Drawing.Image.FromFile("DevObstacleIcon1.png");
            obs.Location = new System.Drawing.Point(rgen.Next(31, 368), 250);
            obs.MaximumSize = new System.Drawing.Size(32, 32);
            obs.MinimumSize = new System.Drawing.Size(32, 32);
            obs.Name = "obstacle" + obstacles.Count;
            obs.Size = new System.Drawing.Size(32, 300);
            obs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            obs.TabIndex = 5;
            obs.TabStop = false;
            this.previewBox.Controls.Add(obs);
            obstacles.Add(obs);

            #endregion
        }

        private void obstacle1Panel_MouseMove(object sender, MouseEventArgs e)
        {
            obstacle1Panel.BackColor = hover;
        }
        #endregion

        #region Moving Obstacle Button
        private void obstacle2Panel_MouseEnter(object sender, EventArgs e)
        {
            obstacle2Panel.BackColor = hover;
        }

        private void obstacle2Panel_MouseLeave(object sender, EventArgs e)
        {
            obstacle2Panel.BackColor = normal;
        }

        private void obstacle2Panel_MouseDown(object sender, MouseEventArgs e)
        {
            obstacle2Panel.BackColor = click;
        }

        private void obstacle2Panel_MouseMove(object sender, MouseEventArgs e)
        {
            obstacle2Panel.BackColor = hover;
        }
        #endregion
    }
}
