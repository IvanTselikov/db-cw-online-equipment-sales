
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
            this.dtpOrdersStart = new System.Windows.Forms.DateTimePicker();
            this.dtpOrdersEnd = new System.Windows.Forms.DateTimePicker();
            this.dgwOrders = new System.Windows.Forms.DataGridView();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.lblOrderProducts = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.dgwOrderProducts = new System.Windows.Forms.DataGridView();
            this.tpCPUSearch = new System.Windows.Forms.TabPage();
            this.cbOrdersStart = new System.Windows.Forms.CheckBox();
            this.cbOrdersEnd = new System.Windows.Forms.CheckBox();
            this.rbAllOrders = new System.Windows.Forms.RadioButton();
            this.rbOrdersInDates = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pOrderDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOrderProducts)).BeginInit();
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
            this.tpOrders.Text = "Заказы";
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
            this.splitContainer1.Panel1.Controls.Add(this.dgwOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelOrder);
            this.splitContainer1.Panel2.Controls.Add(this.lblOrderProducts);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateOrder);
            this.splitContainer1.Panel2.Controls.Add(this.dgwOrderProducts);
            this.splitContainer1.Size = new System.Drawing.Size(862, 395);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 8;
            // 
            // pOrderDates
            // 
            this.pOrderDates.Controls.Add(this.dtpOrdersEnd);
            this.pOrderDates.Controls.Add(this.rbOrdersInDates);
            this.pOrderDates.Controls.Add(this.rbAllOrders);
            this.pOrderDates.Controls.Add(this.cbOrdersEnd);
            this.pOrderDates.Controls.Add(this.cbOrdersStart);
            this.pOrderDates.Controls.Add(this.dtpOrdersStart);
            this.pOrderDates.Location = new System.Drawing.Point(9, 3);
            this.pOrderDates.Name = "pOrderDates";
            this.pOrderDates.Size = new System.Drawing.Size(786, 32);
            this.pOrderDates.TabIndex = 9;
            // 
            // dtpOrdersStart
            // 
            this.dtpOrdersStart.Enabled = false;
            this.dtpOrdersStart.Location = new System.Drawing.Point(215, 1);
            this.dtpOrdersStart.Name = "dtpOrdersStart";
            this.dtpOrdersStart.Size = new System.Drawing.Size(200, 29);
            this.dtpOrdersStart.TabIndex = 5;
            // 
            // dtpOrdersEnd
            // 
            this.dtpOrdersEnd.Enabled = false;
            this.dtpOrdersEnd.Location = new System.Drawing.Point(477, 1);
            this.dtpOrdersEnd.Name = "dtpOrdersEnd";
            this.dtpOrdersEnd.Size = new System.Drawing.Size(200, 29);
            this.dtpOrdersEnd.TabIndex = 8;
            // 
            // dgwOrders
            // 
            this.dgwOrders.AllowUserToAddRows = false;
            this.dgwOrders.AllowUserToDeleteRows = false;
            this.dgwOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOrders.Location = new System.Drawing.Point(9, 41);
            this.dgwOrders.Name = "dgwOrders";
            this.dgwOrders.ReadOnly = true;
            this.dgwOrders.RowTemplate.Height = 25;
            this.dgwOrders.Size = new System.Drawing.Size(844, 115);
            this.dgwOrders.TabIndex = 1;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelOrder.Enabled = false;
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelOrder.Location = new System.Drawing.Point(212, 196);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(200, 33);
            this.btnCancelOrder.TabIndex = 4;
            this.btnCancelOrder.Text = "Отменить заказ...";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            // 
            // lblOrderProducts
            // 
            this.lblOrderProducts.AutoSize = true;
            this.lblOrderProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderProducts.Location = new System.Drawing.Point(6, 10);
            this.lblOrderProducts.Name = "lblOrderProducts";
            this.lblOrderProducts.Size = new System.Drawing.Size(157, 21);
            this.lblOrderProducts.TabIndex = 2;
            this.lblOrderProducts.Text = "Содержимое заказа:";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateOrder.Location = new System.Drawing.Point(6, 196);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(200, 33);
            this.btnCreateOrder.TabIndex = 3;
            this.btnCreateOrder.Text = "Оформить заказ...";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // dgwOrderProducts
            // 
            this.dgwOrderProducts.AllowUserToAddRows = false;
            this.dgwOrderProducts.AllowUserToDeleteRows = false;
            this.dgwOrderProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwOrderProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOrderProducts.Location = new System.Drawing.Point(9, 34);
            this.dgwOrderProducts.Name = "dgwOrderProducts";
            this.dgwOrderProducts.ReadOnly = true;
            this.dgwOrderProducts.RowTemplate.Height = 25;
            this.dgwOrderProducts.Size = new System.Drawing.Size(844, 146);
            this.dgwOrderProducts.TabIndex = 0;
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
            // cbOrdersStart
            // 
            this.cbOrdersStart.AutoSize = true;
            this.cbOrdersStart.Enabled = false;
            this.cbOrdersStart.Location = new System.Drawing.Point(171, 5);
            this.cbOrdersStart.Name = "cbOrdersStart";
            this.cbOrdersStart.Size = new System.Drawing.Size(39, 25);
            this.cbOrdersStart.TabIndex = 1;
            this.cbOrdersStart.Text = "c:";
            this.cbOrdersStart.UseVisualStyleBackColor = true;
            this.cbOrdersStart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbOrdersEnd
            // 
            this.cbOrdersEnd.AutoSize = true;
            this.cbOrdersEnd.Enabled = false;
            this.cbOrdersEnd.Location = new System.Drawing.Point(421, 5);
            this.cbOrdersEnd.Name = "cbOrdersEnd";
            this.cbOrdersEnd.Size = new System.Drawing.Size(50, 25);
            this.cbOrdersEnd.TabIndex = 2;
            this.cbOrdersEnd.Text = "по:";
            this.cbOrdersEnd.UseVisualStyleBackColor = true;
            // 
            // rbAllOrders
            // 
            this.rbAllOrders.AutoSize = true;
            this.rbAllOrders.Checked = true;
            this.rbAllOrders.Location = new System.Drawing.Point(3, 3);
            this.rbAllOrders.Name = "rbAllOrders";
            this.rbAllOrders.Size = new System.Drawing.Size(51, 25);
            this.rbAllOrders.TabIndex = 0;
            this.rbAllOrders.TabStop = true;
            this.rbAllOrders.Text = "все";
            this.rbAllOrders.UseVisualStyleBackColor = true;
            // 
            // rbOrdersInDates
            // 
            this.rbOrdersInDates.AutoSize = true;
            this.rbOrdersInDates.Location = new System.Drawing.Point(60, 4);
            this.rbOrdersInDates.Name = "rbOrdersInDates";
            this.rbOrdersInDates.Size = new System.Drawing.Size(93, 25);
            this.rbOrdersInDates.TabIndex = 1;
            this.rbOrdersInDates.Text = "в период";
            this.rbOrdersInDates.UseVisualStyleBackColor = true;
            this.rbOrdersInDates.CheckedChanged += new System.EventHandler(this.rbOrdersInDates_CheckedChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgwOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOrderProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.TabPage tpCPUSearch;
        private System.Windows.Forms.DataGridView dgwOrders;
        private System.Windows.Forms.DataGridView dgwOrderProducts;
        private System.Windows.Forms.Label lblOrderProducts;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.DateTimePicker dtpOrdersStart;
        private System.Windows.Forms.DateTimePicker dtpOrdersEnd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pOrderDates;
        private System.Windows.Forms.CheckBox cbOrdersEnd;
        private System.Windows.Forms.CheckBox cbOrdersStart;
        private System.Windows.Forms.RadioButton rbOrdersInDates;
        private System.Windows.Forms.RadioButton rbAllOrders;
    }
}