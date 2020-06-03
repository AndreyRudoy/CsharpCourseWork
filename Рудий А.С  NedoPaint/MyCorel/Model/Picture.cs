using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyCorel
{
    class Picture
    {
        public List<Figure> figures;
        public Graphics g;
        public Control gcontrol;

        public Picture(Graphics z)
        {
            g = z;
            figures = new List<Figure>();
        }

        public void AddFigure(Figure f)
        {
            figures.Add(f);
        }

        public void Draw()
        {
            Image buf = new Bitmap((gcontrol as Control).Width, (gcontrol as Control).Height);
            var gbuf = Graphics.FromImage(buf);
            gbuf.Clear(Color.White);
            foreach (Figure t in figures)
            {
                if (t != null)
                {
                    t.Draw(gbuf);
                }
            }
            g.DrawImageUnscaled(buf, new Point(0, 0));
        }
    }
}
