using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCorel
{
    class Rect : Figure
    {
        public Point p1, p2;

        public Rect(int thinkness, Color c)
        {
            p1 = new Point(0,0);
            p2 = new Point(0, 0);
            Color = c;
            Thickness = thinkness;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color, Thickness),p1.X, p1.Y, p2.X-p1.X, p2.Y-p1.Y);
        }
    }
}
