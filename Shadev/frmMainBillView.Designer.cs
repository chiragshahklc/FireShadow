namespace Shadev
{
    partial class frmMainBillView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainBillView));
            this.crvMainBill = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvMainBill
            // 
            this.crvMainBill.ActiveViewIndex = -1;
            this.crvMainBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMainBill.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvMainBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMainBill.Location = new System.Drawing.Point(0, 0);
            this.crvMainBill.Name = "crvMainBill";
            this.crvMainBill.ShowGroupTreeButton = false;
            this.crvMainBill.ShowLogo = false;
            this.crvMainBill.ShowParameterPanelButton = false;
            this.crvMainBill.Size = new System.Drawing.Size(1262, 653);
            this.crvMainBill.TabIndex = 0;
            this.crvMainBill.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmMainBillView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1262, 653);
            this.Controls.Add(this.crvMainBill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainBillView";
            this.ShowInTaskbar = false;
            this.Text = "Bill View";
            this.Load += new System.EventHandler(this.frmMainBillView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMainBill;
    }
}