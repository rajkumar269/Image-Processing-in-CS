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
            OutputImage = CreateBiTonalImage(InputImage, (byte.MaxValue * 3) / 2, Color.LightBlue, Color.ForestGreen);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\CreateBiTonalImage.jpg");

        }

        public Bitmap CreateBiTonalImage(Bitmap Image, short ThresholdValue, Color UpperColor, Color LowerColor)
        {
            int MaxVal = 768;

            if (ThresholdValue < 0) return null;
            else if (ThresholdValue > MaxVal) return null;

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int TotalRGB;

                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                while ((int)Ptr != StopPtr)
                {
                    TotalRGB = Ptr[0] + Ptr[1] + Ptr[2];

                    if (TotalRGB <= ThresholdValue)
                    {
                        Ptr[2] = LowerColor.R;
                        Ptr[1] = LowerColor.G;
                        Ptr[0] = LowerColor.B;
                    }
                    else
                    {
                        Ptr[2] = UpperColor.R;
                        Ptr[1] = UpperColor.G;
                        Ptr[0] = UpperColor.B;
                    }

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }


    }
}