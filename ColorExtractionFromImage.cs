using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WindowsFormsApplication2
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

            InputImage = (Bitmap)Image.FromFile(@"K:\GitProjects\Image Processing\Image.jpg");
            OutputImage = ColorExtractionFromImage(InputImage, 100, Color.ForestGreen, Color.LightBlue);
            OutputImage.Save(@"K:\GitProjects\Image Processing\Output\ColorExtractionFromImage.jpg");
        }

        public Bitmap ColorExtractionFromImage(Bitmap Image, int Threshold, Color ExtractionColor, Color OtherColor)
        {
            BitmapData ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int ExtractionTotalRGB = ExtractionColor.R + ExtractionColor.G + ExtractionColor.B;
                int TotalRGB;

                byte* Ptr = (byte*)ImageData.Scan0.ToPointer();
                int StopPtr = (int)Ptr + ImageData.Stride * ImageData.Height;

                while ((int)Ptr != StopPtr)
                {
                    TotalRGB = Ptr[0] + Ptr[1] + Ptr[2];

                    if (Math.Abs(TotalRGB - ExtractionTotalRGB) >= Threshold)
                    {
                        Ptr[0] = OtherColor.B;
                        Ptr[1] = OtherColor.G;
                        Ptr[2] = OtherColor.R;
                    }

                    Ptr += 3;
                }
            }

            Image.UnlockBits(ImageData);

            return Image;
        }

    }
}
