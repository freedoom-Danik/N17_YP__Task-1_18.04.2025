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
        private Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image files (*.BMP, *.JPG, *.PNG)|*.bmp;*.jpg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    pictureBox1.Size = new Size(image.Width, image.Height);

                    bmp = new Bitmap(image);
                    pictureBox1.Image = bmp;
                    g = Graphics.FromImage(bmp);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) => previousPoint = e.Location;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(blackPen, previousPoint, e.Location);
                previousPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Сохранить картинку как ...";
                saveDialog.Filter = "Bitmap File(*.bmp)|*.bmp|JPEG File(*.jpg)|*.jpg|PNG File(*.png)|*.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
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
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color pixel = bmp.GetPixel(x, y);
                        int gray = (pixel.R + pixel.G + pixel.B) / 3;
                        bmp.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                    }
                }
                pictureBox1.Invalidate();
            }
        }
    }
}