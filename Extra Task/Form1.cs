using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
                g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {

                double a = -2;
                double b = 4;
                double c = 5;

                PointF[] y = new PointF[200];
                for (int x = -100; x < 100; x++)
                {
                    double funkcja = a * Math.Pow(x, 2) + b * x + c;
                    y[x + 100] = new PointF(x, (float)funkcja);

                }

                

                g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
                g.ScaleTransform(1, 0.25F);
                g.DrawLines(Pens.Blue, p);
                pictureBox1.Refresh();

               

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;




        }

        


    }
}