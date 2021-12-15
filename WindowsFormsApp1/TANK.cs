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
        DirectionRod dopEnum;
        public int count_or { private set; get; }
        public int Wheel { set => dopEnum = (DirectionRod)value; }
         IDop idop;
        public bool dulo { private set; get; }
        public bool luk { private set; get; }
        public bool Doors { private set; get; }
        public string Form1 { private set; get; }
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
        public TANK(int maxSpeed, bool dulo, Color MainColor, Color DopCol, bool luk, int numPipes, string Form1, bool doors) :
  base(DopCol, 6, 2)
        {
            this.luk = luk;
            this.dulo = dulo;
           idop = new ClassRectangle(3, DopCol);
            // Wheel = wheel;
            DopColor = DopCol;
            Doors = doors;
            if (Form1 == "ClassTreygol")
            {
                idop = new ClassTreygol(numPipes, DopCol);
            }
            if (Form1 == "ClassRectangle")
            {
                idop = new ClassRectangle(numPipes, DopCol);
            }
            if (Form1 == "ClassKrug")
            {
                idop = new ClassKrug(numPipes, DopCol);
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
            if (dulo)
            {
                g.FillRectangle(d, _startPosX + 140, _startPosY + 15, 80, 10);
            }
            if (luk)
            {
                g.FillRectangle(brushDop, _startPosX + 100, _startPosY, 20, 10);
            }
            if (idop != null)
            {
                idop.DrawDop(g, DopColor, _startPosX, _startPosY);
            }
            if (Doors)
            {
                idop.DrawDop(g, DopColor, _startPosX, _startPosY);
            }
        }

        public void SetOr(IDop or)
        {
            idop = or;
            Form1 = idop.GetType().Name;
        }
        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public void SetCount(int rod_count)
        {
            count_or = rod_count;
        }
    }
}


