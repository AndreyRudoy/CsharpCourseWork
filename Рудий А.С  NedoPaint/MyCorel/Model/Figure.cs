using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyCorel
{
    public abstract class Figure
    {
        public int Thickness;
        public Color Color;

        abstract public void Draw(Graphics g);
    }
}
