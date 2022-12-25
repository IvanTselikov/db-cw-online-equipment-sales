using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineEquipmentSalesApp
{
    public partial class Form2 : Form
    {
        private DateTime? dateStart = null, dateEnd = null;

        public static Form1 MainForm;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = MainForm.DatabaseConnection.GetCustomerOrders();
            FillDgw(dgwOrders, reader);

            // получаем заголовки таблицы
            reader = MainForm.DatabaseConnection.GetOrderProducts();
            FillDgw(dgwOrderProducts, reader);
        }

        private void FillDgw(DataGridView dgw, SqlDataReader reader)
        {
            if (dgw.Columns.Count < 1)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dgw.Columns.Add(reader.GetName(i), reader.GetName(i));
                }
            }

            dgw.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    dgw.Rows.Add(values);
                }
            }
            reader.Close();
        }

        private void rbOrdersInDates_CheckedChanged(object sender, EventArgs e)
        {
            pPeriodChoosing.Enabled = (sender as RadioButton).Checked;
        }

        private void cbOrdersStart_CheckedChanged(object sender, EventArgs e)
        {
            dtpOrdersStart.Enabled = (sender as CheckBox).Checked;
        }

        private void cbOrdersEnd_CheckedChanged(object sender, EventArgs e)
        {
            dtpOrdersEnd.Enabled = (sender as CheckBox).Checked;
        }

        private void btnSearchOrders_Click(object sender, EventArgs e)
        {
            DateTime? dateStart = null, dateEnd = null;

            if (rbOrdersInDates.Checked)
            {
                if (cbOrdersStart.Checked)
                {
                    dateStart = dtpOrdersStart.Value;
                }
                if (cbOrdersEnd.Checked)
                {
                    dateEnd = dtpOrdersEnd.Value;
                }
            }
            
            // выполняем запрос, только если параметры поиска поменялись
            if (dateStart != this.dateStart || dateEnd != this.dateEnd)
            {
                try
                {
                    SqlDataReader reader = MainForm.DatabaseConnection.GetCustomerOrders(dateStart, dateEnd);
                    FillDgw(dgwOrders, reader);

                    this.dateStart = dateStart;
                    this.dateEnd = dateEnd;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private int selectedRow = -1;

        private void dgwOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;

            if (selectedRow >= 0 && selectedRow != this.selectedRow)
            {
                DataGridViewRow row = dgwOrders.Rows[selectedRow];

                int orderNumber = (int)row.Cells[0].Value;

                SqlDataReader reader = MainForm.DatabaseConnection.GetOrderProducts(orderNumber);
                FillDgw(dgwOrderProducts, reader);

                this.selectedRow = selectedRow;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Close();
        }
    }
}
