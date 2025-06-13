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
//using System.Windows.Media;
using Nielk1.Formats.Battlezone.BMF;
using System.Drawing.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace Nielk1.Tools.Battlezone.FontEditor
{
    public partial class Form1 : Form
    {
        // the declarations
        public struct FIXED
        {
            public short fract;
            public short value;
        }

        public struct MAT2
        {
            [MarshalAs(UnmanagedType.Struct)] public FIXED eM11;
            [MarshalAs(UnmanagedType.Struct)] public FIXED eM12;
            [MarshalAs(UnmanagedType.Struct)] public FIXED eM21;
            [MarshalAs(UnmanagedType.Struct)] public FIXED eM22;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        /*[StructLayout(LayoutKind.Sequential)]
        public struct POINTFX
        {
            [MarshalAs(UnmanagedType.Struct)] public FIXED x;
            [MarshalAs(UnmanagedType.Struct)] public FIXED y;
        }*/

        [StructLayout(LayoutKind.Sequential)]
        public struct GLYPHMETRICS
        {

            public int gmBlackBoxX;
            public int gmBlackBoxY;
            [MarshalAs(UnmanagedType.Struct)] public POINT gmptGlyphOrigin;
            //[MarshalAs(UnmanagedType.Struct)] public POINTFX gmptfxGlyphOrigin;
            public short gmCellIncX;
            public short gmCellIncY;

        }

        [StructLayout(LayoutKind.Sequential)]
        struct KERNINGPAIR
        {
            public ushort wFirst; // might be better off defined as char
            public ushort wSecond; // might be better off defined as char
            public int iKernAmount;

            public KERNINGPAIR(ushort wFirst, ushort wSecond, int iKernAmount)
            {
                this.wFirst = wFirst;
                this.wSecond = wSecond;
                this.iKernAmount = iKernAmount;
            }

            public override string ToString()
            {
                return (String.Format("{{First={0}, Second={1}, Amount={2}}}", wFirst, wSecond, iKernAmount));
            }
        }

        private const int GGO_METRICS = 0;
        //private const int GGO_BITMAP = 1;
        private const int GGO_GRAY8_BITMAP = 6;
        //private const uint GDI_ERROR = 0xFFFFFFFF;
        private const int GDI_ERROR = -1;

        [DllImport("gdi32.dll")]
        static extern int GetGlyphOutline(IntPtr hdc, uint uChar, uint uFormat, out GLYPHMETRICS lpgm, uint cbBuffer, IntPtr lpvBuffer, ref MAT2 lpmat2);
        //static extern uint GetGlyphOutline(IntPtr hdc, uint uChar, uint uFormat, out GLYPHMETRICS lpgm, uint cbBuffer, IntPtr lpvBuffer, ref MAT2 lpmat2);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("Gdi32.dll", EntryPoint = "GetKerningPairs", SetLastError = true)]
        static extern int GetKerningPairs(IntPtr hdc, int nNumPairs, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] KERNINGPAIR[] kerningPairs);

        // if you want exact metrics, use a high font size and divide the result
        // otherwise, the resulting rectangle is rounded to nearest int
        //private GLYPHMETRICS? GetGlyphMetrics(char letter, Font font)
        //{
        //    // init the font. Probably better to do this outside this function for performance
        //    GLYPHMETRICS metrics;

        //    // identity matrix, required
        //    MAT2 matrix = new MAT2
        //    {
        //        eM11 = { value = 1 },
        //        eM12 = { value = 0 },
        //        eM21 = { value = 0 },
        //        eM22 = { value = 1 }
        //    };

        //    // HDC needed, we use a bitmap
        //    using (Bitmap b = new Bitmap(1, 1))
        //    using (Graphics g = Graphics.FromImage(b))
        //    {
        //        IntPtr hdc = g.GetHdc();
        //        IntPtr prev = SelectObject(hdc, font.ToHfont());
        //        int retVal = GetGlyphOutline(
        //             /* handle to DC   */ hdc,
        //             /* the char/glyph */ letter,
        //             /* format param   */ GGO_METRICS,
        //             /* glyph-metrics  */ out metrics,
        //             /* buffer, ignore */ 0,
        //             /* buffer, ignore */ IntPtr.Zero,
        //             /* trans-matrix   */ ref matrix);

        //        if (retVal == GDI_ERROR)
        //        {
        //            // something went wrong. Raise your own error here, 
        //            // or just silently ignore
        //            return null;
        //        }


        //        // return the height of the smallest rectangle containing the glyph
        //        return metrics;
        //    }
        //}

        private Bitmap GetGlyphBitmap(char letter, Font font, out GLYPHMETRICS gm)
        //public static Image GetGlyphOutlineImage(Font font, char ch, out GLYPHMETRICS gm)
        {
            byte[] alpha;
            int size;

            //using (FontDC dc = new FontDC(font))
            using (Bitmap tmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(tmp))
            {
                // identity matrix, required
                MAT2 matrix = new MAT2
                {
                    eM11 = { value = 1 },
                    eM12 = { value = 0 },
                    eM21 = { value = 0 },
                    eM22 = { value = 1 }
                };

                IntPtr hdc = g.GetHdc();
                IntPtr prev = SelectObject(hdc, font.ToHfont());
                size = GetGlyphOutline(
                     /* handle to DC   */ hdc,
                     /* the char/glyph */ letter,
                     /* format param   */ GGO_GRAY8_BITMAP,
                     /* glyph-metrics  */ out gm,
                     /* buffer, ignore */ 0,
                     /* buffer, ignore */ IntPtr.Zero,
                     /* trans-matrix   */ ref matrix);
                if (size <= 0) // GDI_ERROR
                {
                    return null;
                }

                IntPtr bufptr = Marshal.AllocHGlobal(size);

                try
                {
                    alpha = new byte[size];

                    GetGlyphOutline(
                         /* handle to DC   */ hdc,
                         /* the char/glyph */ letter,
                         /* format param   */ GGO_GRAY8_BITMAP,
                         /* glyph-metrics  */ out gm,
                         /* buffer, ignore */ (uint)size,
                         /* buffer, ignore */ bufptr,
                         /* trans-matrix   */ ref matrix);

                    Marshal.Copy(bufptr, alpha, 0, size);
                }
                finally
                {
                    Marshal.FreeHGlobal(bufptr);
                }
            }

            int stride = (int)(gm.gmBlackBoxX + 3) & ~3; // dword alinged
            Bitmap bmp = new Bitmap(stride, (int)gm.gmBlackBoxY, PixelFormat.Format32bppArgb);
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int bmpSize = bd.Stride * bd.Height;
            byte[] bmpValues = new byte[bmpSize];
            Marshal.Copy(bd.Scan0, bmpValues, 0, bmpSize);

            const int bias = 0x40;
            for (int i = 0; i < size; i++)
            {
                try
                {
                    byte v = (byte)((int)alpha[i] * 255 / bias);
                    bmpValues[i * 4 + 0] = 0xff;
                    bmpValues[i * 4 + 1] = 0xff;
                    bmpValues[i * 4 + 2] = 0xff;
                    bmpValues[i * 4 + 3] = v;
                }catch(IndexOutOfRangeException) // very odd this happens
                {

                }
            }

            Marshal.Copy(bmpValues, 0, bd.Scan0, bmpSize);
            bmp.UnlockBits(bd);

            return bmp;
        }

        private KERNINGPAIR[] GetKerningPairsData(Font font)
        {
            int numKerningPairs;

            //using (FontDC dc = new FontDC(font))
            using (Bitmap tmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(tmp))
            {
                IntPtr hdc = g.GetHdc();
                IntPtr prev = SelectObject(hdc, font.ToHfont());
                numKerningPairs = GetKerningPairs(hdc, 0, null);

                if (numKerningPairs ==  GDI_ERROR)
                {
                    return null;
                }

                KERNINGPAIR[] kerningPairs = new KERNINGPAIR[numKerningPairs];

                GetKerningPairs(hdc, numKerningPairs, kerningPairs);

                return kerningPairs;
            }
        }

        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern bool RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        HashSet<string> AddedFonts = new HashSet<string>();




        //private String filename;
        private BmfFile FontFile;
        private Font VectorFont;

        private NumericUpDown[] ExtendedKerningEdit;

        public Form1()
        {
            InitializeComponent();

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            ExtendedKerningEdit = new NumericUpDown[256];
            for (int i = 0; i < 256; i++)
            {
                Label lbl = new Label();
                lbl.Font = new Font(FontFamily.GenericMonospace, lbl.Font.Size);
                lbl.Text = i.ToString().PadLeft(3) + "  " + Convert.ToString(i, 16).PadLeft(2) + "  " + (!char.IsControl((char)i) ? "" + (char)i : "");
                lbl.Width = 85;
                NumericUpDown nud = new NumericUpDown();
                nud.Minimum = sbyte.MinValue;
                nud.Maximum = sbyte.MaxValue;
                nud.Width = 49;
                nud.Tag = $"Kerning_{i}";
                nud.ValueChanged += nudFValueChanged_ValueChanged;
                tableLayoutPanel1.Controls.Add(lbl, 0, i);
                tableLayoutPanel1.Controls.Add(nud, 1, i);
                ExtendedKerningEdit[i] = nud;
            }
            tableLayoutPanel1.ResumeLayout();

        }

        ~Form1()
        {
            foreach (string font in AddedFonts)
            {
                bool success = RemoveFontResource(font);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearFontFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                switch (Path.GetExtension(filename).ToLower())
                {
                    case ".ttf":
                        if (System.IO.File.Exists(filename))
                        {
                            PrivateFontCollection fontCol = new PrivateFontCollection();
                            fontCol.AddFontFile(filename);

                            if (!AddedFonts.Contains(filename))
                            {
                                int addedCount = AddFontResource(filename);
                                if (addedCount > 0)
                                {
                                    AddedFonts.Add(filename);
                                }
                            }
                            //LoadVectorFont(new Font(fontCol.Families[0].Name, 12f));
                            fontDialog1.Font = new Font(fontCol.Families[0].Name, 12f);
                            if (fontDialog1.ShowDialog() == DialogResult.OK)
                            {
                                LoadVectorFont(fontDialog1.Font);
                            }
                        }
                        break;
                    case ".st":
                        loadSelectedFileBZ98R(filename);
                        break;
                    case ".bmf":
                    default: // for now assume any unknown is BMF
                        loadSelectedFile(filename);
                        break;
                }
            }
        }

        private void fromFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadVectorFont(fontDialog1.Font);
            }
        }

        private void LoadVectorFont(Font inputFont)
        {
            VectorFont = inputFont;

            //if (FontFile != null)
            //{
            //    // adding to existing font
            //}
            //else

            listBox1.Items.Clear();

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            imgWords.Image = null;

            {
                // font from 0
                int Ascent = VectorFont.FontFamily.GetCellAscent(VectorFont.Style);
                int Descent = VectorFont.FontFamily.GetCellDescent(VectorFont.Style);
                int EmHeight = VectorFont.FontFamily.GetEmHeight(VectorFont.Style);

                int ascentPixel = (int)Math.Ceiling(Math.Ceiling(VectorFont.Size) * Ascent / EmHeight);
                int descentPixel = (int)Math.Ceiling(Math.Ceiling(VectorFont.Size) * Descent / EmHeight);
                int heightPixel = ascentPixel + descentPixel;

                KERNINGPAIR[] RawkerningPairs = GetKerningPairsData(VectorFont);

                BmfFile localFontFile = new BmfFile((byte)heightPixel, (byte)ascentPixel, (byte)descentPixel);
                //GlyphTypeface face = new GlyphTypeface()
                //System.Windows.Media.Typeface.TryGetGlyphTypeface()
                //System.Windows.Media.Typeface face = new Typeface(new System.Windows.Media.FontFamily(VectorFont.FontFamily.Name), VectorFont.Style, System.Windows.FontWeight.FromOpenTypeWeight()
                //using (Bitmap canvasDummy = new Bitmap(1, 1))
                //using (Graphics gDummy = Graphics.FromImage(canvasDummy))
                {
                    Dictionary<byte, int> BumpsNeeded = new Dictionary<byte, int>();

                    for (int i = 0; i < 256; i++)
                    {
                        //if (!char.IsControl((char)i))
                        {
                            //GLYPHMETRICS? metric = GetGlyphMetrics((char)i, VectorFont);
                            GLYPHMETRICS ImageMetric;
                            Bitmap BlackZone = GetGlyphBitmap((char)i, VectorFont, out ImageMetric);
                            if (ImageMetric.gmCellIncX > 0 || BlackZone != null)
                            {
                                //Bitmap canvas = new Bitmap(metric.Value.gmCellIncX - metric.Value.gmptGlyphOrigin.x, heightPixel);
                                //Graphics g = Graphics.FromImage(canvas);
                                //g.FillRectangle(new SolidBrush(Color.White), 0, 0, canvas.Width, canvas.Height);
                                //g.DrawString("" + (char)i, VectorFont, new SolidBrush(Color.Black), metric.Value.gmBlackBoxX - metric.Value.gmptGlyphOrigin.x, y);
                                //localFontFile.Characters.Add((byte)i, GenerateBmfCharacter(canvas));
                                //canvas.Dispose();

                                byte[] rawData;
                                if (BlackZone != null)
                                {
                                    rawData = new byte[BlackZone.Width * BlackZone.Height];
                                    for (int y = 0; y < BlackZone.Height; y++)
                                        for (int x = 0; x < BlackZone.Width; x++)
                                            rawData[y * BlackZone.Width + x] = BlackZone.GetPixel(x, y).A;
                                }
                                else
                                {
                                    rawData = new byte[0];
                                }

                                sbyte[] KerningPairs = new sbyte[256];
                                foreach (KERNINGPAIR pair in RawkerningPairs)
                                {
                                    if (pair.wFirst == i)
                                    {
                                        if (pair.wSecond < 256)
                                        {
                                            KerningPairs[pair.wSecond] = (sbyte)pair.iKernAmount;
                                            //KerningPairs[pair.wSecond] = (sbyte)Math.Ceiling(Math.Ceiling(VectorFont.Size) * pair.iKernAmount / EmHeight);
                                        }
                                    }
                                }

                                int LeftPad = 0;
                                int gmptGlyphOrigin_x = ImageMetric.gmptGlyphOrigin.x;
                                int gmptGlyphOrigin_y = heightPixel - ImageMetric.gmptGlyphOrigin.y;
                                int characterWidth = ImageMetric.gmCellIncX;
                                if (gmptGlyphOrigin_x < 0)
                                {
                                    LeftPad = gmptGlyphOrigin_x; // convert our negative offset into a negative left pad
                                    gmptGlyphOrigin_x = 0; // shift us over back to 0
                                    characterWidth -= LeftPad; // apply our negative offset to the extended left pad to correct the position
                                }
                                if (gmptGlyphOrigin_y < 0)
                                {
                                    BumpsNeeded[(byte)i] = -gmptGlyphOrigin_y; // preserve the bumps for when we loop back over all the items to push them down
                                    gmptGlyphOrigin_y = 0; // shift us over back to 0
                                }

                                BmfCharacter Character = new BmfCharacter(
                                    (byte)characterWidth, // entire width of character
                                    (byte)gmptGlyphOrigin_x, // black area x0
                                    (byte)gmptGlyphOrigin_y, // black area y0
                                    (byte)(gmptGlyphOrigin_x + (BlackZone?.Width ?? 0)), // black area x1
                                    (byte)(gmptGlyphOrigin_y + (BlackZone?.Height ?? 0)), // black area y1
                                    (byte)(BlackZone?.Width ?? 0), // black area width
                                    (byte)(BlackZone?.Height ?? 0), // black area height
                                    rawData, // black area graphics
                                    (sbyte)LeftPad, // left pad
                                    KerningPairs); // kerning
                                localFontFile.Characters.Add((byte)i, Character);
                            }
                        }
                    }

                    int maxHeightOffset = 0;
                    foreach(var off in BumpsNeeded)
                        maxHeightOffset = Math.Max(maxHeightOffset, off.Value);
                    localFontFile.Ascent += (byte)maxHeightOffset;
                    localFontFile.Height += (byte)maxHeightOffset;
                    foreach (var cdata in localFontFile.Characters)
                    {
                        int HeightOffset = maxHeightOffset;
                        if (BumpsNeeded.ContainsKey(cdata.Key))
                            HeightOffset = BumpsNeeded[cdata.Key];

                        cdata.Value.RectY0 += (byte)HeightOffset;
                    }
                }

                LoadFontFile(localFontFile);
            }
        }

        private void clearFontFile()
        {
            listBox1.Items.Clear();

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            imgWords.Image = null;

            FontFile = null;
            VectorFont = null;

            lblFontIdent.Text = string.Empty;
            lblNumChar.Text = "" + 0;
            nudFontHeight.Value = 0;
            nudFontAscent.Value = 0;
            nudFontDescent.Value = 0;

            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.EndUpdate();

            UpdateTextPreview();
        }

        private void loadSelectedFile(string filename)
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

                if (!System.IO.File.Exists(filename))
                    return;

                System.IO.Stream MainFont = System.IO.File.OpenRead(filename);
                
                string ExtendedFile = System.IO.Path.ChangeExtension(filename, ".bm2");
                System.IO.Stream ExtendedFont = null;
                if (System.IO.File.Exists(ExtendedFile))
                    ExtendedFont = System.IO.File.OpenRead(ExtendedFile);
                LoadFontFile(new BmfFile(MainFont, ExtendedFont));
            }
        }

        private struct BZ98R_Sprite_Data
        {
            public string material;
            public int u;
            public int v;
            public int w;
            public int h;
            public int ref_w;
            public int ref_h;
        }

        private void loadSelectedFileBZ98R(string filename)
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

                if (!System.IO.File.Exists(filename))
                    return;

                //string ExtendedFile = System.IO.Path.ChangeExtension(filename, ".png");

                string[] lines = File.ReadAllLines(filename);
                BZ98R_Sprite_Data[] data = new BZ98R_Sprite_Data[256];
                Dictionary<string, Bitmap> images = new Dictionary<string, Bitmap>();

                foreach (string[] line in lines.Select(dr => dr.Split('#')[0].Trim()).Where(dr => dr.Length > 0).Select(dr => dr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)))
                {
                    int idx = int.Parse(line[0].Trim('"').Split('.')[1]);
                    string material = line[1].Trim('"');
                    //int pad = 1024 / int.Parse(line[6]);
                    int u = int.Parse(line[2]);// * pad;
                    int v = int.Parse(line[3]);// * pad;
                    int w = int.Parse(line[4]);// * pad;
                    int h = int.Parse(line[5]);// * pad;
                    int ref_w = int.Parse(line[6]);
                    int ref_h = int.Parse(line[7]);
                    data[idx] = new BZ98R_Sprite_Data()
                    {
                        material = material,
                        u = u,
                        v = v,
                        w = w,
                        h = h,
                        ref_w = ref_w,
                        ref_h = ref_h
                    };
                    if (!images.ContainsKey(material))
                    {
                        string imageFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), material + ".png");
                        if (System.IO.File.Exists(imageFile))
                        {
                            images[material] = (Bitmap)Bitmap.FromFile(imageFile);
                        }
                        else
                        {
                            images[material] = null;
                        }
                    }
                }
                //int maxWidth = data.Max(dr => images[dr.material] != null ? dr.w * images[dr.material].Width / dr.ref_w : 0);
                int maxHeight = data.Max(dr => images[dr.material] != null ? dr.h * images[dr.material].Height / dr.ref_h : 0);

                BmfFile localFontFile = new BmfFile((byte)maxHeight, 0, 0);
                for (int i = 0; i < data.Length; i++)
                {
                    var dr = data[i];
                    int width = images[dr.material] != null ? dr.w * images[dr.material].Width / dr.ref_w : 0;
                    int sidePad = images[dr.material] != null ? 8 * images[dr.material].Width / dr.ref_w : 0;
                    int height = images[dr.material] != null ? dr.h * images[dr.material].Height / dr.ref_h : 0;
                    int u = images[dr.material] != null ? dr.u * images[dr.material].Width / dr.ref_w : 0;
                    int v = images[dr.material] != null ? dr.v * images[dr.material].Height / dr.ref_h : 0;
                    if (width > 0 && height > 0)
                    {
                        byte[] rawData = new byte[width * height];
                        if (images[dr.material] != null)
                        {
                            Bitmap bmp = images[dr.material];
                            for (int y = 0; y < height; y++)
                                for (int x = 0; x < width; x++)
                                {
                                    int sx = u + x;
                                    int sy = v + y;
                                    if (sx >= 0 && sx < bmp.Width && sy >= 0 && sy < bmp.Height)
                                        rawData[y * width + x] = bmp.GetPixel(sx, sy).A;
                                    else
                                        rawData[y * width + x] = 0;
                                }
                        }
                        BmfCharacter Character = new BmfCharacter(
                            (byte)(width + sidePad), // entire width of character
                            0, // black area x0
                            0, // black area y0
                            (byte)width, // black area x1
                            (byte)height, // black area y1
                            (byte)width, // black area width
                            (byte)height, // black area height
                            rawData, // black area graphics
                            0, // left pad
                            new sbyte[256]); // kerning
                        Character.Optimize();
                        localFontFile.Characters.Add((byte)i, Character);
                    }
                }
                LoadFontFile(localFontFile);
            }
        }

        private void RefreshNUDs()
        {
            nudFontHeight.Value = (uint)FontFile.Height;
            nudFontAscent.Value = (uint)FontFile.Ascent;
            nudFontDescent.Value = (uint)FontFile.Descent;

            BmfCharacterListItem item = (BmfCharacterListItem)listBox1.SelectedItem;
            if (item == null)
                return;
            nudRecX0.Value = (uint)item.Value.RectX0;
            nudRecX1.Value = (uint)item.Value.RectX1;
            nudRecY0.Value = (uint)item.Value.RectY0;
            nudRecY1.Value = (uint)item.Value.RectY1;
        }

        private void LoadFontFile(BmfFile file)
        {
            FontFile = file;

            lblFontIdent.Text = FontFile.Indent;
            lblNumChar.Text = "" + (uint)FontFile.CharCount;
            RefreshNUDs();

            listBox1.BeginUpdate();
            foreach (KeyValuePair<byte, BmfCharacter> character in FontFile.Characters)
            {
                listBox1.Items.Add(new BmfCharacterListItem(character));
            }
            listBox1.EndUpdate();

            UpdateTextPreview();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BmfCharacterListItem item = (BmfCharacterListItem)listBox1.SelectedItem;
            int Width = (int)(uint)item.Value.charWidth;
            int Height = (int)(uint)item.Value.charHeight;

            int FullWidth = (int)(uint)item.Value.fullWidth;
            int FullHeight = (int)(uint)FontFile.Height;
            int XOffset = (int)(uint)item.Value.RectX0;
            int YOffset = (int)(uint)item.Value.RectY0;

            nudExtendedLeftOffset.Value = item.Value.extendedLeftOffset;
            for (int i = 0; i < 256; i++)
                ExtendedKerningEdit[i].Value = item.Value.extendedKerningPairs[i];

            FullWidth = Math.Max(FullWidth, Width);
            //FullWidth = Math.Max(FullWidth, (int)(uint)item.Value.RectX1);
            //FullWidth = Math.Max(FullWidth, (int)(uint)item.Value.RectX0 + Width);
            FullHeight = Math.Max(FullHeight, Height);
            //FullHeight = Math.Max(FullHeight, (int)(uint)item.Value.RectY1);
            //FullHeight = Math.Max(FullHeight, (int)(uint)item.Value.RectY0 + Height);

            lblCharWidth.Text = "" + Width;
            lblCharHeight.Text = "" + Height;
            nudCharValue.Value = (uint)item.Key;
            nudFullWidth.Value = (uint)item.Value.fullWidth;
            nudRecX0.Value = (uint)item.Value.RectX0;
            nudRecX1.Value = (uint)item.Value.RectX1;
            nudRecY0.Value = (uint)item.Value.RectY0;
            nudRecY1.Value = (uint)item.Value.RectY1;

            if (Height == 0 || Width == 0)
            {
                Bitmap tmpImage2 = new Bitmap(FullWidth, FullHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Bitmap tmpImage3 = new Bitmap(FullWidth, FullHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                for (int y = 0; y < FullHeight; y++)
                {
                    for (int x = 0; x < FullWidth; x++)
                    {
                        tmpImage2.SetPixel(x, y, Color.Magenta);
                    }
                }
                for (int y = 0; y < FullHeight; y++)
                {
                    for (int x = 0; x < FullWidth; x++)
                    {
                        tmpImage3.SetPixel(x, y, Color.Transparent);
                    }
                }

                pictureBox1.Width = 0;
                pictureBox1.Height = 0;
                pictureBox1.Image = null;
                pictureBox2.Width = tmpImage2.Width;
                pictureBox2.Height = tmpImage2.Height;
                pictureBox2.Image = tmpImage2;
                pictureBox3.Width = tmpImage3.Width;
                pictureBox3.Height = tmpImage3.Height;
                pictureBox3.Image = tmpImage3;
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
                        if (XOffset + x >= FullWidth)
                            continue;
                        if (YOffset + y >= FullHeight)
                            continue;
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
                        if (XOffset + x >= FullWidth)
                            continue;
                        if (YOffset + y >= FullHeight)
                            continue;
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
            if (item == null)
                return;
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
            imgWords.Image = null;

            if (FontFile != null)
            {
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
                        int OffsetRight = (int)(uint)lastChar.RectX1;
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
                            if (dataForChar.RectY1 > extraHeight)
                            {
                                extraHeight = dataForChar.RectY1;
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
                                int LetterXOffset = (int)(uint)dataForChar.RectX0;
                                int LetterYOffset = (int)(uint)dataForChar.RectY0;

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
                                            int x = runningWidth + LetterXOffset + xInner;
                                            if (x < 0) continue;
                                            int y = (lineNum * FontFile.Height) + LetterYOffset + yInner;
                                            int DrawOverColor = DrawOver
                                                ? myImage.GetPixel(x, y).A
                                                : 0;
                                            myImage.SetPixel(x, y, Color.FromArgb(Math.Min(DrawOverColor + z, 255), 0, 0, 0));
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


        private void nudFValueChanged_ValueChanged(object sender, EventArgs e)
        {
            if (FontFile == null)
                return;

            NumericUpDown nud = sender as NumericUpDown;
            if (nud == null)
                return;

            if (nud == nudFontAscent)
            {
                FontFile.Ascent = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }
            if (nud == nudFontDescent)
            {
                FontFile.Descent = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }
            if (nud == nudFontHeight)
            {

                FontFile.Height = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }

            BmfCharacterListItem item = (BmfCharacterListItem)listBox1.SelectedItem;
            if (item == null)
                return;
            if (nud == nudCharValue)
            {
                // prevent editing this, at least for now
                nudCharValue.Value = item.Key;
                return;
            }
            if (nud == nudFullWidth)
            {
                item.Value.fullWidth = (byte)nud.Value;
                UpdateTextPreview();
                return;
            }
            if (nud == nudRecX0)
            {
                item.Value.RectX0 = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }
            if (nud == nudRecX1)
            {
                item.Value.RectX1 = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }
            if (nud == nudRecY0)
            {
                item.Value.RectY0 = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }
            if (nud == nudRecY1)
            {
                item.Value.RectY1 = (byte)nud.Value;
                RefreshNUDs();
                UpdateTextPreview();
                return;
            }

            if (nud == nudExtendedLeftOffset)
            {
                item.Value.extendedLeftOffset = (sbyte)nud.Value;
                UpdateTextPreview();
                return;
            }
            if (nud.Tag != null)
            {
                string tag = nud.Tag as string;
                if(tag != null)
                {
                    string[] splt = tag.Split('_');
                    if(splt[0] == "Kerning" && splt.Length > 1)
                    {
                        int tInt = 0;
                        if (int.TryParse(splt[1], out tInt))
                        {
                            item.Value.extendedKerningPairs[tInt] = (sbyte)nud.Value;
                            UpdateTextPreview();
                            return;
                        }
                    }
                }
            }
        }
    }
}
