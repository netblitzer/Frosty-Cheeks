namespace FrostyCheeksEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputPanel = new System.Windows.Forms.Panel();
            this.obstacle2Panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.obstacle1Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.outputPanel = new System.Windows.Forms.Panel();
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
            this.inputPanel.SuspendLayout();
            this.obstacle2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.obstacle1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPanel
            // 
            this.inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputPanel.Controls.Add(this.obstacle2Panel);
            this.inputPanel.Controls.Add(this.label2);
            this.inputPanel.Controls.Add(this.obstacle1Panel);
            this.inputPanel.Location = new System.Drawing.Point(22, 36);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(200, 510);
            this.inputPanel.TabIndex = 1;
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
            this.label3.Location = new System.Drawing.Point(73, 20);
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
            this.label1.Location = new System.Drawing.Point(73, 20);
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
            this.outputPanel.Location = new System.Drawing.Point(663, 36);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(200, 510);
            this.outputPanel.TabIndex = 2;
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
            this.obstacle2Panel.ResumeLayout(false);
            this.obstacle2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.obstacle1Panel.ResumeLayout(false);
            this.obstacle1Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
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
    }
}

