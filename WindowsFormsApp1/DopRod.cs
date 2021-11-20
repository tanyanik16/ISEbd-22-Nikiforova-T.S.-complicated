using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DopRod
    {
        private DirectionRod rod;
        public int Rod { set => rod = (DirectionRod)value; }
        public void DrawRod(Graphics g, Brush dopcolor, float _startPosX, float _startPosY)
        {
            switch (rod)
            {
                case DirectionRod.One:
                    DrawRodOne(g, dopcolor, _startPosX, _startPosY);
                    break;

                case DirectionRod.Two:
                    DrawRodTwo(g, dopcolor, _startPosX, _startPosY);
                    break;

                case DirectionRod.Three:
                    DrawRodThree(g, dopcolor, _startPosX, _startPosY);
                    break;
            }
        }
        public DopRod(int rod_count)
        {
            Rod = rod_count;
        }
        private void DrawRodOne(Graphics g, Brush dopcolor, float x, float y)
        {
            g.FillEllipse(dopcolor, x + 85, y + 115, 15, 15);
        }
        private void DrawRodTwo(Graphics g, Brush dopcolor, float x, float y)
        {
            DrawRodOne(g, dopcolor, x, y);
            g.FillEllipse(dopcolor, x + 108, y + 115, 15, 15);
        }
        private void DrawRodThree(Graphics g, Brush dopcolor, float x, float y)
        {
            DrawRodTwo(g, dopcolor, x, y);
            g.FillEllipse(dopcolor, x + 130, y + 115, 15, 15);
        }
    }
}
