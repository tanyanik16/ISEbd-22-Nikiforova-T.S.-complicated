using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class TANK
    {
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private readonly int TankWidth = 205;
        /// <summary>
        /// Высота отрисовки автомобиля
        /// </summary>
        private readonly int TankHeight = 85;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        //
        /// <summary>
        /// Признак наличия переднего спойлера
        /// </summary>
        public bool FrontSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия боковых спойлеров
        /// </summary>
        public bool SideSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия гоночной полосы
        /// </summary>
        public bool RodPantograph { private set; get; }
        public bool SportLine { private set; get; }
        public bool Doors { private set; get; }
        private DopRod Rod;
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
        public TANK(int maxSpeed, float weight, Color mainColor, Color dopColor,
bool rodPantograph, bool doors, int rod)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            RodPantograph = rodPantograph;
            Doors = doors;
            Rod = new DopRod(rod);
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureHeight = height;
            _pictureWidth = width;
        }
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - TankWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0) // ??
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > -50) // ?? 
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - TankHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Red);
            // отрисуем сперва передний спойлер автомобиля (чтобы потом отрисовка
            //автомобиля на него "легла")
            //прямоугльники
            Brush br = new SolidBrush(Color.Black);
            g.DrawRectangle(pen, _startPosX + 80, _startPosY + 80, 60, 20);
            g.DrawRectangle(pen, _startPosX + 40, _startPosY + 100, 150, 20);
            g.FillRectangle(br, _startPosX + 40, _startPosY + 100, 149, 19);
            g.FillRectangle(br, _startPosX + 80, _startPosY + 80, 59, 19);
            if (RodPantograph)
            {
                Pen pen1 = new Pen(Color.Black);
                g.DrawEllipse(pen1, _startPosX + 85, _startPosY + 115, 10, 10);
            }
            //колеса
            Brush brYellow = new SolidBrush(Color.Yellow);
            g.DrawEllipse(pen, _startPosX + 40, _startPosY + 130, 20, 20);
            g.DrawEllipse(pen, _startPosX + 75, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 95, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 115, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 135, _startPosY + 140, 10, 10);
            g.DrawEllipse(pen, _startPosX + 170, _startPosY + 130, 20, 20);
            //гусеница
            Brush dopcolor = new SolidBrush(DopColor);
            g.DrawEllipse(pen, _startPosX + 30, _startPosY + 120, 170, 40);
            g.DrawEllipse(pen, _startPosX + 25, _startPosY + 115, 180, 50);
            Rod.DrawRod(g, brush, _startPosX, _startPosY);
        }
    }
}
