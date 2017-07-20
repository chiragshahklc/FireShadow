namespace Shadev
{
    partial class frmTransaction
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            Xbutton.Office2010Yellow office2010Yellow1 = new Xbutton.Office2010Yellow();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransaction));
            this.txtTransactionType = new System.Windows.Forms.TextBox();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.cbmCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTransaction = new System.Windows.Forms.DataGridView();
            this.cmsTransaction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTax1Percentage = new System.Windows.Forms.TextBox();
            this.txtTax2Percentage = new System.Windows.Forms.TextBox();
            this.lblTax1 = new System.Windows.Forms.Label();
            this.lblTax2 = new System.Windows.Forms.Label();
            this.txtTax1Amount = new System.Windows.Forms.TextBox();
            this.txtTax2Amount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFinalAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new Xbutton.xButtons();
            this.btnCancel = new Xbutton.xButtons();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbInvoice = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpBuyersOrderNo = new System.Windows.Forms.TextBox();
            this.dtpDispatchDocNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDispatchDocNo = new System.Windows.Forms.TextBox();
            this.txtTermsOfDelivery = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDispatchThrough = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtBuerOrderNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOtherReferences = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtModeOfPayment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSupplierRef = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeliverNote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).BeginInit();
            this.cmsTransaction.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTransactionType
            // 
            this.txtTransactionType.Location = new System.Drawing.Point(137, 48);
            this.txtTransactionType.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionType.Name = "txtTransactionType";
            this.txtTransactionType.ReadOnly = true;
            this.txtTransactionType.Size = new System.Drawing.Size(230, 22);
            this.txtTransactionType.TabIndex = 2;
            this.txtTransactionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransactionType_KeyPress);
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Location = new System.Drawing.Point(137, 79);
            this.txtTransactionNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(230, 22);
            this.txtTransactionNo.TabIndex = 3;
            this.txtTransactionNo.TextChanged += new System.EventHandler(this.txtTransactionNo_TextChanged);
            this.txtTransactionNo.Leave += new System.EventHandler(this.txtTransactionNo_Leave);
            // 
            // cbmCustomer
            // 
            this.cbmCustomer.FormattingEnabled = true;
            this.cbmCustomer.Location = new System.Drawing.Point(137, 16);
            this.cbmCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.cbmCustomer.Name = "cbmCustomer";
            this.cbmCustomer.Size = new System.Drawing.Size(230, 24);
            this.cbmCustomer.TabIndex = 1;
            this.cbmCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbmCustomer_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Transaction Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transaction No.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Customer:";
            // 
            // dgvTransaction
            // 
            this.dgvTransaction.AllowUserToAddRows = false;
            this.dgvTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaction.ContextMenuStrip = this.cmsTransaction;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransaction.Location = new System.Drawing.Point(451, 12);
            this.dgvTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTransaction.Name = "dgvTransaction";
            this.dgvTransaction.ReadOnly = true;
            this.dgvTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaction.Size = new System.Drawing.Size(798, 557);
            this.dgvTransaction.TabIndex = 6;
            this.dgvTransaction.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvTransaction_ColumnAdded);
            // 
            // cmsTransaction
            // 
            this.cmsTransaction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTransaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsTransaction.Name = "cmsTransaction";
            this.cmsTransaction.Size = new System.Drawing.Size(123, 106);
            this.cmsTransaction.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTransaction_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 24);
            this.toolStripMenuItem1.Text = "None";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(138, 136);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(229, 22);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total:";
            // 
            // txtTax1Percentage
            // 
            this.txtTax1Percentage.Location = new System.Drawing.Point(137, 197);
            this.txtTax1Percentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax1Percentage.Name = "txtTax1Percentage";
            this.txtTax1Percentage.ReadOnly = true;
            this.txtTax1Percentage.Size = new System.Drawing.Size(47, 22);
            this.txtTax1Percentage.TabIndex = 9;
            this.txtTax1Percentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTax1Percentage_KeyPress);
            // 
            // txtTax2Percentage
            // 
            this.txtTax2Percentage.Location = new System.Drawing.Point(137, 229);
            this.txtTax2Percentage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax2Percentage.Name = "txtTax2Percentage";
            this.txtTax2Percentage.ReadOnly = true;
            this.txtTax2Percentage.Size = new System.Drawing.Size(47, 22);
            this.txtTax2Percentage.TabIndex = 10;
            this.txtTax2Percentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTax2Percentage_KeyPress);
            // 
            // lblTax1
            // 
            this.lblTax1.AutoSize = true;
            this.lblTax1.Location = new System.Drawing.Point(62, 200);
            this.lblTax1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTax1.Name = "lblTax1";
            this.lblTax1.Size = new System.Drawing.Size(69, 17);
            this.lblTax1.TabIndex = 11;
            this.lblTax1.Text = "Tax1 (%):";
            // 
            // lblTax2
            // 
            this.lblTax2.AutoSize = true;
            this.lblTax2.Location = new System.Drawing.Point(62, 232);
            this.lblTax2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTax2.Name = "lblTax2";
            this.lblTax2.Size = new System.Drawing.Size(69, 17);
            this.lblTax2.TabIndex = 12;
            this.lblTax2.Text = "Tax2 (%):";
            // 
            // txtTax1Amount
            // 
            this.txtTax1Amount.Location = new System.Drawing.Point(192, 196);
            this.txtTax1Amount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax1Amount.Name = "txtTax1Amount";
            this.txtTax1Amount.ReadOnly = true;
            this.txtTax1Amount.Size = new System.Drawing.Size(175, 22);
            this.txtTax1Amount.TabIndex = 6;
            this.txtTax1Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTax1Amount_KeyPress);
            // 
            // txtTax2Amount
            // 
            this.txtTax2Amount.Location = new System.Drawing.Point(192, 229);
            this.txtTax2Amount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTax2Amount.Name = "txtTax2Amount";
            this.txtTax2Amount.ReadOnly = true;
            this.txtTax2Amount.Size = new System.Drawing.Size(175, 22);
            this.txtTax2Amount.TabIndex = 7;
            this.txtTax2Amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTax2Amount_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 264);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Final Amount:";
            // 
            // txtFinalAmount
            // 
            this.txtFinalAmount.Location = new System.Drawing.Point(138, 260);
            this.txtFinalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtFinalAmount.Name = "txtFinalAmount";
            this.txtFinalAmount.ReadOnly = true;
            this.txtFinalAmount.Size = new System.Drawing.Size(229, 22);
            this.txtFinalAmount.TabIndex = 8;
            this.txtFinalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFinalAmount_KeyPress);
            // 
            // btnSave
            // 
            office2010Yellow1.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(161)))));
            office2010Yellow1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(135)))), ((int)(((byte)(228)))));
            office2010Yellow1.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010Yellow1.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010Yellow1.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(225)))), ((int)(((byte)(137)))));
            office2010Yellow1.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(249)))), ((int)(((byte)(224)))));
            office2010Yellow1.ButtonNormalColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(161)))), ((int)(((byte)(8)))));
            office2010Yellow1.ButtonNormalColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(45)))));
            office2010Yellow1.ButtonNormalColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(161)))), ((int)(((byte)(8)))));
            office2010Yellow1.ButtonNormalColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(45)))));
            office2010Yellow1.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(199)))), ((int)(((byte)(87)))));
            office2010Yellow1.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(243)))), ((int)(((byte)(215)))));
            office2010Yellow1.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(117)))));
            office2010Yellow1.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            office2010Yellow1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010Yellow1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            office2010Yellow1.TextColor = System.Drawing.Color.White;
            this.btnSave.ColorTable = office2010Yellow1;
            this.btnSave.Location = new System.Drawing.Point(138, 292);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.Theme = Xbutton.Theme.MSOffice2010_Yellow;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ColorTable = office2010Yellow1;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(268, 292);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = Xbutton.Theme.MSOffice2010_Yellow;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.CustomFormat = "dd-MM-yyyy";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranDate.Location = new System.Drawing.Point(137, 108);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(230, 22);
            this.dtpTranDate.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 112);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(87, 331);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Bank:";
            // 
            // cmbBank
            // 
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(138, 328);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(230, 24);
            this.cmbBank.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 360);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Invoice Type:";
            // 
            // cmbInvoice
            // 
            this.cmbInvoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoice.FormattingEnabled = true;
            this.cmbInvoice.Items.AddRange(new object[] {
            "Retail Invoice",
            "Tax Invoice",
            "Labour Invoice",
            "Estimate",
            "Bill of Supply"});
            this.cmbInvoice.Location = new System.Drawing.Point(139, 358);
            this.cmbInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.cmbInvoice.Name = "cmbInvoice";
            this.cmbInvoice.Size = new System.Drawing.Size(229, 24);
            this.cmbInvoice.TabIndex = 28;
            this.cmbInvoice.SelectedIndexChanged += new System.EventHandler(this.cmbInvoice_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(400, 463);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.cmbTaxType);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtTransactionType);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.cbmCustomer);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTransactionNo);
            this.tabPage1.Controls.Add(this.cmbInvoice);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbBank);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtTotal);
            this.tabPage1.Controls.Add(this.dtpTranDate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.txtTax1Percentage);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.txtTax2Percentage);
            this.tabPage1.Controls.Add(this.txtFinalAmount);
            this.tabPage1.Controls.Add(this.lblTax1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lblTax2);
            this.tabPage1.Controls.Add(this.txtTax2Amount);
            this.tabPage1.Controls.Add(this.txtTax1Amount);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(392, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Bill Data";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Location = new System.Drawing.Point(137, 166);
            this.cmbTaxType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(230, 24);
            this.cmbTaxType.TabIndex = 6;
            this.cmbTaxType.SelectedIndexChanged += new System.EventHandler(this.cmbTaxType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tax Type:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.dtpBuyersOrderNo);
            this.tabPage2.Controls.Add(this.dtpDispatchDocNo);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.txtDispatchDocNo);
            this.tabPage2.Controls.Add(this.txtTermsOfDelivery);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.txtDispatchThrough);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.txtDestination);
            this.tabPage2.Controls.Add(this.txtBuerOrderNo);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtOtherReferences);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtModeOfPayment);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtSupplierRef);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtDeliverNote);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(392, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Other Data";
            // 
            // dtpBuyersOrderNo
            // 
            this.dtpBuyersOrderNo.Location = new System.Drawing.Point(155, 158);
            this.dtpBuyersOrderNo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBuyersOrderNo.Name = "dtpBuyersOrderNo";
            this.dtpBuyersOrderNo.Size = new System.Drawing.Size(230, 22);
            this.dtpBuyersOrderNo.TabIndex = 27;
            // 
            // dtpDispatchDocNo
            // 
            this.dtpDispatchDocNo.Location = new System.Drawing.Point(155, 219);
            this.dtpDispatchDocNo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDispatchDocNo.Name = "dtpDispatchDocNo";
            this.dtpDispatchDocNo.Size = new System.Drawing.Size(230, 22);
            this.dtpDispatchDocNo.TabIndex = 26;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(94, 223);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(50, 17);
            this.label21.TabIndex = 25;
            this.label21.Text = "Dated:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 308);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 17);
            this.label19.TabIndex = 21;
            this.label19.Text = "Terms of Delivery:";
            // 
            // txtDispatchDocNo
            // 
            this.txtDispatchDocNo.Location = new System.Drawing.Point(155, 188);
            this.txtDispatchDocNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDispatchDocNo.Name = "txtDispatchDocNo";
            this.txtDispatchDocNo.Size = new System.Drawing.Size(230, 22);
            this.txtDispatchDocNo.TabIndex = 14;
            // 
            // txtTermsOfDelivery
            // 
            this.txtTermsOfDelivery.Location = new System.Drawing.Point(155, 305);
            this.txtTermsOfDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.txtTermsOfDelivery.Name = "txtTermsOfDelivery";
            this.txtTermsOfDelivery.Size = new System.Drawing.Size(230, 22);
            this.txtTermsOfDelivery.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(94, 164);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 17);
            this.label20.TabIndex = 23;
            this.label20.Text = "Dated:";
            // 
            // txtDispatchThrough
            // 
            this.txtDispatchThrough.Location = new System.Drawing.Point(155, 247);
            this.txtDispatchThrough.Margin = new System.Windows.Forms.Padding(4);
            this.txtDispatchThrough.Name = "txtDispatchThrough";
            this.txtDispatchThrough.Size = new System.Drawing.Size(230, 22);
            this.txtDispatchThrough.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(59, 277);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 17);
            this.label18.TabIndex = 19;
            this.label18.Text = "Destination:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 191);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 17);
            this.label16.TabIndex = 15;
            this.label16.Text = "Dispatch Doc. No.:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 250);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 17);
            this.label17.TabIndex = 17;
            this.label17.Text = "Dispatch through:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 132);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 17);
            this.label15.TabIndex = 13;
            this.label15.Text = "Buyer\'s Order No.:";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(155, 275);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(4);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(230, 22);
            this.txtDestination.TabIndex = 18;
            // 
            // txtBuerOrderNo
            // 
            this.txtBuerOrderNo.Location = new System.Drawing.Point(155, 130);
            this.txtBuerOrderNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuerOrderNo.Name = "txtBuerOrderNo";
            this.txtBuerOrderNo.Size = new System.Drawing.Size(230, 22);
            this.txtBuerOrderNo.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 102);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 17);
            this.label14.TabIndex = 11;
            this.label14.Text = "Other Refrences:";
            // 
            // txtOtherReferences
            // 
            this.txtOtherReferences.Location = new System.Drawing.Point(155, 100);
            this.txtOtherReferences.Margin = new System.Windows.Forms.Padding(4);
            this.txtOtherReferences.Name = "txtOtherReferences";
            this.txtOtherReferences.Size = new System.Drawing.Size(230, 22);
            this.txtOtherReferences.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 72);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 17);
            this.label13.TabIndex = 9;
            this.label13.Text = "Mode of Payment:";
            // 
            // txtModeOfPayment
            // 
            this.txtModeOfPayment.Location = new System.Drawing.Point(155, 69);
            this.txtModeOfPayment.Margin = new System.Windows.Forms.Padding(4);
            this.txtModeOfPayment.Name = "txtModeOfPayment";
            this.txtModeOfPayment.Size = new System.Drawing.Size(230, 22);
            this.txtModeOfPayment.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Supplier\'s Ref.:";
            // 
            // txtSupplierRef
            // 
            this.txtSupplierRef.Location = new System.Drawing.Point(155, 39);
            this.txtSupplierRef.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupplierRef.Name = "txtSupplierRef";
            this.txtSupplierRef.Size = new System.Drawing.Size(230, 22);
            this.txtSupplierRef.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Delivery Note:";
            // 
            // txtDeliverNote
            // 
            this.txtDeliverNote.Location = new System.Drawing.Point(155, 9);
            this.txtDeliverNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeliverNote.Name = "txtDeliverNote";
            this.txtDeliverNote.Size = new System.Drawing.Size(230, 22);
            this.txtDeliverNote.TabIndex = 4;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1262, 580);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvTransaction);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransaction";
            this.ShowInTaskbar = false;
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaction)).EndInit();
            this.cmsTransaction.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransactionType;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.ComboBox cbmCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTransaction;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTax1Percentage;
        private System.Windows.Forms.TextBox txtTax2Percentage;
        private System.Windows.Forms.Label lblTax1;
        private System.Windows.Forms.Label lblTax2;
        private System.Windows.Forms.TextBox txtTax1Amount;
        private System.Windows.Forms.TextBox txtTax2Amount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFinalAmount;
        private Xbutton.xButtons btnSave;
        private Xbutton.xButtons btnCancel;
        private System.Windows.Forms.ContextMenuStrip cmsTransaction;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbInvoice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTermsOfDelivery;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDispatchThrough;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDispatchDocNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBuerOrderNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOtherReferences;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtModeOfPayment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSupplierRef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeliverNote;
        private System.Windows.Forms.TextBox dtpBuyersOrderNo;
        private System.Windows.Forms.TextBox dtpDispatchDocNo;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTaxType;
    }
}