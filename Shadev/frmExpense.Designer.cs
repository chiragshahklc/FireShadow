namespace Shadev
{
    partial class frmExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpense));
            this.dtpExpense = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.txtExpenseName = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpExpense
            // 
            this.dtpExpense.CustomFormat = "dd-MM-yyyy";
            this.dtpExpense.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpense.Location = new System.Drawing.Point(168, 95);
            this.dtpExpense.Name = "dtpExpense";
            this.dtpExpense.Size = new System.Drawing.Size(200, 22);
            this.dtpExpense.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Amount:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(54, 30);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(107, 17);
            this.lbl1.TabIndex = 16;
            this.lbl1.Text = "Expense Name:";
            // 
            // txtAmt
            // 
            this.txtAmt.Location = new System.Drawing.Point(168, 59);
            this.txtAmt.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(207, 22);
            this.txtAmt.TabIndex = 2;
            // 
            // txtExpenseName
            // 
            this.txtExpenseName.Location = new System.Drawing.Point(168, 27);
            this.txtExpenseName.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpenseName.Name = "txtExpenseName";
            this.txtExpenseName.Size = new System.Drawing.Size(207, 22);
            this.txtExpenseName.TabIndex = 1;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.Teal;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(169, 132);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(99, 29);
            this.btnsave.TabIndex = 30;
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
            this.btnCancel.Location = new System.Drawing.Point(274, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 29);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(451, 196);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.dtpExpense);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.txtExpenseName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExpense";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpExpense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.TextBox txtExpenseName;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnCancel;
    }
}