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
            OutputImage = CreateGammaImage(InputImage, 2, 1, 1);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\CreateGammaImage.jpg");
        }
		
        public Bitmap CreateGammaImage(Bitmap Image, double RedComponent, double GreenComponent, double BlueComponent)
        {
            if (RedComponent < 0.2 || RedComponent > 5) return null;
            if (GreenComponent < 0.2 || GreenComponent > 5) return null;
            if (BlueComponent < 0.2 || BlueComponent > 5) return null;

            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                while ((int)Ptr != StopPtr)
                {
                    Ptr[0] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(Ptr[0] / 255.0, 1.0 / BlueComponent)) + 0.5));
                    Ptr[1] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(Ptr[1] / 255.0, 1.0 / GreenComponent)) + 0.5));
                    Ptr[2] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(Ptr[2] / 255.0, 1.0 / RedComponent)) + 0.5));

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }
    }
}