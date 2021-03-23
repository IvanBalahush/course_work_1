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
    public partial class testForm : Form
    {
        public testForm()
        {
            InitializeComponent();

            try
            {
                /*using (TourFirmContext firm = new TourFirmContext())
                {
                    dtgInfo.DataSource = firm.Client.Select(p => new
                    {
                        id_client = p.ID_client,
                        userName = p.UserName,
                        firstName = p.name,
                        email = p.email,
                        password = p.password,
                        age = p.Age,
                        id_country = p.id_country,
                        isAdmin = p.isAdmin

                    }
                                                         ).ToList();
                }*/
                using (TourFirmContext db = new TourFirmContext())
                {
                    var query1 = from Tour in db.Tour
                                 join Hotel in db.Hotel on Tour.ID_hotel equals Hotel.ID_hotel
                                 join City in db.City on Hotel.ID_city equals City.ID_city
                                 join Country in db.Country on City.id_country equals Country.id_country
                                 select new
                                 {
                                     Но_тура = Tour.ID_tour,
                                     Страна = Country.country_name,
                                     Город = City.city_name,
                                     Категория = Tour.Category,
                                     id_hotel = Hotel.ID_hotel,
                                     Отель = Hotel.Hotel_name,
                                     Стоимость = Tour.cost,
                                     Проезд = Tour.passage,
                                     Проживание = Tour.residence,
                                     Питание = Tour.food
                                 };
                    dtgInfo.DataSource = query1.ToList();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dtgInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientAdminButton_Click(object sender, EventArgs e)
        {
            AdminTours form1 = new AdminTours();
            this.Hide();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminInfo form1 = new AdminInfo();
            this.Hide();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loginForm form1 = new loginForm();
            this.Hide();
            form1.Show();
            form1.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTour form1 = new AddTour();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DeleteTour form1 = new DeleteTour();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TourFirmContext db = new TourFirmContext();

            string category = dtgInfo[3, dtgInfo.SelectedRows[0].Index].Value.ToString();
            decimal cost = Convert.ToDecimal(dtgInfo[6, dtgInfo.SelectedRows[0].Index].Value);
            int hotel = Convert.ToInt32(dtgInfo[4, dtgInfo.SelectedRows[0].Index].Value);
            string passage = dtgInfo[7, dtgInfo.SelectedRows[0].Index].Value.ToString();
            string residence = dtgInfo[8, dtgInfo.SelectedRows[0].Index].Value.ToString();
            string food = dtgInfo[9, dtgInfo.SelectedRows[0].Index].Value.ToString();

            Tour tour = db.Tour.Single(w => w.Category == category && w.cost == cost && w.ID_hotel == hotel && w.passage == passage && w.residence == residence && w.food == w.food);

            UpdateTour form1 = new UpdateTour(this, db, tour);
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            this.Close();
        }
    }
}
