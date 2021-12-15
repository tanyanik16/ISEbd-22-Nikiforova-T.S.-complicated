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
    public partial class FormTank : Form
    {
        private ITransport tank;
        public FormTank()
        {
            InitializeComponent();
            comboRod.Items.AddRange(new string[] { "1", "2", "3" });
        }
        public void SetTank(ITransport tank)
        {
            this.tank = tank;
            Draw();

        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTanks.Width, pictureBoxTanks.Height);
            Graphics gr = Graphics.FromImage(bmp);
            tank.DrawTransport(gr);
            pictureBoxTanks.Image = bmp;
        }
        private void Create_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tank = new BasicTANK(Color.Blue, rnd.Next(100, 300), rnd.Next(1000, 2000));
            tank.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTanks.Width, pictureBoxTanks.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    tank.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    tank.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    tank.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    tank.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

        private void buttonCreateModTank_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int count = Convert.ToInt32(comboRod.SelectedItem);
            string Form1 = (checkBoxTriangle.Checked && !checkBoxRectangle.Checked && !checkBoxRound.Checked) ? "ClassRectangle" :
                (!checkBoxTriangle.Checked && checkBoxRectangle.Checked && !checkBoxRound.Checked) ? "ClassTreygol" :
                (!checkBoxTriangle.Checked && !checkBoxRectangle.Checked && checkBoxRound.Checked ? "ClassKrug" : "0");
            tank = new TANK(rnd.Next(100, 300), true, Color.Blue,
           Color.Red, true, count, Form1,true);
            tank.SetPosition(rnd.Next(50, 100), rnd.Next(50, 100), pictureBoxTanks.Width,
           pictureBoxTanks.Height);
            Draw();
        }
    }
}
