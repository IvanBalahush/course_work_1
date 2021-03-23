﻿using System;
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
    public partial class DeleteClient : Form
    {
        public DeleteClient()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            AdminTours form1 = new AdminTours();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id_of_client = (int)numericUpDown1.Value;

                using (TourFirmContext db = new TourFirmContext())
                {
                    db.Client.Remove(db.Client.Single(w => w.ID_client == id_of_client));
                    db.SaveChanges();
                }
                MessageBox.Show("Клиент с id " + id_of_client + " успешно удален");
                AdminTours form1 = new AdminTours();
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
