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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
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
                    
                    /*dtgInfo.DataSource = db.Tour.Join(db.Hotel,
                        p => p.ID_hotel,
                        c => c.ID_hotel,
                        (p, c) => new
                        {
                            Категория = p.Category,
                            Отель = c.Hotel_name,
                            Стоимость = p.cost,
                            Проезд = p.passage,
                            Проживание = p.residence,
                            Питание = p.food
                        }).ToList();*/

                    var query1 = from Tour in db.Tour
                              join Hotel in db.Hotel on Tour.ID_hotel equals Hotel.ID_hotel
                              join City in db.City on Hotel.ID_city equals City.ID_city
                              join Country in db.Country on City.id_country equals Country.id_country
                              select new
                              {
                                  Номер_тура = Tour.ID_tour,
                                  Страна = Country.country_name,
                                  Город = City.city_name,
                                  Категория = Tour.Category,
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm form1 = new loginForm();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientInfo form1 = new ClientInfo();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbKursachDataSet.Tour". При необходимости она может быть перемещена или удалена.
            this.tourTableAdapter.Fill(this.dbKursachDataSet.Tour);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id_of_tour = idTourUpDown2.Value;
            
            

            ClientPurchase clientPurchase = new ClientPurchase();
            
            clientPurchase.tourLabel.Text = id_of_tour.ToString();
            
            
            this.Hide();
            clientPurchase.StartPosition = FormStartPosition.CenterScreen;
            clientPurchase.Show();
            
        }
    }
}
