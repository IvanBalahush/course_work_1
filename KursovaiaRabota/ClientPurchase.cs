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
    public partial class ClientPurchase : Form
    {
        //decimal costnew = decimal.Parse(label7.Text);
        
        public ClientPurchase()
        {
            
            InitializeComponent();
            //int costing = int.Parse(label7.Text);
            button1.Enabled = false;

            /*try
            {
                int costing = int.Parse(label7.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }*/
            TourFirmContext db = new TourFirmContext();

                var id_of_tour = tourLabel.Text;

                /* var query1 = from Tour in db.Tour
                              join Hotel in db.Hotel on Tour.ID_hotel equals Hotel.ID_hotel
                              join City in db.City on Hotel.ID_city equals City.ID_city
                              join Country in db.Country on City.id_country equals Country.id_country
                              where Tour.ID_tour = int.Parse(hidenUpDown.Value)
                              select new
                              {
                                  Категория = Tour.Category,
                                  Отель = Hotel.Hotel_name,
                                  Стоимость_за_место = Tour.cost,
                                  Страна = Country.country_name,
                                  Город = City.city_name
                              };*/
                //placeLabel.Text =
                /*var a = from Tour in db.Tour
                        join Hotel in db.Hotel on Tour.ID_hotel equals Hotel.ID_hotel
                        join City in db.City on Hotel.ID_city equals City.ID_city
                        join Country in db.Country on City.id_country equals Country.id_country
                        where Tour.ID_tour == Convert.ToInt32(id_of_tour)
                        select new
                        {
                            Страна = Country.country_name
                        };
                 dataGridView1.DataSource = a.ToList();*/
                
                /*var query1 = from Tour in db.Tour
                        join Hotel in db.Hotel on Tour.ID_hotel equals Hotel.ID_hotel
                        join City in db.City on Hotel.ID_city equals City.ID_city
                        join Country in db.Country on City.id_country equals Country.id_country
                        where Tour.ID_tour == 1
                        select new
                        {
                            Страна = Country.country_name,
                            Город = City.city_name,
                            Категория = Tour.Category,
                            Отель = Hotel.Hotel_name,
                            Стоимость = Tour.cost,
                            Проезд = Tour.passage,
                            Проживание = Tour.residence,
                            Питание = Tour.food
                        };
                dataGridView1.DataSource = query1.ToList();
                
                var query5 = from Tour in db.Tour
                             where Tour.ID_tour == 1
                             select new
                             {
                                 cost = Tour.cost
                             };
            textBox1.Text = query5.FirstOrDefault().ToString();*/

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal places = numericUpDown1.Value;
            button1.Enabled = true;
            int tourNo = int.Parse(tourLabel.Text);
            TourFirmContext db = new TourFirmContext();

            
            var query1 = from Tour in db.Tour
                         join Hotel in db.Hotel on Tour.ID_hotel equals Hotel.ID_hotel
                         join City in db.City on Hotel.ID_city equals City.ID_city
                         join Country in db.Country on City.id_country equals Country.id_country
                         where Tour.ID_tour == tourNo
                         select new
                         {
                             Страна = Country.country_name,
                             Город = City.city_name,
                             Категория = Tour.Category,
                             Отель = Hotel.Hotel_name,
                             Стоимость = Tour.cost,
                             Проезд = Tour.passage,
                             Проживание = Tour.residence,
                             Питание = Tour.food
                         };
            dataGridView1.DataSource = query1.ToList();

            var query5 = from Tour in db.Tour
                         where Tour.ID_tour == tourNo
                         select new
                         {
                             cost = Tour.cost * places
                         };
            try
            {
                textBox1.Text = query5.FirstOrDefault().ToString();
                textBox1.Text = textBox1.Text.Remove(0, 9);
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 2, 2);
                textBox1.Text += " UAH";
            }
            catch (Exception)
            {
                MessageBox.Show("Такого тура не существует");
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientForm form1 = new ClientForm();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientCard form1 = new ClientCard();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.label5.Text = textBox1.Text;
            form1.Show();
            this.Hide();
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
    }
}
