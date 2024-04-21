using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        int X1;
        int Y1;
        Color colorPen;

        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Form(object sender,EventArgs e)
        {
            picture.Location = new Point(5, 5);
            picture.Height = ClientSize.Height-10;
            picture.Width = ClientSize.Width - 125;
            picture.BackColor = Color.White;
            colorPen = Color.Black;

            bitmap = new Bitmap(picture.Width, picture.Height);
            for(int i=0;i<bitmap.Height;i = i + bitmap.Height-1)
            {
                for(int j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(j, i, colorPen);
                }
            }
            for (int i = 0; i < bitmap.Width; i = i + bitmap.Width-1)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, colorPen);
                }
            }
            graphics = Graphics.FromImage(bitmap);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            for (int i = 0; i < bitmap.Height; i = i + bitmap.Height - 1)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    bitmap.SetPixel(j, i, colorPen);
                }
            }
            for (int i = 0; i < bitmap.Width; i = i + bitmap.Width - 1)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, colorPen);
                }
            }   
            picture.Image = bitmap;
        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            X1 = e.X;
            Y1 = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                Satravka(X1, Y1);
            }
        }

        private void Satravka(int x,int y)
        {
            List<Coordinat> pix = new List<Coordinat>();
            pix.Add(new Coordinat(x,y));
            while (pix.Count>0)
            {
                if (bitmap.GetPixel(pix.ElementAt(pix.Count - 1).x + 1, pix.ElementAt(pix.Count - 1).y).ToArgb() != Color.Black.ToArgb())
                {
                    bitmap.SetPixel(pix.ElementAt(pix.Count - 1).x + 1, pix.ElementAt(pix.Count - 1).y, colorPen);
                    picture.Image = bitmap;
                    pix.Add(new Coordinat(pix.ElementAt(pix.Count - 1).x + 1, pix.ElementAt(pix.Count - 1).y));
                    continue;
                }
                if (bitmap.GetPixel(pix.ElementAt(pix.Count - 1).x - 1, pix.ElementAt(pix.Count - 1).y).ToArgb() != Color.Black.ToArgb())
                {
                    bitmap.SetPixel(pix.ElementAt(pix.Count - 1).x - 1, pix.ElementAt(pix.Count - 1).y, colorPen);
                    picture.Image = bitmap;
                    pix.Add(new Coordinat(pix.ElementAt(pix.Count - 1).x - 1, pix.ElementAt(pix.Count - 1).y));
                    continue;
                }
                if (bitmap.GetPixel(pix.ElementAt(pix.Count - 1).x, pix.ElementAt(pix.Count - 1).y + 1).ToArgb() != Color.Black.ToArgb())
                {
                    bitmap.SetPixel(pix.ElementAt(pix.Count - 1).x, pix.ElementAt(pix.Count - 1).y+1, colorPen);
                    picture.Image = bitmap;
                    pix.Add(new Coordinat(pix.ElementAt(pix.Count - 1).x, pix.ElementAt(pix.Count - 1).y+1));
                    continue;
                }
                if (bitmap.GetPixel(pix.ElementAt(pix.Count - 1).x, pix.ElementAt(pix.Count - 1).y - 1).ToArgb() != Color.Black.ToArgb())
                {
                    bitmap.SetPixel(pix.ElementAt(pix.Count - 1).x, pix.ElementAt(pix.Count - 1).y - 1, colorPen);
                    picture.Image = bitmap;
                    pix.Add(new Coordinat(pix.ElementAt(pix.Count - 1).x, pix.ElementAt(pix.Count - 1).y - 1));
                    continue;
                }
                pix.RemoveAt(pix.Count - 1);
            }
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                graphics.DrawLine(new Pen(colorPen, 1), e.X, e.Y, X1, Y1);
                X1 = e.X;
                Y1 = e.Y;
                picture.Image = bitmap;
            }
        }
    }
}