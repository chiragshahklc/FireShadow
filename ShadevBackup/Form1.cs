using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadevBackup
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void xButtons1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.DefaultExt = ".fs";
                saveFileDialog1.FileName = "Data.fs";
                saveFileDialog1.Filter = "Fire Shadow Database File(*.fs)|*.fs";
                DialogResult res = saveFileDialog1.ShowDialog();
                if (DialogResult.OK == res)
                {
                    System.IO.File.Copy(AIO.path + @"\Data.fs", saveFileDialog1.FileName);
                    MessageBox.Show("File saved at:\n" + saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xButtons2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.DefaultExt = ".fs";
                openFileDialog1.Filter = "Fire Shadow Database File(*.fs)|*.fs";
                DialogResult res = openFileDialog1.ShowDialog();

                if (DialogResult.OK == res)
                {

                    System.IO.File.Delete(AIO.path + @"\Data.fs");
                    //MessageBox.Show(openFileDialog1.FileName);
                    

                    //System.IO.File.Replace(openFileDialog1.FileName, AIO.path + @"\Data.fs", AIO.path + @"\backup\Data" + DateTime.Today.ToString("dd-MM-yyyy") + ".fs", false);
                    //System.IO.File.Create(AIO.path + @"\Data.fs").Close();
                    
                    //MessageBox.Show(AIO.path + @"\Data.fs");
                    System.IO.File.Copy(openFileDialog1.FileName, AIO.path + @"\Data.fs");
                    MessageBox.Show("File Restored Successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

