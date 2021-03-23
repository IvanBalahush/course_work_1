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
    public partial class AdminTours : Form
    {
        public AdminTours()
        {
            InitializeComponent();

            try
            {
                
                using (TourFirmContext db = new TourFirmContext())
                {
                    var query1 = from Client in db.Client
                                 select new
                                 {
                                     id_client = Client.ID_client,
                                     login = Client.UserName,
                                     name = Client.name,
                                     age = Client.Age,
                                     admin = Client.isAdmin
                                 };
                    dtgInfo.DataSource = query1.ToList();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            testForm form1 = new testForm();
            
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminInfo form1 = new AdminInfo();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm form1 = new loginForm();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient form1 = new AddClient();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DeleteClient form1 = new DeleteClient();
            form1.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            form1.Show();
        }
    }
}
