using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class ClassRectangle : IDop
    {
        private DirectionRod dopEnum;
        public int Wheel { set => dopEnum = (DirectionRod)value; }
        public ClassRectangle(int x)
        {
            Wheel = x;
        }

        public void DrawDop(Graphics g, Point StartPosition, Color color)
        {
            Brush brush = new SolidBrush(Color.Red);
            Brush brushDop = new SolidBrush(Color.DarkGray);
            Pen pen = new Pen(Color.Black);
            g.FillRectangle(brush, StartPosition.X + 88, StartPosition.Y + 45, 10, 10);
            if (dopEnum == DirectionRod.One || dopEnum == DirectionRod.Two)
            {
                g.FillRectangle(brush, StartPosition.X + 108, StartPosition.Y + 45, 10, 10);
            }
            if (dopEnum == DirectionRod.Two || dopEnum == DirectionRod.Three)
            {
                g.FillRectangle(brush, StartPosition.X + 128, StartPosition.Y + 45, 10, 10);
            }
        }
    }
}
