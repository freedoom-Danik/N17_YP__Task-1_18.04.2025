using System;
using System.Drawing;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
        private Point previousPoint = Point.Empty;
        private Bitmap bmp;
        private Pen blackPen = new Pen(Color.Black, 4);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog { Filter = "Image files (*.BMP, *.JPG, *.PNG)|*.bmp;*.jpg;*.png" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = bmp = new Bitmap(dialog.FileName);
                    pictureBox1.Size = bmp.Size;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) => previousPoint = e.Location;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && bmp != null)
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawLine(blackPen, previousPoint, e.Location);
                }
                previousPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog { Filter = "Bitmap File(*.bmp)|*.bmp|JPEG File(*.jpg)|*.jpg|PNG File(*.png)|*.png" })
            {
                if (saveDialog.ShowDialog() == DialogResult.OK && bmp != null)
                {
                    string extension = System.IO.Path.GetExtension(saveDialog.FileName).ToLower();
                    switch (extension)
                    {
                        case ".bmp": bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                        case ".jpg": bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case ".png": bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                for (int x = 0; x < bmp.Width; x++)
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                        bmp.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                    }
                pictureBox1.Invalidate();
            }
        }
    }
}