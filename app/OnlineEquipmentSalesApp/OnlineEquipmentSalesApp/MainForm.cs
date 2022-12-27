using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineEquipmentSalesApp
{
    public partial class MainForm : Form
    {
        private DateTime? dateStart = null, dateEnd = null;
        private AuthorizationForm parent;

        public MainForm(AuthorizationForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private class KeyValueComboBoxItem
        {
            public int Key { get; }
            public string Value { get; }

            public KeyValueComboBoxItem(int key, string value)
            {
                this.Key = key;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Value;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // для вкладки "Просмотр заказов"
            // выводим заказы
            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCustomerOrders();
            FillDgv(dgvOrders, reader);

            // выводим заголовки таблицы с содержимым заказа
            reader = AuthorizationForm.DatabaseConnection.GetOrderProducts();
            FillDgv(dgvOrderProducts, reader);


            // для вкладки "Поиск товаров по характеристикам"
            // заполняем элементы ComboBox
            reader = AuthorizationForm.DatabaseConnection.GetProductTypes();
            FillComboBoxItems(cbProductTypeSearch, reader);
            // по умолчанию - все товары
            short defaultProductType = AuthorizationForm.DatabaseConnection.GetDefaultProductType();
            cbProductTypeSearch.SelectedItem = cbProductTypeSearch.Items
                .Cast<KeyValueComboBoxItem>()
                .Where(item => item.Key == defaultProductType)
                .ToArray()[0];
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

        private void FillComboBoxItems(ComboBox cb, SqlDataReader reader)
        {
            KeyValueComboBoxItem selectedItem = cb.SelectedItem as KeyValueComboBoxItem;
            cb.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    KeyValueComboBoxItem item = new KeyValueComboBoxItem(Convert.ToInt32(reader.GetValue(0)),
                                                             reader.GetValue(1).ToString());
                    cb.Items.Add(item);
                }
            }
            reader.Close();

            if (selectedItem != null)
            {
                // чтобы выбранный элемент не пришлось выбирать заново
                KeyValueComboBoxItem[] copiesOfSelected = cb.Items.Cast<KeyValueComboBoxItem>()
                                                          .Where(item => item.Key == selectedItem.Key)
                                                          .ToArray();
                if (copiesOfSelected.Length > 0)
                {
                    cb.SelectedItem = copiesOfSelected[0];
                }
            }

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
                    SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCustomerOrders(dateStart, dateEnd);
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

                SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetOrderProducts(orderNumber);
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
                        AuthorizationForm.DatabaseConnection.CancelOrder(orderNumber);
                        MessageBox.Show("Заказ успешно отменён!", "Готово", MessageBoxButtons.OK);

                        // обновляем таблицу с заказами
                        SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCustomerOrders();
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

        private int selectedTypeSearchIndex = -1;

        private void cbProductTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            int selectedTypeIndex = cb.SelectedIndex;
            if (selectedTypeIndex != this.selectedTypeSearchIndex)
            {
                // изменяем содержимое ComboBox на список характеристик указанного типа
                SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCharacteristicsOfType(
                    Convert.ToInt16((cb.SelectedItem as KeyValueComboBoxItem).Key));
                FillComboBoxItems(cbCharacteristicName, reader);
                this.selectedTypeSearchIndex = selectedTypeIndex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbProductTypeSearch.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип товара!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (cbCharacteristicName.SelectedItem == null)
            {
                MessageBox.Show("Выберите характеристику, соответствующую указанному типу товара!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                short productTypeCode = (short)(cbProductTypeSearch.SelectedItem as KeyValueComboBoxItem).Key;
                short characteristicCode = (short)(cbCharacteristicName.SelectedItem as KeyValueComboBoxItem).Key;
                byte dataTypeCode = AuthorizationForm.DatabaseConnection.GetCharacteristicDataType(characteristicCode);
                object characteristicValue = null;
                switch (dataTypeCode)
                {
                    case 3:
                        if (double.TryParse(tbCharacteristicValue.Text.Replace(".", ","), out double valueDouble))
                            characteristicValue = valueDouble;
                        else
                            MessageBox.Show("Ожидалось вещественное число!", "Ошибка", MessageBoxButtons.OK);
                        break;
                    case 4:
                        if (short.TryParse(tbCharacteristicValue.Text, out short valueShort))
                            characteristicValue = valueShort;
                        else
                            MessageBox.Show("Ожидалось целое число!", "Ошибка", MessageBoxButtons.OK);
                        break;
                    case 5:
                        if (int.TryParse(tbCharacteristicValue.Text, out int valueInt))
                            characteristicValue = valueInt;
                        else
                            MessageBox.Show("Ожидалось целое число!", "Ошибка", MessageBoxButtons.OK);
                        break;
                    case 1:
                    case 2:
                        characteristicValue = tbCharacteristicValue.Text;
                        break;
                };
                if (characteristicValue != null)
                {
                    SqlDataReader reader = AuthorizationForm.DatabaseConnection.FindProductsByCharacteristic(
                        productTypeCode, characteristicCode, characteristicValue
                    );
                    FillDgv(dgvProductByCharacteristics, reader);
                    if (dgvProductByCharacteristics.Rows.Count < 1)
                    {
                        MessageBox.Show("Ничего не найдено!", "Результат поиска", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }
    }
}
