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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            TableUpdate = true;
            PreviewUpdated = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { PosX.Value -= 10; } catch { }
        }
        public bool loaded = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (!loaded)
            {
                OpenFileDialog FD = new OpenFileDialog();
                FD.Filter = "All Super Danganronpa font Files | ?.font| All Files | *.*";
                DialogResult dr = FD.ShowDialog();
                if (dr == DialogResult.OK)
                    OpenFont(FD.FileName);
            }
        }
        string[] FONTDATA = new string[0];
        string[] OutFont = new string[0];
        Bitmap FONTTABLE;
        private void OpenFont(string fileName)
        {
            FONTTABLE = null;
            FONTDATA = new string[0];
            FONT = new FontChar[0];
            string BMP = System.IO.Path.GetDirectoryName(fileName);
            try { BMP += "\\" + (int.Parse(System.IO.Path.GetFileNameWithoutExtension(fileName)) - 1) + ".bmp"; } catch { MessageBox.Show("Can't find BMP font file, try rename the font file to original pak extracted file name.", "Super Danganronpa 2 Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (System.IO.File.Exists(BMP))
                FONTTABLE = (Bitmap)Image.FromFile(BMP);
            else
            {
                MessageBox.Show("Can't find BMP file, try rename to original pak extracted file name.", "Super Danganronpa 2 Font Editor", MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            FontTable.Image = FONTTABLE;
            FONTDATA = Tools.ByteArrayToString(System.IO.File.ReadAllBytes(fileName)).Split('-');
            string signature = "0x74467053";
            if (signature != "0x" + FONTDATA[0] + FONTDATA[1] + FONTDATA[2] + FONTDATA[3])
            { MessageBox.Show("This not is a font table info file.", "Super Danganronpa 2 Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            int StartFontTable = GetOffset(FONTDATA, 12);
            int Position = StartFontTable;
            while (FONTDATA[Position] + FONTDATA[Position + 1] + FONTDATA[Position + 2] + FONTDATA[Position + 3] + FONTDATA[Position + 4] + FONTDATA[Position + 5] + FONTDATA[Position + 6] + FONTDATA[Position + 7] + FONTDATA[Position + 8] + FONTDATA[Position + 9] + FONTDATA[Position + 10] + FONTDATA[Position + 11] + FONTDATA[Position + 12] + FONTDATA[Position + 13] + FONTDATA[Position + 14] + FONTDATA[Position + 15] != "00000000000000000000000000000000")
            {
                object[] LETTER = GetChar(Position);
                char CHAR = (char)LETTER[0];
                Point POINT = (Point)LETTER[1];
                System.Drawing.Size SIZE = (System.Drawing.Size)LETTER[2];
                string[] EC = (string[])LETTER[3];
                FontChar[] temp = new FontChar[FONT.Length + 1];
                FONT.CopyTo(temp, 0);
                FontChar FC = new FontChar();
                FC.Letter = CHAR;
                FC.Point = POINT;
                FC.Size = SIZE;
                FC.ExtraContent = EC;
                temp[FONT.Length] = FC;
                FONT = temp;
                Position += 16;
            }
            for (; Position < FONTDATA.Length; Position++)
            {
                string[] temp = new string[FontBotton.Length + 1];
                FontBotton.CopyTo(temp, 0);
                temp[FontBotton.Length] = FONTDATA[Position];
                FontBotton = temp;
            }
            WriteRetangles();
            UpdateScrolls();
            SelectLetter(0);
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            BNTTestFont.Enabled = true;
            BNTSave.Enabled = true;
        }
        private void ExportFont(string fileName)
        {
            int FontTableOffset = GetOffset(FONTDATA, 12);
            OutFont = new string[FontTableOffset];
            for (int i = 0; i < FontTableOffset; i++)
            {
                this.Text = "Processing Font: " + i + "/" + OutFont.Length + " (" + ((i*100)/OutFont.Length) +"%)";
                OutFont[i] = FONTDATA[i];
            }
            for (int i = 0; i < FONT.Length; i++)
            {

                this.Text = "Making Chars Entries: " + i + "/" + FONT.Length + " (" + ((i*100)/FONT.Length) + "%)";
                string[] Char = ExportChar(FONT[i]);
                for (int pos = 0; pos < Char.Length; pos++)
                    AppendFont(Char[pos]);
            }
            for (int i = 0; i < FontBotton.Length; i++)
                AppendFont(FontBotton[i]);
            System.IO.File.WriteAllBytes(fileName, Tools.StringToByteArray(OutFont));
            BNTSave.Enabled = true;
            this.Text = "Super Danganronpa 2 Font Editor";
        }
        

        /*.font format

HEX POS - Without data
(Offset)= Hex Data
==========================
2-3 = Posição X -----------

==========================
          |
          |
4-5 = Posição Y    |
==========================

6-7 = tamanho X = ---------

==========================
8-9 = tamanho Y |
       |
       |

00 00 11 11 22 22 33 33 44 44 ?? ?? ?? ?? ?? ?? ??

00 00 = Unicode Char

11 11 = 2-3 (Posição X)

22 22 = 4-5 (Posição Y)

33 33 = 6-7 (Tamanho X)

44 44 = 8-9 (Tamanho Y)*/
        private string[] ExportChar(FontChar Char)
        {
            string Letter = Tools.UnicodeStringToHex(Char.Letter.ToString());
            string PointX = Tools.IntToHex(Char.Point.X).Substring(0, 5);
            string PointY = Tools.IntToHex(Char.Point.Y).Substring(0, 5);
            string WidthX = Tools.IntToHex(Char.Size.Width).Substring(0, 5);
            string HeigthY = Tools.IntToHex(Char.Size.Height).Substring(0, 5);
            string EC = "";
            foreach (string hex in Char.ExtraContent)
                EC += " " + hex;
            string Content = Letter + " " + PointX + " " + PointY + " " + WidthX + " " + HeigthY + EC;
            return Content.Split(' ');

        }

        private void AppendFont(string hex)
        {            
            string[] temp = new string[OutFont.Length + 1];
            OutFont.CopyTo(temp, 0);
            temp[OutFont.Length] = hex;
            OutFont = temp;
        }
        public string[] FontBotton = new string[0];
        

        public FontChar[] FONT = new FontChar[0];

        public bool TableUpdate { get; private set; }
        public bool PreviewUpdated { get; private set; }
        public bool FontPreviewMode { get; private set; }

        private object[] GetChar(int position)
        {
            char CHAR = Tools.UnicodeHexToUnicodeString(FONTDATA[position] + " " + FONTDATA[position+1]).ToCharArray()[0];
            int PointX = Tools.HexToInt(FONTDATA[position + 3] + FONTDATA[position + 2]);
            int PointY = Tools.HexToInt(FONTDATA[position + 5] + FONTDATA[position + 4]);
            int SizeX = Tools.HexToInt(FONTDATA[position + 7] + FONTDATA[position + 6]);
            int SizeY = Tools.HexToInt(FONTDATA[position + 9] + FONTDATA[position + 8]);
            string[] ExtraContent = new string[] { FONTDATA[position + 10], FONTDATA[position + 11], FONTDATA[position + 12], FONTDATA[position + 13], FONTDATA[position + 14], FONTDATA[position + 15] };
            Point POINT = new Point(PointX, PointY);
            System.Drawing.Size SIZE = new System.Drawing.Size(SizeX, SizeY);
            return new object[] { CHAR, POINT, SIZE, ExtraContent};
        }

        public static int GetOffset(string[] pak, int Position)
        {
            return Tools.HexToInt(pak[Position + 3] + pak[Position + 2] + pak[Position + 1] + pak[Position]);
        }

        private void FontTable_MouseClick(object sender, MouseEventArgs e)
        {
            Point Pixel = new Point(e.X, e.Y);
            int ID = 0;
            foreach (FontChar Letter in FONT)
            {
                if (Pixel.X > Letter.Point.X && Pixel.Y > Letter.Point.Y)
                    if (Pixel.X < Letter.Point.X + Letter.Size.Height && Pixel.Y < Letter.Point.Y + Letter.Size.Width)
                        break;
                ID++;
            }
            if (ID == FONT.Length)
                return;
            else
                SelectLetter(ID);
        }
        public int SelectedId = 0;
        private void SelectLetter(int id)
        {
            SelectedId = id;
            TableUpdate = false;
            VHeigth.Value = FONT[id].Size.Height;
            VWidth.Value = FONT[id].Size.Width;
            PosX.Value = FONT[id].Point.X;
            PosY.Value = FONT[id].Point.Y;
            VChar.Text = (FONT[id].Letter+"").Replace(@" ", "[Space]");
            Bitmap Letter = new Bitmap(FONT[id].Size.Width, FONT[id].Size.Height);
            for (int x = 0; x < Letter.Size.Width; x++)
                for (int y = 0; y < Letter.Size.Height; y++)
                    Letter.SetPixel(x, y, ((Bitmap)FontTable.Image).GetPixel(FONT[id].Point.X + x, FONT[id].Point.Y + y));
            Char.Image = ScaleImage(Letter, Char.Width, Char.Height);
        }
        public Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
        private void UpdateScrolls()
        {
            System.Drawing.Size Img = FontTable.Image.Size;
            VerticalScroll.Maximum = (Img.Height-panel1.Size.Height)+HorizontalScroll.Size.Height;
            HorizontalScroll.Maximum = (Img.Width-panel1.Size.Width)+VerticalScroll.Size.Width;
            VerticalScroll.LargeChange = (VerticalScroll.Maximum / 30);
            HorizontalScroll.LargeChange = (HorizontalScroll.Maximum / 30);
        }
        private void VerticalScroll_Scroll(object sender, ScrollEventArgs e)
        {
            FontTable.Top = VerticalScroll.Value*-1;
            TableUpdate = false;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!TableUpdate)
                WriteRetangles();
            if (!PreviewUpdated)
                UpdatePreview();
            if (FontPreviewMode)
            {
                if (FP.close)
                { this.Enabled = true; FontPreviewMode = false; }
                if (FP.PreviewText != "")
                {
                    string str = FP.PreviewText;
                    FP.PreviewText = "";
                    int Correction = 0;
                    int Width = 0;
                    Bitmap Text = new Bitmap(1, 1);
                    foreach (char chr in str.ToCharArray())
                    {
                        if (chr == '\n')
                        {
                            Correction += 20;
                            Width = 0;
                            continue;
                        }
                        Bitmap Temp = GetFontChar(chr);
                        Text = AppendText(Temp, Text, Correction, Width);
                        Width += Temp.Width;
                    }
                    FP.Preview = Text;
                }
            }
        }

        private Bitmap AppendText(Bitmap Letter, Bitmap text, int Correction, int StartPos)
        {
            Bitmap Result = new Bitmap(1, 1);
            if (text.Height <= Correction)
                Result = new Bitmap(text.Width , text.Height + Correction);
            else
                Result = new Bitmap(text.Width, text.Height);
            int fails = 0; //to try extent the width or heigth
        again:;
            try
            {
                for (int x = 0; x < text.Size.Width; x++)
                    for (int y = 0; y < text.Size.Height; y++)
                        Result.SetPixel(x, y, text.GetPixel(x, y));
                for (int x = 0; x < Letter.Size.Width; x++)
                    for (int y = 0; y < Letter.Size.Height; y++)
                        Result.SetPixel(x+StartPos, y + Correction, Letter.GetPixel(x, y));
            }
            catch { fails++;
                if (fails == 1 ) Result = new Bitmap(text.Width+Letter.Width, text.Height);
                if (fails == 2) Result = new Bitmap(text.Width, text.Height + Letter.Height);
                if (fails == 3) Result = new Bitmap(text.Width + Letter.Width, text.Height + Letter.Height);
                if (fails == 4)
                    return Result;
                goto again; }
            return Result;

        }

        private Bitmap GetFontChar(char chr)
        {
            Bitmap Letter = new Bitmap(1, 1);
            foreach (FontChar FC in FONT)
            {
                if (FC.Letter == chr)
                {
                    Letter = new Bitmap(FC.Size.Width, FC.Size.Height);
                    for (int x = 0; x < Letter.Size.Width; x++)
                        for (int y = 0; y < Letter.Size.Height; y++)
                            Letter.SetPixel(x, y, ((Bitmap)FontTable.Image).GetPixel(FC.Point.X + x, FC.Point.Y + y));
                } 
            }
            return Letter;
        }

        private void UpdatePreview()
        {
            PreviewUpdated = true;
            int id = SelectedId;
            Bitmap Letter = new Bitmap(FONT[id].Size.Width, FONT[id].Size.Height);
            try
            {
                for (int x = 0; x < Letter.Size.Width; x++)
                    for (int y = 0; y < Letter.Size.Height; y++)
                        Letter.SetPixel(x, y, ((Bitmap)FontTable.Image).GetPixel(FONT[id].Point.X + x, FONT[id].Point.Y + y));
            }
            catch { return; }
            Char.Image = ScaleImage(Letter, Char.Width, Char.Height);
            }

        private void WriteRetangles() {
            TableUpdate = true;
            FontTable.Refresh();
            int id = 0;
            foreach (FontChar Letter in FONT)
            {
                System.Drawing.Graphics g = FontTable.CreateGraphics();
                Pen p = new Pen(Color.Red);
                if (id == SelectedId)
                {
                    p.Width = 3;
                    p = new Pen(Color.Green);
                }
                g.DrawRectangle(p, new Rectangle(Letter.Point, Letter.Size));
                p.Dispose();
                g.Dispose();
                FontTable.Update();
                id++;
            }
            
        }

        private void HorizontalScroll_Scroll(object sender, ScrollEventArgs e)
        {
            FontTable.Left = HorizontalScroll.Value * -1;
            TableUpdate = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FONT[SelectedId].Point.X = (int)PosX.Value;
            PreviewUpdated = false;
            TableUpdate = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try { PosY.Value += 10; } catch { }
        }

        private void FontTable_Click(object sender, EventArgs e)
        {

        }

        private void VWidth_ValueChanged(object sender, EventArgs e)
        {
            FONT[SelectedId].Size.Width = (int)VWidth.Value;
            PreviewUpdated = false;
            TableUpdate = false;
        }

        private void VHeigth_ValueChanged(object sender, EventArgs e)
        {
            FONT[SelectedId].Size.Height = (int)VHeigth.Value;
            PreviewUpdated = false;
            TableUpdate = false;
        }

        private void PosY_ValueChanged(object sender, EventArgs e)
        {
            FONT[SelectedId].Point.Y = (int)PosY.Value;
            PreviewUpdated = false;
            TableUpdate = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try { PosX.Value += 10; } catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try { PosY.Value -= 10; } catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (SelectedId < (FONT.Length-1))
                SelectLetter(SelectedId+1);
            else
                MessageBox.Show("This is the first char!", "Super Danganronpa 2 Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void RetChar_Click(object sender, EventArgs e)
        {
            if (SelectedId > 0)
                SelectLetter(SelectedId - 1);
            else
                MessageBox.Show("This is the first char!", "Super Danganronpa 2 Font Editor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateScrolls();
        }

        FontPreview FP = new FontPreview();
        private void button6_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            FP = new FontPreview();
            FP.close = false;
            FP.Show();
            FontPreviewMode = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BNTSave_Click(object sender, EventArgs e)
        {
            BNTSave.Enabled = false;
            SaveFileDialog SF = new SaveFileDialog();
            SF.Filter = "All SDR2 Font Files |*.font";
            DialogResult dr = SF.ShowDialog();
            if (dr == DialogResult.OK)
                ExportFont(SF.FileName);
            else BNTSave.Enabled = true;
        }

    }
    public class FontChar
    {
        public Point Point = new Point(0, 0);
        public Size Size = new Size(0, 0);
        public char Letter = '0';
        public string[] ExtraContent = new string[0];
    }
    public class Tools
    {
        public static string IntToHex(int val)
        {
            string hexValue = val.ToString("X");
            if (hexValue.Length > 2)
            {
                if (hexValue.Length.ToString().EndsWith("1") || hexValue.Length.ToString().EndsWith("3") || hexValue.Length.ToString().EndsWith("5") || hexValue.Length.ToString().EndsWith("7") || hexValue.Length.ToString().EndsWith("9"))
                { hexValue = "0" + hexValue; }
                string NHEX = "";
                for (int index = hexValue.Length; index != 0; index -= 2)
                {
                    NHEX += hexValue.Substring(index - 2, 2) + " ";
                }
                NHEX = NHEX.Substring(0, NHEX.Length - 1);
                switch (NHEX.Replace(@" ", "").Length)
                {
                    case 2:
                        return NHEX + " 00 00 00";
                    case 4:
                        return NHEX + " 00 00";
                    case 6:
                        return NHEX + " 00";
                    case 8:
                        return NHEX;
                }
                return "null";
            }
            else
            {
                if (hexValue.Length == 1)
                    return "0" + hexValue + " 00 00 00";
                return hexValue + " 00 00 00";
            }
        }

        public static string StringToHex(string _in)
        {
            string input = _in;
            char[] values = input.ToCharArray();
            string r = "";
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                string hexOutput = String.Format("{0:X}", value);
                if (value > 255)
                    return UnicodeStringToHex(input);
                r += value + " ";
            }
            string[] bytes = r.Split(' ');
            byte[] b = new byte[bytes.Length - 1];
            int index = 0;
            foreach (string val in bytes)
            {
                if (index == bytes.Length - 1)
                    break;
                if (int.Parse(val) > byte.MaxValue)
                {
                    b[index] = byte.Parse("0");
                }
                else
                    b[index] = byte.Parse(val);
                index++;
            }
            r = ByteArrayToString(b);
            return r.Replace("-", @" ");
        }
        public static string UnicodeStringToHex(string _in)
        {
            string input = _in;
            char[] values = Encoding.Unicode.GetChars(Encoding.Unicode.GetBytes(input.ToCharArray()));
            string r = "";
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                string hexOutput = String.Format("{0:X}", value);
                r += value + " ";
            }
            UnicodeEncoding unicode = new UnicodeEncoding();
            byte[] b = unicode.GetBytes(input);
            r = ByteArrayToString(b);
            return r.Replace("-", @" ");
        }
        public static byte[] StringToByteArray(string hex)
        {
            try
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                return bytes;
            }
            catch { Console.Write("Invalid format file!"); return new byte[0]; }
        }
        public static byte[] StringToByteArray(string[] hex)
        {
            try
            {
                int NumberChars = hex.Length;
                byte[] bytes = new byte[NumberChars];
                for (int i = 0; i < NumberChars; i++)
                    bytes[i] = Convert.ToByte(hex[i], 16);
                return bytes;
            }
            catch { Console.Write("Invalid format file!"); return new byte[0]; }
        }
        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex;
        }

        public static int HexToInt(string hex)
        {
            int num = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return num;
        }

        public static string HexToString(string hex)
        {
            string[] hexValuesSplit = hex.Split(' ');
            string returnvar = "";
            foreach (string hexs in hexValuesSplit)
            {
                int value = Convert.ToInt32(hexs, 16);
                char charValue = (char)value;
                returnvar += charValue;
            }
            return returnvar;
        }

        public static string UnicodeHexToUnicodeString(string hex)
        {
            string hexString = hex.Replace(@" ", "");
            int length = hexString.Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }

    }

}