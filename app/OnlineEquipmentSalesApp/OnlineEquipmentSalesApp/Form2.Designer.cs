
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
            this.lblOrdersStart = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblOrdersEnd = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dgwOrders = new System.Windows.Forms.DataGridView();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.lblOrderProducts = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.dgwOrderProducts = new System.Windows.Forms.DataGridView();
            this.tpCPUSearch = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblOrdersStart);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.lblOrdersEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker2);
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
            // lblOrdersStart
            // 
            this.lblOrdersStart.AutoSize = true;
            this.lblOrdersStart.Location = new System.Drawing.Point(6, 10);
            this.lblOrdersStart.Name = "lblOrdersStart";
            this.lblOrdersStart.Size = new System.Drawing.Size(75, 21);
            this.lblOrdersStart.TabIndex = 6;
            this.lblOrdersStart.Text = "Заказы с:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // lblOrdersEnd
            // 
            this.lblOrdersEnd.AutoSize = true;
            this.lblOrdersEnd.Location = new System.Drawing.Point(293, 10);
            this.lblOrdersEnd.Name = "lblOrdersEnd";
            this.lblOrdersEnd.Size = new System.Drawing.Size(31, 21);
            this.lblOrdersEnd.TabIndex = 7;
            this.lblOrdersEnd.Text = "до:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(330, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker2.TabIndex = 8;
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
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblOrdersStart;
        private System.Windows.Forms.Label lblOrdersEnd;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}