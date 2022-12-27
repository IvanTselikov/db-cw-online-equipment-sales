
namespace OnlineEquipmentSalesApp
{
    partial class Form1
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
            this.gbOrderSettings = new System.Windows.Forms.GroupBox();
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
            this.gbOrderSettings.SuspendLayout();
            this.gbBasketItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOrderSettings
            // 
            this.gbOrderSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOrderSettings.Controls.Add(this.cbPaymentMethod);
            this.gbOrderSettings.Controls.Add(this.cbPickupPoint);
            this.gbOrderSettings.Controls.Add(this.lblPaymentMethod);
            this.gbOrderSettings.Controls.Add(this.lblPickupPoint);
            this.gbOrderSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbOrderSettings.Location = new System.Drawing.Point(161, 271);
            this.gbOrderSettings.Name = "gbOrderSettings";
            this.gbOrderSettings.Size = new System.Drawing.Size(472, 140);
            this.gbOrderSettings.TabIndex = 9;
            this.gbOrderSettings.TabStop = false;
            this.gbOrderSettings.Text = "Заказ:";
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(155, 74);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(583, 29);
            this.cbPaymentMethod.TabIndex = 7;
            // 
            // cbPickupPoint
            // 
            this.cbPickupPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPickupPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPickupPoint.FormattingEnabled = true;
            this.cbPickupPoint.Location = new System.Drawing.Point(155, 27);
            this.cbPickupPoint.Name = "cbPickupPoint";
            this.cbPickupPoint.Size = new System.Drawing.Size(583, 29);
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
            this.gbBasketItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbBasketItem.Location = new System.Drawing.Point(161, 40);
            this.gbBasketItem.Name = "gbBasketItem";
            this.gbBasketItem.Size = new System.Drawing.Size(478, 225);
            this.gbBasketItem.TabIndex = 8;
            this.gbBasketItem.TabStop = false;
            this.gbBasketItem.Text = "Элемент корзины:";
            // 
            // tbProductDiscount
            // 
            this.tbProductDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProductDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbProductDiscount.Location = new System.Drawing.Point(675, 149);
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
            this.lblProductDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductDiscount.AutoSize = true;
            this.lblProductDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductDiscount.Location = new System.Drawing.Point(548, 152);
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
            this.nudProductCount.Size = new System.Drawing.Size(75, 29);
            this.nudProductCount.TabIndex = 6;
            this.nudProductCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbProductName
            // 
            this.cbProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.Location = new System.Drawing.Point(155, 68);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(595, 29);
            this.cbProductName.TabIndex = 4;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveChanges.Location = new System.Drawing.Point(530, 107);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(220, 33);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // cbProductType
            // 
            this.cbProductType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProductType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(155, 26);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(595, 29);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbOrderSettings);
            this.Controls.Add(this.gbBasketItem);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbOrderSettings.ResumeLayout(false);
            this.gbOrderSettings.PerformLayout();
            this.gbBasketItem.ResumeLayout(false);
            this.gbBasketItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProductCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrderSettings;
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
    }
}