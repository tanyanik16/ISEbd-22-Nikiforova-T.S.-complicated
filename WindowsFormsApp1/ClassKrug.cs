using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class ClassKrug : IDop
    {
        private DirectionRod dopEnum;
        public Color DopColor { private set; get; }
        public int Wheel { set => dopEnum = (DirectionRod)value; }
        public ClassKrug(int x, Color dopColor)
        {
            Wheel = x;
            DopColor = dopColor;
        }
        public void DrawDop(Graphics g, Color dopColor, float _startPosX, float _startPosY)
        {
            switch (dopEnum)
            {
                case DirectionRod.One:
                    DrawOne(g, dopColor, _startPosX, _startPosY);
                    break;

                case DirectionRod.Two:
                    DrawTwo(g, dopColor, _startPosX, _startPosY);
                    break;

                case DirectionRod.Three:
                    DrawThree(g, dopColor, _startPosX, _startPosY);
                    break;
            }
        }
        public void DrawOne(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, x + 88, y + 45, 10, 10);
        }

        public void DrawTwo(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, x + 88, y + 45, 10, 10);
            g.FillEllipse(brush,x + 108, y + 45, 10, 10);
        }
        public void DrawThree(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, x + 88, y + 45, 10, 10);
            g.FillEllipse(brush, x + 108, y + 45, 10, 10);
            g.FillEllipse(brush, x + 128, y + 45, 10, 10);
        }
    }
}
