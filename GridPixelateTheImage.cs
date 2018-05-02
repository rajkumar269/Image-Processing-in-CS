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
            OutputImage = GridPixelateTheImage(InputImage, new Size(15, 15));
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\GridPixelateTheImage.jpg");
  
        }
        public Bitmap GridPixelateTheImage(Bitmap Image, Size PixelSize)
        {
            Bitmap TempBmp = (Bitmap)Image.Clone();

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData TempBmpData = TempBmp.LockBits(new Rectangle(0, 0, TempBmp.Width, TempBmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                byte* TempPtr = (byte*)TempBmpData.Scan0.ToPointer();

                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                int Val = 0;
                int i = 0, X = 0, Y = 0;
                int BmpStride = ImageData.Stride;
                int BmpWidth = Image.Width;
                int BmpHeight = Image.Height;
                int SqrWidth = PixelSize.Width;
                int SqrHeight = PixelSize.Height;
                int XVal = 0, YVal = 0;

                while ((int)Ptr != StopPtr)
                {
                    X = i % BmpWidth;
                    Y = i / BmpWidth;

                    XVal = (SqrWidth - X % SqrWidth);
                    YVal = (SqrHeight - Y % SqrHeight);

                    if (XVal == SqrWidth)
                        XVal = X + -X;
                    else if (XVal > 0 && XVal < BmpWidth)
                        XVal = X + XVal;

                    if (YVal == SqrHeight)
                        YVal = Y + -Y;
                    else if (YVal > 0 && YVal < BmpHeight)
                        YVal = Y + YVal;

                    if (XVal >= 0 && XVal < BmpWidth && YVal >= 0 && YVal < BmpHeight)
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