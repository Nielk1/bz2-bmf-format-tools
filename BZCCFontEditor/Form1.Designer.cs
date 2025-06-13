namespace BZCCFontEditor
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            fromFontToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblFontIdent = new Label();
            lblNumChar = new Label();
            listBox1 = new ListBox();
            lblCharWidth = new Label();
            lblCharHeight = new Label();
            nudFontHeight = new NumericUpDown();
            nudFontAscent = new NumericUpDown();
            nudFontDescent = new NumericUpDown();
            nudCharValue = new NumericUpDown();
            nudFullWidth = new NumericUpDown();
            nudRecX0 = new NumericUpDown();
            nudRecX1 = new NumericUpDown();
            nudRecY0 = new NumericUpDown();
            nudRecY1 = new NumericUpDown();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtWords = new TextBox();
            imgWords = new PictureBox();
            label12 = new Label();
            nudExtendedLeftOffset = new NumericUpDown();
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            splitContainer2 = new SplitContainer();
            fontDialog1 = new FontDialog();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog2 = new OpenFileDialog();
            saveFileDialog2 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFontHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFontAscent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFontDescent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCharValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFullWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRecX0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRecX1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRecY0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRecY1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgWords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudExtendedLeftOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(422, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripMenuItem2, exportToolStripMenuItem, importToolStripMenuItem, fromFontToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(180, 22);
            toolStripMenuItem2.Text = "&Save";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(180, 22);
            exportToolStripMenuItem.Text = "E&xport";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(180, 22);
            importToolStripMenuItem.Text = "&Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // fromFontToolStripMenuItem
            // 
            fromFontToolStripMenuItem.Name = "fromFontToolStripMenuItem";
            fromFontToolStripMenuItem.Size = new Size(180, 22);
            fromFontToolStripMenuItem.Text = "&Load System Font";
            fromFontToolStripMenuItem.Click += fromFontToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Font|*.bmf;*.st;*.sta;*.ttf|BZCC/BZ2 Bitmap Font|*.bmf|BZ98 Sprite Font|*.st;*.sta|True Type Font|*.ttf";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 5);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 1;
            label1.Text = "Font Ident";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 27);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 2;
            label2.Text = "Number of Characters";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 51);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 3;
            label3.Text = "Font Height";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 81);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 4;
            label4.Text = "Font Ascent";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 111);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 5;
            label5.Text = "Font Descent";
            // 
            // lblFontIdent
            // 
            lblFontIdent.AutoSize = true;
            lblFontIdent.Location = new Point(149, 5);
            lblFontIdent.Margin = new Padding(4, 0, 4, 0);
            lblFontIdent.Name = "lblFontIdent";
            lblFontIdent.Size = new Size(34, 15);
            lblFontIdent.TabIndex = 6;
            lblFontIdent.Text = "Ident";
            // 
            // lblNumChar
            // 
            lblNumChar.AutoSize = true;
            lblNumChar.Location = new Point(149, 27);
            lblNumChar.Margin = new Padding(4, 0, 4, 0);
            lblNumChar.Name = "lblNumChar";
            lblNumChar.Size = new Size(40, 15);
            lblNumChar.TabIndex = 7;
            lblNumChar.Text = "Count";
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(14, 143);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(171, 259);
            listBox1.TabIndex = 11;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.DoubleClick += listBox1_DoubleClick;
            // 
            // lblCharWidth
            // 
            lblCharWidth.AutoSize = true;
            lblCharWidth.Location = new Point(260, 5);
            lblCharWidth.Margin = new Padding(4, 0, 4, 0);
            lblCharWidth.Name = "lblCharWidth";
            lblCharWidth.Size = new Size(13, 15);
            lblCharWidth.TabIndex = 16;
            lblCharWidth.Text = "x";
            // 
            // lblCharHeight
            // 
            lblCharHeight.AutoSize = true;
            lblCharHeight.Location = new Point(345, 5);
            lblCharHeight.Margin = new Padding(4, 0, 4, 0);
            lblCharHeight.Name = "lblCharHeight";
            lblCharHeight.Size = new Size(13, 15);
            lblCharHeight.TabIndex = 17;
            lblCharHeight.Text = "y";
            // 
            // nudFontHeight
            // 
            nudFontHeight.Location = new Point(153, 48);
            nudFontHeight.Margin = new Padding(4, 3, 4, 3);
            nudFontHeight.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudFontHeight.Name = "nudFontHeight";
            nudFontHeight.Size = new Size(57, 23);
            nudFontHeight.TabIndex = 18;
            nudFontHeight.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudFontAscent
            // 
            nudFontAscent.Location = new Point(153, 78);
            nudFontAscent.Margin = new Padding(4, 3, 4, 3);
            nudFontAscent.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudFontAscent.Name = "nudFontAscent";
            nudFontAscent.Size = new Size(57, 23);
            nudFontAscent.TabIndex = 19;
            nudFontAscent.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudFontDescent
            // 
            nudFontDescent.Location = new Point(153, 108);
            nudFontDescent.Margin = new Padding(4, 3, 4, 3);
            nudFontDescent.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudFontDescent.Name = "nudFontDescent";
            nudFontDescent.Size = new Size(57, 23);
            nudFontDescent.TabIndex = 20;
            nudFontDescent.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudCharValue
            // 
            nudCharValue.Location = new Point(349, 25);
            nudCharValue.Margin = new Padding(4, 3, 4, 3);
            nudCharValue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudCharValue.Name = "nudCharValue";
            nudCharValue.Size = new Size(57, 23);
            nudCharValue.TabIndex = 21;
            nudCharValue.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudFullWidth
            // 
            nudFullWidth.Location = new Point(349, 54);
            nudFullWidth.Margin = new Padding(4, 3, 4, 3);
            nudFullWidth.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudFullWidth.Name = "nudFullWidth";
            nudFullWidth.Size = new Size(57, 23);
            nudFullWidth.TabIndex = 22;
            nudFullWidth.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudRecX0
            // 
            nudRecX0.Location = new Point(285, 83);
            nudRecX0.Margin = new Padding(4, 3, 4, 3);
            nudRecX0.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRecX0.Name = "nudRecX0";
            nudRecX0.Size = new Size(57, 23);
            nudRecX0.TabIndex = 23;
            nudRecX0.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudRecX1
            // 
            nudRecX1.Location = new Point(349, 83);
            nudRecX1.Margin = new Padding(4, 3, 4, 3);
            nudRecX1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRecX1.Name = "nudRecX1";
            nudRecX1.Size = new Size(57, 23);
            nudRecX1.TabIndex = 24;
            nudRecX1.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudRecY0
            // 
            nudRecY0.Location = new Point(285, 112);
            nudRecY0.Margin = new Padding(4, 3, 4, 3);
            nudRecY0.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRecY0.Name = "nudRecY0";
            nudRecY0.Size = new Size(57, 23);
            nudRecY0.TabIndex = 25;
            nudRecY0.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // nudRecY1
            // 
            nudRecY1.Location = new Point(349, 112);
            nudRecY1.Margin = new Padding(4, 3, 4, 3);
            nudRecY1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRecY1.Name = "nudRecY1";
            nudRecY1.Size = new Size(57, 23);
            nudRecY1.TabIndex = 26;
            nudRecY1.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(215, 28);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 27;
            label6.Text = "Character Value";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(215, 57);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 28;
            label7.Text = "Full Width";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(215, 85);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 29;
            label8.Text = "Rect X";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(215, 114);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 30;
            label9.Text = "Rect Y";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(217, 5);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 31;
            label10.Text = "Width";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(294, 5);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(43, 15);
            label11.TabIndex = 32;
            label11.Text = "Height";
            // 
            // txtWords
            // 
            txtWords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtWords.Location = new Point(4, 3);
            txtWords.Margin = new Padding(4, 3, 4, 3);
            txtWords.Multiline = true;
            txtWords.Name = "txtWords";
            txtWords.Size = new Size(414, 71);
            txtWords.TabIndex = 33;
            txtWords.Text = "abcdefghijklmnopqrstuvwxyz\r\nABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n123456789.:,;'\"(!?)+-*/=\r\nThe quick brown fox jumps over the lazy dog.";
            txtWords.TextChanged += txtWords_TextChanged;
            // 
            // imgWords
            // 
            imgWords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imgWords.BorderStyle = BorderStyle.FixedSingle;
            imgWords.Location = new Point(4, 3);
            imgWords.Margin = new Padding(4, 3, 4, 3);
            imgWords.Name = "imgWords";
            imgWords.Size = new Size(414, 140);
            imgWords.TabIndex = 34;
            imgWords.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(217, 144);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(62, 15);
            label12.TabIndex = 29;
            label12.Text = "Left Offset";
            // 
            // nudExtendedLeftOffset
            // 
            nudExtendedLeftOffset.Location = new Point(350, 142);
            nudExtendedLeftOffset.Margin = new Padding(4, 3, 4, 3);
            nudExtendedLeftOffset.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            nudExtendedLeftOffset.Minimum = new decimal(new int[] { 128, 0, 0, int.MinValue });
            nudExtendedLeftOffset.Name = "nudExtendedLeftOffset";
            nudExtendedLeftOffset.Size = new Size(57, 23);
            nudExtendedLeftOffset.TabIndex = 28;
            nudExtendedLeftOffset.ValueChanged += nudFValueChanged_ValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer3);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label12);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(nudExtendedLeftOffset);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label11);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label10);
            splitContainer1.Panel1.Controls.Add(lblFontIdent);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(lblNumChar);
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(listBox1);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(lblCharWidth);
            splitContainer1.Panel1.Controls.Add(nudRecY1);
            splitContainer1.Panel1.Controls.Add(lblCharHeight);
            splitContainer1.Panel1.Controls.Add(nudRecY0);
            splitContainer1.Panel1.Controls.Add(nudFontHeight);
            splitContainer1.Panel1.Controls.Add(nudRecX1);
            splitContainer1.Panel1.Controls.Add(nudFontAscent);
            splitContainer1.Panel1.Controls.Add(nudRecX0);
            splitContainer1.Panel1.Controls.Add(nudFontDescent);
            splitContainer1.Panel1.Controls.Add(nudFullWidth);
            splitContainer1.Panel1.Controls.Add(nudCharValue);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(422, 648);
            splitContainer1.SplitterDistance = 410;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 36;
            // 
            // splitContainer3
            // 
            splitContainer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            splitContainer3.Location = new Point(192, 172);
            splitContainer3.Margin = new Padding(4, 3, 4, 3);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer3.Size = new Size(217, 231);
            splitContainer3.SplitterDistance = 150;
            splitContainer3.SplitterWidth = 5;
            splitContainer3.TabIndex = 37;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(4, 3);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(210, 143);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kerning Pair";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(7, 21);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(196, 115);
            panel1.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Location = new Point(4, 3);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(152, 113);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(pictureBox3);
            flowLayoutPanel1.Controls.Add(pictureBox2);
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(217, 76);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // pictureBox3
            // 
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(4, 3);
            pictureBox3.Margin = new Padding(4, 3, 4, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(37, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(49, 3);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(94, 3);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(txtWords);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(imgWords);
            splitContainer2.Size = new Size(422, 233);
            splitContainer2.SplitterDistance = 77;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 37;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "bmf";
            saveFileDialog1.Filter = "BZCC/BZ2 Bitmap Font|*.bmf";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "font.json";
            openFileDialog2.Filter = "Font Data|*.json";
            // 
            // saveFileDialog2
            // 
            saveFileDialog2.FileName = "font.json";
            saveFileDialog2.Filter = "Font Data|*.json";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 672);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(438, 711);
            Name = "Form1";
            Text = "BZ2 - Font Viewer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFontHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFontAscent).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFontDescent).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCharValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFullWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRecX0).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRecX1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRecY0).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRecY1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgWords).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudExtendedLeftOffset).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.PictureBox imgWords;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudExtendedLeftOffset;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem fromFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog2;
        private SaveFileDialog saveFileDialog2;
    }
}

