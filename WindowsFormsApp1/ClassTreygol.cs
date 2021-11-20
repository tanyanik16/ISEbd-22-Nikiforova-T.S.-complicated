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
        Color dopColor2;
        public int Wheel { set => dopEnum = (DirectionRod)value; }
        public ClassTreygol(int x, Color dopColor2)
        {
            Wheel = x;
            this.dopColor2 = dopColor2;
        }

        public void DrawDop(Graphics g, Point StartPosition, Color color)
        {
            Brush brush = new SolidBrush(Color.Red);
            PointF One1 = new PointF(StartPosition.X + 83, StartPosition.Y + 55);
            PointF Two1 = new PointF(StartPosition.X + 88, StartPosition.Y + 40);
            PointF Three1 = new PointF(StartPosition.X + 95, StartPosition.Y + 55);
            PointF[] points1 = { One1, Two1, Three1 };
            g.FillPolygon(brush, points1);
            if (dopEnum == DirectionRod.One || dopEnum == DirectionRod.Two)
            {
                PointF One2 = new PointF(StartPosition.X + 113, StartPosition.Y + 55);
                PointF Two2 = new PointF(StartPosition.X + 118, StartPosition.Y + 40);
                PointF Three2 = new PointF(StartPosition.X + 125, StartPosition.Y + 55);
                PointF[] points2 = { One2, Two2, Three2 };
                g.FillPolygon(brush, points2);
            }
            if (dopEnum == DirectionRod.Two || dopEnum == DirectionRod.Three)
            {
                PointF One3 = new PointF(StartPosition.X + 143, StartPosition.Y + 55);
                PointF Two3 = new PointF(StartPosition.X + 148, StartPosition.Y + 40);
                PointF Three3 = new PointF(StartPosition.X + 155, StartPosition.Y + 55);
                PointF[] points3 = { One3, Two3, Three3 };
                g.FillPolygon(brush, points3);
            }
        }
    }
}
