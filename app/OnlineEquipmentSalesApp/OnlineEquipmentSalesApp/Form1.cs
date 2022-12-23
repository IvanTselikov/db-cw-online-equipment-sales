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
        DatabaseConnection databaseConnection = new DatabaseConnection();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.databaseConnection.Login(tbPassword.Text))
            {
                Form2 f2 = new Form2(this);
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
