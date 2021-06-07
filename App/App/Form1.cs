using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(Draw);
        }

        void Draw(object sender, PaintEventArgs e)
        {
            double x1 = 50, y1 = 50, x2 = 700, y2 = 300;
            int stepen = 15;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            g.DrawEllipse(pen, (int)x1 - 4, (int)y1 - 4, 8, 8);
            g.DrawEllipse(pen, (int)x2 - 4, (int)y2 - 4, 8, 8);
            double rast = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            double ugol = -atg((y2 - y1) / (x2 - x1), stepen);
            double x = x1, y = y1, distance = 0;
            while (distance < rast)
            {
                x += 1 * cos(ugol, stepen);
                y -= 1 * sin(ugol, stepen);
                g.DrawEllipse(pen, (int)x, (int)y, 1, 1);
                distance = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));
            }
        }

        static int factorial(int x)
        {
            if (x <= 0)
                return 1;
            return x * factorial(x - 1);
        }

        double sin(double x, int stepen)
        {
            double sin = 0;
            for (int i = 1; i < stepen + 1; i++)
            {
                sin += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / factorial(2 * i - 1);
            }
            return sin;
        }

        double cos(double x, int stepen)
        {
            double cos = 0;
            for (int i = 1; i < stepen + 1; i++)
            {
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / factorial(2 * i - 2);
            }
            return cos;
        }

        double atg(double x, int stepen)
        {
            double atg = 0;
            for (int i = 1; i < stepen + 1; i++)
            {
                atg += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            }
            return atg;
        }
    }
}