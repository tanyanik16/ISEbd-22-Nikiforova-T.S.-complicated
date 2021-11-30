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
        private  readonly Parking< Vehicle , IDop> parking;
        public FormParking()
        {
            InitializeComponent();
            parking = new Parking<Vehicle, IDop>(pictureBoxParking.Width, pictureBoxParking.Height);
            Draw();
          
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }

        public  void buttonTank_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var tank= new BasicTANK(100, 100, dialog.Color);
                if (parking + tank!=-1)
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
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var tank= new TANK(2, 2, dialog.Color, dialogDop.Color, 10,10, 2);
                    if (parking + tank!=-1)
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

        private void buttonZ_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxParking.Text != "")
            {
                var tank = parking - Convert.ToInt32(maskedTextBoxParking.Text);
                Random rand = new Random();

                if (tank != null)
                {
                    FormTank form = new FormTank();
                    tank.SetPosition(rand.Next(150), rand.Next(150), form.Size.Width, form.Size.Height);
                    form.SetTank(tank);
                    form.ShowDialog();
                }
                Draw();
            }
        }
    }
}
