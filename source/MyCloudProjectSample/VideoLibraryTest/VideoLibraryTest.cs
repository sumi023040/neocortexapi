using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using VideoLibrary;
namespace VideoLibraryTest1
{
    [TestClass]
    public class VideoLibraryTest
    {
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        public TestInfo ReadVideo()
        {
            TestInfo result = new TestInfo
            {
                TestName = "ReadVideo",
                IsPassing = true // Assume passing, modify based on the actual test logic
            };

            try {
                // Read Video from a file path
                string filePath = "testFile//ReadVideo//circle_mp4.mp4";
                NVideo nv = new(filePath, "test", ColorMode.BLACKWHITE, 24, 24, 24);

                // export Video to outputFilePath
                string outputFilePath = "testFile//ReadVideo//output_mp4.mp4";
                List<Bitmap> bitmapList = new();
                NVideo.NFrameListToVideo(nv.nFrames, outputFilePath, 24, new Size(24, 24), false);
            }
            catch (Exception ex)
            {
                result.IsPassing = false;
            }
            return result;

        }

        public TestInfo BitmapResize()
        {
            TestInfo result = new TestInfo
            {
                TestName = "BitmapResize",
                IsPassing = true // Assume passing, modify based on the actual test logic
            };
            try
            {
                Bitmap temp = new(Image.FromFile("testFile//image//street.jpg"));

                // oversizing the image
                Bitmap output = NFrame.ResizeBitmap(temp, 5000, 5000);
                output.Save("testFile//image//streetOutput_5000x5000.jpg");

                // undersizing the image
                output = NFrame.ResizeBitmap(temp, 5000, 5000);
                output.Save("testFile//image//streetOutput_300x300.jpg");
            }
            catch (Exception ex)
            {
                result.IsPassing = false;
            }
            return result;
        }

        public TestInfo ColorChannelConvert()
        {
            TestInfo result = new TestInfo
            {
                TestName = "ColorChannelConvert",
                IsPassing = true // Assume passing, modify based on the actual test logic
            };
            try
            {
                // Convert from byte to List of binary value
                byte value = 42;
                List<int> a = NFrame.ColorChannelToBinList(value);

                Debug.WriteLine("Testing byte conversion to Binary array");
                foreach (int i in a)
                {
                    Debug.WriteLine(i);
                }
                Debug.WriteLine("End testing ...");
            }
            catch (Exception ex)
            {
                result.IsPassing = false;
            }
            return result;
        }

        public TestInfo SubArrayTest()
        {
            TestInfo result = new TestInfo
            {
                TestName = "SubArrayTest",
                IsPassing = true // Assume passing, modify based on the actual test logic
            };
            try
            {
                int[] a = { 1, 2, 3, 4, 5 };
                int[] outputArray = NFrame.SubArray<int>(a, 3, 2);
                Debug.WriteLine("Testing with sub array function");
                foreach (int i in outputArray)
                {
                    Debug.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                result.IsPassing = false;
            }
            return result;
        }

        public TestInfo BitmapConvert()
        {
            TestInfo result = new TestInfo
            {
                TestName = "BitmapConvert",
                IsPassing = true // Assume passing, modify based on the actual test logic
            };
            try
            {
                Bitmap img = new(Image.FromFile("testFile//image//street.jpg"));
                img = NFrame.ResizeBitmap(img, 40, 200);
                //img.Save("testFile//image//street_Resized.jpg");
                string outputFile = "testFile//image//streetOutput_bitmapConverted.jpg";
                ColorMode colorMode = ColorMode.PURE;
                List<int> imageBinary = new List<int>();

                for (int y = 0; y < img.Height; y++)
                {
                    for (int x = 0; x < img.Width; x++)
                    {
                        Color pixel = img.GetPixel(x, y);
                        switch (colorMode)
                        {
                            // adding different color mode here for different format of output int[]
                            // more info/color resolution resulted in increase of output bit
                            case ColorMode.BLACKWHITE:
                                // image binarization of GRAYSCALE source image
                                // taking red channel as comparatee for binarization 
                                imageBinary.Add((pixel.R > 254 / 2) ? 0 : 1);
                                break;
                            case ColorMode.BINARIZEDRGB:
                                // image binarization of RGB source image
                                // binarize each color from RGB channels in order : red --> green --> blue
                                imageBinary.AddRange(new List<int>() { (pixel.R > 254 / 2) ? 1 : 0, (pixel.G > 254 / 2) ? 1 : 0, (pixel.B > 254 / 2) ? 1 : 0 });
                                break;
                            case ColorMode.PURE:
                                imageBinary.AddRange(NFrame.ColorChannelToBinList(pixel.R));
                                /*
                                Debug.WriteLine($"Original pixel red channel value: {pixel.R}");
                                Debug.WriteLine("Converted to binary array value:");
                                List<int> temp = NFrame.ColorChannelToBinList(pixel.R);
                                foreach (int t in temp)
                                {
                                    Debug.Write($"{t} ");
                                }
                                Debug.WriteLine("Reverted value from binary array:");
                                Debug.WriteLine(NFrame.BinaryToDecimal(NFrame.ColorChannelToBinList(pixel.R).ToArray()));
                                */
                                imageBinary.AddRange(NFrame.ColorChannelToBinList(pixel.G));
                                imageBinary.AddRange(NFrame.ColorChannelToBinList(pixel.B));
                                break;
                        }
                    }
                }
                int[] rgb = { 0, 0, 0 };
                Bitmap output = new(img.Width, img.Height);
                for (int y = 0; y < img.Height; y += 1)
                {
                    for (int x = 0; x < img.Width; x += 1)
                    {
                        switch (colorMode)
                        {
                            case ColorMode.BLACKWHITE:
                                if (imageBinary[y * img.Width + x] == 0)
                                {
                                    output.SetPixel(x, y, Color.FromArgb(254, 254, 254, 254));
                                }
                                else
                                {
                                    output.SetPixel(x, y, Color.FromArgb(254, 0, 0, 0));
                                }
                                break;
                            case ColorMode.BINARIZEDRGB:
                                for (int i = 0; i < 3; i += 1)
                                {
                                    rgb[i] = (imageBinary[(y * img.Width + x) * 3 + i] == 1) ? 254 : 0;
                                }
                                output.SetPixel(x, y, Color.FromArgb(254, rgb[0], rgb[1], rgb[2]));
                                break;
                            case ColorMode.PURE:
                                for (int i = 0; i < 3; i += 1)
                                {
                                    int[] binaryColorArray = NFrame.SubArray<int>(imageBinary.ToArray(), (y * img.Width + x) * 24 + 8 * i, 8);
                                    rgb[i] = NFrame.BinaryToDecimal(binaryColorArray);

                                }
                                output.SetPixel(x, y, Color.FromArgb(255, rgb[0], rgb[1], rgb[2]));
                                break;
                        }
                    }
                }
                output.Save(outputFile);
            }
            catch (Exception ex)
            {
                result.IsPassing = false;
            }
            return result;
        }

        public TestInfo WriteFile()
        {
            TestInfo result = new TestInfo
            {
                TestName = "WriteFile",
                IsPassing = true // Assume passing, modify based on the actual test logic
            };
            try
            {
                static void RecordResult(List<string> result, string fileName)
                {
                    File.WriteAllLines($"{fileName}.txt", result);
                }
                List<string> a = new();
                a.Add($"Testing meThod");
                a.Add($"For Sequence Learning Experiment");
                RecordResult(a, "Outputter.txt");
            }
            catch (Exception ex)
            {
                result.IsPassing = false;
            }
            return result;
        }

    }

    public class TestInfo
    {
        public string TestName { get; set; }
        public bool IsPassing { get; set; }
    }
}
