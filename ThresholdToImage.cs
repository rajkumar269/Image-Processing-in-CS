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
            OutputImage = ThresholdToImage(InputImage, 300);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\ThresholdToImage.jpg");

        }

        public Bitmap ThresholdToImage(Bitmap Image, short Threshold)
        {
            int MaxVal = 768;

            if (Threshold < 0) return null;
            else if (Threshold > MaxVal) return null;

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int TotalRGB;

                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                while ((int)Ptr != StopPtr)
                {
                    TotalRGB = Ptr[0] + Ptr[1] + Ptr[2];

                    if (TotalRGB <= Threshold)
                    {
                        Ptr[2] = 0;
                        Ptr[1] = 0;
                        Ptr[0] = 0;
                    }
                    else
                    {
                        Ptr[2] = 255;
                        Ptr[1] = 255;
                        Ptr[0] = 255;
                    }

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }        
	}
}
