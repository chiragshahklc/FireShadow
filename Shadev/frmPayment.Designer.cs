namespace Shadev
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.cmbmethod = new System.Windows.Forms.ComboBox();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPayType = new System.Windows.Forms.ComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbmethod
            // 
            this.cmbmethod.FormattingEnabled = true;
            this.cmbmethod.Items.AddRange(new object[] {
            "CASH",
            "Cheque"});
            this.cmbmethod.Location = new System.Drawing.Point(173, 73);
            this.cmbmethod.Margin = new System.Windows.Forms.Padding(4);
            this.cmbmethod.Name = "cmbmethod";
            this.cmbmethod.Size = new System.Drawing.Size(207, 24);
            this.cmbmethod.TabIndex = 3;
            this.cmbmethod.Text = "Select Method";
            this.cmbmethod.SelectedIndexChanged += new System.EventHandler(this.cmbmethod_SelectedIndexChanged);
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Enabled = false;
            this.txtCheckNo.Location = new System.Drawing.Point(173, 137);
            this.txtCheckNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(207, 22);
            this.txtCheckNo.TabIndex = 5;
            // 
            // txtAmt
            // 
            this.txtAmt.Enabled = false;
            this.txtAmt.Location = new System.Drawing.Point(173, 169);
            this.txtAmt.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(207, 22);
            this.txtAmt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cash Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cheque No.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 210);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(173, 205);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Outstanding:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 43);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(207, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Payment Type:";
            // 
            // cmbPayType
            // 
            this.cmbPayType.FormattingEnabled = true;
            this.cmbPayType.Items.AddRange(new object[] {
            "Paid",
            "Receive"});
            this.cmbPayType.Location = new System.Drawing.Point(173, 105);
            this.cmbPayType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPayType.Name = "cmbPayType";
            this.cmbPayType.Size = new System.Drawing.Size(207, 24);
            this.cmbPayType.TabIndex = 4;
            this.cmbPayType.Text = "Select Type";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(173, 13);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(207, 22);
            this.txtCustomer.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Name:";
            // 
            // rtbDesc
            // 
            this.rtbDesc.Location = new System.Drawing.Point(173, 233);
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.Size = new System.Drawing.Size(207, 96);
            this.rtbDesc.TabIndex = 8;
            this.rtbDesc.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(83, 236);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Description:";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.Teal;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(173, 335);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 29);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Teal;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(280, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(445, 394);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPayType);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.cmbmethod);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.ShowInTaskbar = false;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbmethod;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPayType;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnCancel;
    }
}