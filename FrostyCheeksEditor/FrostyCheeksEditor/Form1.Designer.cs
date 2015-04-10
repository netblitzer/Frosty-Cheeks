﻿namespace FrostyCheeksEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputPanel = new System.Windows.Forms.Panel();
            this.obstacle4Panel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.obstacle2Panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.obstacle3Panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.obstacle1Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.xPosInputBox = new System.Windows.Forms.TextBox();
            this.speedInputBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.obstaclePreviewPic = new System.Windows.Forms.PictureBox();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pulseTimer = new System.Windows.Forms.Timer(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.deleteButton = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.inputPanel.SuspendLayout();
            this.obstacle4Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.obstacle2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.obstacle3Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.obstacle1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.outputPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclePreviewPic)).BeginInit();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.deleteButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPanel
            // 
            this.inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPanel.Controls.Add(this.obstacle4Panel);
            this.inputPanel.Controls.Add(this.obstacle2Panel);
            this.inputPanel.Controls.Add(this.obstacle3Panel);
            this.inputPanel.Controls.Add(this.label2);
            this.inputPanel.Controls.Add(this.obstacle1Panel);
            this.inputPanel.Location = new System.Drawing.Point(22, 36);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(200, 510);
            this.inputPanel.TabIndex = 1;
            // 
            // obstacle4Panel
            // 
            this.obstacle4Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.obstacle4Panel.Controls.Add(this.label4);
            this.obstacle4Panel.Controls.Add(this.pictureBox3);
            this.obstacle4Panel.Location = new System.Drawing.Point(2, 285);
            this.obstacle4Panel.Name = "obstacle4Panel";
            this.obstacle4Panel.Size = new System.Drawing.Size(194, 70);
            this.obstacle4Panel.TabIndex = 4;
            this.obstacle4Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle4Panel_MouseDown);
            this.obstacle4Panel.MouseEnter += new System.EventHandler(this.obstacle4Panel_MouseEnter);
            this.obstacle4Panel.MouseLeave += new System.EventHandler(this.obstacle4Panel_MouseLeave);
            this.obstacle4Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle4Panel_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(88, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "Huge";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle4Panel_MouseDown);
            this.label4.MouseEnter += new System.EventHandler(this.obstacle4Panel_MouseEnter);
            this.label4.MouseLeave += new System.EventHandler(this.obstacle4Panel_MouseLeave);
            this.label4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle4Panel_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle4Panel_MouseDown);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.obstacle4Panel_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.obstacle4Panel_MouseLeave);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle4Panel_MouseMove);
            // 
            // obstacle2Panel
            // 
            this.obstacle2Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.obstacle2Panel.Controls.Add(this.label3);
            this.obstacle2Panel.Controls.Add(this.pictureBox2);
            this.obstacle2Panel.Location = new System.Drawing.Point(2, 131);
            this.obstacle2Panel.Name = "obstacle2Panel";
            this.obstacle2Panel.Size = new System.Drawing.Size(194, 70);
            this.obstacle2Panel.TabIndex = 2;
            this.obstacle2Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle2Panel_MouseDown);
            this.obstacle2Panel.MouseEnter += new System.EventHandler(this.obstacle2Panel_MouseEnter);
            this.obstacle2Panel.MouseLeave += new System.EventHandler(this.obstacle2Panel_MouseLeave);
            this.obstacle2Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle2Panel_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(77, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Moving";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle2Panel_MouseDown);
            this.label3.MouseEnter += new System.EventHandler(this.obstacle2Panel_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.obstacle2Panel_MouseLeave);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle2Panel_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle2Panel_MouseDown);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.obstacle2Panel_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.obstacle2Panel_MouseLeave);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle2Panel_MouseMove);
            // 
            // obstacle3Panel
            // 
            this.obstacle3Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.obstacle3Panel.Controls.Add(this.label5);
            this.obstacle3Panel.Controls.Add(this.pictureBox4);
            this.obstacle3Panel.Location = new System.Drawing.Point(2, 207);
            this.obstacle3Panel.Name = "obstacle3Panel";
            this.obstacle3Panel.Size = new System.Drawing.Size(194, 70);
            this.obstacle3Panel.TabIndex = 3;
            this.obstacle3Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle3Panel_MouseDown);
            this.obstacle3Panel.MouseEnter += new System.EventHandler(this.obstacle3Panel_MouseEnter);
            this.obstacle3Panel.MouseLeave += new System.EventHandler(this.obstacle3Panel_MouseLeave);
            this.obstacle3Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle3Panel_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(95, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tall";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle3Panel_MouseDown);
            this.label5.MouseEnter += new System.EventHandler(this.obstacle3Panel_MouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.obstacle3Panel_MouseLeave);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle3Panel_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle3Panel_MouseDown);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.obstacle3Panel_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.obstacle3Panel_MouseLeave);
            this.pictureBox4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle3Panel_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Obstacles";
            // 
            // obstacle1Panel
            // 
            this.obstacle1Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.obstacle1Panel.Controls.Add(this.label1);
            this.obstacle1Panel.Controls.Add(this.pictureBox1);
            this.obstacle1Panel.Location = new System.Drawing.Point(2, 53);
            this.obstacle1Panel.Name = "obstacle1Panel";
            this.obstacle1Panel.Size = new System.Drawing.Size(194, 70);
            this.obstacle1Panel.TabIndex = 0;
            this.obstacle1Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle1Panel_MouseDown);
            this.obstacle1Panel.MouseEnter += new System.EventHandler(this.obstacle1Panel_MouseEnter);
            this.obstacle1Panel.MouseLeave += new System.EventHandler(this.obstacle1Panel_MouseLeave);
            this.obstacle1Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle1Panel_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Normal";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle1Panel_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.obstacle1Panel_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.obstacle1Panel_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle1Panel_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.obstacle1Panel_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.obstacle1Panel_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.obstacle1Panel_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.obstacle1Panel_MouseMove);
            // 
            // outputPanel
            // 
            this.outputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputPanel.Controls.Add(this.panel3);
            this.outputPanel.Location = new System.Drawing.Point(663, 36);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(200, 510);
            this.outputPanel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.deleteButton);
            this.panel3.Controls.Add(this.xPosInputBox);
            this.panel3.Controls.Add(this.speedInputBox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.obstaclePreviewPic);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 164);
            this.panel3.TabIndex = 0;
            // 
            // xPosInputBox
            // 
            this.xPosInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPosInputBox.Location = new System.Drawing.Point(102, 105);
            this.xPosInputBox.MaxLength = 2;
            this.xPosInputBox.Name = "xPosInputBox";
            this.xPosInputBox.Size = new System.Drawing.Size(48, 22);
            this.xPosInputBox.TabIndex = 5;
            this.xPosInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // speedInputBox
            // 
            this.speedInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedInputBox.Location = new System.Drawing.Point(102, 80);
            this.speedInputBox.MaxLength = 2;
            this.speedInputBox.Name = "speedInputBox";
            this.speedInputBox.Size = new System.Drawing.Size(48, 22);
            this.speedInputBox.TabIndex = 4;
            this.speedInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(32, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "X Pos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(27, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Speed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(74, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Type:";
            // 
            // obstaclePreviewPic
            // 
            this.obstaclePreviewPic.Location = new System.Drawing.Point(3, 3);
            this.obstaclePreviewPic.Name = "obstaclePreviewPic";
            this.obstaclePreviewPic.Size = new System.Drawing.Size(64, 64);
            this.obstaclePreviewPic.TabIndex = 0;
            this.obstaclePreviewPic.TabStop = false;
            // 
            // debugTextBox
            // 
            this.debugTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.debugTextBox.Location = new System.Drawing.Point(241, 460);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(400, 75);
            this.debugTextBox.TabIndex = 3;
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(884, 24);
            this.menuBar.TabIndex = 4;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            // 
            // previewBox
            // 
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Image = ((System.Drawing.Image)(resources.GetObject("previewBox.Image")));
            this.previewBox.Location = new System.Drawing.Point(241, 36);
            this.previewBox.MaximumSize = new System.Drawing.Size(400, 400);
            this.previewBox.MinimumSize = new System.Drawing.Size(400, 400);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(400, 400);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewBox.TabIndex = 5;
            this.previewBox.TabStop = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "dat";
            this.saveFileDialog.InitialDirectory = "Frames";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // pulseTimer
            // 
            this.pulseTimer.Tick += new System.EventHandler(this.pulseTimer_Tick);
            // 
            // deleteButton
            // 
            this.deleteButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deleteButton.Controls.Add(this.label9);
            this.deleteButton.Location = new System.Drawing.Point(45, 133);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 26);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseDown);
            this.deleteButton.MouseEnter += new System.EventHandler(this.deleteButton_MouseEnter);
            this.deleteButton.MouseLeave += new System.EventHandler(this.deleteButton_MouseLeave);
            this.deleteButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseMove);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(19, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Delete";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseDown);
            this.label9.MouseEnter += new System.EventHandler(this.deleteButton_MouseEnter);
            this.label9.MouseLeave += new System.EventHandler(this.deleteButton_MouseLeave);
            this.label9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frosty Cheeks Frame Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.obstacle4Panel.ResumeLayout(false);
            this.obstacle4Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.obstacle2Panel.ResumeLayout(false);
            this.obstacle2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.obstacle3Panel.ResumeLayout(false);
            this.obstacle3Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.obstacle1Panel.ResumeLayout(false);
            this.obstacle1Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.outputPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclePreviewPic)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.deleteButton.ResumeLayout(false);
            this.deleteButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
        protected System.Windows.Forms.PictureBox previewBox;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel obstacle1Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.Panel obstacle2Panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel obstacle4Panel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel obstacle3Panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Timer pulseTimer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox obstaclePreviewPic;
        private System.Windows.Forms.TextBox xPosInputBox;
        private System.Windows.Forms.TextBox speedInputBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.Panel deleteButton;
        private System.Windows.Forms.Label label9;
    }
}

