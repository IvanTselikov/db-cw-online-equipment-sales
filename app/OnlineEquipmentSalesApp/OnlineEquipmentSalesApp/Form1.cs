using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineEquipmentSalesApp
{
    public partial class Form1 : Form
    {
        internal DatabaseConnection DatabaseConnection = new DatabaseConnection();

        public Form1()
        {
            InitializeComponent();
            Form2.MainForm = this;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TryToLogIn();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TryToLogIn();
            }
        }

        private void TryToLogIn()
        {
            if (this.DatabaseConnection.Login(tbPassword.Text))
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DatabaseConnection.Logout();
        }
    }
}
