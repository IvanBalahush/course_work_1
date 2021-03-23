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
    public partial class loginForm : Form
    {
        TourFirmContext context = new TourFirmContext();

        public loginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loginBox.Text = "Введите имя";
            loginBox.ForeColor = Color.Gray;
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

        private void loginBox_MouseEnter(object sender, EventArgs e)
        {
            if (loginBox.Text == "Введите имя")
            {
                loginBox.Text = "";
                loginBox.ForeColor = Color.Black;
            }
        }

        private void loginBox_MouseLeave(object sender, EventArgs e)
        {
            if (loginBox.Text == "")
            {
                loginBox.Text = "Введите имя";
                loginBox.ForeColor = Color.Gray;
            }
        }
        private void registrationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string UserLogin = loginBox.Text;
            string UserPassword = passwordBox.Text;

            using (TourFirmContext db = new TourFirmContext())
            {
                var user = db.Client.ToList();
                bool LogedIn = false;
                foreach(var u in user)
                {
                    if (UserLogin == u.UserName && UserPassword == u.password)
                    {
                        LogedIn = true;
                        switch (u.isAdmin)
                        {
                            case "True":
                                this.Hide();
                                testForm test_form = new testForm();
                                test_form.StartPosition = FormStartPosition.CenterScreen;
                                test_form.Show();
                                break;
                            case "False":
                                this.Hide();
                                ClientForm test_form2 = new ClientForm();
                                test_form2.StartPosition = FormStartPosition.CenterScreen;
                                test_form2.label2.Text = u.name;
                                test_form2.Show();
                                break;
                        }
                    }
                }
                if (LogedIn == false)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                passwordBox.UseSystemPasswordChar = false;
            }
            else
            {
                passwordBox.UseSystemPasswordChar = true;
            }
        }
    }
}
