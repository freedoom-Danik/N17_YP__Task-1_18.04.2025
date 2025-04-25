using System;
using System.Drawing;
using System.Windows.Forms;
namespace task1
{
   public partial class Form1 : Form
    {
        private Point pP = Point.Empty;
        private Bitmap bmp;
        private Pen bP = new Pen(Color.Black, 4);
        public Form1()
        {
            InitializeComponent();
        }
        private void b1_C(object s, EventArgs e)
        {
            using (OpenFileDialog oD = new OpenFileDialog { Filter = "Image files (*.BMP, *.JPG, *.PNG)|*.bmp;*.jpg;*.png" })
            {
                if (oD.ShowDialog() == DialogResult.OK)
                {
                    pB.Image = bmp = new Bitmap(oD.FileName);
                    pB.Size = bmp.Size;
                }
            }
        }
        private void pB_MD(object s, MouseEventArgs e) => pP = e.Location; private void pB_MM(object s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && bmp != null)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawLine(bP, pP, e.Location);
                }
                pP = e.Location;
                pB.Invalidate();
            }
        }
        private void b2_C(object s, EventArgs e)
        {
            using (SaveFileDialog sD = new SaveFileDialog { Filter = "PNG File (*.png)|*.png" })
            {
                if (sD.ShowDialog() == DialogResult.OK && bmp != null)
                {
                    bmp.Save(sD.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
        private void b3_C(object s, EventArgs e)
        {
            if (bmp != null)
            {
                for (int x = 0; x < bmp.Width; x++)
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color c = bmp.GetPixel(x, y);
                        int g = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                        bmp.SetPixel(x, y, Color.FromArgb(255, g, g, g));
                    }
                pB.Invalidate();
            }
        }
    }
}