namespace Shadev
{
    partial class frmCopytoSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopytoSale));
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCustName = new System.Windows.Forms.ComboBox();
            this.txtTax1Percentage = new System.Windows.Forms.TextBox();
            this.txtTax2Percentage = new System.Windows.Forms.TextBox();
            this.lblTax1 = new System.Windows.Forms.Label();
            this.lblTax2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTransNo
            // 
            this.txtTransNo.Location = new System.Drawing.Point(182, 21);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(200, 22);
            this.txtTransNo.TabIndex = 0;
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.CustomFormat = "dd-MM-yyyy";
            this.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransDate.Location = new System.Drawing.Point(184, 143);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.Size = new System.Drawing.Size(200, 22);
            this.dtpTransDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transaction No.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Transaction Date:";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Location = new System.Drawing.Point(184, 82);
            this.cmbTaxType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(200, 24);
            this.cmbTaxType.TabIndex = 34;
            this.cmbTaxType.SelectedIndexChanged += new System.EventHandler(this.cmbTaxType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tax Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Customer Name:";
            // 
            // cmbCustName
            // 
            this.cmbCustName.FormattingEnabled = true;
            this.cmbCustName.Location = new System.Drawing.Point(183, 50);
            this.cmbCustName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCustName.Name = "cmbCustName";
            this.cmbCustName.Size = new System.Drawing.Size(200, 24);
            this.cmbCustName.TabIndex = 37;
            // 
            // txtTax1Percentage
            // 
            this.txtTax1Percentage.Location = new System.Drawing.Point(207, 114);
            this.txtTax1Percentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax1Percentage.Name = "txtTax1Percentage";
            this.txtTax1Percentage.ReadOnly = true;
            this.txtTax1Percentage.Size = new System.Drawing.Size(47, 22);
            this.txtTax1Percentage.TabIndex = 38;
            // 
            // txtTax2Percentage
            // 
            this.txtTax2Percentage.Location = new System.Drawing.Point(337, 114);
            this.txtTax2Percentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax2Percentage.Name = "txtTax2Percentage";
            this.txtTax2Percentage.ReadOnly = true;
            this.txtTax2Percentage.Size = new System.Drawing.Size(47, 22);
            this.txtTax2Percentage.TabIndex = 39;
            // 
            // lblTax1
            // 
            this.lblTax1.AutoSize = true;
            this.lblTax1.Location = new System.Drawing.Point(132, 117);
            this.lblTax1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTax1.Name = "lblTax1";
            this.lblTax1.Size = new System.Drawing.Size(69, 17);
            this.lblTax1.TabIndex = 40;
            this.lblTax1.Text = "Tax1 (%):";
            // 
            // lblTax2
            // 
            this.lblTax2.AutoSize = true;
            this.lblTax2.Location = new System.Drawing.Point(262, 117);
            this.lblTax2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTax2.Name = "lblTax2";
            this.lblTax2.Size = new System.Drawing.Size(69, 17);
            this.lblTax2.TabIndex = 41;
            this.lblTax2.Text = "Tax2 (%):";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(183, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 36);
            this.btnSave.TabIndex = 42;
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
            this.btnCancel.Location = new System.Drawing.Point(286, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 36);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCopytoSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 235);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTax1Percentage);
            this.Controls.Add(this.txtTax2Percentage);
            this.Controls.Add(this.lblTax1);
            this.Controls.Add(this.lblTax2);
            this.Controls.Add(this.cmbCustName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTaxType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTransDate);
            this.Controls.Add(this.txtTransNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopytoSale";
            this.ShowInTaskbar = false;
            this.Text = "Enter New Details:";
            this.Load += new System.EventHandler(this.frmCopytoSale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransNo;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustName;
        private System.Windows.Forms.TextBox txtTax1Percentage;
        private System.Windows.Forms.TextBox txtTax2Percentage;
        private System.Windows.Forms.Label lblTax1;
        private System.Windows.Forms.Label lblTax2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}