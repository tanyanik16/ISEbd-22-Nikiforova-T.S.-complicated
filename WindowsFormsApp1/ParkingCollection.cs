using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс-коллекция парковок
    /// </summary>э
    public class ParkingCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, Parking<Vehicle, ClassRectangle>> parkingStages;
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => parkingStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        private readonly char separator = ':';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public ParkingCollection(int pictureWidth, int pictureHeight)
        {
            parkingStages = new Dictionary<string, Parking<Vehicle, ClassRectangle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                return;
            }
            parkingStages.Add(name, new Parking<Vehicle, ClassRectangle>(pictureWidth, pictureHeight));
        }

        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                parkingStages.Remove(name);
            }
        }
        /// <summary>
        /// Доступ к парковке
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Parking<Vehicle, ClassRectangle> this[string ind]
        {
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind];
                }
                else
                {
                    return null;
                }
            }
        }
        public Vehicle this[string ind, int ind2]
        { 
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind][ind2];
                }
                return null;
            }
        }
        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        /// <summary>
        /// Сохранение информации по автомобилям на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine($"ParkingCollection");
                    foreach (var level in parkingStages)
                    {
                        sw.WriteLine($"Station{separator}{level.Key}");
                        ITransport tank = null;
                        for (int i = 0; (tank = level.Value[i]) != null; i++)
                        {
                            if (tank != null)
                            {
                                if (tank.GetType().Name == "BasicTANK")
                                {
                                    sw.Write($"BasicTANK{separator}");
                                }
                                if (tank.GetType().Name == "TANK")
                                {
                                    sw.Write($"TANK{separator}");
                                }
                                //Записываемые параметры
                                sw.WriteLine(tank);
                            }
                        }
                    }
                }
            }
            return true;
        }
        public bool SaveData(string filename, string dockName)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            if (!parkingStages.ContainsKey(dockName))
            {
                return false;
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine($"OneTankStation");
                    sw.WriteLine($"Station{separator}{dockName}");
                    ITransport tank = null;
                    var level = parkingStages[dockName];
                    for (int i = 0; (tank = level[i]) != null; i++)
                    {
                        if (tank != null)
                        {
                            if (tank.GetType().Name == "BasicTANK")
                            {
                                sw.Write($"BasicTANK{separator}");
                            }
                            if (tank.GetType().Name == "TANK")
                            {
                                sw.Write($"TANK{separator}");
                            }
                            //Записываемые параметры
                            sw.WriteLine(tank);
                        }
                    }
                }
            }
            return true;
        }
        public void LoadParkingCollection(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                if (line.Contains("TankStationCollection"))
                {
                    //очищаем записи
                    parkingStages.Clear();
                }
                else
                {
                    //если нет такой записи, то это не те данные
                    throw new FormatException("Неверный формат файла");
                }
                line = sr.ReadLine();
                Vehicle tank = null;
                string key = string.Empty;
                while (line != null && line.Contains("Station"))
                {
                    key = line.Split(separator)[1];
                    parkingStages.Add(key, new Parking<Vehicle, ClassRectangle>(pictureWidth, pictureHeight));

                    line = sr.ReadLine();
                    while (line != null && (line.Contains("BasicTANK") || line.Contains("TANK")))
                    {
                        if (line.Split(separator)[0] == "BasicTANK")
                        {
                            tank = new BasicTANK(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "TANK")
                        {
                            tank = new TANK(line.Split(separator)[1]);
                        }
                        var result = parkingStages[key] + tank;
                        if (!result)
                        {
                            throw new NullReferenceException();
                        }
                        line = sr.ReadLine();
                    }
                }
                
            }
        }
        /// <summary>
        /// Загрузка нформации по автомобилям на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public void LoadParking(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();

                if (line.Contains("OneTankStation")) { }
                else
                {
                    //если нет такой записи, то это не те данные
                    throw new FormatException("Неверный формат файла");
                }
                line = sr.ReadLine();
                Vehicle tank = null;
                string key = string.Empty;
                if (line != null && line.Contains("Station"))
                {
                    key = line.Split(separator)[1];
                    if (parkingStages.ContainsKey(key))
                    {
                        parkingStages[key].ClearPlaces();
                    }
                    else
                    {
                        parkingStages.Add(key, new Parking<Vehicle, ClassRectangle>(pictureWidth, pictureHeight));
                    }

                    line = sr.ReadLine();
                    while (line != null && (line.Contains("BasicTANK") || line.Contains("TANK")))
                    {
                        if (line.Split(separator)[0] == "BasicTANK")
                        {
                            tank = new BasicTANK(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "TANK")
                        {
                            tank = new TANK(line.Split(separator)[1]);
                        }
                        var result = parkingStages[key] + tank;
                        if (!result)
                        {
                             throw new NullReferenceException();
                        }
                        line = sr.ReadLine();
                    }
                }
               
            }
        }
    }      
 }

