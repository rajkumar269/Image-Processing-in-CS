using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Bitmap InputImage;
            Bitmap OutputImage;

            InputImage = (Bitmap)Image.FromFile(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Input\Image.jpg");
            OutputImage = TimeWarpForImage(InputImage, 5);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\TimeWarpForImage.jpg");
           
        }


        public Bitmap TimeWarpForImage(Bitmap Image, byte Factor)
        {
            int ImageWidth = Image.Width;
            int ImageHeight = Image.Height;
            int ImageStride = 0;

            Bitmap TempBmp = (Bitmap)Image.Clone();

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, ImageWidth, ImageHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            ImageStride = ImageData.Stride;

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                int StopPtr = (int)Ptr + ImageStride * ImageHeight;

                int Val = 0;
                int MidX = ImageWidth / 2;
                int MidY = ImageHeight / 2;
                int i = 0, X = 0, Y = 0;
                int TrueX = 0, TrueY = 0;
                int NewX = 0, NewY = 0;

                double NewRadius = 0;
                double Theta = 0, Radius = 0;

                while ((int)Ptr != StopPtr)
                {
                    X = i % ImageWidth;
                    Y = i / ImageWidth;

                    TrueX = X - MidX;
                    TrueY = Y - MidY;

                    Theta = Math.Atan2(TrueY, TrueX);
                    Radius = Math.Sqrt(TrueX * TrueX + TrueY * TrueY);
                    NewRadius = Math.Sqrt(Radius) * Factor;

                    NewX = (int)(MidX + (NewRadius * Math.Cos(Theta)));
                    NewY = (int)(MidY + (NewRadius * Math.Sin(Theta)));

                    if (NewY >= 0 && NewY < ImageHeight && NewX >= 0 && NewX < ImageWidth)
                    {
                        Val = (NewY * ImageStride) + (NewX * 3);

                        Ptr[0] = TempPtr[Val];
                        Ptr[1] = TempPtr[Val + 1];
                        Ptr[2] = TempPtr[Val + 2];
                    }

                    Ptr += 3;
                    i++;
                }
            }

            Image.UnlockBits(ImageData);
            TempBmp.UnlockBits(TempBmpData);

            return Image;
        }
    }
}