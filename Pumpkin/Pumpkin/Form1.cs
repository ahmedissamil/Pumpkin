using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pumpkin
{
    public partial class Form1 : Form
    {
        Bitmap off;
        public int f = 0;
        public int pos = 0; 
        Random x1 = new Random();
        Random y1 = new Random();
        List<pum> p = new List<pum>();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_paint;
            this.MouseDown += Form1_MouseDown;
            this.Load += Form1_loade;
            Timer t = new Timer();
            t.Start();
            t.Tick += T_Tick;
            t.Interval = 1000;
        }
        private void T_Tick(object sender, EventArgs e)
        {
            int x = x1.Next(0, ClientSize.Width);
            int y = y1.Next(0, ClientSize.Height);
            pum pnn = new pum();
            pnn.x = x;
            pnn.y = y;
            pnn.h = 50;
            pnn.w = 50;
            pnn.im = new Bitmap ("image_1.bmp");
            p.Add(pnn);
            if(f == 1)
            {
                p[pos].im = new Bitmap("image_2.bmp");
                if (p[pos].h != 0)
                {
                    p[pos].h = p[pos].h - 10;
                    p[pos].w = p[pos].w - 10;
                }
            }
            Dubblebuffer(CreateGraphics());
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].x < e.X && p[i].x+30 > e.X)
                {
                    f = 1;
                    pos = i;
                }
            }
        }
        private void Form1_loade(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        void Dubblebuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drowscene(g2);
            g.DrawImage(off, 0, 0);
        }
        private void Form1_paint(object sender, PaintEventArgs e)
        {
            Dubblebuffer(e.Graphics);
        }
        void Drowscene(Graphics g)
        {
            g.Clear(Color.Black);
            for (int i = 0; i < p.Count; i++)
            {
                g.DrawImage(p[i].im, p[i].x, p[i].y, p[i].w, p[i].h);
            }
        }
    }
    class pum
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public Bitmap im;
    }
}
