using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class ClassTreygol : IDop
    {
        private DirectionRod dopEnum;
        public Color DopColor { private set; get; }
        public int Wheel { set => dopEnum = (DirectionRod)value; }
       
        public ClassTreygol(int x, Color dopColor)
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
            Brush brushDop2 = Brushes.Red;
         
            PointF One1 = new PointF(x + 83, y + 55);
            PointF Two1 = new PointF(x + 88, y + 40);
            PointF Three1 = new PointF(x + 95, y + 55);
            PointF[] points1 = { One1, Two1, Three1 };
            g.FillPolygon(brushDop2, points1);
        }

        public void DrawTwo(Graphics g, Color dopColor, float x, float y)
        {
            Brush brushDop2 = Brushes.Red;
            PointF One1 = new PointF(x + 83, y + 55);
            PointF Two1 = new PointF(x + 88, y + 40);
            PointF Three1 = new PointF(x + 95, y + 55);
            PointF[] points1 = { One1, Two1, Three1 };
            g.FillPolygon(brushDop2, points1);

            Brush brush = new SolidBrush(Color.Red);
            PointF One2 = new PointF(x + 113, y + 55);
            PointF Two2 = new PointF(x+ 118, y + 40);
            PointF Three2 = new PointF(x + 125, y + 55);
            PointF[] points2 = { One2, Two2, Three2 };
            g.FillPolygon(brush, points2);
        }
        public void DrawThree(Graphics g, Color dopColor, float x, float y)
        {
            Brush brushDop2 = Brushes.Red;
            PointF One1 = new PointF(x + 83, y + 55);
            PointF Two1 = new PointF(x + 88, y + 40);
            PointF Three1 = new PointF(x + 95, y + 55);
            PointF[] points1 = { One1, Two1, Three1 };
            g.FillPolygon(brushDop2, points1);

            Brush brush = new SolidBrush(Color.Red);
            PointF One2 = new PointF(x + 113, y + 55);
            PointF Two2 = new PointF(x + 118, y + 40);
            PointF Three2 = new PointF(x + 125, y + 55);
            PointF[] points2 = { One2, Two2, Three2 };
            g.FillPolygon(brush, points2);

            PointF One3 = new PointF(x + 143, y + 55);
            PointF Two3 = new PointF(x + 148, y + 40);
            PointF Three3 = new PointF(x + 155, y + 55);
            PointF[] points3 = { One3, Two3, Three3 };
            g.FillPolygon(brush, points3);
        }
    }
}
