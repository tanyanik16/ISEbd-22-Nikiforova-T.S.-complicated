using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public  class TANK : BasicTANK
    {
        public Color DopColor { private set; get; }

        public bool Instr { private set; get; }
        private DirectionRod dopEnum;

        public int Wheel { set => dopEnum = (DirectionRod)value; }
        private IDop idop;
        private bool dulo;
        private bool luk;
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        /// <param name="sportLine">Признак наличия гоночной полосы</param>
        public TANK(int maxSpeed, bool dulo, Color MainColor, Color DopCol, bool luk, int numPipes, int shipState) :
 base(DopCol, 6, 2)
        {
            this.luk = luk;
            this.dulo = dulo;
           // Wheel = wheel;
            DopColor = DopCol;
            switch (shipState)
            {
                case 0:
                    idop = new ClassKrug(numPipes);
                    break;
                case 1:
                    idop = new ClassRectangle(numPipes);
                    break;
                case 2:
                    idop = new ClassTreygol(numPipes, Color.DarkRed);
                    break;
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brushDop = new SolidBrush(DopColor);

            Brush d = new SolidBrush(Color.Green);
            base.DrawTransport(g);
            if (dulo){
            g.FillRectangle(brushDop, StartPosition.X + 140, StartPosition.Y + 15, 80, 10);
            }
            if (luk)
            {
                g.FillRectangle(d, StartPosition.X + 100, StartPosition.Y, 20, 10);
            }
            idop.DrawDop(g, StartPosition, Color.LightGray);
        }
    }
}
