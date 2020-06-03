using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCorel
{
    class Line : Figure
    {
        public Point p1, p2;

        public Line(int thinkness, Color c)
        {
            p1 = new Point(0,0);
            p2 = new Point(0, 0);
            Color = c;
            Thickness = thinkness;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color, Thickness), p1, p2);
        }

    }
}
