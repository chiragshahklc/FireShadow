namespace Shadev
{
    partial class frmLRReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLRReport));
            this.crvLrReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPayCust = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // crvLrReport
            // 
            this.crvLrReport.ActiveViewIndex = -1;
            this.crvLrReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crvLrReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLrReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLrReport.DisplayStatusBar = false;
            this.crvLrReport.Location = new System.Drawing.Point(15, 108);
            this.crvLrReport.Margin = new System.Windows.Forms.Padding(4);
            this.crvLrReport.Name = "crvLrReport";
            this.crvLrReport.ShowCloseButton = false;
            this.crvLrReport.ShowGotoPageButton = false;
            this.crvLrReport.ShowGroupTreeButton = false;
            this.crvLrReport.ShowLogo = false;
            this.crvLrReport.Size = new System.Drawing.Size(1299, 592);
            this.crvLrReport.TabIndex = 0;
            this.crvLrReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd-MM-yyyy";
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(276, 59);
            this.fromDate.Margin = new System.Windows.Forms.Padding(4);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(265, 22);
            this.fromDate.TabIndex = 1;
            // 
            // toDate
            // 
            this.toDate.CustomFormat = "dd-MM-yyyy";
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.Location = new System.Drawing.Point(584, 59);
            this.toDate.Margin = new System.Windows.Forms.Padding(4);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(265, 22);
            this.toDate.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(857, 56);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPayCust
            // 
            this.btnPayCust.BackColor = System.Drawing.Color.Teal;
            this.btnPayCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayCust.ForeColor = System.Drawing.Color.White;
            this.btnPayCust.Location = new System.Drawing.Point(857, 18);
            this.btnPayCust.Name = "btnPayCust";
            this.btnPayCust.Size = new System.Drawing.Size(118, 31);
            this.btnPayCust.TabIndex = 17;
            this.btnPayCust.Text = "Customer";
            this.btnPayCust.UseVisualStyleBackColor = false;
            this.btnPayCust.Click += new System.EventHandler(this.btnPayCust_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(550, 64);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 17);
            this.label24.TabIndex = 19;
            this.label24.Text = "To";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(227, 64);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 17);
            this.label20.TabIndex = 18;
            this.label20.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Select:";
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(276, 24);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(573, 24);
            this.cmbCustomerName.TabIndex = 21;
            // 
            // frmLRReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 713);
            this.Controls.Add(this.cmbCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnPayCust);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.crvLrReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "frmLRReport";
            this.ShowInTaskbar = false;
            this.Text = "Ledger Report";
            this.Load += new System.EventHandler(this.frmLRReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLrReport;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPayCust;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomerName;
    }
}