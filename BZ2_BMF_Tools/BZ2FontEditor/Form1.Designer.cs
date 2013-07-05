namespace BZ2FontEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFontIdent = new System.Windows.Forms.Label();
            this.lblNumChar = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCharWidth = new System.Windows.Forms.Label();
            this.lblCharHeight = new System.Windows.Forms.Label();
            this.nudFontHeight = new System.Windows.Forms.NumericUpDown();
            this.nudFontAscent = new System.Windows.Forms.NumericUpDown();
            this.nudFontDescent = new System.Windows.Forms.NumericUpDown();
            this.nudCharValue = new System.Windows.Forms.NumericUpDown();
            this.nudFullWidth = new System.Windows.Forms.NumericUpDown();
            this.nudRecX0 = new System.Windows.Forms.NumericUpDown();
            this.nudRecX1 = new System.Windows.Forms.NumericUpDown();
            this.nudRecY0 = new System.Windows.Forms.NumericUpDown();
            this.nudRecY1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.imgWords = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontAscent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontDescent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFullWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecX0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecY0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWords)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Battlezone II Bitmap Font|*.bmf";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Font Ident";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Characters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Font Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Font Ascent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Font Descent";
            // 
            // lblFontIdent
            // 
            this.lblFontIdent.AutoSize = true;
            this.lblFontIdent.Location = new System.Drawing.Point(128, 24);
            this.lblFontIdent.Name = "lblFontIdent";
            this.lblFontIdent.Size = new System.Drawing.Size(31, 13);
            this.lblFontIdent.TabIndex = 6;
            this.lblFontIdent.Text = "Ident";
            // 
            // lblNumChar
            // 
            this.lblNumChar.AutoSize = true;
            this.lblNumChar.Location = new System.Drawing.Point(128, 43);
            this.lblNumChar.Name = "lblNumChar";
            this.lblNumChar.Size = new System.Drawing.Size(35, 13);
            this.lblNumChar.TabIndex = 7;
            this.lblNumChar.Text = "Count";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 144);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 199);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.pictureBox3);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(186, 144);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 199);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // lblCharWidth
            // 
            this.lblCharWidth.AutoSize = true;
            this.lblCharWidth.Location = new System.Drawing.Point(223, 24);
            this.lblCharWidth.Name = "lblCharWidth";
            this.lblCharWidth.Size = new System.Drawing.Size(12, 13);
            this.lblCharWidth.TabIndex = 16;
            this.lblCharWidth.Text = "x";
            // 
            // lblCharHeight
            // 
            this.lblCharHeight.AutoSize = true;
            this.lblCharHeight.Location = new System.Drawing.Point(296, 24);
            this.lblCharHeight.Name = "lblCharHeight";
            this.lblCharHeight.Size = new System.Drawing.Size(12, 13);
            this.lblCharHeight.TabIndex = 17;
            this.lblCharHeight.Text = "y";
            // 
            // nudFontHeight
            // 
            this.nudFontHeight.Location = new System.Drawing.Point(131, 62);
            this.nudFontHeight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFontHeight.Name = "nudFontHeight";
            this.nudFontHeight.Size = new System.Drawing.Size(49, 20);
            this.nudFontHeight.TabIndex = 18;
            // 
            // nudFontAscent
            // 
            this.nudFontAscent.Location = new System.Drawing.Point(131, 88);
            this.nudFontAscent.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFontAscent.Name = "nudFontAscent";
            this.nudFontAscent.Size = new System.Drawing.Size(49, 20);
            this.nudFontAscent.TabIndex = 19;
            // 
            // nudFontDescent
            // 
            this.nudFontDescent.Location = new System.Drawing.Point(131, 114);
            this.nudFontDescent.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFontDescent.Name = "nudFontDescent";
            this.nudFontDescent.Size = new System.Drawing.Size(49, 20);
            this.nudFontDescent.TabIndex = 20;
            // 
            // nudCharValue
            // 
            this.nudCharValue.Location = new System.Drawing.Point(299, 42);
            this.nudCharValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudCharValue.Name = "nudCharValue";
            this.nudCharValue.Size = new System.Drawing.Size(49, 20);
            this.nudCharValue.TabIndex = 21;
            // 
            // nudFullWidth
            // 
            this.nudFullWidth.Location = new System.Drawing.Point(299, 67);
            this.nudFullWidth.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFullWidth.Name = "nudFullWidth";
            this.nudFullWidth.Size = new System.Drawing.Size(49, 20);
            this.nudFullWidth.TabIndex = 22;
            // 
            // nudRecX0
            // 
            this.nudRecX0.Location = new System.Drawing.Point(244, 92);
            this.nudRecX0.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRecX0.Name = "nudRecX0";
            this.nudRecX0.Size = new System.Drawing.Size(49, 20);
            this.nudRecX0.TabIndex = 23;
            // 
            // nudRecX1
            // 
            this.nudRecX1.Location = new System.Drawing.Point(299, 92);
            this.nudRecX1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRecX1.Name = "nudRecX1";
            this.nudRecX1.Size = new System.Drawing.Size(49, 20);
            this.nudRecX1.TabIndex = 24;
            // 
            // nudRecY0
            // 
            this.nudRecY0.Location = new System.Drawing.Point(244, 117);
            this.nudRecY0.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRecY0.Name = "nudRecY0";
            this.nudRecY0.Size = new System.Drawing.Size(49, 20);
            this.nudRecY0.TabIndex = 25;
            // 
            // nudRecY1
            // 
            this.nudRecY1.Location = new System.Drawing.Point(299, 117);
            this.nudRecY1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRecY1.Name = "nudRecY1";
            this.nudRecY1.Size = new System.Drawing.Size(49, 20);
            this.nudRecY1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Character Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Full Width";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Rect X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(184, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Rect Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(186, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Width";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(252, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Height";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(3, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // txtWords
            // 
            this.txtWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWords.Location = new System.Drawing.Point(12, 349);
            this.txtWords.Multiline = true;
            this.txtWords.Name = "txtWords";
            this.txtWords.Size = new System.Drawing.Size(336, 81);
            this.txtWords.TabIndex = 33;
            this.txtWords.TextChanged += new System.EventHandler(this.txtWords_TextChanged);
            // 
            // imgWords
            // 
            this.imgWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgWords.Location = new System.Drawing.Point(12, 436);
            this.imgWords.Name = "imgWords";
            this.imgWords.Size = new System.Drawing.Size(336, 69);
            this.imgWords.TabIndex = 34;
            this.imgWords.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 517);
            this.Controls.Add(this.imgWords);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudRecY1);
            this.Controls.Add(this.nudRecY0);
            this.Controls.Add(this.nudRecX1);
            this.Controls.Add(this.nudRecX0);
            this.Controls.Add(this.nudFullWidth);
            this.Controls.Add(this.nudCharValue);
            this.Controls.Add(this.nudFontDescent);
            this.Controls.Add(this.nudFontAscent);
            this.Controls.Add(this.nudFontHeight);
            this.Controls.Add(this.lblCharHeight);
            this.Controls.Add(this.lblCharWidth);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblNumChar);
            this.Controls.Add(this.lblFontIdent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BZ2 - Font Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFontHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontAscent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontDescent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFullWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecX0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecY0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFontIdent;
        private System.Windows.Forms.Label lblNumChar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblCharWidth;
        private System.Windows.Forms.Label lblCharHeight;
        private System.Windows.Forms.NumericUpDown nudFontHeight;
        private System.Windows.Forms.NumericUpDown nudFontAscent;
        private System.Windows.Forms.NumericUpDown nudFontDescent;
        private System.Windows.Forms.NumericUpDown nudCharValue;
        private System.Windows.Forms.NumericUpDown nudFullWidth;
        private System.Windows.Forms.NumericUpDown nudRecX0;
        private System.Windows.Forms.NumericUpDown nudRecX1;
        private System.Windows.Forms.NumericUpDown nudRecY0;
        private System.Windows.Forms.NumericUpDown nudRecY1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.PictureBox imgWords;
    }
}

