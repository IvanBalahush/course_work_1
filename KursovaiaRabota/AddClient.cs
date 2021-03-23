using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovaiaRabota
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminTours form1 = new AdminTours();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
        }
        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TourFirmContext db = new TourFirmContext();

            Client client = new Client()
            {
                ID_client = db.Client.AsEnumerable().Last(u => u.ID_client > -1).ID_client + 1,
                /*Category = comboBox1.SelectedItem.ToString(),
                cost = (decimal)numericUpDown1.Value,
                ID_hotel = (int)numericUpDown2.Value,
                passage = comboBox7.SelectedItem.ToString(),
                residence = comboBox5.SelectedItem.ToString(),
                food = comboBox6.SelectedItem.ToString()*/
                UserName = textBox1.Text,
                Client_country = textBox2.Text,
                Age = (int)numericUpDown2.Value,
                name = textBox4.Text,
                 password = textBox3.Text,
                 isAdmin = comboBox6.SelectedItem.ToString()

            };
            db.Client.Add(client);
            db.SaveChanges();
            MessageBox.Show("Информация была занесена");
            AdminTours form1 = new AdminTours();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
        }
    }
}
