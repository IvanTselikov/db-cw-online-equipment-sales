using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace OnlineEquipmentSalesApp
{
    public partial class Form3 : Form
    {
        private class KeyValueCbItem
        {
            public int Key { get; }
            public string Value { get; }

            public KeyValueCbItem(int key, string value)
            {
                this.Key = key;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Value;
            }
        }

        public Form3()
        {
            InitializeComponent();

            // заполняем элементы ComboBox
            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetProductTypes();
            FillComboBoxItems(cbProductType, reader);
            // по умолчанию - все товары
            int defaultProductType = AuthorizationForm.DatabaseConnection.GetDefaultProductType();
            cbProductType.SelectedItem = cbProductType.Items
                .Cast<KeyValueCbItem>()
                .Where(item => item.Key == defaultProductType)
                .ToArray()[0];

            reader = AuthorizationForm.DatabaseConnection.GetProductsOfType();
            FillComboBoxItems(cbProductName, reader);

            reader = AuthorizationForm.DatabaseConnection.GetPickupPointsAddresses();
            FillComboBoxItems(cbPickupPoint, reader);

            reader = AuthorizationForm.DatabaseConnection.GetPaymentMethods();
            FillComboBoxItems(cbPaymentMethod, reader);

            // инициализация таблицы с корзиной
            dgvBasket.Columns.Add("type", "Тип товара");
            dgvBasket.Columns.Add("name", "Товар");
            dgvBasket.Columns.Add("countDesired", "Количество");
            dgvBasket.Columns.Add("countAvailable", "Количество на складах, шт.");

            dgvBasket.Rows.Add(null, null, null, null);
            dgvBasket.Rows[0].Selected = true;
        }

        private void FillComboBoxItems(ComboBox cb, SqlDataReader reader)
        {
            cb.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    KeyValueCbItem item = new KeyValueCbItem(Convert.ToInt32(reader.GetValue(0)),
                                                             reader.GetValue(1).ToString());
                    cb.Items.Add(item);
                }
            }
            reader.Close();

            // создаём подсказки для ComboBox для ускорения поиска
            AutoCompleteStringCollection values = new AutoCompleteStringCollection();
            string[] comboboxValues = new string[cb.Items.Count];
            for (int i = 0; i < cb.Items.Count; i++)
            {
                comboboxValues[i] = cb.Items[i].ToString();
            }

            values.AddRange(comboboxValues);
            cb.AutoCompleteCustomSource = values;
            cb.AutoCompleteMode = AutoCompleteMode.Suggest;
            cb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        private int selectedTypeIndex = -1;
        private void cbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            int selectedTypeIndex = cb.SelectedIndex;
            if (selectedTypeIndex != this.selectedTypeIndex)
            {
                // изменяем содержимое ComboBox на список товаров указанного типа
                SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetProductsOfType(
                    (cb.SelectedItem as KeyValueCbItem).Key);
                FillComboBoxItems(cbProductName, reader);
                this.selectedTypeIndex = selectedTypeIndex;
            }
        }


        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (cbProductName.SelectedItem != null)
            {
                // добавляем/изменяем товар в корзине
                int productCode = (cbProductName.SelectedItem as KeyValueCbItem).Key;
                short? pickupPointCode = null;
                if (cbPickupPoint.SelectedItem != null)
                {
                    pickupPointCode = (short)(cbPickupPoint.SelectedItem as KeyValueCbItem).Key;
                }
                int countAvailable = AuthorizationForm.DatabaseConnection.GetPickupPointProductCount(
                    productCode, pickupPointCode
                );

                string typeName = AuthorizationForm.DatabaseConnection.GetTypeOfProduct(productCode);
                string productName = (cbProductName.SelectedItem as KeyValueCbItem).Value;
                int countDesired = (int)nudProductCount.Value;

                dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].SetValues(
                    typeName, productName, countDesired, countAvailable
                );
            }
            else
            {
                MessageBox.Show("Выберите товар указанного типа!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private bool IsNewItem()
        {
            // добавляем новый товар, если выделена пустая строка
            return dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].Cells[0].Value == null;
        }
    }
}
