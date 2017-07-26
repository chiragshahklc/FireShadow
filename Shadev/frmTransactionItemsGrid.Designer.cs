namespace Shadev
{
    partial class frmTransactionItemsGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionItemsGrid));
            this.cmbComapny = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTax1Amount = new System.Windows.Forms.TextBox();
            this.txtTax1Percentage = new System.Windows.Forms.TextBox();
            this.txtTax2Percentage = new System.Windows.Forms.TextBox();
            this.txtTax2Amount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCurrStock = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbComapny
            // 
            this.cmbComapny.FormattingEnabled = true;
            this.cmbComapny.Location = new System.Drawing.Point(87, 8);
            this.cmbComapny.Margin = new System.Windows.Forms.Padding(4);
            this.cmbComapny.Name = "cmbComapny";
            this.cmbComapny.Size = new System.Drawing.Size(363, 24);
            this.cmbComapny.TabIndex = 1;
            this.cmbComapny.SelectedIndexChanged += new System.EventHandler(this.cmbComapny_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(87, 40);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(363, 24);
            this.cmbCategory.TabIndex = 2;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(87, 76);
            this.cmbModel.Margin = new System.Windows.Forms.Padding(4);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(363, 24);
            this.cmbModel.TabIndex = 3;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            this.cmbModel.Leave += new System.EventHandler(this.cmbModel_Leave);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(149, 182);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(363, 22);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtTax1Amount
            // 
            this.txtTax1Amount.Location = new System.Drawing.Point(210, 405);
            this.txtTax1Amount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax1Amount.Name = "txtTax1Amount";
            this.txtTax1Amount.ReadOnly = true;
            this.txtTax1Amount.Size = new System.Drawing.Size(300, 22);
            this.txtTax1Amount.TabIndex = 44;
            this.txtTax1Amount.Visible = false;
            // 
            // txtTax1Percentage
            // 
            this.txtTax1Percentage.Location = new System.Drawing.Point(148, 405);
            this.txtTax1Percentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax1Percentage.Name = "txtTax1Percentage";
            this.txtTax1Percentage.ReadOnly = true;
            this.txtTax1Percentage.Size = new System.Drawing.Size(53, 22);
            this.txtTax1Percentage.TabIndex = 66;
            this.txtTax1Percentage.Visible = false;
            this.txtTax1Percentage.Leave += new System.EventHandler(this.txtTax1Percentage_Leave);
            // 
            // txtTax2Percentage
            // 
            this.txtTax2Percentage.Location = new System.Drawing.Point(148, 437);
            this.txtTax2Percentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax2Percentage.Name = "txtTax2Percentage";
            this.txtTax2Percentage.ReadOnly = true;
            this.txtTax2Percentage.Size = new System.Drawing.Size(53, 22);
            this.txtTax2Percentage.TabIndex = 77;
            this.txtTax2Percentage.Visible = false;
            this.txtTax2Percentage.Leave += new System.EventHandler(this.txtTax2Percentage_Leave);
            // 
            // txtTax2Amount
            // 
            this.txtTax2Amount.Location = new System.Drawing.Point(211, 437);
            this.txtTax2Amount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax2Amount.Name = "txtTax2Amount";
            this.txtTax2Amount.ReadOnly = true;
            this.txtTax2Amount.Size = new System.Drawing.Size(300, 22);
            this.txtTax2Amount.TabIndex = 45;
            this.txtTax2Amount.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(148, 469);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(363, 22);
            this.txtTotal.TabIndex = 88;
            this.txtTotal.Visible = false;
            this.txtTotal.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(149, 152);
            this.txtqty.Margin = new System.Windows.Forms.Padding(4);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(363, 22);
            this.txtqty.TabIndex = 4;
            this.txtqty.Leave += new System.EventHandler(this.txtqty_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Company:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Qty:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 409);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tax1 (%):";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 441);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tax2 (%):";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 473);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Total:";
            this.label8.Visible = false;
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(149, 212);
            this.rtbDesc.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(363, 117);
            this.rtbDesc.TabIndex = 6;
            this.rtbDesc.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 266);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Description:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbComapny);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Controls.Add(this.cmbModel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(60, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 123);
            this.panel1.TabIndex = 0;
            // 
            // txtCurrStock
            // 
            this.txtCurrStock.Location = new System.Drawing.Point(13, 104);
            this.txtCurrStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrStock.Name = "txtCurrStock";
            this.txtCurrStock.ReadOnly = true;
            this.txtCurrStock.Size = new System.Drawing.Size(40, 22);
            this.txtCurrStock.TabIndex = 89;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(149, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Teal;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(255, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 91;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTransactionItemsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(529, 507);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCurrStock);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtqty);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtTax2Percentage);
            this.Controls.Add(this.txtTax2Amount);
            this.Controls.Add(this.txtTax1Percentage);
            this.Controls.Add(this.txtTax1Amount);
            this.Controls.Add(this.txtPrice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransactionItemsGrid";
            this.ShowInTaskbar = false;
            this.Text = "Items of Transaction";
            this.Load += new System.EventHandler(this.frmTransactionItemsGrid_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbComapny;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTax1Amount;
        private System.Windows.Forms.TextBox txtTax1Percentage;
        private System.Windows.Forms.TextBox txtTax2Percentage;
        private System.Windows.Forms.TextBox txtTax2Amount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCurrStock;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}