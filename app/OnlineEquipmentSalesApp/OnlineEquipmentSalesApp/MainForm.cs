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

        private string productCodeKey = "code",
                       productNameKey = "name",
                       productCountDesiredKey = "countDesired",
                       productCountAvailableKey = "countAvailable",
                       productPriceKey = "price",
                       productSumKey = "sum",
                       productDiscountKey = "discount";

        private void MainForm_Load(object sender, EventArgs e)
        {
            // для вкладки "Просмотр заказов"
            // выводим заказы
            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCustomerOrders();
            FillDgv(dgvOrders, reader);

            // выводим заголовки таблицы с содержимым заказа
            reader = AuthorizationForm.DatabaseConnection.GetOrderProducts();
            FillDgv(dgvOrderProducts, reader);



            // для вкладки "Оформление заказа"
            // заполняем элементы ComboBox
            reader = AuthorizationForm.DatabaseConnection.GetProductTypes();
            FillComboBoxItems(cbProductType, reader);
            // по умолчанию - все товары
            int defaultProductType = AuthorizationForm.DatabaseConnection.GetDefaultProductType();
            cbProductType.SelectedItem = cbProductType.Items
                .Cast<KeyValueComboBoxItem>()
                .Where(item => item.Key == defaultProductType)
                .ToArray()[0];

            reader = AuthorizationForm.DatabaseConnection.GetProductsOfType();
            FillComboBoxItems(cbProductName, reader);

            reader = AuthorizationForm.DatabaseConnection.GetPickupPointsAddresses();
            FillComboBoxItems(cbPickupPoint, reader);

            reader = AuthorizationForm.DatabaseConnection.GetPaymentMethods();
            FillComboBoxItems(cbPaymentMethod, reader);

            // инициализация таблицы с корзиной
            dgvBasket.Columns.Add(productCodeKey, "Код товара");
            dgvBasket.Columns.Add(productNameKey, "Название товара");
            dgvBasket.Columns.Add(productCountDesiredKey, "Количество");
            dgvBasket.Columns.Add(productCountAvailableKey, "Количество на складах, шт.");
            dgvBasket.Columns.Add(productPriceKey, "Цена, руб.");
            dgvBasket.Columns.Add(productSumKey, "Стоимость, руб.");
            dgvBasket.Columns.Add(productDiscountKey, "Скидка, %");


            dgvBasket.Rows.Add();
            dgvBasket.Rows[0].Selected = true;

            RecalculateOrderDiscount();



            // для вкладки "Поиск товаров по характеристикам"
            // заполняем элементы ComboBox
            reader = AuthorizationForm.DatabaseConnection.GetProductTypes();
            FillComboBoxItems(cbProductTypeSearch, reader);
            // по умолчанию - все товары
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

        private int selectedTypeIndex = -1;
        private void cbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            int selectedTypeIndex = cb.SelectedIndex;
            //if (selectedTypeIndex != this.selectedTypeIndex)
            //{
                // изменяем содержимое ComboBox на список товаров указанного типа
                SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetProductsOfType(
                    (cb.SelectedItem as KeyValueComboBoxItem).Key);
                FillComboBoxItems(cbProductName, reader);
                this.selectedTypeIndex = selectedTypeIndex;
            //}
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (cbProductName.SelectedItem != null)
            {
                // добавляем/изменяем товар в корзине
                int productCode = (cbProductName.SelectedItem as KeyValueComboBoxItem).Key;
                short? pickupPointCode = null;
                if (cbPickupPoint.SelectedItem != null)
                {
                    pickupPointCode = (short)(cbPickupPoint.SelectedItem as KeyValueComboBoxItem).Key;
                }
                int countAvailable = AuthorizationForm.DatabaseConnection.GetPickupPointProductCount(
                    productCode, pickupPointCode
                );

                // string typeName = AuthorizationForm.DatabaseConnection.GetTypeOfProduct(productCode);
                //string typeName = (cbProductType.SelectedItem as KeyValueComboBoxItem).Value;
                string productName = (cbProductName.SelectedItem as KeyValueComboBoxItem).Value;
                int countDesired = (int)nudProductCount.Value;

                byte orderDiscount = byte.Parse(tbOrderDiscount.Text);
                decimal productPrice;
                byte productDiscount;
                AuthorizationForm.DatabaseConnection.GetProductOrderInfo(
                    productCode, countDesired, orderDiscount, out productPrice, out productDiscount
                );

                dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].SetValues(
                    productCode, productName, countDesired, countAvailable, productPrice,
                    productPrice * countDesired, productDiscount
                );

                if (countDesired > countAvailable)
                {
                    HighlightRow(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex], true);
                }
                else
                {
                    HighlightRow(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex], false);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар указанного типа!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void HighlightRow(DataGridViewRow row, bool paint)
        {
            if (paint)
            {
                row.Cells[productCountDesiredKey].Style.BackColor = Color.Orange;
                row.Cells[productCountAvailableKey].Style.BackColor = Color.Orange;
            }
            else
            {
                row.Cells[productCountDesiredKey].Style.BackColor = Color.Empty;
                row.Cells[productCountAvailableKey].Style.BackColor = Color.Empty;
            }
        }

        private void dgvBasket_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int rowsCount = dgvBasket.Rows.Count;
            if (dgvBasket.Rows[rowsCount - 1].Cells[productCodeKey] == null
                && rowsCount > 1
                && dgvBasket.CurrentCell.RowIndex != rowsCount - 1)
            {
                // удаляем строку для нового товара
                dgvBasket.Rows.Remove(dgvBasket.Rows[rowsCount - 1]);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (dgvBasket.Rows[dgvBasket.Rows.Count - 1].Cells[productCodeKey].Value != null)
            {
                // добавляем, если пустая строка для нового товара ещё не добавлена
                dgvBasket.Rows.Add();
                dgvBasket.Rows[dgvBasket.Rows.Count - 1].Selected = true;

                cbProductType.Text = string.Empty;
                cbProductName.Text = string.Empty;
                nudProductCount.Value = 1;
                tbProductSum.Text = "0";
                tbProductDiscount.Text = "0";
                dgvProductInfo.Rows.Clear();
            }
        }

        private void dgvBasket_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal orderSum = 0;
            if (e.ColumnIndex == 5)
            {
                foreach (DataGridViewRow row in dgvBasket.Rows)
                {
                    orderSum += decimal.Parse(row.Cells[productSumKey].Value.ToString());
                }
            }
            tbOrderSum.Text = orderSum.ToString();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string warning = "Вы действительно хотите удалить следующие товары из корзины?";
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
            if (dgvBasket.SelectedRows.Count > 0
                && dgvBasket.SelectedRows[0].Cells[productCodeKey].Value != null)
            {
                foreach (DataGridViewRow row in dgvBasket.SelectedRows)
                {
                    if (row.Cells[productCodeKey].Value != null)
                    {
                        warning += $"\n- {row.Cells[productNameKey].Value}";
                        rowsToRemove.Add(row);
                    }
                }
            }
            if (dgvBasket.CurrentCell != null
                && dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].Cells[productCodeKey].Value != null)
            {
                warning += $"\n- {dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].Cells[productNameKey].Value}";
                rowsToRemove.Add(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex]);
            }
            else
            {
                MessageBox.Show("Выберите товар(-ы) для удаления!", "Удаление из корзины", MessageBoxButtons.OK);
                return;
            }

            DialogResult result = MessageBox.Show(warning, "Удаление из корзины", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvBasket.SelectedRows)
                {
                    dgvBasket.Rows.Remove(row);
                }
            }
        }

        private void dgvBasket_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            decimal orderSum = 0;
            foreach (DataGridViewRow row in dgvBasket.Rows)
            {
                orderSum += decimal.Parse(row.Cells[productSumKey].Value.ToString());
            }
            tbOrderSum.Text = orderSum.ToString();
        }

        private void btnEmptyTrash_Click(object sender, EventArgs e)
        {
            dgvBasket.Rows.Clear();
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productCode = (cbProductName.SelectedItem as KeyValueComboBoxItem).Key;
            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetProductInfo(productCode);
            FillProductInfoDgv(reader);

            RecalculateProductSum();
        }

        private void FillProductInfoDgv(SqlDataReader reader)
        {
            if (dgvProductInfo.Columns.Count == 0)
            {
                dgvProductInfo.Columns.Add("characteristic", "Характеристика");
                dgvProductInfo.Columns.Add("value", "Значение");
            }
            if (reader.HasRows)
            {
                dgvProductInfo.Rows.Clear();
                reader.Read();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dgvProductInfo.Rows.Add(reader.GetName(i), reader.GetValue(i));
                }
            }
            reader.Close();
        }

        private void dgvBasket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBasket.Rows[e.RowIndex].Cells[productCodeKey].Value != null)
            {
                int selectedProductCode = (int)dgvBasket.Rows[e.RowIndex].Cells[productCodeKey].Value;

                string selectedProductTypeName = AuthorizationForm.DatabaseConnection.GetTypeOfProduct(selectedProductCode);
                cbProductType.SelectedItem = cbProductType.Items
                    .Cast<KeyValueComboBoxItem>()
                    .Where(item => item.Value == selectedProductTypeName).ToArray()[0];

                cbProductName.SelectedItem = cbProductName.Items
                    .Cast<KeyValueComboBoxItem>()
                    .Where(item => item.Key == selectedProductCode).ToArray()[0];

                nudProductCount.Value = decimal.Parse(dgvBasket.Rows[e.RowIndex].Cells[productCountDesiredKey]
                    .Value.ToString());
            }
        }

        private void RecalculateProductSum()
        {
            if (cbProductName.SelectedItem != null)
            {
                int productCode = (cbProductName.SelectedItem as KeyValueComboBoxItem).Key;
                int productCount = (int)nudProductCount.Value;
                byte orderDiscount = byte.Parse(tbOrderDiscount.Text);
                decimal productPrice;
                byte productDiscount;
                AuthorizationForm.DatabaseConnection.GetProductOrderInfo(
                    productCode, productCount, orderDiscount, out productPrice, out productDiscount
                );
                tbProductSum.Text = (productPrice * productCount).ToString();
                tbProductDiscount.Text = productDiscount.ToString();
            }
        }

        private void RecalculateOrderDiscount()
        {
            byte orderDiscount = AuthorizationForm.DatabaseConnection.GetCustomerDiscount();
            tbOrderDiscount.Text = orderDiscount.ToString();
        }

        private void nudProductCount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateProductSum();
        }


        private void cbPickupPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pickupPointNumber = (cbPickupPoint.SelectedItem as KeyValueComboBoxItem).Key;
            foreach (DataGridViewRow row in dgvBasket.Rows)
            {
                int productCode = (int)row.Cells[productCodeKey].Value;
                int productCountAvailable = AuthorizationForm.DatabaseConnection.GetPickupPointProductCount(
                    productCode, pickupPointNumber
                );
                row.Cells[productCountAvailableKey].Value = productCountAvailable;
                if ((int)row.Cells[productCountDesiredKey].Value > productCountAvailable)
                {
                    HighlightRow(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex], true);
                }
                else
                {
                    HighlightRow(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex], false);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }
    }
}
