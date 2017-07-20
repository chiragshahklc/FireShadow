using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SqliteDbAIO;

namespace Shadev
{
    public partial class frmExpense : Form
    {
        AIO a1 = new AIO();

        public frmExpense()
        {
            try
            {
                InitializeComponent();
                //this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtAmt.Text) || !string.IsNullOrWhiteSpace(txtExpenseName.Text))
                {
                    if (Convert.ToDouble(txtAmt.Text) < 0)
                    {
                        MessageBox.Show("Minus Value Cant Be Consider", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string name = txtExpenseName.Text.Replace("'", "''");
                        AIO.command = "insert into Expense(expName,expAmount,expDate) Values('" + name + "'," + txtAmt.Text + ",'" + dtpExpense.Value.ToString("yyyy-MM-dd") + "')";
                        a1.cmdexe();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Blank is not Allow", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
