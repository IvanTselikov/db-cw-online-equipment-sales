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
        private enum OrderDisplayingModes
        {
            All,
            From,
            To,
            FromTo
        }

        private OrderDisplayingModes currentMode;

        private DateTime? dateStart = null, dateEnd = null;

        public static Form1 MainForm;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitOrdersDwg();
        }

        private void InitOrdersDwg()
        {
            SqlDataReader reader = MainForm.DatabaseConnection.GetCustomerOrders();

            dgwOrders.Columns.Add(reader.GetName(0), reader.GetName(0));
            dgwOrders.Columns.Add(reader.GetName(1), reader.GetName(1));
            dgwOrders.Columns.Add(reader.GetName(2), reader.GetName(2));
            dgwOrders.Columns.Add(reader.GetName(3), reader.GetName(3));
            dgwOrders.Columns.Add(reader.GetName(4), reader.GetName(4));
            dgwOrders.Columns.Add(reader.GetName(5), reader.GetName(5));
            dgwOrders.Columns.Add(reader.GetName(6), reader.GetName(6));
            dgwOrders.Columns.Add(reader.GetName(7), reader.GetName(7));
            dgwOrders.Columns.Add(reader.GetName(8), reader.GetName(8));

            InsertRowsIntoOrdersDwg(reader);

            currentMode = OrderDisplayingModes.All;
        }

        private void InsertRowsIntoOrdersDwg(SqlDataReader reader)
        {
            dgwOrders.Rows.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dgwOrders.Rows.Add(reader.GetValue(0),
                                       reader.GetValue(1),
                                       reader.GetValue(2),
                                       reader.GetValue(3),
                                       reader.GetValue(4),
                                       reader.GetValue(5),
                                       reader.GetValue(6),
                                       reader.GetValue(7),
                                       reader.GetValue(8));
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
                    InsertRowsIntoOrdersDwg(reader);
                    this.dateStart = dateStart;
                    this.dateEnd = dateEnd;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Close();
        }
    }
}
