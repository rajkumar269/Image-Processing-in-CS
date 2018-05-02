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
            OutputImage = JitterImage(InputImage, 15);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\JitterImage.jpg");
        }


        public Bitmap JitterImage(Bitmap Image, short Degree)
        {
            Bitmap TempBmp = (Bitmap)Image.Clone();

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                int BmpWidth = Image.Width;
                int BmpHeight = Image.Height;
                int BmpStride = ImageData.Stride;
                int i = 0, X = 0, Y = 0;
                int Val = 0, XVal = 0, YVal = 0;
                short Half = (short)(Degree / 2);
                Random rand = new Random();

                while ((int)Ptr != StopPtr)
                {
                    X = i % BmpWidth;
                    Y = i / BmpWidth;

                    XVal = X + (rand.Next(Degree) - Half);
                    YVal = Y + (rand.Next(Degree) - Half);

                    if (XVal > 0 && XVal < BmpWidth && YVal > 0 && YVal < BmpHeight)
                    {
                        Val = (YVal * BmpStride) + (XVal * 3);

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