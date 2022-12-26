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
            // выводим заказы
            SqlDataReader reader = Form1.DatabaseConnection.GetCustomerOrders();
            FillDgv(dgvOrders, reader);

            // выводим заголовки таблицы с содержимым заказа
            reader = Form1.DatabaseConnection.GetOrderProducts();
            FillDgv(dgvOrderProducts, reader);
        }

        private void FillDgv(DataGridView dgv, SqlDataReader reader)
        {
            if (dgv.Columns.Count < 1)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dgv.Columns.Add(reader.GetName(i), reader.GetName(i));
                }
            }

            dgv.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    dgv.Rows.Add(values);
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
                    SqlDataReader reader = Form1.DatabaseConnection.GetCustomerOrders(dateStart, dateEnd);
                    FillDgv(dgvOrders, reader);

                    this.dateStart = dateStart;
                    this.dateEnd = dateEnd;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private int selectedRowIndex = -1;

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;

            if (selectedRowIndex >= 0 && selectedRowIndex != this.selectedRowIndex)
            {
                DataGridViewRow row = dgvOrders.Rows[selectedRowIndex];

                int orderNumber = (int)row.Cells[0].Value;

                SqlDataReader reader = Form1.DatabaseConnection.GetOrderProducts(orderNumber);
                FillDgv(dgvOrderProducts, reader);

                lblOrderProducts.Text = $"Содержимое заказа №{orderNumber}:";

                this.selectedRowIndex = selectedRowIndex;
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentCell == null)
            {
                MessageBox.Show("Выберите заказ для отмены!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                int rowIndex = dgvOrders.CurrentCell.RowIndex;
                int orderNumber = (int)dgvOrders.Rows[rowIndex].Cells[0].Value;
                DialogResult dialogResult = MessageBox.Show($"Вы действительно хотите отменить заказ №{orderNumber}?",
                                                             "Отмена заказа", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Form1.DatabaseConnection.CancelOrder(orderNumber);
                        MessageBox.Show("Заказ успешно отменён!", "Готово", MessageBoxButtons.OK);

                        // обновляем таблицу с заказами
                        SqlDataReader reader = Form1.DatabaseConnection.GetCustomerOrders();
                        FillDgv(dgvOrders, reader);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Close();
        }
    }
}
