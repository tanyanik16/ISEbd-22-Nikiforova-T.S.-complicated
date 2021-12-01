using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FormParking()
        {
            InitializeComponent();
            stationCollection = new ParkingCollection(pictureBoxParking.Width, pictureBoxParking.Height);
            TankStack = new Stack<Vehicle>();
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
            if (listBoxParking.SelectedIndex > -1)
            {
                
                    ColorDialog dialog = new ColorDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ColorDialog dialogDop = new ColorDialog();
                        if (dialogDop.ShowDialog() == DialogResult.OK)
                        {
                            var tank = new TANK(100, true, dialog.Color,
                           dialogDop.Color, true, 2, 2);
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
                
            }
        }
        private void listBoxParking_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
        private void buttonZ_Click(object sender, EventArgs e)
        {
            if(listBoxParking.SelectedIndex > -1 && maskedTextBoxParking.Text != "")
            {
                var tank = stationCollection[listBoxParking.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxParking.Text);
                if (tank != null)
                {
                    TankStack.Push(tank);
                }
                maskedTextBoxParking.Text = "";
                Draw();
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
                MessageBox.Show("Стек пуст");
            }
        }
    }
}
