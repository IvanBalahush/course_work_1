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
    public partial class AddTour : Form
    {
        public AddTour()
        {
            InitializeComponent();
            using (TourFirmContext db = new TourFirmContext())
            {
                var query1 = from Hotel in db.Hotel
                             join City in db.City on Hotel.ID_city equals City.ID_city
                             join Country in db.Country on City.id_country equals Country.id_country
                             select new
                             {
                                 id_hotel = Hotel.ID_hotel,
                                 Название = Hotel.Hotel_name,
                                 Город = City.city_name,
                                 Страна = Country.country_name
                             };
                dtgInfo.DataSource = query1.ToList();
            }
        }

        private void AddTour_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbKursachDataSet1.Country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.dbKursachDataSet1.Country);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TourFirmContext db = new TourFirmContext();

            Tour tour = new Tour()
            {
                ID_tour = db.Tour.AsEnumerable().Last(u => u.ID_tour > -1).ID_tour + 1,
                Category = comboBox1.SelectedItem.ToString(),
                cost = (decimal)numericUpDown1.Value,
                ID_hotel = (int)numericUpDown2.Value,
                passage = comboBox7.SelectedItem.ToString(),
                residence = comboBox5.SelectedItem.ToString(),
                food = comboBox6.SelectedItem.ToString()

            };
            db.Tour.Add(tour);
            db.SaveChanges();
            MessageBox.Show("Информация была занесена");
            testForm form1 = new testForm();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
            /*Client client = new Client
            {
                ID_client = context.Client.AsEnumerable().Last(u => u.ID_client > -1).ID_client + 1,
                UserName = usernameBox.Text,
                password = passwordBox.Text,
                name = firstName.Text,
                Age = (int)UserAgeUpDown.Value,
                Client_country = userCountry.Text,
                isAdmin = "False"
            };
            
            context.Client.Add(client);
            context.SaveChanges();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            testForm form1 = new testForm();
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
    }
}
