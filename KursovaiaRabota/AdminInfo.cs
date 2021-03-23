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
    public partial class AdminInfo : Form
    {
        
        public AdminInfo()
        {
            InitializeComponent();
        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            testForm form1 = new testForm();
            this.Hide();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void clientAdminButton_Click(object sender, EventArgs e)
        {
            AdminTours form1 = new AdminTours();
            this.Hide();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loginForm form1 = new loginForm();
            this.Hide();
            form1.StartPosition = FormStartPosition.CenterScreen;
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
