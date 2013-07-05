using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nielk1.Formats.Battlezone.BMF;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;
using CompileFont;

namespace Nielk1.Tools.Battlezone.CompileFont
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string filename = args[0];
                if (Directory.Exists(filename))
                {
                    string decriptionF = filename + Path.DirectorySeparatorChar + @"font.txt";
                    if (File.Exists(decriptionF))
                    {
                        string description;
                        using (StreamReader descriptionR = File.OpenText(decriptionF))
                        {
                            description = descriptionR.ReadToEnd();
                        }
                        if (description == null) return;

                        JavaScriptSerializer jsonMaker = new JavaScriptSerializer();
                        JSONOutputObject data = jsonMaker.Deserialize <JSONOutputObject>(description);

                        BmfFile FontFile = new BmfFile(data.fontHeight, data.fontAscent, data.fontDescent);

                        for (int x = 0; x < 256; x++)
                        {
                            string imageFilename = filename + Path.DirectorySeparatorChar + Convert.ToString(x, 16).PadLeft(2, '0') + @".bmp";
                            if (File.Exists(imageFilename))
                            {
                                using (Bitmap thisLetter = (Bitmap)Bitmap.FromFile(imageFilename))
                                {
                                    int Height = thisLetter.Size.Height;
                                    int Width = thisLetter.Size.Width;
                                    int FullWidth = Width;

                                    int OffsetX0 = 0;
                                    int OffsetY0 = 0;
                                    int OffsetX1 = Width;
                                    int OffsetY1 = Height;

                                    Console.WriteLine("Processing letter: " + (uint)x + "\t" + Convert.ToString(x, 16) + "\t" + (!char.IsControl((char)x) ? "" + (char)x : ""));

                                    bool nonWhiteLine = false;
                                    for (int Iy = 0; Iy < Height; Iy++)
                                    {
                                        for (int Ix = 0; Ix < Width; Ix++)
                                        {
                                            if (thisLetter.GetPixel(Ix, Iy).R != 0xFF)
                                            {
                                                nonWhiteLine = true;
                                                OffsetY0 = Iy;
                                                break;
                                            }
                                        }
                                        if (nonWhiteLine) break;
                                    }
                                    Console.WriteLine("Got OffsetY0: " + OffsetY0);

                                    nonWhiteLine = false;
                                    for (int Iy = Height - 1; Iy >= 0; Iy--)
                                    {
                                        for (int Ix = 0; Ix < Width; Ix++)
                                        {
                                            if (thisLetter.GetPixel(Ix, Iy).R != 0xFF)
                                            {
                                                nonWhiteLine = true;
                                                OffsetY1 = Iy + 1;
                                                break;
                                            }
                                        }
                                        if (nonWhiteLine) break;
                                    }
                                    if (!nonWhiteLine) OffsetY1 = 0;
                                    Console.WriteLine("Got OffsetY1: " + OffsetY1);

                                    nonWhiteLine = false;
                                    for (int Ix = 0; Ix < Width; Ix++)
                                    {
                                        for (int Iy = 0; Iy < Height; Iy++)
                                        {
                                            if (thisLetter.GetPixel(Ix, Iy).R != 0xFF)
                                            {
                                                nonWhiteLine = true;
                                                OffsetX0 = Ix;
                                                break;
                                            }
                                        }
                                        if (nonWhiteLine) break;
                                    }
                                    Console.WriteLine("Got OffsetX0: " + OffsetX0);

                                    nonWhiteLine = false;
                                    for (int Ix = Width - 1; Ix >= 0; Ix--)
                                    {
                                        for (int Iy = 0; Iy < Height; Iy++)
                                        {
                                            if (thisLetter.GetPixel(Ix, Iy).R != 0xFF)
                                            {
                                                nonWhiteLine = true;
                                                OffsetX1 = Ix + 1;
                                                break;
                                            }
                                        }
                                        if (nonWhiteLine) break;
                                    }
                                    if (!nonWhiteLine) OffsetX1 = 0;
                                    Console.WriteLine("Got OffsetX1: " + OffsetX1);

                                    int croppedWidth = OffsetX1 - OffsetX0;
                                    int croppedHeight = OffsetY1 - OffsetY0;

                                    if (croppedWidth < 0 || croppedHeight < 0)
                                    {
                                        Console.WriteLine("wtf");
                                    }

                                    byte[] colorBytes = new byte[croppedWidth * croppedHeight];

                                    for (int Iy = OffsetY0; Iy < OffsetY1; Iy++)
                                    {
                                        for (int Ix = OffsetX0; Ix < OffsetX1; Ix++)
                                        {
                                            colorBytes[(Iy - OffsetY0) * croppedWidth + (Ix - OffsetX0)] = (byte)(255 - thisLetter.GetPixel(Ix, Iy).R);
                                        }
                                    }
                                    FontFile.Characters.Add((byte)x, new BmfCharacter(
                                        (byte)FullWidth,
                                        (byte)OffsetX0,
                                        (byte)OffsetY0,
                                        (byte)OffsetX1,
                                        (byte)OffsetY1,
                                        (byte)croppedWidth,
                                        (byte)croppedHeight,
                                        colorBytes));

                                    Console.WriteLine("------------");
                                }
                            }
                        }

                        using (FileStream outputStream = File.Create(filename.TrimEnd(Path.DirectorySeparatorChar) + @".bmf"))
                        {
                            FontFile.Write(outputStream);
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
