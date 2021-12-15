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
    public partial class FormTankConfig : Form
    {
        Vehicle tank = null;
        private event Action<Vehicle> eventAddTank;
        public FormTankConfig()
        {
            InitializeComponent();
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            this.panel8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
        }
        /// <summary>
        /// Отрисовать танк
        /// </summary>
        private void DrawTank()
        {
            if (tank != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxConfig.Width, pictureBoxConfig.Height);
                Graphics gr = Graphics.FromImage(bmp);
                tank.SetPosition(5, 5, pictureBoxConfig.Width, pictureBoxConfig.Height);
                tank.DrawTransport(gr);
                pictureBoxConfig.Image = bmp;
            }
        }
        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTank_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddTank == null)
            {
                eventAddTank = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddTank += ev;
            }
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTank_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
                switch (e.Data.GetData(DataFormats.Text).ToString())
                {
                    case "Обычный танк":
                        tank = new BasicTANK(Color.White, (int)numericUpDownVes.Value, (int)numericUpDownMaxSpeed.Value);
                        break;
                    case "Модифицированный танк":
                        tank = new TANK((int)numericUpDownMaxSpeed.Value,
                      checkBoxdulo.Checked, Color.White, Color.Black, checkBoxluk.Checked, 3, "ClassRectangle", true);
                        break;
                }
            DrawTank();
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if (tank != null)
            {
                tank.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawTank();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (tank != null)
            {
                var temp = sender as Panel;
                if (tank is TANK)
                {
                    (tank as TANK).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawTank();
                }
            }
        }
        /// <summary>
        /// Передаем информацию при нажатии на обыч.танк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTank_MouseDown(object sender, MouseEventArgs e)
        {
            labelTank.DoDragDrop(labelTank.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Передаем информацию при нажатии на модиф.танк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void labelModTank_MouseDown(object sender, MouseEventArgs e)
        {
            labelModTank.DoDragDrop(labelModTank.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            Panel temp = sender as Panel;
            labelModTank.DoDragDrop(temp.BackColor, DragDropEffects.Move |
DragDropEffects.Copy);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddTank?.Invoke(tank);
            Close();
        }
        private void LabelCount_MouseDown(object sender, MouseEventArgs e)
        {
            if (tank is TANK t)
            {
                IDop or = null;
                int count = Convert.ToInt32(((Label)sender).Text);
                switch (t.Form1)
                {
                    case "ClassRectangle":
                        or = new ClassRectangle(count, t.DopColor);
                        break;
                    case "ClassKrug":
                        or = new ClassKrug(count, t.DopColor);
                        break;
                    case "ClassTreygol":
                        or = new ClassTreygol(count, t.DopColor);
                        break;
                }
                if (or != null)
                {
                    ((Label)sender).DoDragDrop(or, DragDropEffects.Move | DragDropEffects.Copy);
                    t.SetCount(count);
                }
            }
        }

        private void labelForm_MouseDown(object sender, MouseEventArgs e)
        {
            IDop or = null;
            if (tank is TANK t)
            {
                switch (((Label)sender).Text)
                {
                    case "Квадратные":
                        or = new ClassRectangle(t.count_or, t.DopColor);
                        break;
                    case "Круглые":
                        or = new ClassKrug(t.count_or, t.DopColor);
                        break;
                    case "Треугольные":
                        or = new ClassTreygol(t.count_or, t.DopColor);
                        break;
                }
                if (or != null)
                {
                    ((Label)sender).DoDragDrop(or, DragDropEffects.Move | DragDropEffects.Copy);
                }
            }
        }

        private void labelForm_DragDop(object sender, DragEventArgs e)
        {
            if (tank is TANK t)
            {
                if (e.Data.GetData(typeof(ClassRectangle)) != null)
                {
                    t.SetOr((ClassRectangle)e.Data.GetData(typeof(ClassRectangle)));
                }
                else if (e.Data.GetData(typeof(ClassKrug)) != null)
                {
                    t.SetOr((ClassKrug)e.Data.GetData(typeof(ClassKrug)));
                }
                else if (e.Data.GetData(typeof(ClassTreygol)) != null)
                {
                    t.SetOr((ClassTreygol)e.Data.GetData(typeof(ClassTreygol)));
                }
                DrawTank();
            }
        }

        private void labelForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ClassRectangle)) || e.Data.GetDataPresent(typeof(ClassKrug))
              || e.Data.GetDataPresent(typeof(ClassTreygol)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
