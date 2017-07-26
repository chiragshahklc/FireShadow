namespace ShadevBackup
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xButtons1 = new System.Windows.Forms.Button();
            this.xButtons2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xButtons2);
            this.groupBox1.Controls.Add(this.xButtons1);
            this.groupBox1.Location = new System.Drawing.Point(72, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 123);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Backup/Restore";
            // 
            // xButtons1
            // 
            this.xButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtons1.BackColor = System.Drawing.Color.Teal;
            this.xButtons1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xButtons1.ForeColor = System.Drawing.Color.White;
            this.xButtons1.Location = new System.Drawing.Point(74, 37);
            this.xButtons1.Name = "xButtons1";
            this.xButtons1.Size = new System.Drawing.Size(132, 50);
            this.xButtons1.TabIndex = 20;
            this.xButtons1.Text = "Backup";
            this.xButtons1.UseVisualStyleBackColor = false;
            this.xButtons1.Click += new System.EventHandler(this.xButtons1_Click);
            // 
            // xButtons2
            // 
            this.xButtons2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtons2.BackColor = System.Drawing.Color.Teal;
            this.xButtons2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xButtons2.ForeColor = System.Drawing.Color.White;
            this.xButtons2.Location = new System.Drawing.Point(212, 37);
            this.xButtons2.Name = "xButtons2";
            this.xButtons2.Size = new System.Drawing.Size(132, 50);
            this.xButtons2.TabIndex = 22;
            this.xButtons2.Text = "Restore";
            this.xButtons2.UseVisualStyleBackColor = false;
            this.xButtons2.Click += new System.EventHandler(this.xButtons2_Click);
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 221);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fire Shadow Backup";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button xButtons1;
        private System.Windows.Forms.Button xButtons2;
    }
}

