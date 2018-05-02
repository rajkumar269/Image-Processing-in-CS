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
            OutputImage = SubstitutionColorInImage(InputImage, 50, Color.ForestGreen, Color.Brown);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\SubstitutionColorInImage.jpg");

        }

        public Bitmap SubstitutionColorInImage( Bitmap Image, int threshold, Color sourceColor, Color newColor)
        {
            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;
                int SrcTotalRGB = sourceColor.R + sourceColor.G + sourceColor.B;
                int TotalRGB;

                while ((int)Ptr != StopPtr)
                {
                    TotalRGB = Ptr[0] + Ptr[1] + Ptr[2];

                    if (Math.Abs(SrcTotalRGB - TotalRGB) < threshold)
                    {
                        Ptr[0] = newColor.B;
                        Ptr[1] = newColor.G;
                        Ptr[2] = newColor.R;
                    }

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }

    }
}