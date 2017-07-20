namespace Shadev
{
    partial class frmpaymentreport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpaymentreport));
            this.crvPyamentReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPyamentReport
            // 
            this.crvPyamentReport.ActiveViewIndex = -1;
            this.crvPyamentReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPyamentReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPyamentReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPyamentReport.Location = new System.Drawing.Point(0, 0);
            this.crvPyamentReport.Name = "crvPyamentReport";
            this.crvPyamentReport.ShowGroupTreeButton = false;
            this.crvPyamentReport.ShowLogo = false;
            this.crvPyamentReport.ShowParameterPanelButton = false;
            this.crvPyamentReport.Size = new System.Drawing.Size(1182, 653);
            this.crvPyamentReport.TabIndex = 42;
            this.crvPyamentReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvPyamentReport.Load += new System.EventHandler(this.crvPyamentReport_Load);
            // 
            // frmpaymentreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.crvPyamentReport);
            this.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmpaymentreport";
            this.Text = "Payment Report";
            this.Load += new System.EventHandler(this.frmpaymentreport_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPyamentReport;
    }
}