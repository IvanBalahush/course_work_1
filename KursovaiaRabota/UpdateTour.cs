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
    public partial class UpdateTour : Form
    {
        Tour tournew = new Tour();
        bool isEdit = false;
        public UpdateTour()
        {
            InitializeComponent();
            /*comboBox1.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox7.Enabled = false;
            comboBox5.Enabled = false; 
            comboBox6.Enabled = false;
            button1.Enabled = false;*/

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
                                 Отель = Hotel.Hotel_name,
                                 Стоимость = Tour.cost,
                                 Проезд = Tour.passage,
                                 Проживание = Tour.residence,
                                 Питание = Tour.food
                             };
                dtgInfo.DataSource = query1.ToList();
            }
        }
        public UpdateTour(testForm testForm, TourFirmContext db, Tour tour)
        {
            InitializeComponent();
            //
            tournew = tour;
            isEdit = true;
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
                             Отель = Hotel.Hotel_name,
                             Стоимость = Tour.cost,
                             Проезд = Tour.passage,
                             Проживание = Tour.residence,
                             Питание = Tour.food
                         };
            dtgInfo.DataSource = query1.ToList();
            //
            List<Tour> tours1 = new List<Tour>();
            tours1 = db.Tour.ToList();

            List<string> categories = new List<string>(), passages = new List<string>(),
                 residences = new List<string>(),  foods = new List<string>();

            foreach(Tour item in tours1)
            {
                categories.Add(item.Category);
                passages.Add(item.passage);
                residences.Add(item.passage);
                foods.Add(item.food);
            }

            categories = categories.Distinct().ToList();
            passages = passages.Distinct().ToList();
            residences = residences.Distinct().ToList();
            foods = foods.Distinct().ToList();


            /*comboBox1.Items.AddRange(categories.ToArray());
            comboBox7.Items.AddRange(passages.ToArray());
            comboBox5.Items.AddRange(residences.ToArray());
            comboBox6.Items.AddRange(foods.ToArray());*/

            comboBox1.SelectedItem = tour.Category;
            comboBox7.SelectedItem = tour.passage;
            comboBox5.SelectedItem = tour.residence;
            comboBox6.SelectedItem = tour.food;

            numericUpDown1.Value = (decimal)tour.cost;
            numericUpDown2.Value = (decimal)tour.ID_hotel;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            testForm form1 = new testForm();
            this.Close();
            form1.Show();
            form1.StartPosition = FormStartPosition.CenterScreen;
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
            MessageBox.Show(isEdit.ToString());
            try
            {
                if (isEdit)
                {
                    tournew.Category = comboBox1.SelectedItem.ToString();
                    tournew.cost = numericUpDown1.Value;
                    tournew.ID_hotel = Convert.ToInt32(numericUpDown2.Value);
                    tournew.passage = comboBox7.SelectedItem.ToString();
                    tournew.residence = comboBox5.SelectedItem.ToString();
                    tournew.food = comboBox6.SelectedItem.ToString();


                    MessageBox.Show("Тур успешно изменен");
                    db.SaveChanges();
                    testForm testForm = new testForm();
                    testForm.StartPosition = FormStartPosition.CenterScreen;
                    testForm.Show();
                    this.Close();
                }
                else
                {
                    testForm testForm = new testForm();
                    testForm.StartPosition = FormStartPosition.CenterScreen;
                    testForm.Show();
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        
    }
}
