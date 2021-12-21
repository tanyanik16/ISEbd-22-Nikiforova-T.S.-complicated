using NLog;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public  partial class FormParking : Form
    {
       // private  readonly Parking< Vehicle , IDop> parking;
        private readonly ParkingCollection stationCollection;
        private readonly Stack<Vehicle> TankStack;
        private readonly Logger logger;
        public FormParking()
        {
            InitializeComponent();
            stationCollection = new ParkingCollection(pictureBoxParking.Width, pictureBoxParking.Height);
            TankStack = new Stack<Vehicle>();
            logger = LogManager.GetCurrentClassLogger();
            Draw();
          
        }
       
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxParking.SelectedIndex;
            listBoxParking.Items.Clear();
            for (int i = 0; i < stationCollection.Keys.Count; i++)
            {
                listBoxParking.Items.Add(stationCollection.Keys[i]);
            }
            if (listBoxParking.Items.Count > 0 && (index == -1 || index >=
          listBoxParking.Items.Count))
            {
                listBoxParking.SelectedIndex = 0;
            }
            else if (listBoxParking.Items.Count > 0 && index > -1 && index <
          listBoxParking.Items.Count)
            {
                listBoxParking.SelectedIndex = index;
            }
        }
        private void Draw()
        {
            if (listBoxParking.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пунктне будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
                Bitmap bmp = new Bitmap(pictureBoxParking.Width,
                pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                stationCollection[listBoxParking.SelectedItem.ToString()].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }
      
        public  void buttonTank_Click(object sender, EventArgs e)
        {
           
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var tank = new BasicTANK(dialog.Color, 1000, 100);
                    if (stationCollection[listBoxParking.SelectedItem.ToString()] + tank)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Парковка переполнена");
                    }
                }
            
        }

        private void buttonModTank_Click(object sender, EventArgs e)
        {
            var formTankConfig = new FormTankConfig();
            formTankConfig.AddEvent(Addtank);
            formTankConfig.Show();
        }
        private void listBoxParking_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на парковку { listBoxParking.SelectedItem.ToString()}");
            Draw();
        }
        private void buttonZ_Click(object sender, EventArgs e)
        {
            if(listBoxParking.SelectedIndex > -1 && maskedTextBoxParking.Text != "")
            {
                try
                {
                    var tank = stationCollection[listBoxParking.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxParking.Text);
                    if (tank != null)
                    {
                        logger.Info($"Изъят танк {tank} с места { maskedTextBoxParking.Text}");
                        TankStack.Push(tank);
                    }
                    maskedTextBoxParking.Text = "";
                    Draw();
                }
                catch (ParkingNotFoundException ex)
                {
                    logger.Warn("Вызвана ошибка ParkingNotFoundException");
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка изъятии танка с парковки");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Метод добавления машины
        /// </summary>
        /// <param name="car"></param>
        private void Addtank(Vehicle tank)
        {
            if (tank != null && listBoxParking.SelectedIndex > -1)
            {
                try
                {
                    if ((stationCollection[listBoxParking.SelectedItem.ToString()]) + tank)
                    {

                        logger.Info($"Добавлен танк {tank}");
                    }
                    else
                    {
                        MessageBox.Show("танк не удалось поставить");
                    }
                    Draw();
                }
                catch (ParkingOverflowException ex)
                {
                    logger.Warn("Вызвано исключение - переполнение парковок ");
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxParking.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stationCollection.AddParking(textBoxParking.Text);
            logger.Info($"Добавлена парковка {textBoxParking.Text}");
            textBoxParking.Text = "";
            ReloadLevels();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxParking.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку {listBoxParking.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    {
                        stationCollection.DelParking(listBoxParking.SelectedItem.ToString());
                        logger.Info($"Удалена парковка{ listBoxParking.SelectedItem.ToString()}");
                        ReloadLevels();
                        Draw();
                    }
                }
            }
        }
        private void buttonStack_Click(object sender, EventArgs e)
        {
            if (TankStack.Count() > 0)
            {
                FormTank form = new FormTank();
                form.SetTank(TankStack.Pop());
                form.ShowDialog();
            }
            else
            {
                logger.Fatal("В стек занесено неправильное значение");
            }
        }

        private void текущуюПарковкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.SaveData(saveFileDialog1.FileName, listBoxParking.SelectedItem.ToString());
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog1.FileName);
                }
                catch (FormatException ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при сохранении");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void всеПарковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.SaveData(saveFileDialog1.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при сохранении");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void однуПарковкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.LoadParking(openFileDialog1.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog1.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (FileNotFoundException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Место занято", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (NullReferenceException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Место занято", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при загрузке");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void всеПарковкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.LoadParkingCollection(openFileDialog1.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog1.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (FileNotFoundException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Место занято", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Обращение к null объекту", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при загрузке");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
