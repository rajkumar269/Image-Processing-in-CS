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
            OutputImage = SepiaToImage(InputImage, 60);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\SepiaToImage.jpg");


        }

	public Bitmap SepiaToImage(Bitmap Image, int Depth)
        {
            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;
                int Pixel = 0;

                while ((int)Ptr != StopPtr)
                {
                    Ptr[0] = (byte)((.299 * Ptr[2]) + (Ptr[1] * .587) + (Ptr[0] * .114));

                    Pixel = Ptr[2] + (Depth * 2);
                    if (Pixel > 255)
                        Pixel = 255;
                    Ptr[2] = (byte)Pixel;

                    Pixel = Ptr[1] + Depth;
                    if (Pixel > 255)
                        Pixel = 255;
                    Ptr[1] = (byte)Pixel;

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }
	}
}