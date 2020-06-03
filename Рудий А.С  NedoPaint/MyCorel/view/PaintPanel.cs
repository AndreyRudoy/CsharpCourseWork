using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCorel
{
    class PaintPanel : Panel
    {
        MouseEventHandler down;
        MouseEventHandler up;
        MouseEventHandler move;
        public new event MouseEventHandler MouseDown
        {
            add
            {
                base.MouseDown -= down;
                base.MouseDown += value;
                down = value;
            }
            remove { }
        }

        public new event MouseEventHandler MouseMove
        {
            add
            {
                base.MouseMove -= move;
                base.MouseMove += value;
                move = value;
            }
            remove { }
        }

        public new event MouseEventHandler MouseUp
        {
            add
            {
                base.MouseUp -= up;
                base.MouseUp += value;
                up = value;
            }
            remove { }
        }
    }
}
