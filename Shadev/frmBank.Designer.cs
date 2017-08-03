namespace Shadev
{
    partial class frmBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBank));
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtACNO = new System.Windows.Forms.TextBox();
            this.txtBankBranch = new System.Windows.Forms.TextBox();
            this.txtBankIFSC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCencel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(140, 34);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(304, 22);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBankName_KeyPress);
            // 
            // txtACNO
            // 
            this.txtACNO.Location = new System.Drawing.Point(140, 66);
            this.txtACNO.Margin = new System.Windows.Forms.Padding(4);
            this.txtACNO.Name = "txtACNO";
            this.txtACNO.Size = new System.Drawing.Size(304, 22);
            this.txtACNO.TabIndex = 1;
            // 
            // txtBankBranch
            // 
            this.txtBankBranch.Location = new System.Drawing.Point(140, 98);
            this.txtBankBranch.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankBranch.Name = "txtBankBranch";
            this.txtBankBranch.Size = new System.Drawing.Size(304, 22);
            this.txtBankBranch.TabIndex = 2;
            // 
            // txtBankIFSC
            // 
            this.txtBankIFSC.Location = new System.Drawing.Point(140, 130);
            this.txtBankIFSC.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankIFSC.Name = "txtBankIFSC";
            this.txtBankIFSC.Size = new System.Drawing.Size(304, 22);
            this.txtBankIFSC.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "A/C No.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Branch:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "IFSC:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.xButtons1_Click);
            // 
            // btnCencel
            // 
            this.btnCencel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCencel.BackColor = System.Drawing.Color.Teal;
            this.btnCencel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCencel.ForeColor = System.Drawing.Color.White;
            this.btnCencel.Location = new System.Drawing.Point(246, 189);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(100, 29);
            this.btnCencel.TabIndex = 14;
            this.btnCencel.Text = "Cancel";
            this.btnCencel.UseVisualStyleBackColor = false;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Opening Balance:";
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.Location = new System.Drawing.Point(140, 160);
            this.txtOpeningBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.Size = new System.Drawing.Size(304, 22);
            this.txtOpeningBalance.TabIndex = 15;
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(486, 241);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOpeningBalance);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBankIFSC);
            this.Controls.Add(this.txtBankBranch);
            this.Controls.Add(this.txtACNO);
            this.Controls.Add(this.txtBankName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBank";
            this.ShowInTaskbar = false;
            this.Text = "Bank";
            this.Load += new System.EventHandler(this.frmBank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.TextBox txtACNO;
        private System.Windows.Forms.TextBox txtBankBranch;
        private System.Windows.Forms.TextBox txtBankIFSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOpeningBalance;
    }
}