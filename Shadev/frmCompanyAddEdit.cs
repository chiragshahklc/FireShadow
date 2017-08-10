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
    public partial class frmCompanyAddEdit : Form
    {
        AIO a1 = new AIO();
        public FrmCompany Stat { get; set; }
        public string comName { get; set; }
        public string catName { get; set; }
        public string modName { get; set; }
        public long id { get; set; }
        public frmCompanyAddEdit()
        {
            try
            {
                InitializeComponent();

                //this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCompanyAddEdit_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Stat)
                {
                    case FrmCompany.CompanyAdd:
                        {
                            this.Text = "Company: Add";
                            lblName.Text = "Enter the name for the new Company:";
                        }
                        break;
                    case FrmCompany.CompanyEdit:
                        {
                            this.Text = "Company: Edit";
                            lblName.Text = "Modify the name for the Company:";
                            txtName.Text = comName;
                        }
                        break;
                    case FrmCompany.CategoryAdd:
                        {
                            this.Text = "Category for {" + comName + "}: Add";
                            lblName.Text = "Enter the name for the new Category:";
                        }
                        break;
                    case FrmCompany.CategoryEdit:
                        {
                            this.Text = "Category for {" + comName + "}: Edit";
                            lblName.Text = "Modify the name for the Category:";
                            txtName.Text = catName;
                        }
                        break;
                    case FrmCompany.ModelAdd:
                        {
                            this.Text = "Model for {" + comName + " - " + catName + "}: Add";
                            lblName.Text = "Enter the name for the new Model:";
                        }
                        break;
                    case FrmCompany.ModelEdit:
                        {
                            this.Text = "Model for {" + comName + " - " + catName + "}: Edit";
                            lblName.Text = "Modify the name for the Model:";
                            txtName.Text = modName;
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

        private void xButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    switch (Stat)
                    {
                        case FrmCompany.CompanyAdd:
                            {
                                AIO.command = "select count(id) from Company where comName='" + txtName.Text + "'";
                                var count = Convert.ToInt32(a1.cmdexesc());
                                if (count > 0)
                                {
                                    MessageBox.Show("Company has been already added.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtName.Clear();
                                }
                                else
                                {
                                    AIO.command = "insert into Company(comName) values('" + txtName.Text + "')";
                                    a1.cmdexe();
                                    this.Close();
                                }
                            }
                            break;
                        case FrmCompany.CompanyEdit:
                            {
                                AIO.command = "update Company set comName='"+txtName.Text+"' where id="+ id;
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        case FrmCompany.CategoryAdd:
                            {
                                AIO.command = "select count(id) from Category where catName='" + txtName.Text + "' and catComID=" + id;
                                var count = Convert.ToInt32(a1.cmdexesc());
                                if (count > 0)
                                {
                                    MessageBox.Show("Category has been already added.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtName.Clear();
                                }
                                else
                                {
                                    AIO.command = "insert into Category(catName,catComID) values('" + txtName.Text + "'," + id + ")";
                                    a1.cmdexe();
                                    this.Close();
                                }
                            }
                            break;
                        case FrmCompany.CategoryEdit:
                            {
                                AIO.command = "update Category set catName='"+txtName.Text+"' where id="+ id;
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        case FrmCompany.ModelAdd:
                            {
                                AIO.command = "select count(id) from Model where modName='"+txtName.Text+"' and modCatID="+id;
                                var count = Convert.ToInt32(a1.cmdexesc());
                                if (count > 0)
                                {
                                    MessageBox.Show("Model has been already added.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtName.Clear();
                                }
                                else
                                {
                                    AIO.command = "insert into Model(modName,modCatID) values('" + txtName.Text + "'," + id + ")";
                                    a1.cmdexe();
                                    this.Close();
                                }
                            }
                            break;
                        case FrmCompany.ModelEdit:
                            {
                                AIO.command = "update Model set modName='"+txtName.Text+"' where id=" + id;
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

        
    }
}
