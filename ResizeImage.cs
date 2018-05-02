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
            OutputImage = ResizeImage(InputImage, 300, 200);
            OutputImage.Save(@"C:\Users\david.rajkumar\Documents\Visual Studio 2015\Projects\David\ImageProcessing\Output\ResizeImage.jpg");

        }

        public static Bitmap ResizeImage(Bitmap Image, int Width, int Height)
        {
            Bitmap NewBitmap = new Bitmap(Width, Height);
            using (Graphics NewGraphics = Graphics.FromImage(NewBitmap))
            {
                
                NewGraphics.CompositingQuality = CompositingQuality.HighSpeed;
                NewGraphics.SmoothingMode = SmoothingMode.HighSpeed;
                NewGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                
                NewGraphics.DrawImage(Image, new System.Drawing.Rectangle(0, 0, Width, Height));
            }
            return NewBitmap;
        }

    }
}