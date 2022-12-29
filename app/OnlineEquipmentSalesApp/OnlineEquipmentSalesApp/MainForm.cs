using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace OnlineEquipmentSalesApp
{
    public partial class MainForm : Form
    {
        private AuthorizationForm parent;

        public MainForm(AuthorizationForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        // класс для хранения элементов ComboBox в формате "ключ" - "текст";
        // ключ нужен для выполнения запросов к БД
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

        private object defaultCBProductType;
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ===== ВКЛАДКА "ПРОСМОТР ЗАКАЗОВ" =====

            // выводим заказы
            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCustomerOrders();
            FillDgv(dgvOrders, reader);

            // выводим заголовки таблицы с содержимым заказа
            reader = AuthorizationForm.DatabaseConnection.GetOrderProducts();
            FillDgv(dgvOrderProducts, reader);



            // ===== ВКЛАДКА "ОФОРМИТЬ ЗАКАЗ" =====

            // заполняем элементы ComboBox
            reader = AuthorizationForm.DatabaseConnection.GetProductTypes();
            FillComboBoxItems(cbProductType, reader);
            // по умолчанию - все товары
            int defaultProductType = AuthorizationForm.DatabaseConnection.GetDefaultProductType();
            cbProductType.SelectedItem = cbProductType.Items
                .Cast<KeyValueComboBoxItem>()
                .Where(item => item.Key == defaultProductType)
                .ToArray()[0];
            defaultCBProductType = cbProductType.SelectedItem;

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

            RecalculateOrderDiscount(); // выводим скидку для нового заказа

            dgvBasket.DefaultCellStyle.Font = new Font("Sans Serif", 12, FontStyle.Regular);
            dgvBasket.ColumnHeadersDefaultCellStyle.Font = new Font("Sans Serif", 12, FontStyle.Regular);
            dgvProductInfo.DefaultCellStyle.Font = new Font("Sans Serif", 12, FontStyle.Regular);
            dgvProductInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Sans Serif", 12, FontStyle.Regular);



            // ===== ВКЛАДКА "ПОИСК ТОВАРОВ ПО ХАРАКТЕРИСТИКАМ" =====

            // заполняем элементы ComboBox
            reader = AuthorizationForm.DatabaseConnection.GetProductTypes();
            FillComboBoxItems(cbProductTypeSearch, reader);
            // по умолчанию - все товары
            cbProductTypeSearch.SelectedItem = cbProductTypeSearch.Items
                .Cast<KeyValueComboBoxItem>()
                .Where(item => item.Key == defaultProductType)
                .ToArray()[0];
        }



        // ===== ВКЛАДКА "ПРОСМОТР ЗАКАЗОВ" =====

        private void FillDgv(DataGridView dgv, SqlDataReader reader)
        {
            if (dgv.Columns.Count < 1)
            {
                // создаём колонки
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dgv.Columns.Add(reader.GetName(i), reader.GetName(i));
                }
            }

            dgv.Rows.Clear();
            if (reader.HasRows)
            {
                // заполняем строки данными
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

        private DateTime? dateStart = null, dateEnd = null;
        private void btnSearchOrders_Click(object sender, EventArgs e)
        {
            RefreshOrdersDgv();
        }

        private void RefreshOrdersDgv(bool force = false)
        {
            // выполняем поиск заказов в выбранный период
            DateTime? dateStart = null, dateEnd = null;

            if (rbOrdersInDates.Checked)
            {
                if (cbOrdersStart.Checked)
                {
                    dateStart = dtpOrdersStart.Value.Date;
                }
                if (cbOrdersEnd.Checked)
                {
                    dateEnd = dtpOrdersEnd.Value.Date;
                }
            }

            // выполняем запрос, только если параметры поиска поменялись
            if (dateStart != this.dateStart || dateEnd != this.dateEnd || force)
            {
                try
                {
                    SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCustomerOrders(
                        dateStart, dateEnd
                    );
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
            // отображаем товары из выбранного заказа
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
                DialogResult dialogResult = MessageBox.Show(
                    $"Вы действительно хотите отменить заказ №{orderNumber}?",
                    "Отмена заказа",
                    MessageBoxButtons.YesNo
                );
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
            tabControl1.SelectedTab = tpCreateOrder;
        }



        // ===== ВКЛАДКА "ОФОРМИТЬ ЗАКАЗ" =====

        private void FillComboBoxItems(ComboBox cb, SqlDataReader reader)
        {
            KeyValueComboBoxItem selectedItem = cb.SelectedItem as KeyValueComboBoxItem;
            cb.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    KeyValueComboBoxItem item = new KeyValueComboBoxItem(
                        Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString()
                    );
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


        private void cbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // в выпадающем списке с товарами отображаем только те, что соответствуют выбранному типу
            ComboBox cb = sender as ComboBox;

            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetProductsOfType(
                (short)(cb.SelectedItem as KeyValueComboBoxItem).Key
            );
            FillComboBoxItems(cbProductName, reader);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // сохраняем новый товар/изменения старого в корзине
            if (cbProductName.SelectedItem is KeyValueComboBoxItem product)
            {
                // формируем строку для добавления в корзину:
                // код товара - название - желаемое количество - доступное на складах количество
                // - цена - стоимость - скидка:
                int productCode = product.Key;

                // проверяем, не добавлен ли уже этот товар в корзину
                int selectedRowIndex = dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].Index;
                if (dgvBasket.Rows
                    .Cast<DataGridViewRow>()
                    .Any(row => row.Index != selectedRowIndex
                        && row.Cells[productCodeKey].Value != null
                        && (int)row.Cells[productCodeKey].Value == productCode))
                {
                    MessageBox.Show("Указанный товар уже присутствует в корзине!", "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    string productName = product.Value;

                    int countDesired = (int)nudProductCount.Value;

                    short? pickupPointCode = null;
                    if (cbPickupPoint.SelectedItem is KeyValueComboBoxItem pickupPoint)
                    {
                        pickupPointCode = (short)pickupPoint.Key;
                    }
                    int countAvailable = AuthorizationForm.DatabaseConnection.GetPickupPointProductCount(
                        productCode, pickupPointCode
                    );

                    byte orderDiscount = byte.Parse(tbOrderDiscount.Text);
                    AuthorizationForm.DatabaseConnection.GetProductOrderInfo(
                        productCode, countDesired, orderDiscount,
                        out decimal productPrice,
                        out byte productDiscount
                    );

                    decimal productSum = productPrice * countDesired;

                    if (dgvBasket.SelectedRows.Count < 2)
                    {
                        // добавляем/изменяем только одну строку
                        dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex].SetValues(
                            productCode, productName, countDesired, countAvailable, productPrice.ToString("N"),
                            productSum.ToString("N"), productDiscount
                        );
                    }

                    // если желаемое количество товара превосходит его количество на доступных складах,
                    // выделяем для клиента эту строку
                    HighlightRow(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex], countDesired > countAvailable);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар указанного типа!", "Ошибка", MessageBoxButtons.OK);
            }                
        }

        private void HighlightRow(DataGridViewRow row, bool paint)
        {
            // true - выделяем, false - снимаем выделение

            Color bgColor = (paint) ? Color.Orange : Color.Empty;

            row.Cells[productCountDesiredKey].Style.BackColor = bgColor;
            row.Cells[productCountAvailableKey].Style.BackColor = bgColor;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            dgvBasket.ClearSelection();

            if (dgvBasket.Rows[dgvBasket.Rows.Count - 1].Cells[productCodeKey].Value != null)
            {
                // добавляем, если пустая строка для нового товара ещё не добавлена
                dgvBasket.Rows.Add();
                EmptyProductInfo();
            }

            dgvBasket.CurrentCell = dgvBasket.Rows[dgvBasket.Rows.Count - 1].Cells[0];
            dgvBasket.Rows[dgvBasket.Rows.Count - 1].Selected = true;
        }

        private void EmptyProductInfo()
        {
            nudProductCount.Value = 1;

            tbProductSum.Text = "0";
            tbProductDiscount.Text = "0";

            cbProductType.SelectedItem = defaultCBProductType;

            cbProductName.SelectedIndex = -1;
            cbProductName.Text = "";

            dgvProductInfo.Rows.Clear();
        }

        private void dgvBasket_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                // если изменилась стоимость элемента корзины, необходимо пересчитать сумму заказа
                RecalculateOrderSum();
            }
        }

        private void RecalculateOrderSum()
        {
            decimal orderSum = 0;
            foreach (DataGridViewRow row in dgvBasket.Rows)
            {
                if (row.Cells[productSumKey].Value != null)
                {
                    orderSum += decimal.Parse(row.Cells[productSumKey].Value.ToString());
                }
            }
            tbOrderSum.Text = orderSum.ToString("N");
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string warning = "Вы действительно хотите удалить следующие товары из корзины?";
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            if (dgvBasket.SelectedRows.Count > 0)
            {
                // помечаем на удаление все выделенные товары
                foreach (DataGridViewRow row in dgvBasket.SelectedRows)
                {
                    rowsToRemove.Add(row);
                }
            }
            else if (dgvBasket.CurrentCell != null)
            {
                // помечаем на удаление один выбранный товар
                rowsToRemove.Add(dgvBasket.Rows[dgvBasket.CurrentCell.RowIndex]);
            }

            if (rowsToRemove.Count == 0)
            {
                MessageBox.Show(
                    "Выберите товар(-ы) для удаления!", "Удаление из корзины", MessageBoxButtons.OK
                );
            }
            else if (rowsToRemove[rowsToRemove.Count - 1].Cells[productCodeKey].Value == null)
            {
                // удаляем только пустую строку
                dgvBasket.Rows.Remove(rowsToRemove[rowsToRemove.Count - 1]);
            }
            else
            {
                foreach (DataGridViewRow row in rowsToRemove)
                {
                    if (row.Cells[productCodeKey].Value != null) // пустая строка
                    {
                        warning += $"\n- {row.Cells[productNameKey].Value}";
                    }
                }

                DialogResult result = MessageBox.Show(warning, "Удаление из корзины", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in rowsToRemove)
                    {
                        dgvBasket.Rows.Remove(row);
                    }
                }
            }

            if (dgvBasket.Rows.Count == 0)
            {
                dgvBasket.Rows.Add();
            }
            RecalculateOrderSum();
        }

        private void btnEmptyBasket_Click(object sender, EventArgs e)
        {
            if (dgvBasket.Rows[0].Cells[productCodeKey].Value != null)
            {
                DialogResult result = MessageBox.Show(
                    "Вы действительно хотите очистить корзину?", "Очистка корзины", MessageBoxButtons.YesNo
                );
                if (result == DialogResult.Yes)
                {
                    EmptyBasket();
                }
            }
            
        }

        private void EmptyBasket()
        {
            dgvBasket.Rows.Clear();
            dgvBasket.Rows.Add();
            RecalculateOrderSum();
        }

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // выводим информацию о выбранном в ComboBox товаре
            if (cbProductName.SelectedItem is KeyValueComboBoxItem product)
            {
                SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetProductInfo(product.Key);
                FillProductInfoDgv(reader);
                RecalculateProductSum();
            }
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

        private void RecalculateProductSum()
        {
            if (cbProductName.SelectedItem is KeyValueComboBoxItem product)
            {
                int productCode = product.Key;
                int productCount = (int)nudProductCount.Value;
                byte orderDiscount = byte.Parse(tbOrderDiscount.Text);
                AuthorizationForm.DatabaseConnection.GetProductOrderInfo(
                    productCode,
                    productCount,
                    orderDiscount,
                    out decimal productPrice,
                    out byte productDiscount
                );
                decimal productSum = productPrice * productCount;
                tbProductSum.Text = productSum.ToString("N");
                tbProductDiscount.Text = productDiscount.ToString();
            }
        }

        private void dgvBasket_SelectionChanged(object sender, EventArgs e)
        {
            // отображаем информацию о выбранном товаре
            if (dgvBasket.CurrentCell != null)
            {
                int rowIndex = dgvBasket.CurrentCell.RowIndex;
                if (rowIndex != -1)
                {
                    if (dgvBasket.Rows[rowIndex].Cells[productCodeKey].Value != null)
                    {
                        int selectedProductCode = (int)dgvBasket.Rows[rowIndex].Cells[productCodeKey].Value;

                        if (!(cbProductName.SelectedItem is KeyValueComboBoxItem product)
                            || selectedProductCode != product.Key)
                        {
                            // если выбран другой товар, отображаем информацию о нём
                            string selectedProductTypeName = AuthorizationForm.DatabaseConnection
                                .GetTypeOfProduct(selectedProductCode);

                            cbProductType.SelectedItem = cbProductType.Items
                                .Cast<KeyValueComboBoxItem>()
                                .Where(item => item.Value == selectedProductTypeName).ToArray()[0];

                            cbProductName.SelectedItem = cbProductName.Items
                                .Cast<KeyValueComboBoxItem>()
                                .Where(item => item.Key == selectedProductCode).ToArray()[0];

                            nudProductCount.Value = decimal.Parse(
                                dgvBasket.Rows[rowIndex].Cells[productCountDesiredKey].Value.ToString()
                            );
                        }
                    }
                    else
                    {
                        // выбрана пустая строка с новым товаром
                        EmptyProductInfo();
                    }
                }
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
            // пересчитываем для каждого товара количество из доступных
            // для выбранного пункта выдачи складов
            if (cbPickupPoint.SelectedItem is KeyValueComboBoxItem pickupPoint)
            {
                int pickupPointNumber = pickupPoint.Key;
                foreach (DataGridViewRow row in dgvBasket.Rows)
                {
                    if (row.Cells[productCodeKey].Value != null)
                    {
                        int productCode = (int)row.Cells[productCodeKey].Value;
                        int productCountAvailable = AuthorizationForm.DatabaseConnection.GetPickupPointProductCount(
                            productCode, pickupPointNumber
                        );

                        row.Cells[productCountAvailableKey].Value = productCountAvailable;
                        HighlightRow(
                            row,
                            ((int)row.Cells[productCountDesiredKey].Value > productCountAvailable)
                        );
                    }
                }
            }
        }

        private void btnFinishOrderCreating_Click(object sender, EventArgs e)
        {
            if (!(cbPickupPoint.SelectedItem is KeyValueComboBoxItem pickupPoint))
            {
                MessageBox.Show("Выберите пункт выдачи заказа!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (!(cbPaymentMethod.SelectedItem is KeyValueComboBoxItem paymentMethod))
            {
                MessageBox.Show("Выберите способ оплаты!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                List<DatabaseConnection.Product> products = new List<DatabaseConnection.Product>();
                foreach (DataGridViewRow row in dgvBasket.Rows)
                {
                    if (row.Cells[productCodeKey].Value != null)
                    {
                        int productCode = int.Parse(row.Cells[productCodeKey].Value.ToString());
                        int productCount = int.Parse(row.Cells[productCountDesiredKey].Value.ToString());
                        DatabaseConnection.Product product = new DatabaseConnection.Product(
                            productCode, productCount
                        );
                        products.Add(product);
                    }
                }

                if (products.Count == 0)
                {
                    MessageBox.Show("Выберите товары для покупки!", "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        "Вы уверены, что хотите совершить покупку?",
                        "Оформление заказа",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        short pickupPointNumber = (short)pickupPoint.Key;
                        byte paymentMethodCode = (byte)paymentMethod.Key;

                        try
                        {
                            AuthorizationForm.DatabaseConnection.CreateOrder(
                                pickupPointNumber, paymentMethodCode, products
                            );

                            MessageBox.Show(
                                "Заказ успешно оформлен!", "Оформление заказа", MessageBoxButtons.OK
                            );

                            // очищаем настройки заказа

                            EmptyBasket();

                            cbPickupPoint.SelectedIndex = -1;
                            cbPickupPoint.Text = string.Empty;

                            cbPaymentMethod.SelectedIndex = -1;
                            cbPaymentMethod.Text = string.Empty;

                            // обновляем таблицу с заказами на вкладке "Заказы"
                            RefreshOrdersDgv(true);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }



        // ===== ВКЛАДКА "ПОИСК ТОВАРОВ ПО ХАРАКТЕРИСТИКАМ"

        private void cbProductTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            int selectedTypeIndex = cb.SelectedIndex;

            // изменяем содержимое ComboBox на список характеристик указанного типа
            SqlDataReader reader = AuthorizationForm.DatabaseConnection.GetCharacteristicsOfType(
                Convert.ToInt16((cb.SelectedItem as KeyValueComboBoxItem).Key));
            FillComboBoxItems(cbCharacteristicName, reader);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!(cbProductTypeSearch.SelectedItem is KeyValueComboBoxItem productType))
            {
                MessageBox.Show("Выберите тип товара!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (!(cbCharacteristicName.SelectedItem is KeyValueComboBoxItem productCharacteristic))
            {
                MessageBox.Show("Выберите характеристику, соответствующую указанному типу товара!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                short productTypeCode = (short)productType.Key;
                short characteristicCode = (short)productCharacteristic.Key;
                byte dataTypeCode = AuthorizationForm.DatabaseConnection.GetCharacteristicDataType(
                    characteristicCode
                );
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



        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Close();
        }
    }
}
