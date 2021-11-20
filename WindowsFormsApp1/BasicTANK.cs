using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class BasicTANK : Vehicle
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
        public BasicTANK(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
        /// <summary>
        /// Конструкторс изменением размеров машины
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="tankWidth">Ширина отрисовки автомобиля</param>
        /// <param name="tankHeight">Высота отрисовки автомобиля</param>
        protected BasicTANK(int maxSpeed, float weight, Color mainColor, int tankWidth, int
       tankHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.tankWidth = tankWidth;
            this.tankHeight = tankHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            int step = (int)Math.Round(MaxSpeed * 100 / Weight);
            switch (direction)
            {// вправо
                case Direction.Right:
                    if (StartPosition.X + step < _pictureWidth - tankWidth)
                    {
                        StartPosition.X += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (StartPosition.X - step > 40) // ??
                    {
                        StartPosition.X -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (StartPosition.Y - step > 40) // ?? 
                    {
                        StartPosition.Y -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (StartPosition.Y + step < _pictureHeight - tankHeight)
                    {
                        StartPosition.Y += step;
                    }
                    break;
            }
        }
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            //прямоугльники
            Brush br = new SolidBrush(Color.Yellow);
            g.DrawRectangle(pen, StartPosition.X + 80, StartPosition.Y + 10, 60, 20);
            g.DrawRectangle(pen, StartPosition.X + 40, StartPosition.Y + 30, 150, 20);
            g.FillRectangle(br, StartPosition.X + 40, StartPosition.Y + 30, 149, 19);
            g.FillRectangle(br, StartPosition.X + 80, StartPosition.Y + 10, 59, 19);

            //колеса
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.DrawEllipse(pen, StartPosition.X + 40, StartPosition.Y + 60, 20, 20);
            g.DrawEllipse(pen, StartPosition.X + 75, StartPosition.Y + 70, 10, 10);
            g.DrawEllipse(pen, StartPosition.X + 95, StartPosition.Y + 70, 10, 10);
            g.DrawEllipse(pen, StartPosition.X + 115, StartPosition.Y + 70, 10, 10);
            g.DrawEllipse(pen, StartPosition.X + 135, StartPosition.Y + 70, 10, 10);
            g.DrawEllipse(pen, StartPosition.X + 170, StartPosition.Y + 60, 20, 20);
            //гусеница

            g.DrawEllipse(pen, StartPosition.X + 30, StartPosition.Y + 50, 170, 40);
            g.DrawEllipse(pen, StartPosition.X + 25, StartPosition.Y + 45, 180, 50);

        }
    }
}
