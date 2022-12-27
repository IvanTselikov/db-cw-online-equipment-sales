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
    public partial class AuthorizationForm : Form
    {
        internal static DatabaseConnection DatabaseConnection = new DatabaseConnection();

        public AuthorizationForm()
        {
            InitializeComponent();
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
            if (DatabaseConnection.Login(tbServerName.Text, tbPassword.Text))
            {
                MainForm f2 = new MainForm(this);
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильное имя сервера или пароль!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void AuthorizationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DatabaseConnection.Logout();
        }
    }
}
