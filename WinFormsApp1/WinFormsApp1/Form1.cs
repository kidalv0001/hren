using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        double res = 0;
        double g = 9.80665;
        PointF[] points = new PointF[1000];
        double[] time = new double[1000];
        double[] x = new double[1000];
        double[] y = new double[1000];
        Pen coord = new Pen(Color.Black);
        Pen graph = new Pen(Color.Red, 4f);
        float x1, y1;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            float x = Width;
            float y = Height;
            //double k =Convert.ToDouble(textBox1.Text);
            double v0 = Convert.ToDouble(textBox2.Text);
            double alpha = Convert.ToDouble(textBox3.Text);
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red, 3f);

            graphics.DrawLine(coord, x / 3, 0, x / 3, y);
            graphics.DrawLine(coord, 0, y / 2, x, y / 2);
            graphics.TranslateTransform(x / 3, y / 2);
            // time to max height
            double timeMax = v0 * Math.Sin(alpha) / g;

            for (int i = 0; i < time.Length; i++)
            {
                time[i] = 2 * timeMax / 1000 * i;
            }

            for (int i = 0; i < points.Length; i++)
            {
                x1 = x/500*(float)(v0 * Math.Cos(alpha) * time[i]);
                y1 = y/500*(float)(v0 * Math.Sin(alpha) * time[i] - g * Math.Pow(time[i], 2) / 2);
                points[i] = new PointF(x1, y1);
            }

            for (int i = 1; i < 1000; i++)
            {
                graphics.DrawLine(pen, points[i], points[i - 1]);
            }

          //  pictureBox1.Refresh();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*float x = Width;
            float y = Height;
            Graphics g = this.CreateGraphics();
            e.Graphics.DrawLine(coord, x / 3, 0, x / 3, y);
            e.Graphics.DrawLine(coord, 0, y / 2, x, y / 2);
            e.Graphics.TranslateTransform(x / 3, y / 2);
            for (int i = 0; i < x / 20; i++)
            {
                e.Graphics.DrawLine(coord, -200 + i * 20, -3, -200 + i * 20, 3);

            }
            for (int i = 0; i < y / 20; i++)
            {
                e.Graphics.DrawLine(coord, -3, -200 + i * 20, 3, -200 + i * 20);
            }*/
        }
    }
}
