using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class TANK : BasicTANK
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
        public TANK(int maxSpeed, float weight, Color mainColor, Color DopColor, int wheel, int numPipes, int shipState) :
 base(maxSpeed, weight, Color.LightGray, 300, 100)
        {
            this.luk = luk;
            this.dulo = dulo;
            Wheel = wheel;
            DopColor = DopColor;
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
            Brush brush = new SolidBrush(Color.Red);
            base.DrawTransport(g);


            idop.DrawDop(g, StartPosition, Color.LightGray);
            //if (dulo)

            //дуло
            Brush dulo = new SolidBrush(Color.Green);
            g.FillRectangle(dulo, StartPosition.X + 140, StartPosition.Y + 15, 80, 10);

            // if (luk)

            // люк
            Brush luk = new SolidBrush(Color.Blue);
            g.FillRectangle(luk, StartPosition.X + 100, StartPosition.Y, 20, 10);

        }
    }
}
