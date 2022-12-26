
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.tpCPUSearch = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pOrderDates.SuspendLayout();
            this.pPeriodChoosing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpOrders);
            this.tabControl1.Controls.Add(this.tpCPUSearch);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // tpOrders
            // 
            this.tpOrders.Controls.Add(this.splitContainer1);
            this.tpOrders.Location = new System.Drawing.Point(4, 30);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(874, 407);
            this.tpOrders.TabIndex = 0;
            this.tpOrders.Text = "Просмотр заказов";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pOrderDates);
            this.splitContainer1.Panel1.Controls.Add(this.dgvOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelOrder);
            this.splitContainer1.Panel2.Controls.Add(this.lblOrderProducts);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateOrder);
            this.splitContainer1.Panel2.Controls.Add(this.dgvOrderProducts);
            this.splitContainer1.Size = new System.Drawing.Size(862, 395);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 8;
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
            this.dgvOrders.Size = new System.Drawing.Size(844, 116);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelOrder.Location = new System.Drawing.Point(212, 183);
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
            this.btnCreateOrder.Location = new System.Drawing.Point(6, 183);
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
            this.dgvOrderProducts.Size = new System.Drawing.Size(844, 133);
            this.dgvOrderProducts.TabIndex = 0;
            // 
            // tpCPUSearch
            // 
            this.tpCPUSearch.Location = new System.Drawing.Point(4, 30);
            this.tpCPUSearch.Name = "tpCPUSearch";
            this.tpCPUSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpCPUSearch.Size = new System.Drawing.Size(874, 407);
            this.tpCPUSearch.TabIndex = 1;
            this.tpCPUSearch.Text = "Поиск копьютеров по процессорам";
            this.tpCPUSearch.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 463);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Интернет-магазин компьютерной техники";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpOrders.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pOrderDates.ResumeLayout(false);
            this.pOrderDates.PerformLayout();
            this.pPeriodChoosing.ResumeLayout(false);
            this.pPeriodChoosing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.TabPage tpCPUSearch;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderProducts;
        private System.Windows.Forms.Label lblOrderProducts;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.DateTimePicker dtpOrdersStart;
        private System.Windows.Forms.DateTimePicker dtpOrdersEnd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pOrderDates;
        private System.Windows.Forms.CheckBox cbOrdersEnd;
        private System.Windows.Forms.CheckBox cbOrdersStart;
        private System.Windows.Forms.RadioButton rbOrdersInDates;
        private System.Windows.Forms.RadioButton rbAllOrders;
        private System.Windows.Forms.Button btnSearchOrders;
        private System.Windows.Forms.Panel pPeriodChoosing;
        private System.Windows.Forms.Button btnCreateOrder;
    }
}