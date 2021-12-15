using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public  class BasicTANK : Vehicle
    {
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected readonly int tankWidth = 300;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        protected readonly int tankHeight = 100;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public  BasicTANK(Color mainColor, int maxSpeed, int weight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
      
        public override void MoveTransport(Direction direction)
        {
            int step = (int)Math.Round(MaxSpeed * 100 / Weight);
            switch (direction)
            {// вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - tankWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 40) // ??
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 40) // ?? 
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - tankHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            //прямоугльники
            Brush br = new SolidBrush(MainColor);
            g.DrawRectangle(pen, _startPosX + 80, _startPosY + 10, 60, 20);
            g.DrawRectangle(pen, _startPosX + 40, _startPosY + 30, 150, 20);
            g.FillRectangle(br, _startPosX + 40, _startPosY + 30, 149, 19);
            g.FillRectangle(br, _startPosX + 80, _startPosY + 10, 59, 19);

            //колеса
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.DrawEllipse(pen, _startPosX + 40, _startPosY + 60, 20, 20);
            g.DrawEllipse(pen, _startPosX + 75, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 95, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 115, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 135, _startPosY + 70, 10, 10);
            g.DrawEllipse(pen, _startPosX + 170, _startPosY + 60, 20, 20);
            //гусеница

            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 50, 170, 40);
            g.DrawEllipse(pen, _startPosX + 25, _startPosY + 45, 180, 50);

        }
    }
}
