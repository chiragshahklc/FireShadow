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
    public partial class frmCustomer : Form
    {
        public FrmCompany Stat { get; set; }
        AIO a1 = new AIO();
        public long id { get; set; }
        public DataRow row { get; set; }
        public string custType { get; set; }
        public frmCustomer()
        {
            try
            {
                InitializeComponent();

                //this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string add = rtbCustomerAdd.Text.Replace("'", "''");
                if (string.IsNullOrWhiteSpace(txtOpeningBalance.Text))
                {
                    txtOpeningBalance.Text = "0";
                }
                if (!string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    switch (Stat)
                    {
                        case FrmCompany.CustAdd:
                            {   
                                AIO.command = "insert into Customer(custName,custAdd,custMob,custEmail,custVatTIN,custCstNo,custPAN,custType,custOpenBal) values('" + txtCustomerName.Text + "','" + add + "','" + txtCustomerMobile.Text + "','" + txtCustomerEmail.Text + "','" + txtCustomerVat.Text + "','" + txtCSTNo.Text + "','" + txtPAN.Text + "','"+custType+"','"+txtOpeningBalance.Text+"')";
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        case FrmCompany.CustEdit:
                            {
                                AIO.command = "update Customer set custName='" + txtCustomerName.Text + "',custAdd='" + add + "',custMob='" + txtCustomerMobile.Text + "',custEmail='" + txtCustomerEmail.Text + "',custVatTIN='" + txtCustomerVat.Text + "',custCstNo='" + txtCSTNo.Text + "',custPAN='" + txtPAN.Text + "',custOpenBal="+txtOpeningBalance.Text+" where id=" + id;
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCencel_Click(object sender, EventArgs e)
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

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCustomerMobile_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCustomerEmail_Leave(object sender, EventArgs e)
        {
            
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Stat)
                {
                    case FrmCompany.CustAdd:
                        {
                            this.Text = "Customer: Add";
                            txtOpeningBalance.Text = "0";
                        }
                        break;
                    case FrmCompany.CustEdit:
                        {
                            this.Text = "Customer: Edit";
                            if (!DBNull.Value.Equals(row[0]))
                            {
                                txtCustomerName.Text = row["Name"].ToString();
                                rtbCustomerAdd.Text = row["Address"].ToString();
                                txtCustomerMobile.Text = row["Mobile"].ToString();
                                txtCustomerEmail.Text = row["Email"].ToString();
                                txtCustomerVat.Text = row["GSTIN"].ToString();
                                txtCSTNo.Text = row["CST No"].ToString();
                                txtPAN.Text = row["PAN"].ToString();
                                txtOpeningBalance.Text = row["custOpenBal"].ToString();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
