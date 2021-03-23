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
    public partial class Form1 : Form
    {
        TourFirmContext context = new TourFirmContext();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            usernameBox.Text = "Введите логин";
            usernameBox.ForeColor = Color.Gray;

            firstName.Text = "Введите имя";
            firstName.ForeColor = Color.Gray;
            userCountry.Text = "Введите страну";
            userCountry.ForeColor = Color.Gray;
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
        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        //textBoxes' placeholder
        private void usernameBox_Enter(object sender, EventArgs e)
        {
            if (usernameBox.Text == "Введите логин")
            {
                usernameBox.Text = "";
                usernameBox.ForeColor = Color.Black;
            }
        }

        private void usernameBox_Leave(object sender, EventArgs e)
        {
            if (usernameBox.Text == "")
            {
                usernameBox.Text = "Введите логин";
                usernameBox.ForeColor = Color.Gray;
            }
        }


        private void firstName_Enter(object sender, EventArgs e)
        {
            if (firstName.Text == "Введите имя")
            {
                firstName.Text = "";
                firstName.ForeColor = Color.Black;
            }
        }

        private void firstName_Leave(object sender, EventArgs e)
        {
            if (firstName.Text == "")
            {
                firstName.Text = "Введите имя";
                firstName.ForeColor = Color.Gray;
            }
        }

        

        private void userCountry_Enter(object sender, EventArgs e)
        {
            if (userCountry.Text == "Введите страну")
            {
                userCountry.Text = "";
                userCountry.ForeColor = Color.Black;
            }
        }

        private void userCountry_Leave(object sender, EventArgs e)
        {
            if (userCountry.Text == "")
            {
                userCountry.Text = "Введите страну";
                userCountry.ForeColor = Color.Gray;
            }
        }
        
        private void registrationLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
        }
        public void newUser()
        {
            Client client = new Client
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
            context.SaveChanges();
            this.Hide();
            ClientForm testForm = new ClientForm();
            testForm.StartPosition = FormStartPosition.CenterScreen;
            testForm.label2.Text = firstName.Text;
            testForm.Show();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = usernameBox.Text;
            string password = passwordBox.Text;
            string passwordAgain = passwordAgainBox.Text;
            if ((password != passwordAgain))
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен быть больше 6-ти символов");
            }
            else
            {
                newUser();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
