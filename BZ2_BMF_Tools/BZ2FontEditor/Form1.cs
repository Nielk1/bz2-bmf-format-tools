using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Nielk1.Formats.Battlezone.BMF;

namespace Nielk1.Tools.Battlezone.FontEditor
{
    public partial class Form1 : Form
    {
        private String filename;
        private BmfFile FontFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(!e.Cancel)
            {
                filename = openFileDialog1.FileName;
                loadSelectedFile();
            }
        }

        private void loadSelectedFile()
        {
            if (System.IO.File.Exists(filename))
            {
                // unload anything loaded?
                listBox1.Items.Clear();

                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                imgWords.Image = null;
                // />

                string ExtendedFile = System.IO.Path.ChangeExtension(filename, ".bm2");

                FontFile = System.IO.File.Exists(ExtendedFile) ? new BmfFile(System.IO.File.OpenRead(filename), System.IO.File.OpenRead(ExtendedFile)) : new BmfFile(System.IO.File.OpenRead(filename));

                lblFontIdent.Text = FontFile.Indent;
                lblNumChar.Text = "" + (uint)FontFile.CharCount;
                nudFontHeight.Value = (uint)FontFile.Height;
                nudFontAscent.Value = (uint)FontFile.Ascent;
                nudFontDescent.Value = (uint)FontFile.Descent;

                listBox1.BeginUpdate();
                foreach (KeyValuePair<byte, BmfCharacter> character in FontFile.Characters)
                {
                    listBox1.Items.Add(new BmfCharacterListItem(character));
                }
                listBox1.EndUpdate();

                UpdateTextPreview();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BmfCharacterListItem item = (BmfCharacterListItem)listBox1.SelectedItem;
            int Width = (int)(uint)item.Value.charWidth;
            int Height = (int)(uint)item.Value.charHeight;

            int FullWidth = (int)(uint)item.Value.fullWidth;
            int FullHeight = (int)(uint)FontFile.Height;
            int XOffset = (int)(uint)item.Value.rectX0;
            int YOffset = (int)(uint)item.Value.rectY0;

            FullWidth = Math.Max(FullWidth, (int)(uint)item.Value.rectX1);
            FullHeight = Math.Max(FullHeight, (int)(uint)item.Value.rectY1);

            lblCharWidth.Text = "" + Width;
            lblCharHeight.Text = "" + Height;
            nudCharValue.Value = (uint)item.Key;
            nudFullWidth.Value = (uint)item.Value.fullWidth;
            nudRecX0.Value = (uint)item.Value.rectX0;
            nudRecX1.Value = (uint)item.Value.rectX1;
            nudRecY0.Value = (uint)item.Value.rectY0;
            nudRecY1.Value = (uint)item.Value.rectY1;

            if (Height == 0 || Width == 0)
            {
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
            }
            else
            {
                Bitmap tmpImage1 = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Bitmap tmpImage2 = new Bitmap(FullWidth, FullHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Bitmap tmpImage3 = new Bitmap(FullWidth, FullHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int z = 255 - item.Value.charData[y * Width + x];
                        tmpImage1.SetPixel(x, y, Color.FromArgb(255, z, z, z));
                    }
                }
                ////////////////////////
                for (int y = 0; y < FullHeight; y++)
                {
                    for (int x = 0; x < FullWidth; x++)
                    {
                        tmpImage2.SetPixel(x, y, Color.Magenta);
                    }
                }
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int z = 255 - item.Value.charData[y * Width + x];
                        tmpImage2.SetPixel(XOffset + x, YOffset + y, Color.FromArgb(255, z, z, z));
                    }
                }
                ////////////////////////
                for (int y = 0; y < FullHeight; y++)
                {
                    for (int x = 0; x < FullWidth; x++)
                    {
                        tmpImage3.SetPixel(x, y, Color.Transparent);
                    }
                }
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int z = item.Value.charData[y * Width + x];
                        tmpImage3.SetPixel(XOffset + x, YOffset + y, Color.FromArgb(z, 0, 0, 0));
                    }
                }

                pictureBox1.Width = tmpImage1.Width;
                pictureBox1.Height = tmpImage1.Height;
                pictureBox1.Image = tmpImage1;
                pictureBox2.Width = tmpImage2.Width;
                pictureBox2.Height = tmpImage2.Height;
                pictureBox2.Image = tmpImage2;
                pictureBox3.Width = tmpImage3.Width;
                pictureBox3.Height = tmpImage3.Height;
                pictureBox3.Image = tmpImage3;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            BmfCharacterListItem item = (BmfCharacterListItem)listBox1.SelectedItem;
            //txtWords.Text += (char)item.Key;
            int SelectionStart = txtWords.SelectionStart;
            int SelectionLength = txtWords.SelectionLength;
            txtWords.Text = txtWords.Text.Substring(0, SelectionStart) + (char)item.Key + txtWords.Text.Substring(SelectionStart + SelectionLength);
            txtWords.SelectionStart = SelectionStart + 1;
            txtWords.SelectionLength = 0;
        }

        private class BmfCharacterListItem
        {
            private KeyValuePair<byte, BmfCharacter> item;

            public byte Key
            {
                get { return item.Key; }
            }

            public BmfCharacter Value
            {
                get { return item.Value; }
            }

            public BmfCharacterListItem(KeyValuePair<byte, BmfCharacter> item)
            {
                this.item = item;
            }

            public override string ToString()
            {
                return (uint)item.Key + "\t" + Convert.ToString(item.Key, 16) + "\t" + (!char.IsControl((char)item.Key) ? "" + (char)item.Key : "");
            }
        }

        private void UpdateTextPreview()
        {
            if (FontFile != null)
            {
                imgWords.Image = null;

                string containedText = txtWords.Text;
                string[] lines = containedText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                int[] counts = new int[lines.Length];
                /*for (int x = 0; x < counts.Length; x++)
                {
                    counts[x] = 0;
                }*/
                for (int x = 0; x < lines.Length; x++)
                {
                    BmfCharacter lastChar = null;
                    for (int y = 0; y < lines[x].Length; y++)
                    {
                        if (FontFile.Characters.ContainsKey((byte)lines[x][y]))
                        {
                            BmfCharacter dataForChar = FontFile.Characters[(byte)lines[x][y]];
                            lastChar = dataForChar;
                            counts[x] += dataForChar.fullWidth;
                        }
                    }
                    if (lastChar != null)
                    {
                        int OffsetRight = (int)(uint)lastChar.rectX1;
                        int fullWidth = (int)(uint)lastChar.fullWidth;
                        int extraWidth = fullWidth - OffsetRight;
                        if (extraWidth > 0)
                        {
                            counts[x] += extraWidth;
                        }
                    }
                }

                int Width = counts.Max();
                int Height = lines.Length * FontFile.Height;

                if (Height > 0 && Width > 0)
                {
                    // wierd code here to fix stuff that hangs low
                    int extraHeight = 0;
                    for (int x = 0; x < lines.Last().Length; x++)
                    {
                        if (FontFile.Characters.ContainsKey((byte)lines.Last()[x]))
                        {
                            BmfCharacter dataForChar = FontFile.Characters[(byte)lines.Last()[x]];
                            if (dataForChar.rectY1 > extraHeight)
                            {
                                extraHeight = dataForChar.rectY1;
                            }
                        }
                    }
                    extraHeight -= FontFile.Height;
                    if (extraHeight > 0) Height += extraHeight;


                    Bitmap myImage = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    for (int lineNum = 0; lineNum < lines.Length; lineNum++)
                    {
                        int CleanDrawOffset = 0; // new line means no redraws
                        int runningWidth = 0;
                        for (int wordNum = 0; wordNum < lines[lineNum].Length; wordNum++)
                        {
                            if (FontFile.Characters.ContainsKey((byte)lines[lineNum][wordNum]))
                            {
                                BmfCharacter dataForChar = FontFile.Characters[(byte)lines[lineNum][wordNum]];

                                int LetterWidth = (int)(uint)dataForChar.charWidth;
                                int LetterHeight = (int)(uint)dataForChar.charHeight;

                                int LetterFullWidth = (int)(uint)dataForChar.fullWidth;
                                int LetterXOffset = (int)(uint)dataForChar.rectX0;
                                int LetterYOffset = (int)(uint)dataForChar.rectY0;

                                if (wordNum == 0)
                                {
                                    runningWidth -= dataForChar.extendedLeftOffset;
                                }
                                else
                                {
                                    runningWidth += dataForChar.extendedLeftOffset;
                                }
                                if (runningWidth > CleanDrawOffset)
                                    CleanDrawOffset = runningWidth;

                                bool DrawOver = CleanDrawOffset > runningWidth;
                                for (int yInner = 0; yInner < LetterHeight; yInner++)
                                {
                                    for (int xInner = 0; xInner < LetterWidth; xInner++)
                                    {
                                        int z = dataForChar.charData[yInner * LetterWidth + xInner];
                                        if (runningWidth + LetterXOffset + xInner < Width && (lineNum * FontFile.Height) + LetterYOffset + yInner < Height)
                                        {
                                            int DrawOverColor = DrawOver
                                                ? myImage.GetPixel(runningWidth + LetterXOffset + xInner, (lineNum * FontFile.Height) + LetterYOffset + yInner).A
                                                : 0;
                                            myImage.SetPixel(runningWidth + LetterXOffset + xInner,
                                                (lineNum * FontFile.Height) + LetterYOffset + yInner,
                                                Color.FromArgb(Math.Min(DrawOverColor + z, 255), 0, 0, 0));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pixel outside valid range");
                                        }
                                    }
                                }

                                runningWidth += LetterFullWidth;
                                if (runningWidth > CleanDrawOffset)
                                    CleanDrawOffset = runningWidth;

                                byte nextForKerning = (wordNum + 1) < lines[lineNum].Length ? (byte)lines[lineNum][(wordNum + 1)] : (byte)'A';
                                int KerningOffset = dataForChar.extendedKerningPairs[nextForKerning];
                                runningWidth += KerningOffset;
                                if (runningWidth > CleanDrawOffset)
                                    CleanDrawOffset = runningWidth;
                            }
                        }
                    }
                    imgWords.Image = myImage;
                }
                else
                {
                    imgWords.Image = null;
                }
            }
        }

        private void txtWords_TextChanged(object sender, EventArgs e)
        {
            UpdateTextPreview();
        }
    }
}
