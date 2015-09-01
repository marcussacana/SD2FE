using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDR2FE
{
    public partial class FontPreview : Form
    {
        public Bitmap Preview = new Bitmap(1, 1);
        public string PreviewText = "";
        public FontPreview()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreviewText = TextBox.Text.Replace("\\n", "\n");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Preview != new Bitmap(1, 1))
            {
                timer1.Enabled = false;
                pictureBox1.Image = Preview;
                Preview = new Bitmap(1, 1);
            }
        }
        public bool close = true;
        private void FontPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            close = true;
        }
    }
}
