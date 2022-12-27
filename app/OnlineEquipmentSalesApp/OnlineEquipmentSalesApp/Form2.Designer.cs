
namespace OnlineEquipmentSalesApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.spOrders = new System.Windows.Forms.SplitContainer();
            this.pOrderDates = new System.Windows.Forms.Panel();
            this.pPeriodChoosing = new System.Windows.Forms.Panel();
            this.cbOrdersStart = new System.Windows.Forms.CheckBox();
            this.dtpOrdersStart = new System.Windows.Forms.DateTimePicker();
            this.dtpOrdersEnd = new System.Windows.Forms.DateTimePicker();
            this.cbOrdersEnd = new System.Windows.Forms.CheckBox();
            this.btnSearchOrders = new System.Windows.Forms.Button();
            this.rbOrdersInDates = new System.Windows.Forms.RadioButton();
            this.rbAllOrders = new System.Windows.Forms.RadioButton();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.lblOrderProducts = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.dgvOrderProducts = new System.Windows.Forms.DataGridView();
            this.tpCreateOrder = new System.Windows.Forms.TabPage();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbBasket = new System.Windows.Forms.GroupBox();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.scSettings = new System.Windows.Forms.SplitContainer();
            this.gbOrderSettings = new System.Windows.Forms.GroupBox();
            this.tbOrderDiscount = new System.Windows.Forms.TextBox();
            this.lblOrderDiscount = new System.Windows.Forms.Label();
            this.tbOrderSum = new System.Windows.Forms.TextBox();
            this.lblOrderSum = new System.Windows.Forms.Label();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.cbPickupPoint = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPickupPoint = new System.Windows.Forms.Label();
            this.gbBasketItem = new System.Windows.Forms.GroupBox();
            this.tbProductDiscount = new System.Windows.Forms.TextBox();
            this.tbProductSum = new System.Windows.Forms.TextBox();
            this.lblProductDiscount = new System.Windows.Forms.Label();
            this.lblProductSum = new System.Windows.Forms.Label();
            this.nudProductCount = new System.Windows.Forms.NumericUpDown();
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnFinishOrderCreating = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.tpSearch = new System.Windows.Forms.TabPage();
            this.spSearch = new System.Windows.Forms.SplitContainer();
            this.gbSearchSettings = new System.Windows.Forms.GroupBox();
            this.cbProductTypeSearch = new System.Windows.Forms.ComboBox();
            this.lblProductTypeSearch = new System.Windows.Forms.Label();
            this.lblCharacteristicValue = new System.Windows.Forms.Label();
            this.tbCharacteristicValue = new System.Windows.Forms.TextBox();
            this.lblCharacteristicName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbCharacteristicName = new System.Windows.Forms.ComboBox();
            this.gbSearchResults = new System.Windows.Forms.GroupBox();
            this.dgvProductByCharacteristics = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spOrders)).BeginInit();
            this.spOrders.Panel1.SuspendLayout();
            this.spOrders.Panel2.SuspendLayout();
            this.spOrders.SuspendLayout();
            this.pOrderDates.SuspendLayout();
            this.pPeriodChoosing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderProducts)).BeginInit();
            this.tpCreateOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.gbBasket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scSettings)).BeginInit();
            this.scSettings.Panel1.SuspendLayout();
            this.scSettings.Panel2.SuspendLayout();
            this.scSettings.SuspendLayout();
            this.gbOrderSettings.SuspendLayout();
            this.gbBasketItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCount)).BeginInit();
            this.gbActions.SuspendLayout();
            this.tpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSearch)).BeginInit();
            this.spSearch.Panel1.SuspendLayout();
            this.spSearch.Panel2.SuspendLayout();
            this.spSearch.SuspendLayout();
            this.gbSearchSettings.SuspendLayout();
            this.gbSearchResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductByCharacteristics)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpOrders);
            this.tabControl1.Controls.Add(this.tpCreateOrder);
            this.tabControl1.Controls.Add(this.tpSearch);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 690);
            this.tabControl1.TabIndex = 0;
            // 
            // tpOrders
            // 
            this.tpOrders.Controls.Add(this.spOrders);
            this.tpOrders.Location = new System.Drawing.Point(4, 30);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(874, 656);
            this.tpOrders.TabIndex = 0;
            this.tpOrders.Text = "Просмотр заказов";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // spOrders
            // 
            this.spOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spOrders.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.spOrders.Location = new System.Drawing.Point(6, 6);
            this.spOrders.Name = "spOrders";
            this.spOrders.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spOrders.Panel1
            // 
            this.spOrders.Panel1.Controls.Add(this.pOrderDates);
            this.spOrders.Panel1.Controls.Add(this.dgvOrders);
            // 
            // spOrders.Panel2
            // 
            this.spOrders.Panel2.Controls.Add(this.btnCancelOrder);
            this.spOrders.Panel2.Controls.Add(this.lblOrderProducts);
            this.spOrders.Panel2.Controls.Add(this.btnCreateOrder);
            this.spOrders.Panel2.Controls.Add(this.dgvOrderProducts);
            this.spOrders.Size = new System.Drawing.Size(862, 644);
            this.spOrders.SplitterDistance = 278;
            this.spOrders.TabIndex = 8;
            // 
            // pOrderDates
            // 
            this.pOrderDates.Controls.Add(this.pPeriodChoosing);
            this.pOrderDates.Controls.Add(this.btnSearchOrders);
            this.pOrderDates.Controls.Add(this.rbOrdersInDates);
            this.pOrderDates.Controls.Add(this.rbAllOrders);
            this.pOrderDates.Location = new System.Drawing.Point(9, 3);
            this.pOrderDates.Name = "pOrderDates";
            this.pOrderDates.Size = new System.Drawing.Size(844, 44);
            this.pOrderDates.TabIndex = 9;
            // 
            // pPeriodChoosing
            // 
            this.pPeriodChoosing.Controls.Add(this.cbOrdersStart);
            this.pPeriodChoosing.Controls.Add(this.dtpOrdersStart);
            this.pPeriodChoosing.Controls.Add(this.dtpOrdersEnd);
            this.pPeriodChoosing.Controls.Add(this.cbOrdersEnd);
            this.pPeriodChoosing.Enabled = false;
            this.pPeriodChoosing.Location = new System.Drawing.Point(159, 0);
            this.pPeriodChoosing.Name = "pPeriodChoosing";
            this.pPeriodChoosing.Size = new System.Drawing.Size(534, 44);
            this.pPeriodChoosing.TabIndex = 10;
            // 
            // cbOrdersStart
            // 
            this.cbOrdersStart.AutoSize = true;
            this.cbOrdersStart.Location = new System.Drawing.Point(3, 11);
            this.cbOrdersStart.Name = "cbOrdersStart";
            this.cbOrdersStart.Size = new System.Drawing.Size(39, 25);
            this.cbOrdersStart.TabIndex = 1;
            this.cbOrdersStart.Text = "c:";
            this.cbOrdersStart.UseVisualStyleBackColor = true;
            this.cbOrdersStart.CheckedChanged += new System.EventHandler(this.cbOrdersStart_CheckedChanged);
            // 
            // dtpOrdersStart
            // 
            this.dtpOrdersStart.Enabled = false;
            this.dtpOrdersStart.Location = new System.Drawing.Point(44, 6);
            this.dtpOrdersStart.Name = "dtpOrdersStart";
            this.dtpOrdersStart.Size = new System.Drawing.Size(200, 29);
            this.dtpOrdersStart.TabIndex = 5;
            // 
            // dtpOrdersEnd
            // 
            this.dtpOrdersEnd.Enabled = false;
            this.dtpOrdersEnd.Location = new System.Drawing.Point(306, 6);
            this.dtpOrdersEnd.Name = "dtpOrdersEnd";
            this.dtpOrdersEnd.Size = new System.Drawing.Size(200, 29);
            this.dtpOrdersEnd.TabIndex = 8;
            // 
            // cbOrdersEnd
            // 
            this.cbOrdersEnd.AutoSize = true;
            this.cbOrdersEnd.Location = new System.Drawing.Point(250, 10);
            this.cbOrdersEnd.Name = "cbOrdersEnd";
            this.cbOrdersEnd.Size = new System.Drawing.Size(50, 25);
            this.cbOrdersEnd.TabIndex = 2;
            this.cbOrdersEnd.Text = "по:";
            this.cbOrdersEnd.UseVisualStyleBackColor = true;
            this.cbOrdersEnd.CheckedChanged += new System.EventHandler(this.cbOrdersEnd_CheckedChanged);
            // 
            // btnSearchOrders
            // 
            this.btnSearchOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOrders.Location = new System.Drawing.Point(699, 4);
            this.btnSearchOrders.Name = "btnSearchOrders";
            this.btnSearchOrders.Size = new System.Drawing.Size(116, 37);
            this.btnSearchOrders.TabIndex = 9;
            this.btnSearchOrders.Text = "Поиск";
            this.btnSearchOrders.UseVisualStyleBackColor = true;
            this.btnSearchOrders.Click += new System.EventHandler(this.btnSearchOrders_Click);
            // 
            // rbOrdersInDates
            // 
            this.rbOrdersInDates.AutoSize = true;
            this.rbOrdersInDates.Location = new System.Drawing.Point(60, 10);
            this.rbOrdersInDates.Name = "rbOrdersInDates";
            this.rbOrdersInDates.Size = new System.Drawing.Size(93, 25);
            this.rbOrdersInDates.TabIndex = 1;
            this.rbOrdersInDates.Text = "в период";
            this.rbOrdersInDates.UseVisualStyleBackColor = true;
            this.rbOrdersInDates.CheckedChanged += new System.EventHandler(this.rbOrdersInDates_CheckedChanged);
            // 
            // rbAllOrders
            // 
            this.rbAllOrders.AutoSize = true;
            this.rbAllOrders.Checked = true;
            this.rbAllOrders.Location = new System.Drawing.Point(3, 10);
            this.rbAllOrders.Name = "rbAllOrders";
            this.rbAllOrders.Size = new System.Drawing.Size(51, 25);
            this.rbAllOrders.TabIndex = 0;
            this.rbAllOrders.TabStop = true;
            this.rbAllOrders.Text = "все";
            this.rbAllOrders.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(9, 53);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowTemplate.Height = 25;
            this.dgvOrders.Size = new System.Drawing.Size(844, 233);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelOrder.Location = new System.Drawing.Point(212, 326);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(200, 33);
            this.btnCancelOrder.TabIndex = 4;
            this.btnCancelOrder.Text = "Отменить заказ...";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // lblOrderProducts
            // 
            this.lblOrderProducts.AutoSize = true;
            this.lblOrderProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderProducts.Location = new System.Drawing.Point(6, 10);
            this.lblOrderProducts.Name = "lblOrderProducts";
            this.lblOrderProducts.Size = new System.Drawing.Size(282, 21);
            this.lblOrderProducts.TabIndex = 2;
            this.lblOrderProducts.Text = "Содержимое заказа (выберите заказ):";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateOrder.Location = new System.Drawing.Point(6, 326);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(200, 33);
            this.btnCreateOrder.TabIndex = 3;
            this.btnCreateOrder.Text = "Оформить заказ...";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // dgvOrderProducts
            // 
            this.dgvOrderProducts.AllowUserToAddRows = false;
            this.dgvOrderProducts.AllowUserToDeleteRows = false;
            this.dgvOrderProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderProducts.Location = new System.Drawing.Point(9, 34);
            this.dgvOrderProducts.Name = "dgvOrderProducts";
            this.dgvOrderProducts.ReadOnly = true;
            this.dgvOrderProducts.RowTemplate.Height = 25;
            this.dgvOrderProducts.Size = new System.Drawing.Size(844, 286);
            this.dgvOrderProducts.TabIndex = 0;
            // 
            // tpCreateOrder
            // 
            this.tpCreateOrder.Controls.Add(this.scMain);
            this.tpCreateOrder.Location = new System.Drawing.Point(4, 30);
            this.tpCreateOrder.Name = "tpCreateOrder";
            this.tpCreateOrder.Size = new System.Drawing.Size(874, 656);
            this.tpCreateOrder.TabIndex = 2;
            this.tpCreateOrder.Text = "Оформить заказ";
            this.tpCreateOrder.UseVisualStyleBackColor = true;
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.scMain.Location = new System.Drawing.Point(3, 3);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gbBasket);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scSettings);
            this.scMain.Size = new System.Drawing.Size(868, 615);
            this.scMain.SplitterDistance = 232;
            this.scMain.TabIndex = 6;
            // 
            // gbBasket
            // 
            this.gbBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasket.Controls.Add(this.dgvBasket);
            this.gbBasket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbBasket.Location = new System.Drawing.Point(3, 3);
            this.gbBasket.Name = "gbBasket";
            this.gbBasket.Size = new System.Drawing.Size(862, 226);
            this.gbBasket.TabIndex = 4;
            this.gbBasket.TabStop = false;
            this.gbBasket.Text = "Корзина";
            // 
            // dgvBasket
            // 
            this.dgvBasket.AllowUserToAddRows = false;
            this.dgvBasket.AllowUserToDeleteRows = false;
            this.dgvBasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBasket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(9, 28);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.ReadOnly = true;
            this.dgvBasket.RowTemplate.Height = 25;
            this.dgvBasket.Size = new System.Drawing.Size(847, 192);
            this.dgvBasket.TabIndex = 0;
            // 
            // scSettings
            // 
            this.scSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scSettings.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.scSettings.IsSplitterFixed = true;
            this.scSettings.Location = new System.Drawing.Point(0, 3);
            this.scSettings.Name = "scSettings";
            // 
            // scSettings.Panel1
            // 
            this.scSettings.Panel1.Controls.Add(this.gbOrderSettings);
            this.scSettings.Panel1.Controls.Add(this.gbBasketItem);
            // 
            // scSettings.Panel2
            // 
            this.scSettings.Panel2.AutoScroll = true;
            this.scSettings.Panel2.Controls.Add(this.gbActions);
            this.scSettings.Size = new System.Drawing.Size(865, 368);
            this.scSettings.SplitterDistance = 591;
            this.scSettings.TabIndex = 3;
            // 
            // gbOrderSettings
            // 
            this.gbOrderSettings.Controls.Add(this.tbOrderDiscount);
            this.gbOrderSettings.Controls.Add(this.lblOrderDiscount);
            this.gbOrderSettings.Controls.Add(this.tbOrderSum);
            this.gbOrderSettings.Controls.Add(this.lblOrderSum);
            this.gbOrderSettings.Controls.Add(this.cbPaymentMethod);
            this.gbOrderSettings.Controls.Add(this.cbPickupPoint);
            this.gbOrderSettings.Controls.Add(this.lblPaymentMethod);
            this.gbOrderSettings.Controls.Add(this.lblPickupPoint);
            this.gbOrderSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbOrderSettings.Location = new System.Drawing.Point(3, 234);
            this.gbOrderSettings.Name = "gbOrderSettings";
            this.gbOrderSettings.Size = new System.Drawing.Size(525, 155);
            this.gbOrderSettings.TabIndex = 3;
            this.gbOrderSettings.TabStop = false;
            this.gbOrderSettings.Text = "Заказ:";
            // 
            // tbOrderDiscount
            // 
            this.tbOrderDiscount.Location = new System.Drawing.Point(390, 118);
            this.tbOrderDiscount.Name = "tbOrderDiscount";
            this.tbOrderDiscount.ReadOnly = true;
            this.tbOrderDiscount.Size = new System.Drawing.Size(75, 29);
            this.tbOrderDiscount.TabIndex = 14;
            this.tbOrderDiscount.Text = "0";
            // 
            // lblOrderDiscount
            // 
            this.lblOrderDiscount.AutoSize = true;
            this.lblOrderDiscount.Location = new System.Drawing.Point(251, 121);
            this.lblOrderDiscount.Name = "lblOrderDiscount";
            this.lblOrderDiscount.Size = new System.Drawing.Size(133, 21);
            this.lblOrderDiscount.TabIndex = 13;
            this.lblOrderDiscount.Text = "С уч. скидки, %:";
            // 
            // tbOrderSum
            // 
            this.tbOrderSum.Location = new System.Drawing.Point(155, 118);
            this.tbOrderSum.Name = "tbOrderSum";
            this.tbOrderSum.ReadOnly = true;
            this.tbOrderSum.Size = new System.Drawing.Size(75, 29);
            this.tbOrderSum.TabIndex = 11;
            this.tbOrderSum.Text = "0";
            // 
            // lblOrderSum
            // 
            this.lblOrderSum.AutoSize = true;
            this.lblOrderSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrderSum.Location = new System.Drawing.Point(9, 118);
            this.lblOrderSum.Name = "lblOrderSum";
            this.lblOrderSum.Size = new System.Drawing.Size(107, 21);
            this.lblOrderSum.TabIndex = 10;
            this.lblOrderSum.Text = "Сумма, руб.:";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(155, 74);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(364, 29);
            this.cbPaymentMethod.TabIndex = 7;
            // 
            // cbPickupPoint
            // 
            this.cbPickupPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPickupPoint.FormattingEnabled = true;
            this.cbPickupPoint.Location = new System.Drawing.Point(155, 27);
            this.cbPickupPoint.Name = "cbPickupPoint";
            this.cbPickupPoint.Size = new System.Drawing.Size(364, 29);
            this.cbPickupPoint.TabIndex = 6;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentMethod.Location = new System.Drawing.Point(9, 74);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(122, 21);
            this.lblPaymentMethod.TabIndex = 1;
            this.lblPaymentMethod.Text = "Способ оплаты:";
            // 
            // lblPickupPoint
            // 
            this.lblPickupPoint.AutoSize = true;
            this.lblPickupPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPickupPoint.Location = new System.Drawing.Point(9, 30);
            this.lblPickupPoint.Name = "lblPickupPoint";
            this.lblPickupPoint.Size = new System.Drawing.Size(114, 21);
            this.lblPickupPoint.TabIndex = 0;
            this.lblPickupPoint.Text = "Пункт выдачи:";
            // 
            // gbBasketItem
            // 
            this.gbBasketItem.Controls.Add(this.tbProductDiscount);
            this.gbBasketItem.Controls.Add(this.tbProductSum);
            this.gbBasketItem.Controls.Add(this.lblProductDiscount);
            this.gbBasketItem.Controls.Add(this.lblProductSum);
            this.gbBasketItem.Controls.Add(this.nudProductCount);
            this.gbBasketItem.Controls.Add(this.cbProductName);
            this.gbBasketItem.Controls.Add(this.btnSaveChanges);
            this.gbBasketItem.Controls.Add(this.cbProductType);
            this.gbBasketItem.Controls.Add(this.label1);
            this.gbBasketItem.Controls.Add(this.lblProductName);
            this.gbBasketItem.Controls.Add(this.lblProductType);
            this.gbBasketItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbBasketItem.Location = new System.Drawing.Point(3, 3);
            this.gbBasketItem.Name = "gbBasketItem";
            this.gbBasketItem.Size = new System.Drawing.Size(525, 225);
            this.gbBasketItem.TabIndex = 2;
            this.gbBasketItem.TabStop = false;
            this.gbBasketItem.Text = "Элемент корзины:";
            // 
            // tbProductDiscount
            // 
            this.tbProductDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbProductDiscount.Location = new System.Drawing.Point(390, 149);
            this.tbProductDiscount.Name = "tbProductDiscount";
            this.tbProductDiscount.ReadOnly = true;
            this.tbProductDiscount.Size = new System.Drawing.Size(75, 29);
            this.tbProductDiscount.TabIndex = 16;
            this.tbProductDiscount.Text = "0";
            // 
            // tbProductSum
            // 
            this.tbProductSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbProductSum.Location = new System.Drawing.Point(155, 149);
            this.tbProductSum.Name = "tbProductSum";
            this.tbProductSum.ReadOnly = true;
            this.tbProductSum.Size = new System.Drawing.Size(75, 29);
            this.tbProductSum.TabIndex = 15;
            this.tbProductSum.Text = "0";
            // 
            // lblProductDiscount
            // 
            this.lblProductDiscount.AutoSize = true;
            this.lblProductDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductDiscount.Location = new System.Drawing.Point(251, 152);
            this.lblProductDiscount.Name = "lblProductDiscount";
            this.lblProductDiscount.Size = new System.Drawing.Size(121, 21);
            this.lblProductDiscount.TabIndex = 15;
            this.lblProductDiscount.Text = "С уч. скидки, %:";
            // 
            // lblProductSum
            // 
            this.lblProductSum.AutoSize = true;
            this.lblProductSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductSum.Location = new System.Drawing.Point(5, 152);
            this.lblProductSum.Name = "lblProductSum";
            this.lblProductSum.Size = new System.Drawing.Size(126, 21);
            this.lblProductSum.TabIndex = 14;
            this.lblProductSum.Text = "Стоимость, руб.:";
            // 
            // nudProductCount
            // 
            this.nudProductCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudProductCount.Location = new System.Drawing.Point(155, 109);
            this.nudProductCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudProductCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudProductCount.Name = "nudProductCount";
            this.nudProductCount.Size = new System.Drawing.Size(120, 29);
            this.nudProductCount.TabIndex = 6;
            this.nudProductCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbProductName
            // 
            this.cbProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.Location = new System.Drawing.Point(155, 68);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(364, 29);
            this.cbProductName.TabIndex = 4;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveChanges.Location = new System.Drawing.Point(305, 107);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(214, 33);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // cbProductType
            // 
            this.cbProductType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(155, 26);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(364, 29);
            this.cbProductType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductName.Location = new System.Drawing.Point(6, 68);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(55, 21);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Товар:";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductType.Location = new System.Drawing.Point(6, 29);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(92, 21);
            this.lblProductType.TabIndex = 0;
            this.lblProductType.Text = "Тип товара:";
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnFinishOrderCreating);
            this.gbActions.Controls.Add(this.button1);
            this.gbActions.Controls.Add(this.btnRemoveItem);
            this.gbActions.Controls.Add(this.btnAddItem);
            this.gbActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbActions.Location = new System.Drawing.Point(3, 3);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(232, 386);
            this.gbActions.TabIndex = 0;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Действия:";
            // 
            // btnFinishOrderCreating
            // 
            this.btnFinishOrderCreating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFinishOrderCreating.Location = new System.Drawing.Point(7, 279);
            this.btnFinishOrderCreating.Name = "btnFinishOrderCreating";
            this.btnFinishOrderCreating.Size = new System.Drawing.Size(214, 73);
            this.btnFinishOrderCreating.TabIndex = 4;
            this.btnFinishOrderCreating.Text = "Оформить заказ";
            this.btnFinishOrderCreating.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(6, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Очистить корзину";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveItem.Location = new System.Drawing.Point(7, 68);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(214, 33);
            this.btnRemoveItem.TabIndex = 1;
            this.btnRemoveItem.Text = "Удалить товар";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddItem.Location = new System.Drawing.Point(7, 29);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(214, 33);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "Добавить новый товар";
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // tpSearch
            // 
            this.tpSearch.Controls.Add(this.spSearch);
            this.tpSearch.Location = new System.Drawing.Point(4, 30);
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpSearch.Size = new System.Drawing.Size(874, 656);
            this.tpSearch.TabIndex = 1;
            this.tpSearch.Text = "Поиск товаров по характеристикам";
            this.tpSearch.UseVisualStyleBackColor = true;
            // 
            // spSearch
            // 
            this.spSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spSearch.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.spSearch.Location = new System.Drawing.Point(6, 6);
            this.spSearch.Name = "spSearch";
            this.spSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spSearch.Panel1
            // 
            this.spSearch.Panel1.Controls.Add(this.gbSearchSettings);
            // 
            // spSearch.Panel2
            // 
            this.spSearch.Panel2.Controls.Add(this.gbSearchResults);
            this.spSearch.Size = new System.Drawing.Size(862, 644);
            this.spSearch.SplitterDistance = 258;
            this.spSearch.TabIndex = 7;
            // 
            // gbSearchSettings
            // 
            this.gbSearchSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchSettings.Controls.Add(this.cbProductTypeSearch);
            this.gbSearchSettings.Controls.Add(this.lblProductTypeSearch);
            this.gbSearchSettings.Controls.Add(this.lblCharacteristicValue);
            this.gbSearchSettings.Controls.Add(this.tbCharacteristicValue);
            this.gbSearchSettings.Controls.Add(this.lblCharacteristicName);
            this.gbSearchSettings.Controls.Add(this.btnSearch);
            this.gbSearchSettings.Controls.Add(this.cbCharacteristicName);
            this.gbSearchSettings.Location = new System.Drawing.Point(3, 3);
            this.gbSearchSettings.Name = "gbSearchSettings";
            this.gbSearchSettings.Size = new System.Drawing.Size(856, 252);
            this.gbSearchSettings.TabIndex = 7;
            this.gbSearchSettings.TabStop = false;
            this.gbSearchSettings.Text = "Параметры поиска:";
            // 
            // cbProductTypeSearch
            // 
            this.cbProductTypeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProductTypeSearch.FormattingEnabled = true;
            this.cbProductTypeSearch.Location = new System.Drawing.Point(223, 28);
            this.cbProductTypeSearch.Name = "cbProductTypeSearch";
            this.cbProductTypeSearch.Size = new System.Drawing.Size(627, 29);
            this.cbProductTypeSearch.TabIndex = 1;
            this.cbProductTypeSearch.SelectedIndexChanged += new System.EventHandler(this.cbProductTypeSearch_SelectedIndexChanged);
            // 
            // lblProductTypeSearch
            // 
            this.lblProductTypeSearch.AutoSize = true;
            this.lblProductTypeSearch.Location = new System.Drawing.Point(12, 36);
            this.lblProductTypeSearch.Name = "lblProductTypeSearch";
            this.lblProductTypeSearch.Size = new System.Drawing.Size(92, 21);
            this.lblProductTypeSearch.TabIndex = 0;
            this.lblProductTypeSearch.Text = "Тип товара:";
            // 
            // lblCharacteristicValue
            // 
            this.lblCharacteristicValue.AutoSize = true;
            this.lblCharacteristicValue.Location = new System.Drawing.Point(12, 139);
            this.lblCharacteristicValue.Name = "lblCharacteristicValue";
            this.lblCharacteristicValue.Size = new System.Drawing.Size(199, 21);
            this.lblCharacteristicValue.TabIndex = 4;
            this.lblCharacteristicValue.Text = "Значение характеристики:";
            // 
            // tbCharacteristicValue
            // 
            this.tbCharacteristicValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCharacteristicValue.Location = new System.Drawing.Point(223, 136);
            this.tbCharacteristicValue.Name = "tbCharacteristicValue";
            this.tbCharacteristicValue.Size = new System.Drawing.Size(627, 29);
            this.tbCharacteristicValue.TabIndex = 5;
            // 
            // lblCharacteristicName
            // 
            this.lblCharacteristicName.AutoSize = true;
            this.lblCharacteristicName.Location = new System.Drawing.Point(12, 81);
            this.lblCharacteristicName.Name = "lblCharacteristicName";
            this.lblCharacteristicName.Size = new System.Drawing.Size(127, 21);
            this.lblCharacteristicName.TabIndex = 2;
            this.lblCharacteristicName.Text = "Характеристика:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(365, 190);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 43);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbCharacteristicName
            // 
            this.cbCharacteristicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCharacteristicName.FormattingEnabled = true;
            this.cbCharacteristicName.Location = new System.Drawing.Point(223, 78);
            this.cbCharacteristicName.Name = "cbCharacteristicName";
            this.cbCharacteristicName.Size = new System.Drawing.Size(627, 29);
            this.cbCharacteristicName.TabIndex = 3;
            // 
            // gbSearchResults
            // 
            this.gbSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchResults.Controls.Add(this.dgvProductByCharacteristics);
            this.gbSearchResults.Location = new System.Drawing.Point(3, 14);
            this.gbSearchResults.Name = "gbSearchResults";
            this.gbSearchResults.Size = new System.Drawing.Size(856, 365);
            this.gbSearchResults.TabIndex = 1;
            this.gbSearchResults.TabStop = false;
            this.gbSearchResults.Text = "Результаты поиска:";
            // 
            // dgvProductByCharacteristics
            // 
            this.dgvProductByCharacteristics.AllowUserToAddRows = false;
            this.dgvProductByCharacteristics.AllowUserToDeleteRows = false;
            this.dgvProductByCharacteristics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductByCharacteristics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductByCharacteristics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductByCharacteristics.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvProductByCharacteristics.Location = new System.Drawing.Point(12, 28);
            this.dgvProductByCharacteristics.Name = "dgvProductByCharacteristics";
            this.dgvProductByCharacteristics.ReadOnly = true;
            this.dgvProductByCharacteristics.RowTemplate.Height = 25;
            this.dgvProductByCharacteristics.Size = new System.Drawing.Size(838, 337);
            this.dgvProductByCharacteristics.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 711);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Интернет-магазин компьютерной техники";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpOrders.ResumeLayout(false);
            this.spOrders.Panel1.ResumeLayout(false);
            this.spOrders.Panel2.ResumeLayout(false);
            this.spOrders.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spOrders)).EndInit();
            this.spOrders.ResumeLayout(false);
            this.pOrderDates.ResumeLayout(false);
            this.pOrderDates.PerformLayout();
            this.pPeriodChoosing.ResumeLayout(false);
            this.pPeriodChoosing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderProducts)).EndInit();
            this.tpCreateOrder.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.gbBasket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.scSettings.Panel1.ResumeLayout(false);
            this.scSettings.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSettings)).EndInit();
            this.scSettings.ResumeLayout(false);
            this.gbOrderSettings.ResumeLayout(false);
            this.gbOrderSettings.PerformLayout();
            this.gbBasketItem.ResumeLayout(false);
            this.gbBasketItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCount)).EndInit();
            this.gbActions.ResumeLayout(false);
            this.tpSearch.ResumeLayout(false);
            this.spSearch.Panel1.ResumeLayout(false);
            this.spSearch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spSearch)).EndInit();
            this.spSearch.ResumeLayout(false);
            this.gbSearchSettings.ResumeLayout(false);
            this.gbSearchSettings.PerformLayout();
            this.gbSearchResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductByCharacteristics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.TabPage tpSearch;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderProducts;
        private System.Windows.Forms.Label lblOrderProducts;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.DateTimePicker dtpOrdersStart;
        private System.Windows.Forms.DateTimePicker dtpOrdersEnd;
        private System.Windows.Forms.SplitContainer spOrders;
        private System.Windows.Forms.Panel pOrderDates;
        private System.Windows.Forms.CheckBox cbOrdersEnd;
        private System.Windows.Forms.CheckBox cbOrdersStart;
        private System.Windows.Forms.RadioButton rbOrdersInDates;
        private System.Windows.Forms.RadioButton rbAllOrders;
        private System.Windows.Forms.Button btnSearchOrders;
        private System.Windows.Forms.Panel pPeriodChoosing;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.TabPage tpCreateOrder;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.GroupBox gbBasket;
        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.SplitContainer scSettings;
        private System.Windows.Forms.GroupBox gbOrderSettings;
        private System.Windows.Forms.TextBox tbOrderDiscount;
        private System.Windows.Forms.Label lblOrderDiscount;
        private System.Windows.Forms.TextBox tbOrderSum;
        private System.Windows.Forms.Label lblOrderSum;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.ComboBox cbPickupPoint;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPickupPoint;
        private System.Windows.Forms.GroupBox gbBasketItem;
        private System.Windows.Forms.TextBox tbProductDiscount;
        private System.Windows.Forms.TextBox tbProductSum;
        private System.Windows.Forms.Label lblProductDiscount;
        private System.Windows.Forms.Label lblProductSum;
        private System.Windows.Forms.NumericUpDown nudProductCount;
        private System.Windows.Forms.ComboBox cbProductName;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnFinishOrderCreating;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.SplitContainer spSearch;
        private System.Windows.Forms.Label lblProductTypeSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCharacteristicName;
        private System.Windows.Forms.Label lblCharacteristicValue;
        private System.Windows.Forms.TextBox tbCharacteristicValue;
        private System.Windows.Forms.ComboBox cbProductTypeSearch;
        private System.Windows.Forms.ComboBox cbCharacteristicName;
        private System.Windows.Forms.DataGridView dgvProductByCharacteristics;
        private System.Windows.Forms.GroupBox gbSearchSettings;
        private System.Windows.Forms.GroupBox gbSearchResults;
    }
}