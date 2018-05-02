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
            OutputImage = SetBrightnessForImage(InputImage, 50);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\SetBrightnessForImage.jpg");        }

        public Bitmap SetBrightnessForImage(Bitmap Image, byte Brightness)
        {
            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int stopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                int val = 0;

                while ((int)Ptr != stopPtr)
                {
                    val = Ptr[2] + Brightness;
                    if (val < 0) val = 0;
                    else if (val > 255) val = 255;
                    Ptr[2] = (byte)val;

                    val = Ptr[1] + Brightness;
                    if (val < 0) val = 0;
                    else if (val > 255) val = 255;
                    Ptr[1] = (byte)val;

                    val = Ptr[0] + Brightness;
                    if (val < 0) val = 0;
                    else if (val > 255) val = 255;
                    Ptr[0] = (byte)val;

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }

    }
}