namespace Shadev
{
    partial class frmNewItems
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
            this.label3 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Unit :";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 32);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(113, 17);
            this.lbl1.TabIndex = 20;
            this.lbl1.Text = "Item Description:";
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Location = new System.Drawing.Point(123, 32);
            this.txtItemDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(401, 22);
            this.txtItemDescription.TabIndex = 1;
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(123, 64);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(207, 24);
            this.cmbUnit.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtItemDescription);
            this.groupBox2.Controls.Add(this.lbl1);
            this.groupBox2.Controls.Add(this.cmbUnit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 112);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Description";
            // 
            // dgvItem
            // 
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Location = new System.Drawing.Point(21, 138);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.RowTemplate.Height = 24;
            this.dgvItem.Size = new System.Drawing.Size(863, 177);
            this.dgvItem.TabIndex = 33;
            this.dgvItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(21, 332);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(211, 332);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(308, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 28);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmNewItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 398);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmNewItems";
            this.Text = "New Item";
            this.Load += new System.EventHandler(this.frmNewItems_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}