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
            OutputImage = SetContrastForImage(InputImage, 50);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\SetContrastForImage.jpg");

        }

		   public Bitmap SetContrastForImage(Bitmap Image, sbyte Contrast)
        {
            if (Contrast < -100 || Contrast > 100) return null;

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();

                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                double pixel = 0, contrast = (100.0 + Contrast) / 100.0;

                contrast *= contrast;

                while ((int)Ptr != StopPtr)
                {
                    pixel = Ptr[0] / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    else if (pixel > 255) pixel = 255;
                    Ptr[0] = (byte)pixel;

                    pixel = Ptr[1] / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    else if (pixel > 255) pixel = 255;
                    Ptr[1] = (byte)pixel;

                    pixel = Ptr[2] / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    else if (pixel > 255) pixel = 255;
                    Ptr[2] = (byte)pixel;

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }

    }
}