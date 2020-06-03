using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCorel
{
    public class Curve : Figure
    {
        List<Point> points = new List<Point>();


        public override void Draw(Graphics g)
        {
            for (int i = 1; i < points.Count; i++)
            {
                g.DrawLine(new Pen(Color, Thickness), points[i-1], points[i]); //исправить цвет толщину
            }
        }

        public Curve(int thikness, Color c)
        {
            this.Thickness = thikness;
            Color = c;
        }

        public void AddPoint(Point p)
        {
            points.Add(p);
        }
    }
}
