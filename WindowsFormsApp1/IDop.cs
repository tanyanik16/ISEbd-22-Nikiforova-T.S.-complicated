using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public interface IDop
    {
        int Wheel { set; }
        void DrawDop(Graphics g, Color dopColor, float x, float y);
    }
}
