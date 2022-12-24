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
        public static Form1 MainForm;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object age = reader.GetValue(2);
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
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Close();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            
        }
    }
}
