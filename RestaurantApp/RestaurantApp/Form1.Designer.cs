namespace RestaurantApp

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
            this.cmbMenuItems = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.gridOrderItems = new System.Windows.Forms.DataGridView();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMenuItems
            // 
            this.cmbMenuItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenuItems.FormattingEnabled = true;
            this.cmbMenuItems.Location = new System.Drawing.Point(12, 12);
            this.cmbMenuItems.Name = "cmbMenuItems";
            this.cmbMenuItems.Size = new System.Drawing.Size(200, 21);
            this.cmbMenuItems.TabIndex = 0;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(234, 12);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(60, 20);
            this.numQuantity.TabIndex = 1;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(334, 12);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(80, 23);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // gridOrderItems
            // 
            this.gridOrderItems.AllowUserToAddRows = false;
            this.gridOrderItems.AllowUserToDeleteRows = false;
            this.gridOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrderItems.Location = new System.Drawing.Point(12, 145);
            this.gridOrderItems.Name = "gridOrderItems";
            this.gridOrderItems.ReadOnly = true;
            this.gridOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOrderItems.Size = new System.Drawing.Size(776, 250);
            this.gridOrderItems.TabIndex = 3;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLabel.Location = new System.Drawing.Point(13, 413);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(47, 16);
            this.lblTotalLabel.TabIndex = 4;
            this.lblTotalLabel.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(83, 413);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 16);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0.00";
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Location = new System.Drawing.Point(554, 413);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(100, 23);
            this.btnSubmitOrder.TabIndex = 6;
            this.btnSubmitOrder.Text = "Submit Order";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(688, 413);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(100, 23);
            this.btnCancelOrder.TabIndex = 7;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnSubmitOrder);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.gridOrderItems);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbMenuItems);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMenuItems;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView gridOrderItems;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.Button btnCancelOrder;
    }
}

