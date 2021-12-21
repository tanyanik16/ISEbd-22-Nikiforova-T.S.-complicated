using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WindowsFormsApp1
{
    public class Parking<T, W>
         where T : class, ITransport
         where W : class, IDop
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        private readonly List<T> _places;
        private readonly int _maxCount;

        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 225;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 105;
        public int index = -1;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public Parking(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _places = new List<T>();
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _maxCount = width * height;
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="car">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static bool operator +(Parking<T, W> p, T tank)
        {
            if(p._places.Count >= p._maxCount)
            {
                throw new ParkingOverflowException();
            }
            p._places.Add(tank);
            return true;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся объект</param>
        /// <returns></returns>
        public static T operator -(Parking<T, W> p, int index)
        {
            if (index < -1 || index > p._places.Count)
            {
                throw new ParkingNotFoundException(index);
            }
            T tank = p._places[index];
            p._places.RemoveAt(index);
            return tank;

        }
        public static bool operator >(Parking<T, W> p, int index)
        {
            return p.count_operator() > index;
        }
        public static bool operator <(Parking<T, W> p, int index)
        {
            return p.count_operator() < index;
        }

        public int count_operator()
        {
            int count = 0;
            for (int i = 0; i < _places.Count; ++i)
            {
                if (_places[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; ++i)
            {
                _places[i].SetPosition( i / (pictureHeight / _placeSizeHeight) * _placeSizeWidth , i % (pictureHeight / _placeSizeHeight) *
               _placeSizeHeight + 27, pictureWidth, pictureHeight);
                _places[i].DrawTransport(g);
            }
        }
        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight+20, i *
 _placeSizeWidth + _placeSizeWidth / 2+20, j * _placeSizeHeight+20);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0+20, i * _placeSizeWidth,
               (pictureHeight / _placeSizeHeight) * _placeSizeHeight+20);

            }
        }
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _places.Count)
                {
                    return _places[index];
                }
                return null;
            }
        }
        
        public void ClearPlaces()
        {
            _places.Clear();
        }
    }
}
