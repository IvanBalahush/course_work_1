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
    public partial class ClientInfo : Form
    {
        public ClientInfo()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientForm form1 = new ClientForm();
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
    }
}
