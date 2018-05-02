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
            OutputImage = GrayscaleTheImage(InputImage);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\GrayscaleTheImage.jpg");           
        }
		public Bitmap GrayscaleTheImage(Bitmap Image)
        {
            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                while ((int)Ptr != StopPtr)
                {
                    *Ptr = (byte)((Ptr[2] * .299) + (Ptr[1] * .587) + (Ptr[0] * .114));
                    Ptr[1] = *Ptr;
                    Ptr[2] = *Ptr;

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }

    }
}
