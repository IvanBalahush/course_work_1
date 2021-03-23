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
    public partial class DeleteTour : Form
    {
        public DeleteTour()
        {
            InitializeComponent();
        }

        private void DeleteTour_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbKursachDataSet2.Tour". При необходимости она может быть перемещена или удалена.
            this.tourTableAdapter.Fill(this.dbKursachDataSet2.Tour);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            testForm form1 = new testForm();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            this.Close();
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
            try
            {
                int id_of_tour = (int)numericUpDown1.Value;
                
                using (TourFirmContext db = new TourFirmContext())
                {
                    db.Tour.Remove(db.Tour.Single(w => w.ID_tour == id_of_tour));
                    db.SaveChanges();
                }
                MessageBox.Show("Тур с id " + id_of_tour + " успешно удален");
                testForm form1 = new testForm();
                form1.Show();
                form1.StartPosition = FormStartPosition.CenterScreen;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
