﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            BinaryWriter output = new BinaryWriter(File.OpenWrite("frame1.dat"));
            output.Write("bg.png");
            output.Write(1000);
            output.Write(500);
			output.Write(1000);
            output.Write(500);
        }
    }
}
