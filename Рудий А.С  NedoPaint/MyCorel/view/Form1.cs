using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCorel
{
    public partial class Form1 : Form
    {
        Picture p;
        bool IsDown;
        Figure temp;
        Graphics g;
        PaintPanel panel;
        Color tcolor;
        int thickness;
        public Form1()
        {
            InitializeComponent();
            p = new Picture(g);
            Paint += new PaintEventHandler(OnPaint);
            panel = new PaintPanel();
            panel.Location = new System.Drawing.Point(96, 41);
            panel.Size = new System.Drawing.Size(631, 510);
            panel.Parent = this;
            panel.BackColor = Color.White;
            g = panel.CreateGraphics();
            panel.MouseDown += panel1_MouseDown_1;
            panel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            p.g = g;
            p.gcontrol = panel;
            panel.Resize += Form1_Resize;
            tcolor = Color.Black;
        }

        void OnPaint(object sender, PaintEventArgs e)
        {
            p.Draw();
        }

        #region кнопка "очистить"
        private void button3_Click(object sender, EventArgs e) //очистить
        {
            p.figures.Clear();
            g.Clear(Color.White);
        }
        #endregion

        void ButtonImages() 
        {
            button1.BackgroundImage = Properties.Resources.Line;
            button2.BackgroundImage = Properties.Resources.Curve;
            button4.BackgroundImage = Properties.Resources.Rect;
            button5.BackgroundImage = Properties.Resources.Ellipse;
        }

        #region Curve
        private void button2_Click(object sender, EventArgs e) //выбираем кривую
        {
            ButtonImages();
            (sender as Button).BackgroundImage = Properties.Resources.CurveSelect;
            panel.MouseDown += DownCurve;
            panel.MouseMove += MoveCurve;
            panel.MouseUp += UpCurve;
        }
        public void UpCurve(object sender, MouseEventArgs e)
        {
            IsDown = false;
            p.AddFigure(temp);
        }
        public void DownCurve(object sender, MouseEventArgs e)
        {
            IsDown = true;
            temp = new Curve(thickness, tcolor);
            (temp as Curve).AddPoint(e.Location);
        }
        public void MoveCurve(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                (temp as Curve).AddPoint(e.Location);
                (temp as Curve).Draw(g);
            }
        }
        #endregion

        #region Line
        private void button1_Click(object sender, EventArgs e) //выбираем линию
        {
            ButtonImages();
            (sender as Button).BackgroundImage = Properties.Resources.LineSelect;
            panel.MouseDown += DownLine;
            panel.MouseMove += MoveLine;
            panel.MouseUp += UpLine;
        }
        public void UpLine(object sender, MouseEventArgs e)
        {
            (temp as Line).p2 = e.Location;
            p.AddFigure(temp);
            IsDown = false;
        }
        public void DownLine(object sender, MouseEventArgs e)
        {
            IsDown = true;
            temp = new Line(thickness, tcolor);
            (temp as Line).p1 = e.Location;
        }
        public void MoveLine(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                (temp as Line).p2 = e.Location;
                p.Draw();
                (temp as Line).Draw(g);
            }
        }
        #endregion

        #region Rect
        private void button4_Click(object sender, EventArgs e) //выбираем прямоугольник
        {
            ButtonImages();
            (sender as Button).BackgroundImage = Properties.Resources.RectSelect;
            panel.MouseDown += DownRect;
            panel.MouseMove += MoveRect;
            panel.MouseUp += UpRect;
        }
        public void UpRect(object sender, MouseEventArgs e)
        {
            (temp as Rect).p2 = e.Location;
            p.AddFigure(temp);
            IsDown = false;
        }
        public void DownRect(object sender, MouseEventArgs e)
        {
            IsDown = true;
            temp = new Rect(thickness, tcolor);
            (temp as Rect).p1 = e.Location;
        }
        public void MoveRect(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                (temp as Rect).p2 = e.Location;
                p.Draw();
                (temp as Rect).Draw(g);
            }
        }
        #endregion

        #region Ellipse
        private void button5_Click(object sender, EventArgs e) //выбираем эллипс
        {
            ButtonImages();
            (sender as Button).BackgroundImage = Properties.Resources.EllipseSelect;
            panel.MouseDown += DownEllipse;
            panel.MouseMove += MoveEllipse;
            panel.MouseUp += UpEllipse;
        }
        public void UpEllipse(object sender, MouseEventArgs e)
        {
            (temp as Ellipse).p2 = e.Location;
            p.AddFigure(temp);
            IsDown = false;
        }
        public void DownEllipse(object sender, MouseEventArgs e)
        {
            IsDown = true;
            temp = new Ellipse(thickness, tcolor);
            (temp as Ellipse).p1 = e.Location;
        }
        public void MoveEllipse(object sender, MouseEventArgs e)
        {
            if (IsDown)
            {
                (temp as Ellipse).p2 = e.Location;
                p.Draw();
                (temp as Ellipse).Draw(g);
            }
        }
        #endregion

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Выберите инструмент рисования");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g = panel.CreateGraphics();
            p.g = g;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            colorDialog1.ShowDialog();
            tcolor = colorDialog1.Color;
            panel1.BackColor = tcolor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool result = Int32.TryParse((sender as Control).Text, out number);
            if (result)
            {
                thickness = number;
            }
            else
            {
                MessageBox.Show("Ошибка ввода. Введите число.");
                (sender as Control).Text = "1";
            }
        }
    }
}
