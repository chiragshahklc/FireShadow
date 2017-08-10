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
    public partial class frmBank : Form
    {
        public FrmCompany Stat { get; set; }
        AIO a1 = new AIO();
        public DataRow row { get; set; }
        public long id { get; set; }
        public frmBank()
        {

            InitializeComponent();

            this.ShowInTaskbar = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void xButtons1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtBankName.Text.Replace("'", "''");

                //If Opening balance is null then set it to 0(Zero).
                if (string.IsNullOrWhiteSpace(txtOpeningBalance.Text))
                    txtOpeningBalance.Text = "0";


                if (!string.IsNullOrWhiteSpace(txtBankName.Text))
                {
                    switch (Stat)
                    {
                        case FrmCompany.BankAdd:
                            {
                                

                                AIO.command = "INSERT INTO  Banks(bnkname,bnkACNo,bnkBranch,bnkIFSC,bnkOpeningBalance) VALUES('" + name + "'," + txtACNO.Text + ",'" + txtBankBranch.Text + "','" + txtBankIFSC.Text + "',"+txtOpeningBalance.Text+")";
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        case FrmCompany.BankEdit:
                            {
                                AIO.command = "update Banks  set bnkname='" + name + "',bnkACNo=" + txtACNO.Text + ",bnkBranch='" + txtBankBranch.Text + "',bnkIFSC='" + txtBankIFSC.Text + "',bnkOpeningBalance="+txtOpeningBalance.Text+" where id=" + id;
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
                MessageBox.Show(ex.ToString(),Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public bool a { get; set; }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBank_Load(object sender, EventArgs e)
        {
            try
            {
                txtOpeningBalance.Text = "0";

                switch (Stat)
                {

                    case FrmCompany.BankAdd:
                        {
                            this.Text = "Bank: Add";
                        }
                        break;

                    case FrmCompany.BankEdit:
                        {
                            this.Text = "Bank: Edit";
                            txtBankName.Text = row["Name"].ToString();
                            txtBankBranch.Text = row["Branch"].ToString();
                            txtACNO.Text = row["AccountNo"].ToString();
                            txtBankIFSC.Text = row["IFSC"].ToString();
                            txtOpeningBalance.Text = row["Opening Balance"].ToString();
                            id = Convert.ToInt64(row["id"].ToString());
                        }
                        break;

                    default:
                        break;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
