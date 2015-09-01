namespace SDR2FE
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.VerticalScroll = new System.Windows.Forms.VScrollBar();
            this.HorizontalScroll = new System.Windows.Forms.HScrollBar();
            this.FontTable = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BNTTestFont = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RetChar = new System.Windows.Forms.Button();
            this.JumChar = new System.Windows.Forms.Button();
            this.VHeigth = new System.Windows.Forms.NumericUpDown();
            this.VWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VChar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BNTOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.PosY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PosX = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Char = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BNTSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontTable)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VHeigth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Char)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.VerticalScroll);
            this.panel1.Controls.Add(this.HorizontalScroll);
            this.panel1.Controls.Add(this.FontTable);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 467);
            this.panel1.TabIndex = 0;
            // 
            // VerticalScroll
            // 
            this.VerticalScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.VerticalScroll.Location = new System.Drawing.Point(506, 0);
            this.VerticalScroll.Maximum = 9;
            this.VerticalScroll.Name = "VerticalScroll";
            this.VerticalScroll.Size = new System.Drawing.Size(17, 450);
            this.VerticalScroll.TabIndex = 3;
            this.VerticalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VerticalScroll_Scroll);
            // 
            // HorizontalScroll
            // 
            this.HorizontalScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HorizontalScroll.Location = new System.Drawing.Point(0, 450);
            this.HorizontalScroll.Maximum = 9;
            this.HorizontalScroll.Name = "HorizontalScroll";
            this.HorizontalScroll.Size = new System.Drawing.Size(523, 17);
            this.HorizontalScroll.TabIndex = 2;
            this.HorizontalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HorizontalScroll_Scroll);
            // 
            // FontTable
            // 
            this.FontTable.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.FontTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FontTable.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FontTable.Location = new System.Drawing.Point(0, 0);
            this.FontTable.Name = "FontTable";
            this.FontTable.Size = new System.Drawing.Size(506, 449);
            this.FontTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.FontTable.TabIndex = 0;
            this.FontTable.TabStop = false;
            this.FontTable.Click += new System.EventHandler(this.FontTable_Click);
            this.FontTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FontTable_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.BNTSave);
            this.panel2.Controls.Add(this.BNTTestFont);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.BNTOpen);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.Char);
            this.panel2.Location = new System.Drawing.Point(541, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 467);
            this.panel2.TabIndex = 1;
            // 
            // BNTTestFont
            // 
            this.BNTTestFont.Enabled = false;
            this.BNTTestFont.Location = new System.Drawing.Point(3, 370);
            this.BNTTestFont.Name = "BNTTestFont";
            this.BNTTestFont.Size = new System.Drawing.Size(207, 23);
            this.BNTTestFont.TabIndex = 8;
            this.BNTTestFont.Text = "Test Font";
            this.BNTTestFont.UseVisualStyleBackColor = true;
            this.BNTTestFont.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.RetChar);
            this.groupBox2.Controls.Add(this.JumChar);
            this.groupBox2.Controls.Add(this.VHeigth);
            this.groupBox2.Controls.Add(this.VWidth);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.VChar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(3, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(96, 156);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Char Values";
            // 
            // RetChar
            // 
            this.RetChar.Location = new System.Drawing.Point(9, 36);
            this.RetChar.Name = "RetChar";
            this.RetChar.Size = new System.Drawing.Size(18, 22);
            this.RetChar.TabIndex = 5;
            this.RetChar.Text = "<";
            this.RetChar.UseVisualStyleBackColor = true;
            this.RetChar.Click += new System.EventHandler(this.RetChar_Click);
            // 
            // JumChar
            // 
            this.JumChar.Location = new System.Drawing.Point(72, 36);
            this.JumChar.Name = "JumChar";
            this.JumChar.Size = new System.Drawing.Size(18, 22);
            this.JumChar.TabIndex = 6;
            this.JumChar.Text = ">";
            this.JumChar.UseVisualStyleBackColor = true;
            this.JumChar.Click += new System.EventHandler(this.button7_Click);
            // 
            // VHeigth
            // 
            this.VHeigth.Location = new System.Drawing.Point(9, 130);
            this.VHeigth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.VHeigth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VHeigth.Name = "VHeigth";
            this.VHeigth.Size = new System.Drawing.Size(78, 20);
            this.VHeigth.TabIndex = 8;
            this.VHeigth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VHeigth.ValueChanged += new System.EventHandler(this.VHeigth_ValueChanged);
            // 
            // VWidth
            // 
            this.VWidth.Location = new System.Drawing.Point(9, 85);
            this.VWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.VWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VWidth.Name = "VWidth";
            this.VWidth.Size = new System.Drawing.Size(78, 20);
            this.VWidth.TabIndex = 5;
            this.VWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VWidth.ValueChanged += new System.EventHandler(this.VWidth_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Heigth:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Width:";
            // 
            // VChar
            // 
            this.VChar.HideSelection = false;
            this.VChar.Location = new System.Drawing.Point(33, 38);
            this.VChar.MaxLength = 1;
            this.VChar.Name = "VChar";
            this.VChar.ReadOnly = true;
            this.VChar.Size = new System.Drawing.Size(33, 20);
            this.VChar.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Char:";
            // 
            // BNTOpen
            // 
            this.BNTOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BNTOpen.Location = new System.Drawing.Point(3, 441);
            this.BNTOpen.Name = "BNTOpen";
            this.BNTOpen.Size = new System.Drawing.Size(207, 23);
            this.BNTOpen.TabIndex = 6;
            this.BNTOpen.Text = "Open a font";
            this.BNTOpen.UseVisualStyleBackColor = true;
            this.BNTOpen.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.PosY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.PosX);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(105, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 22);
            this.button3.TabIndex = 3;
            this.button3.Text = "^";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(37, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "v";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PosY
            // 
            this.PosY.Location = new System.Drawing.Point(6, 130);
            this.PosY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(78, 20);
            this.PosY.TabIndex = 3;
            this.PosY.ValueChanged += new System.EventHandler(this.PosY_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pos Y:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PosX
            // 
            this.PosX.Location = new System.Drawing.Point(7, 88);
            this.PosX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(78, 20);
            this.PosX.TabIndex = 1;
            this.PosX.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 22);
            this.button2.TabIndex = 2;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pos X:";
            // 
            // Char
            // 
            this.Char.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Char.Location = new System.Drawing.Point(3, 3);
            this.Char.Name = "Char";
            this.Char.Size = new System.Drawing.Size(207, 205);
            this.Char.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Char.TabIndex = 0;
            this.Char.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BNTSave
            // 
            this.BNTSave.Enabled = false;
            this.BNTSave.Location = new System.Drawing.Point(3, 412);
            this.BNTSave.Name = "BNTSave";
            this.BNTSave.Size = new System.Drawing.Size(207, 23);
            this.BNTSave.TabIndex = 9;
            this.BNTSave.Text = "Save";
            this.BNTSave.UseVisualStyleBackColor = true;
            this.BNTSave.Click += new System.EventHandler(this.BNTSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 491);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Super Danganronpa 2 Font Editor";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FontTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VHeigth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Char)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox FontTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox Char;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BNTOpen;
        private System.Windows.Forms.VScrollBar VerticalScroll;
        private System.Windows.Forms.HScrollBar HorizontalScroll;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown PosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PosY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown VHeigth;
        private System.Windows.Forms.NumericUpDown VWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VChar;
        private System.Windows.Forms.Button RetChar;
        private System.Windows.Forms.Button JumChar;
        private System.Windows.Forms.Button BNTTestFont;
        private System.Windows.Forms.Button BNTSave;
    }
}

