
namespace OnlineEquipmentSalesApp
{
    partial class Form3
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
            this.gbBasketItem = new System.Windows.Forms.GroupBox();
            this.nudProductCount = new System.Windows.Forms.NumericUpDown();
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.scSettings = new System.Windows.Forms.SplitContainer();
            this.gbOrderSettings = new System.Windows.Forms.GroupBox();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.cbPickupPoint = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPickupPoint = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinishOrderCreating = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.gbBasket = new System.Windows.Forms.GroupBox();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gbBasketItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scSettings)).BeginInit();
            this.scSettings.Panel1.SuspendLayout();
            this.scSettings.Panel2.SuspendLayout();
            this.scSettings.SuspendLayout();
            this.gbOrderSettings.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.gbBasket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBasketItem
            // 
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
            this.gbBasketItem.Size = new System.Drawing.Size(525, 163);
            this.gbBasketItem.TabIndex = 2;
            this.gbBasketItem.TabStop = false;
            this.gbBasketItem.Text = "Элемент корзины:";
            // 
            // nudProductCount
            // 
            this.nudProductCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudProductCount.Location = new System.Drawing.Point(155, 113);
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
            this.btnSaveChanges.Location = new System.Drawing.Point(305, 111);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(214, 33);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // cbProductType
            // 
            this.cbProductType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(155, 26);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(364, 29);
            this.cbProductType.TabIndex = 3;
            this.cbProductType.SelectedIndexChanged += new System.EventHandler(this.cbProductType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 113);
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
            // scSettings
            // 
            this.scSettings.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.scSettings.Size = new System.Drawing.Size(776, 296);
            this.scSettings.SplitterDistance = 531;
            this.scSettings.TabIndex = 3;
            // 
            // gbOrderSettings
            // 
            this.gbOrderSettings.Controls.Add(this.cbPaymentMethod);
            this.gbOrderSettings.Controls.Add(this.cbPickupPoint);
            this.gbOrderSettings.Controls.Add(this.lblPaymentMethod);
            this.gbOrderSettings.Controls.Add(this.lblPickupPoint);
            this.gbOrderSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbOrderSettings.Location = new System.Drawing.Point(3, 172);
            this.gbOrderSettings.Name = "gbOrderSettings";
            this.gbOrderSettings.Size = new System.Drawing.Size(525, 121);
            this.gbOrderSettings.TabIndex = 3;
            this.gbOrderSettings.TabStop = false;
            this.gbOrderSettings.Text = "Заказ:";
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
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnCancel);
            this.gbActions.Controls.Add(this.btnFinishOrderCreating);
            this.gbActions.Controls.Add(this.button1);
            this.gbActions.Controls.Add(this.btnRemoveItem);
            this.gbActions.Controls.Add(this.btnAddItem);
            this.gbActions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbActions.Location = new System.Drawing.Point(3, 3);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(232, 290);
            this.gbActions.TabIndex = 0;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Действия:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(6, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отменить оформление";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnFinishOrderCreating
            // 
            this.btnFinishOrderCreating.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFinishOrderCreating.Location = new System.Drawing.Point(6, 199);
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
            // gbBasket
            // 
            this.gbBasket.Controls.Add(this.dgvBasket);
            this.gbBasket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbBasket.Location = new System.Drawing.Point(3, 3);
            this.gbBasket.Name = "gbBasket";
            this.gbBasket.Size = new System.Drawing.Size(767, 278);
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
            this.dgvBasket.Size = new System.Drawing.Size(746, 241);
            this.dgvBasket.TabIndex = 0;
            // 
            // scMain
            // 
            this.scMain.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.scMain.IsSplitterFixed = true;
            this.scMain.Location = new System.Drawing.Point(12, 12);
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
            this.scMain.Size = new System.Drawing.Size(776, 590);
            this.scMain.SplitterDistance = 284;
            this.scMain.TabIndex = 5;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.scMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление заказа";
            this.gbBasketItem.ResumeLayout(false);
            this.gbBasketItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCount)).EndInit();
            this.scSettings.Panel1.ResumeLayout(false);
            this.scSettings.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSettings)).EndInit();
            this.scSettings.ResumeLayout(false);
            this.gbOrderSettings.ResumeLayout(false);
            this.gbOrderSettings.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.gbBasket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbBasketItem;
        private System.Windows.Forms.SplitContainer scSettings;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbProductName;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.GroupBox gbOrderSettings;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.ComboBox cbPickupPoint;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPickupPoint;
        private System.Windows.Forms.Button btnFinishOrderCreating;
        private System.Windows.Forms.GroupBox gbBasket;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.NumericUpDown nudProductCount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvBasket;
    }
}