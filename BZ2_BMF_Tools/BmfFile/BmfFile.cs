using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nielk1.Formats.Battlezone.BMF
{
    public class BmfFile
    {
        // FILE FONT HEADER
        /*public struct FontHeader
        {
            public byte[] fontIdent;// unique font identifier
            public byte numChar;// number of characters in the font
            public byte fontHeight;// maximum height of each character
            public byte fontAscent;// character ascent above the baseline
            public byte fontDescent;// character descent below the baseline
        };*/

        // FILE CHARACTER HEADER
        private struct CharHeader
        {
            public byte charValue;// character ascii value
            public byte fullWidth;// full character width
            public byte rectX0;// left x position in image
            public byte rectY0;// top y position in image
            public byte rectX1;// right x position in image
            public byte rectY1;// bottom y position in image
        };

        // FILE CHARACTER IMAGE
        private struct CharImage
        {
            public byte charWidth;// width of the character image
            public byte charHeight;// height of the character image
            public byte[] charData;// character pixels
        };

        private struct CharExtension
        {
            public sbyte leftOffset; // extended data
            public sbyte[] kerningPairs; // extended data
        }

        //private FontHeader fontHeader;
        //public/*private*/ CharHeader[] charHeaders;
        //public/*private*/ CharImage[] charImages;

        private byte[] fontIdent;// unique font identifier
        //private byte numChar;// number of characters in the font
        private byte fontHeight;// maximum height of each character
        private byte fontAscent;// character ascent above the baseline
        private byte fontDescent;// character descent below the baseline

        private Dictionary<byte, BmfCharacter> characters;

        public BmfFile(Stream fileStream, Stream extendedFile = null)
        {
            using (fileStream)
            {
                fontIdent = new byte[4];
                fileStream.Read(fontIdent, 0, fontIdent.Length);
                byte numChar = (byte)fileStream.ReadByte();
                fontHeight = (byte)fileStream.ReadByte();
                fontAscent = (byte)fileStream.ReadByte();
                fontDescent = (byte)fileStream.ReadByte();

                // read in data
                CharHeader[] charHeaders = new CharHeader[(uint)numChar];
                CharImage[] charImages = new CharImage[(uint)numChar];
                CharExtension[] charExtension = new CharExtension[256];
                for (uint x = 0; x < (uint)numChar; x++)
                {
                    charHeaders[x].charValue = (byte)fileStream.ReadByte();
                    charHeaders[x].fullWidth = (byte)fileStream.ReadByte();
                    charHeaders[x].rectX0 = (byte)fileStream.ReadByte();
                    charHeaders[x].rectY0 = (byte)fileStream.ReadByte();
                    charHeaders[x].rectX1 = (byte)fileStream.ReadByte();
                    charHeaders[x].rectY1 = (byte)fileStream.ReadByte();
                }
                for (uint x = 0; x < (uint)numChar; x++)
                {
                    charImages[x].charWidth = (byte)fileStream.ReadByte();
                    charImages[x].charHeight = (byte)fileStream.ReadByte();
                    charImages[x].charData = new byte[((uint)charImages[x].charWidth) * ((uint)charImages[x].charHeight)];
                    for (uint y = 0; y < charImages[x].charData.Length; y++)
                    {
                        charImages[x].charData[y] = (byte)fileStream.ReadByte();
                    }
                }
                for (uint x = 0; x < 256; x++)
                {
                    if (extendedFile == null)
                    {
                        charExtension[x].leftOffset = (sbyte)0x00;
                        charExtension[x].kerningPairs = new sbyte[256];
                        //for (uint y = 0; y < 256; y++)
                        //    charHeaders[x].extendedKerningPairs[y] = (sbyte)0x00;
                    }
                    else
                    {
                        charExtension[x].leftOffset = (sbyte)extendedFile?.ReadByte();
                        charExtension[x].kerningPairs = new sbyte[256];
                        for (uint y = 0; y < 256; y++)
                            charExtension[x].kerningPairs[y] = (sbyte)extendedFile?.ReadByte();
                    }
                }

                //re-roll data
                characters = new Dictionary<byte, BmfCharacter>();
                for (uint x = 0; x < (uint)numChar; x++)
                {
                    characters.Add(charHeaders[x].charValue,
                        new BmfCharacter(
                            charHeaders[x].fullWidth,
                            charHeaders[x].rectX0,
                            charHeaders[x].rectY0,
                            charHeaders[x].rectX1,
                            charHeaders[x].rectY1,
                            charImages[x].charWidth,
                            charImages[x].charHeight,
                            charImages[x].charData,
                            charExtension[charHeaders[x].charValue].leftOffset,
                            charExtension[charHeaders[x].charValue].kerningPairs));
                }
            }
        }

        public BmfFile(byte fontHeight, byte fontAscent, byte fontDescent)
        {
            this.fontIdent = new byte[4] {(byte)'F',(byte)'O',(byte)'N',(byte)'T'};
            this.fontHeight = fontHeight;
            this.fontAscent = fontAscent;
            this.fontDescent = fontDescent;
            this.characters = new Dictionary<byte, BmfCharacter>();
        }

        public void Write(Stream output, Stream output2)
        {
            output.Write(fontIdent, 0, 4);
            output.WriteByte(CharCount);
            output.WriteByte(fontHeight);
            output.WriteByte(fontAscent);
            output.WriteByte(fontDescent);

            foreach (KeyValuePair<byte, BmfCharacter> character in characters)
            {
                output.WriteByte(character.Key);
                output.WriteByte(character.Value.fullWidth);
                output.WriteByte(character.Value.RectX0);
                output.WriteByte(character.Value.RectY0);
                output.WriteByte(character.Value.RectX1);
                output.WriteByte(character.Value.RectY1);
            }
            foreach (KeyValuePair<byte, BmfCharacter> character in characters)
            {
                output.WriteByte(character.Value.charWidth);
                output.WriteByte(character.Value.charHeight);
                output.Write(character.Value.charData, 0, character.Value.charData.Length);
            }

            if (output2 != null)
            {
                for (int i = 0; i < 256; i++)
                {
                    if (!characters.ContainsKey((byte)i))
                    {
                        output2.WriteByte(0x00);
                        continue;
                    }
                    output2.WriteByte((byte)characters[(byte)i].extendedLeftOffset);
                }
                for (int i = 0; i < 256; i++)
                {
                    if (!characters.ContainsKey((byte)i))
                    {
                        for (int j = 0; i < 256; j++)
                            output2.WriteByte(0x00);
                        continue;
                    }
                    for (int j = 0; i < 256; j++)
                        output2.WriteByte((byte)characters[(byte)i].extendedKerningPairs[j]);
                }
            }
        }

        public string Indent
        {
            get { return ASCIIEncoding.ASCII.GetString(fontIdent); }
        }

        public byte CharCount
        {
            get { return (byte)characters.Count; }
        }

        public byte Height
        {
            get { return fontHeight; }
            set
            {
                int NewAscent = value - fontDescent;
                if (NewAscent < 256 && NewAscent >= 0)
                {
                    fontHeight = value;
                    fontAscent = (byte)NewAscent;
                }
            }
        }
        public byte Ascent
        {
            get { return fontAscent; }
            set
            {
                int NewDescent = fontHeight - value;
                if (NewDescent < 256 && NewDescent >= 0)
                {
                    fontAscent = value;
                    fontDescent = (byte)NewDescent;
                }
            }
        }
        public byte Descent
        {
            get { return fontDescent; }
            set
            {
                int NewAscent = fontHeight - value;
                if (NewAscent < 256 && NewAscent >= 0)
                {
                    fontDescent = value;
                    fontAscent = (byte)NewAscent;
                }
            }
        }

        public Dictionary<byte, BmfCharacter> Characters
        {
            get { return characters; }
            set { characters = value; }
        }
    }

    public class BmfCharacter
    {
        //byte charValue;// character ascii value
        public byte fullWidth;// full character width
        private byte rectX0;// left x position in image
        private byte rectY0;// top y position in image
        private byte rectX1;// right x position in image
        private byte rectY1;// bottom y position in image

        public byte RectX0
        {
            get { return rectX0; }
            set
            {
                int newValue = charWidth - value;
                if (newValue < 256 && newValue >= 0)
                {
                    rectX0 = value;
                    rectX1 = (byte)newValue;
                }
            }
        }
        public byte RectY0
        {
            get { return rectY0; }
            set
            {
                int newValue = charHeight - value;
                if (newValue < 256 && newValue >= 0)
                {
                    rectY0 = value;
                    rectY1 = (byte)newValue;
                }
            }
        }

        public byte RectX1
        {
            get { return rectX1; }
            set
            {
                int newValue = charWidth - value;
                if (newValue < 256 && newValue >= 0)
                {
                    rectX1 = value;
                    rectX0 = (byte)newValue;
                }
            }
        }
        public byte RectY1
        {
            get { return rectY1; }
            set
            {
                int newValue = charHeight - value;
                if (newValue < 256 && newValue >= 0)
                {
                    rectY1 = value;
                    rectY0 = (byte)newValue;
                }
            }
        }

        public byte charWidth;// width of the character image
        public byte charHeight;// height of the character image
        public byte[] charData;// character pixels

        public sbyte extendedLeftOffset; // extended data
        public sbyte[] extendedKerningPairs; // extended data

        public BmfCharacter(byte fullWidth, byte rectX0, byte rectY0, byte rectX1, byte rectY1, byte charWidth, byte charHeight, byte[] charData, sbyte extendedLeftOffset, sbyte[] extendedKerningPairs)
        {
            this.fullWidth = fullWidth;
            this.rectX0 = rectX0;
            this.rectY0 = rectY0;
            this.rectX1 = rectX1;
            this.rectY1 = rectY1;
            this.charWidth = charWidth;
            this.charHeight = charHeight;
            this.charData = charData;
            this.extendedLeftOffset = extendedLeftOffset;
            this.extendedKerningPairs = extendedKerningPairs;
        }

        /// <summary>
        /// Compact the character by removing empty space around the image data and shifting the offsets.
        /// </summary>
        public void Optimize()
        {
            int origWidth = charWidth;
            int origHeight = charHeight;
            int origRectX0 = rectX0;
            int origRectY0 = rectY0;
            int origRectX1 = rectX1;
            int origRectY1 = rectY1;

            int left = origWidth;
            int right = -1;
            int top = origHeight;
            int bottom = -1;

            for (int y = 0; y < origHeight; y++)
            {
                for (int x = 0; x < origWidth; x++)
                {
                    if (charData[y * origWidth + x] != 0)
                    {
                        if (x < left) left = x;
                        if (x > right) right = x;
                        if (y < top) top = y;
                        if (y > bottom) bottom = y;
                    }
                }
            }

            // check if empty
            if (left > right || top > bottom)
            {
                rectX0 = 0;
                rectY0 = 0;
                rectX1 = 0;
                rectY1 = 0;
                charWidth = 0;
                charHeight = 0;
                charData = new byte[0];
                return;
            }

            int newWidth = right - left + 1;
            int newHeight = bottom - top + 1;
            byte[] newData = new byte[newWidth * newHeight];
            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    newData[y * newWidth + x] = charData[(y + top) * origWidth + (x + left)];
                }
            }

            // adjust rects to preserve glyph origin
            rectX0 = (byte)(origRectX0 + left);
            rectY0 = (byte)(origRectY0 + top);
            rectX1 = (byte)(origRectX1 + left);
            rectY1 = (byte)(origRectY1 + top);
            charWidth = (byte)newWidth;
            charHeight = (byte)newHeight;
            charData = newData;
        }
    }
}
