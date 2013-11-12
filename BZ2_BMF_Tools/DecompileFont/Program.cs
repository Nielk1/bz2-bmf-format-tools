using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nielk1.Formats.Battlezone.BMF;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization; 

namespace Nielk1.Tools.Battlezone.DecompileFont
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string filename = args[0];
                if (System.IO.File.Exists(filename))
                {
                    FileStream stream = File.OpenRead(filename);
                    BmfFile FontFile = new BmfFile(stream);

                    string saveLocation = Path.GetDirectoryName(filename);
                    saveLocation += Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filename);
                    if(!Directory.Exists(saveLocation))
                    {
                        Directory.CreateDirectory(saveLocation);
                    }

                    var outputObj = new {
                        fontHeight = FontFile.Height,
                        fontAscent = FontFile.Ascent,
                        fontDescent = FontFile.Descent
                    };

                    JavaScriptSerializer jsonMaker = new JavaScriptSerializer();
                    string output = jsonMaker.Serialize(outputObj);
                    using (StreamWriter fileWriter = File.CreateText(saveLocation + Path.DirectorySeparatorChar + @"font.txt"))
                    {
                        fileWriter.Write(output);
                    }

                    foreach (KeyValuePair<byte, BmfCharacter> character in FontFile.Characters)
                    {
                        int keyVal = (int)(uint)character.Key;

                        int Width = (int)(uint)character.Value.charWidth;
                        int Height = (int)(uint)character.Value.charHeight;

                        int FullWidth = (int)(uint)character.Value.fullWidth;
                        int FullHeight = (int)(uint)FontFile.Height;
                        int XOffset = (int)(uint)character.Value.rectX0;
                        int YOffset = (int)(uint)character.Value.rectY0;

                        FullWidth = Math.Max(FullWidth, (int)(uint)character.Value.rectX1);
                        FullHeight = Math.Max(FullHeight, (int)(uint)character.Value.rectY1);

                        string outputIDString = Convert.ToString(keyVal, 16).PadLeft(2, '0');

                        if (FullWidth == 0 || FullWidth == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Bitmap tmpImage = new Bitmap(FullWidth, FullHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                            for (int y = 0; y < FullHeight; y++)
                            {
                                for (int x = 0; x < FullWidth; x++)
                                {
                                    tmpImage.SetPixel(x, y, Color.White);
                                }
                            }
                            for (int y = 0; y < Height; y++)
                            {
                                for (int x = 0; x < Width; x++)
                                {
                                    int z = 255 - character.Value.charData[y * Width + x];
                                    tmpImage.SetPixel(XOffset + x, YOffset + y, Color.FromArgb(255, z, z, z));
                                }
                            }
                            tmpImage.Save(saveLocation + Path.DirectorySeparatorChar + outputIDString + @".bmp");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("{Write Usage}");
            }
        }
    }
}
