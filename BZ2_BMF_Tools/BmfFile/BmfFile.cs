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

        public void Write(Stream output)
        {
            output.Write(fontIdent,0,4);
            output.WriteByte(CharCount);
            output.WriteByte(fontHeight);
            output.WriteByte(fontAscent);
            output.WriteByte(fontDescent);

            foreach(KeyValuePair<byte, BmfCharacter> character in characters)
            {
                output.WriteByte(character.Key);
                output.WriteByte(character.Value.fullWidth);
                output.WriteByte(character.Value.rectX0);
                output.WriteByte(character.Value.rectY0);
                output.WriteByte(character.Value.rectX1);
                output.WriteByte(character.Value.rectY1);
            }
            foreach (KeyValuePair<byte, BmfCharacter> character in characters)
            {
                output.WriteByte(character.Value.charWidth);
                output.WriteByte(character.Value.charHeight);
                output.Write(character.Value.charData, 0, character.Value.charData.Length);
            }
        }

        public string Indent
        {
            get { return ASCIIEncoding.ASCII.GetString(fontIdent); }
        }

        public byte CharCount
        {
            //get { return numChar; }
            get { return (byte)characters.Count; }
        }

        public byte Height
        {
            get { return fontHeight; }
        }
        public byte Ascent
        {
            get { return fontAscent; }
        }
        public byte Descent
        {
            get { return fontDescent; }
        }

        public Dictionary<byte, BmfCharacter> Characters
        {
            get { return characters; }
        }
    }

    public class BmfCharacter
    {
        //byte charValue;// character ascii value
        public byte fullWidth;// full character width
        public byte rectX0;// left x position in image
        public byte rectY0;// top y position in image
        public byte rectX1;// right x position in image
        public byte rectY1;// bottom y position in image

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
    }
}
