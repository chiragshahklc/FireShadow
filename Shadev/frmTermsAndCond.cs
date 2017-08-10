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
    public partial class frmTermsAndCond : Form
    {
        public FrmCompany Stat { get; set; }
        AIO a1 = new AIO();
        public long id { get; set; }
        public string termVal { get; set; }
        public frmTermsAndCond()
        {
            try
            {
                InitializeComponent();
                //this.ShowInTaskbar = false;
                //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(rtbTerms.Text))
                {
                    switch (Stat)
                    {
                        case FrmCompany.TermsAdd:
                            {
                                string s = rtbTerms.Text.Replace("'", "''");
                                AIO.command = @"insert into TermsCond(tcVal) VALUES('" + s + "')";
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        case FrmCompany.TermsEdit:
                            {
                                string s = rtbTerms.Text.Replace("'", "''");
                                AIO.command = @"update TermsCond set tcVal='" + s + "' where id=" + id;
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTermsAndCond_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Stat)
                {

                    case FrmCompany.TermsAdd:
                        {
                            this.Text = "Terms & Condition: Add";
                        }
                        break;

                    case FrmCompany.TermsEdit:
                        {
                            this.Text = "Terms & Condition: Edit";
                            rtbTerms.Text = termVal;
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
