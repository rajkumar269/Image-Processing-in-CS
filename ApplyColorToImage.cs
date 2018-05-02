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
            OutputImage = ApplyColorToImage(InputImage, Color.LawnGreen);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\ApplyColorToImage.jpg");            
		}

        public Bitmap ApplyColorToImage(Bitmap Image, Color ColorName)
        {
            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                int RetVal;

                while ((int)Ptr != StopPtr)
                {
                    RetVal = Ptr[2] + ColorName.R;
                    if (RetVal < 0) RetVal = 0;
                    else if (RetVal > 255) RetVal = 255;
                    Ptr[2] = (byte)RetVal;

                    RetVal = Ptr[1] + ColorName.G;
                    if (RetVal < 0) RetVal = 0;
                    else if (RetVal > 255) RetVal = 255;
                    Ptr[1] = (byte)RetVal;

                    RetVal = Ptr[0] + ColorName.B;
                    if (RetVal < 0) RetVal = 0;
                    else if (RetVal > 255) RetVal = 255;
                    Ptr[0] = (byte)RetVal;

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }

    }
}