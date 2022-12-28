using System;
using System.Windows.Forms;

namespace OnlineEquipmentSalesApp
{
    public partial class AuthorizationForm : Form
    {
        internal static DatabaseConnection DatabaseConnection = new DatabaseConnection();

        public AuthorizationForm()
        {
            InitializeComponent();
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
                MainForm mainForm = new MainForm(this);
                mainForm.Show();
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
