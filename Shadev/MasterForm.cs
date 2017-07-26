using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
//using SqliteDbAIO;

namespace Shadev
{
    public partial class MasterForm : Form
    {
        AIO a1 = new AIO();
        List<long> comID = new List<long>();
        List<long> catID = new List<long>();
        List<long> modID = new List<long>();
        List<long> CustID = new List<long>();
        List<long> CustIDSearch = new List<long>();
        List<TabPage> allTabs = new List<TabPage>();
        public string custType { get; set; }
        TranSearc tranSearchStat;

        public MasterForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void txtAboutCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAboutCompanyContact_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtAboutCompanyEmail_Leave(object sender, EventArgs e)
        {

        }
        private void OpenFrmCompanyAddEdit(FrmCompany stat, string Company, string Category, string Model, long ID)
        {
            try
            {
                frmCompanyAddEdit fr = new frmCompanyAddEdit();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = stat;
                fr.comName = Company;
                fr.catName = Category;
                fr.modName = Model;
                fr.id = ID;
                fr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFrmCompanyAddEdit(FrmCompany.CompanyAdd, "", "", "", -1);
                RefreshCompany();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFrmCompanyAddEdit(FrmCompany.CompanyEdit, cmsCompany.Items[0].Text, "", "", int.Parse(dgvCompany.SelectedRows[0].Cells["id"].Value.ToString()));
                RefreshCompany();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFrmCompanyAddEdit(FrmCompany.CategoryAdd, cmbCategoryCompany.SelectedItem.ToString(), "", "", comID[cmbCategoryCompany.SelectedIndex]);
                RefreshCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFrmCompanyAddEdit(FrmCompany.CategoryEdit, cmbCategoryCompany.SelectedItem.ToString(), cmsCategory.Items[0].Text, "", int.Parse(dgvCategory.SelectedRows[0].Cells["id"].Value.ToString()));
                RefreshCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFrmCompanyAddEdit(FrmCompany.ModelAdd, cmbModelCompany.SelectedItem.ToString(), cmbModelCatagory.SelectedItem.ToString(), "", catID[cmbModelCatagory.SelectedIndex]);
                RefreshModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFrmCompanyAddEdit(FrmCompany.ModelEdit, cmbModelCompany.SelectedItem.ToString(), cmbModelCatagory.SelectedItem.ToString(), cmsModel.Items[0].Text, int.Parse(dgvModel.SelectedRows[0].Cells["id"].Value.ToString()));
                RefreshModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCompany()
        {
            try
            {
                AIO.command = "select  id,comName as [Company] from Company order by comName ASC";
                var dt = a1.dataload();
                dgvCompany.DataSource = dt;
                dgvCompany.Columns["id"].Visible = false;

                cmbCategoryCompany.Items.Clear();
                cmbModelCompany.Items.Clear();
                comID.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbCategoryCompany.Items.Add(row["Company"].ToString());
                    cmbModelCompany.Items.Add(row["Company"].ToString());
                    comID.Add(long.Parse(row["id"].ToString()));
                }

                cmbCategoryCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategoryCompany.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbModelCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbModelCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProdReg(string Serial)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            if (Serial == config.AppSettings.Settings["Serial"].Value)
            {
                if (string.IsNullOrWhiteSpace(config.AppSettings.Settings["RunPath"].Value))
                {
                    config.AppSettings.Settings["RunPath"].Value = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    MessageBox.Show("Registration Successful.\r\nApplication will now exit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    // SwitchTabPages(AllTabs.Login);
                    // this.ActiveControl = textBox2;
                }
                else
                {
                    MessageBox.Show("Application Path has been registered. You can't register again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial Key is Not Verified.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show(config.AppSettings.Settings["Serial"].Value);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                //ProdReg();

                btnPayCust.Text = customerToolStripMenuItem.Text;
                btnTRCust.Text = customerToolStripMenuItem.Text;
                custType = customerToolStripMenuItem.Text;
                dtpStartStock.Value = new DateTime(2017, 04, 01);

                refreshbank();
                RefreshCompany();
                RefreshCustomer();
                RefreshAboutMe();
                RefreshTransaction();
                RefreshExpense();
                refreshTandD();
                RefreshGeneralSettings();
                RefreshTaxMaster();

                foreach (TabPage page in tabControl1.TabPages)
                {
                    allTabs.Add(page);
                    tabControl1.TabPages.Remove(page);
                }

                btnHomePage.Visible = false;
                menuStrip1.Visible = false;
                tranSearchStat = TranSearc.TransNo;


                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                if (string.IsNullOrWhiteSpace(config.AppSettings.Settings["RunPath"].Value))
                {
                    SwitchTabPages(AllTabs.Registration);
                }
                else
                {
                    if (config.AppSettings.Settings["RunPath"].Value == System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath))
                    {
                        SwitchTabPages(AllTabs.Login);
                        this.ActiveControl = textBox2;
                    }
                    else
                    {
                        MessageBox.Show("This is not Registered location for the Application.\r\n Application will now Exit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }

                // SwitchTabPages(AllTabs.Login);
                // this.ActiveControl = textBox2;
                //this.AcceptButton = xButtons2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbCategoryCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbModelCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbModelCompany.SelectedIndex >= 0)
                {
                    AIO.command = "select id,catName from Category where catComID=" + comID[cmbModelCompany.SelectedIndex];
                    var dt = a1.dataload();

                    cmbModelCatagory.Items.Clear();
                    cmbModelCatagory.Text = "";
                    catID.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbModelCatagory.Items.Add(row["catName"].ToString());
                        catID.Add(long.Parse(row["id"].ToString()));
                    }

                    cmbModelCatagory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbModelCatagory.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbModelCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsCompany_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvCompany.SelectedRows.Count > 0)
                {
                    cmsCompany.Items[0].Text = dgvCompany.SelectedRows[0].Cells["Company"].Value.ToString();
                    cmsCompany.Items[3].Enabled = true;
                    cmsCompany.Items[4].Enabled = true;
                }
                else
                {
                    cmsCompany.Items[0].Text = "";
                    cmsCompany.Items[3].Enabled = false;
                    cmsCompany.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCompany.SelectedRows.Count > 0)
                {
                    AIO.command = "select count(id) from Category where catComID=" + dgvCompany.SelectedRows[0].Cells["id"].Value.ToString();
                    var count = Convert.ToInt32(a1.cmdexesc());
                    if (count > 0)
                    {
                        MessageBox.Show("Foreign Key Error: Company can't be delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        AIO.command = "delete from Company where id=" + dgvCompany.SelectedRows[0].Cells["id"].Value.ToString();
                        a1.cmdexe();
                    }
                }
                RefreshCompany();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsCategory_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbCategoryCompany.SelectedIndex >= 0)
                {
                    cmsCategory.Items[2].Enabled = true;

                    if (dgvCategory.SelectedRows.Count > 0)
                    {
                        cmsCategory.Items[0].Text = dgvCategory.SelectedRows[0].Cells["Category"].Value.ToString();
                        cmsCategory.Items[3].Enabled = true;
                        cmsCategory.Items[4].Enabled = true;
                    }
                    else
                    {
                        cmsCategory.Items[0].Text = "";
                        cmsCategory.Items[3].Enabled = false;
                        cmsCategory.Items[4].Enabled = false;
                    }
                }
                else
                {
                    cmsCategory.Items[2].Enabled = false;
                    cmsCategory.Items[3].Enabled = false;
                    cmsCategory.Items[4].Enabled = false;
                    cmsCategory.Items[0].Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCategory()
        {
            try
            {
                if (cmbCategoryCompany.SelectedIndex >= 0)
                {
                    AIO.command = "select id,catName as [Category] from Category where catComID=" + comID[cmbCategoryCompany.SelectedIndex] + " order by catName ASC";
                    var dt = a1.dataload();
                    dgvCategory.DataSource = dt;
                    dgvCategory.Columns["id"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategory.SelectedRows.Count > 0)
                {
                    AIO.command = "select count(id) from Model where modCatID=" + dgvCategory.SelectedRows[0].Cells["id"].Value.ToString();
                    var count = Convert.ToInt32(a1.cmdexesc());
                    if (count > 0)
                    {
                        MessageBox.Show("Foreign Key Error: Category can't be delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        AIO.command = "delete from Category where id=" + dgvCategory.SelectedRows[0].Cells["id"].Value.ToString();
                        a1.cmdexe();
                    }
                }
                RefreshCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshModel()
        {
            try
            {
                if (cmbModelCatagory.SelectedIndex >= 0)
                {

                    AIO.command = "select id,modName as [Model],stock as [Current Stock] from Model where modCatID=" + catID[cmbModelCatagory.SelectedIndex] + " order by modName ASC";
                    var dt = a1.dataload();

                    dgvModel.DataSource = dt;
                    dgvModel.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsModel_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (cmbModelCatagory.SelectedIndex >= 0)
                {
                    cmsModel.Items[2].Enabled = true;
                    if (dgvModel.SelectedRows.Count > 0)
                    {
                        cmsModel.Items[0].Text = dgvModel.SelectedRows[0].Cells["Model"].Value.ToString();
                        cmsModel.Items[3].Enabled = true;
                        cmsModel.Items[4].Enabled = true;
                    }
                    else
                    {
                        cmsModel.Items[0].Text = "";
                        cmsModel.Items[3].Enabled = false;
                        cmsModel.Items[4].Enabled = false;
                    }
                }
                else
                {
                    cmsModel.Items[0].Text = "";
                    cmsModel.Items[2].Enabled = false;
                    cmsModel.Items[3].Enabled = false;
                    cmsModel.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvModel.SelectedRows.Count > 0)
                {
                    AIO.command = "select count(id) from TranItemsGrid where itgModID=" + dgvModel.SelectedRows[0].Cells["id"].Value.ToString();
                    var count = Convert.ToInt32(a1.cmdexesc());
                    if (count > 0)
                    {
                        MessageBox.Show("Foreign Key Error: Model can't be delete.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        AIO.command = "delete from Model where id=" + dgvModel.SelectedRows[0].Cells["id"].Value.ToString();
                        a1.cmdexe();
                    }
                }
                RefreshModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            try
            {
                frmCustomer fr = new frmCustomer();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.CustAdd;
                fr.custType = custType;

                fr.ShowDialog();
                RefreshCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAboutSave_Click(object sender, EventArgs e)
        {
            try
            {
                AIO.command = "select id from AboutMe";
                var dt = a1.dataload();
                string name = "", add = "";
                name = txtAboutCompanyName.Text.Replace("'", "''");
                add = rtbAboutAdd.Text.Replace("'", "''");
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(txtAboutCompanyName.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtAboutCompanyContact.Text))
                        {
                            txtAboutCompanyContact.Text = "0";
                        }

                        AIO.command = "update AboutMe set abtComName='" + name + "',abtComAdd='" + add + "',abtComMob='" + txtAboutCompanyContact.Text + "',abtComEmail='" + txtAboutCompanyEmail.Text + "',abtVatTIN='" + txtAboutCompanyVAT.Text + "',abtCstNo='" + txtAboutCompanyCST.Text + "',abtPAN='" + txtAboutCompanyPAN.Text + "',abtCIN='" + txtAboutCompanyCIN.Text + "',abtEsta='" + dtpAboutCompanyEsta.Value.ToString("yyyy-MM-dd") + "'";
                        a1.cmdexe();
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtAboutCompanyName.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtAboutCompanyContact.Text))
                        {
                            txtAboutCompanyContact.Text = "0";
                        }
                        AIO.command = "INSERT INTO AboutMe(abtComName,abtComAdd,abtComMob,abtComEmail,abtVatTIN,abtCstNo,abtPAN,abtCIN,abtEsta) VALUES('" + name + "','" + add + "','" + txtAboutCompanyContact.Text + "','" + txtAboutCompanyEmail.Text + "','" + txtAboutCompanyVAT.Text + "','" + txtAboutCompanyCST.Text + "','" + txtAboutCompanyPAN.Text + "','" + txtAboutCompanyCIN.Text + "','" + dtpAboutCompanyEsta.Value.ToString("yyyy-MM-dd") + "')";
                        a1.cmdexe();
                    }
                }

                txtAboutCompanyName.Enabled = false;
                rtbAboutAdd.Enabled = false;
                txtAboutCompanyContact.Enabled = false;
                txtAboutCompanyEmail.Enabled = false;
                txtAboutCompanyVAT.Enabled = false;
                txtAboutCompanyCST.Enabled = false;
                txtAboutCompanyPAN.Enabled = false;
                txtAboutCompanyCIN.Enabled = false;
                dtpAboutCompanyEsta.Enabled = false;

                RefreshAboutMe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomer fr = new frmCustomer();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.CustEdit;
                fr.row = ((DataTable)dgvCustomer.DataSource).Rows[dgvCustomer.SelectedRows[0].Index];
                fr.id = long.Parse(dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString());
                fr.ShowDialog();

                RefreshCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCustomer()
        {
            try
            {
                txtCustSearch.Clear();
                AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN] from Customer as c where custType='" + custType + "' order by [Name]";
                var dt = a1.dataload();
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["id"].Visible = false;
                txtCustSearch.Clear();


                cmbCustomerName.Items.Clear();
                cmbTRCustomerName.Items.Clear();

                CustID.Clear();
                cmbCustomerName.Items.Add("None");
                cmbTRCustomerName.Items.Add("None");
                CustID.Add(-1);
                foreach (DataRow row in dt.Rows)
                {
                    cmbCustomerName.Items.Add(row["Name"].ToString());
                    cmbTRCustomerName.Items.Add(row["Name"].ToString());
                    CustID.Add(long.Parse(row["id"].ToString()));
                }

                cmbCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbTRCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbTRCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbModelCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbModelCompany.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from Customer where id=" + dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }
                RefreshCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsCustomer_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    cmsCustomer.Items[0].Text = dgvCustomer.SelectedRows[0].Cells["Name"].Value.ToString();
                    cmsCustomer.Items[3].Enabled = true;
                    cmsCustomer.Items[4].Enabled = true;
                }
                else
                {
                    cmsCustomer.Items[0].Text = "";
                    cmsCustomer.Items[3].Enabled = false;
                    cmsCustomer.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAboutEdit_Click(object sender, EventArgs e)
        {
            try
            {
                txtAboutCompanyName.Enabled = true;
                rtbAboutAdd.Enabled = true;
                txtAboutCompanyContact.Enabled = true;
                txtAboutCompanyEmail.Enabled = true;
                txtAboutCompanyVAT.Enabled = true;
                txtAboutCompanyCST.Enabled = true;
                txtAboutCompanyPAN.Enabled = true;
                txtAboutCompanyCIN.Enabled = true;
                dtpAboutCompanyEsta.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAboutMe()
        {
            try
            {
                AIO.command = "select id,abtComName as [Name],abtComAdd as [Address],abtComMob as [Mobile],abtComEmail as [Email],abtVatTIN as [VAT],abtCstNo as [CST],abtPAN as [PAN],abtCIN as [CIN],abtEsta as [EST] from AboutMe";
                var dt = a1.dataload();
                if (dt.Rows.Count > 0 && !DBNull.Value.Equals(dt.Rows[0][0]))
                {
                    txtAboutCompanyName.Text = dt.Rows[0]["Name"].ToString();
                    rtbAboutAdd.Text = dt.Rows[0]["Address"].ToString();
                    txtAboutCompanyContact.Text = dt.Rows[0]["Mobile"].ToString();
                    txtAboutCompanyEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtAboutCompanyVAT.Text = dt.Rows[0]["VAT"].ToString();
                    txtAboutCompanyCST.Text = dt.Rows[0]["CST"].ToString();
                    txtAboutCompanyPAN.Text = dt.Rows[0]["PAN"].ToString();
                    txtAboutCompanyCIN.Text = dt.Rows[0]["CIN"].ToString();
                    dtpAboutCompanyEsta.Value = Convert.ToDateTime(dt.Rows[0]["EST"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                frmBank fr = new frmBank();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.BankAdd;
                fr.ShowDialog();
                refreshbank();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                frmBank fr = new frmBank();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.BankEdit;
                fr.row = ((DataTable)dgvBank.DataSource).Rows[dgvBank.SelectedRows[0].Index];
                fr.ShowDialog();
                refreshbank();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshbank()
        {
            try
            {
                AIO.command = "select id,bnkname as [Name],bnkBranch as [Branch],bnkACNo as [AccountNo],bnkIFSC as [IFSC] from Banks order by [Name]";
                var dt = a1.dataload();
                dgvBank.DataSource = dt;
                dgvBank.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBank.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from Banks where id=" + dgvBank.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }
                refreshbank();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                frmTermsAndCond fr = new frmTermsAndCond();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.TermsAdd;
                fr.ShowDialog();

                refreshTandD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                frmTermsAndCond fr = new frmTermsAndCond();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.TermsEdit;
                fr.termVal = dgvTC.SelectedRows[0].Cells["Term and Cond"].Value.ToString();
                fr.id = Convert.ToInt64(dgvTC.SelectedRows[0].Cells["id"].Value.ToString());
                fr.ShowDialog();

                refreshTandD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTC.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from TermsCond where id=" + dgvTC.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }

                refreshTandD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshTandD()
        {
            try
            {
                AIO.command = "select id,tcVal as [Term and Cond] from TermsCond";
                var dt = a1.dataload();
                dgvTC.DataSource = dt;
                //dgvTC.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                AIO.command = "select max(tranNo) from Trans";
                var x = a1.cmdexesc();


                frmTransaction fr = new frmTransaction();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.TransAdd;
                fr.custType = custType;
                fr.TransType = btnTransType.Text;
                //fr.TransNo = x != null ? Convert.ToInt32(x) + 1 : 1;
                fr.ShowDialog();

                RefreshTransaction();
                RefreshCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                frmTransaction fr = new frmTransaction();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.TransEdit;
                fr.TransType = dgvTransaction.SelectedRows[0].Cells["Type"].Value.ToString();
                fr.id = Convert.ToInt64(dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString());

                fr.TransNo = dgvTransaction.SelectedRows[0].Cells["No."].Value.ToString();
                fr.date = Convert.ToDateTime(dgvTransaction.SelectedRows[0].Cells["Date"].Value.ToString());
                fr.ShowDialog();

                RefreshTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransType_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnTransType.Text == "All")
                {
                    btnTransType.Text = "Purchase";
                    btnTranBillView.Visible = false;
                }
                else if (btnTransType.Text == "Purchase")
                {
                    btnTransType.Text = "Sale";
                    btnTranBillView.Visible = true;
                }
                else
                {
                    btnTransType.Text = "All";
                    btnTranBillView.Visible = false;
                }

                RefreshTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsTrans_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    cmsTrans.Items[0].Text = dgvTransaction.SelectedRows[0].Cells["No."].Value.ToString();
                    cmsTrans.Items[3].Enabled = true;
                    cmsTrans.Items[4].Enabled = true;
                    if (btnTransType.Text == "All")
                    {
                        cmsTrans.Items[2].Enabled = false;
                    }
                    else
                    {
                        cmsTrans.Items[2].Enabled = true;
                    }
                }
                else
                {
                    cmsTrans.Items[0].Text = "";
                    cmsTrans.Items[3].Enabled = false;
                    cmsTrans.Items[4].Enabled = false;
                    if (btnTransType.Text == "All")
                    {
                        cmsTrans.Items[2].Enabled = false;
                    }
                    else
                    {
                        cmsTrans.Items[2].Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RefreshTransaction()
        {
            try
            {
                txtTransactionSearch.Clear();
                string query = "", sort = "", asc = "", param = "";


                if (btnTransCustSearch.Text != "Transaction No")
                {
                    if (comboBox2.SelectedIndex < 0)
                        param = "";
                    else
                    {
                        param = " tranCustID=" + CustIDSearch[comboBox2.SelectedIndex] + " and";
                        //query = CustIDSearch[comboBox2.SelectedIndex].ToString();
                    }
                }
                else if (btnTransCustSearch.Text == "Transaction No")
                {
                    param = " tranNo like '%" + comboBox2.Text + "%' and";
                }



                if (btnTransType.Text == "All")
                    query = " where tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
                else if (btnTransType.Text == "Purchase")
                    query = " where" + param + " tranType='Purchase' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
                else if (btnTransType.Text == "Sale")
                    query = " where" + param + "  tranType='Sale' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
                else if (btnTransType.Text == "Estimate")
                    query = " where" + param + "  tranType='Estimate' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                if (cmbTransSort.SelectedIndex > 0)
                    sort = " order by [" + cmbTransSort.SelectedItem.ToString() + "]";
                if (cmbTransSort.SelectedIndex > 0 && cmbTransASC.SelectedIndex > 0)
                    asc = " " + cmbTransASC.SelectedItem.ToString();
                AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Name],tranDate as [Date],tranTotal as [Price],Round(((tranTax1/100) * tranTotal),2) as [Tax1],Round(((tranTax2/100) * tranTotal),2) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + query + "" + sort + "" + asc;
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshPayment()
        {
            try
            {
                string custName = "", payMode = "", payType = "", sort = "", asc = "";
                if (cmbCustomerName.SelectedIndex > 0)
                    custName = " and payCustID=" + CustID[cmbCustomerName.SelectedIndex];
                if (cmbPaymentMethod.SelectedIndex > 0)
                    payMode = " and payMethod='" + cmbPaymentMethod.SelectedItem.ToString() + "'";
                if (cmbPaymentType.SelectedIndex > 0)
                    payType = " and payType='" + cmbPaymentType.SelectedItem.ToString() + "'";
                if (cmbPaymentSortby.SelectedIndex > 0)
                    sort = " order by [" + cmbPaymentSortby.SelectedItem.ToString() + "]";
                if (cmbPaymentSortby.SelectedIndex > 0 && cmbPayASC.SelectedIndex > 0)
                    asc = " " + cmbPayASC.SelectedItem.ToString();
                AIO.command = "select id,(select custName from Customer where id =payCustID) as [Name],payMethod as [Cash Mode],payType as [Payment Type],payCheck as [Cheque No],payAmount as [Amount],payDate as [Date],payDesc as [Desc] from Payment as [Payment1] where payDate between '" + dtpPaymentStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPaymentEnd.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + payMode + "" + payType + "" + sort + "" + asc;
                var dt = a1.dataload();
                dgvPayment.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshExpense()
        {
            try
            {
                AIO.command = "select id,expName as [Name],expAmount as [Amount],expDate as [Date] from Expense where expDate between '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' order by [Date] DESC";
                var dt = a1.dataload();
                dgvExpense.DataSource = dt;
                dgvExpense.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    string id = dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString();

                    AIO.command = "delete from TranItemsGrid where itgTranID=" + id;
                    a1.cmdexe();
                    AIO.command = "delete from TranOtherDetails where todTransID=" + id;
                    a1.cmdexe();
                    AIO.command = "delete from Trans where id=" + id;
                    a1.cmdexe();
                }

                RefreshTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SwitchTabPages(AllTabs tab)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    foreach (TabPage page in tabControl1.TabPages)
                    {
                        tabControl1.TabPages.Remove(page);
                    }
                }
                tabControl1.TabPages.Add(allTabs[(int)tab]);
                tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Company);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Category);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.AboutMe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void termsAndConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.TermsAndCondition);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                custType = customerToolStripMenuItem.Text;
                btnPayCust.Text = customerToolStripMenuItem.Text;
                btnTRCust.Text = customerToolStripMenuItem.Text;
                TabCustomer.Text = customerToolStripMenuItem.Text;
                RefreshCustomer();
                SwitchTabPages(AllTabs.Customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Transaction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {

                    frmPayment fr = new frmPayment();
                    fr.StartPosition = FormStartPosition.CenterParent;
                    fr.Stat = FrmCompany.PaymentAdd;
                    fr.OutAmount = Convert.ToDouble(txtOutstanding.Text);
                    fr.custID = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["id"].Value);
                    fr.custName = dgvCustomer.SelectedRows[0].Cells["Name"].Value.ToString();
                    fr.ShowDialog();

                    RefreshCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpense.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from Expense where id=" + dgvExpense.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }

                RefreshExpense();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void addToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                frmExpense fr = new frmExpense();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.ShowDialog();

                RefreshExpense();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    double payReceive = 0, payDone = 0, tranPurchase = 0, tranSell = 0;
                    string id = dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString();

                    AIO.command = "select sum(payAmount) from Payment where payCustId=" + id + " and payType='Receive'";
                    var tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        payReceive = Convert.ToDouble(tmp);
                    AIO.command = "select sum(payAmount) from Payment where payCustId=" + id + " and payType='Paid'";
                    tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        payDone = Convert.ToDouble(tmp);
                    AIO.command = "select sum(tranFinalTotal) from Trans where TranCustID=" + id + " and tranType='Purchase'";
                    tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        tranPurchase = Convert.ToDouble(tmp);
                    AIO.command = "select sum(tranFinalTotal) from Trans where TranCustID=" + id + " and tranType='Sale'";
                    tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        tranSell = Convert.ToDouble(tmp);

                    //double outstand = (tranPurchase - payDone) - (tranSell - payReceive);
                    double outstand = (tranSell - payReceive) - (tranPurchase - payDone);
                    txtOutstanding.Text = outstand.ToString();
                    txtOutstanding.BackColor = txtOutstanding.BackColor;
                    if (outstand > 0)
                        txtOutstanding.ForeColor = Color.Green;
                    else if (outstand < 0)
                        txtOutstanding.ForeColor = Color.Red;
                    else
                        txtOutstanding.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCustSearch.Text))
                    AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN] from Customer as c where custType='" + custType + "'";
                else
                    AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN] from Customer as c where custName like '%" + txtCustSearch.Text + "%' and custType='" + custType + "'";
                var dt = a1.dataload();
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Expense);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsExpense_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvExpense.SelectedRows.Count > 0)
                {
                    cmsExpense.Items[0].Text = dgvExpense.SelectedRows[0].Cells["id"].Value.ToString();
                    cmsExpense.Items[3].Enabled = true;
                }
                else
                {
                    cmsExpense.Items[0].Text = "";
                    cmsExpense.Items[3].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmsTandC_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvTC.SelectedRows.Count > 0)
                {
                    cmsTandC.Items[0].Text = dgvTC.SelectedRows[0].Cells["id"].Value.ToString();
                    cmsTandC.Items[3].Enabled = true;
                    cmsTandC.Items[4].Enabled = true;
                }
                else
                {
                    cmsTandC.Items[0].Text = "";
                    cmsTandC.Items[3].Enabled = false;
                    cmsTandC.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTranBillView_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    if (btnTranBillView.Text == "Generate Bill")
                    {
                        frmMainBillView fr = new frmMainBillView();
                        fr.StartPosition = FormStartPosition.CenterParent;
                        fr.ShowInTaskbar = false;
                        fr.ID = int.Parse(dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString());
                        fr.ShowDialog();
                    }
                    else if (btnTranBillView.Text == "Copy to Sale")
                    {
                        frmCopytoSale fr = new frmCopytoSale();
                        fr.StartPosition = FormStartPosition.CenterParent;
                        fr.estID = Convert.ToInt32(dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString());
                        fr.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void xButtons1_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Home);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                AIO.command = "select sum(tranFinalTotal) from Trans where TranDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and tranType='Purchase' ";
                lblTotalPurchase.Text = a1.cmdexesc().ToString();

                AIO.command = "select sum(payAmount) from Payment where payDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and payType='Paid' ";
                lblTotalPaymentDone.Text = a1.cmdexesc().ToString();

                AIO.command = "select sum(tranFinalTotal) from Trans where TranDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and tranType='Sale' ";
                lblTotalSell.Text = a1.cmdexesc().ToString();

                AIO.command = "select sum(payAmount) from Payment where payDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and payType='Receive' ";
                lblTotalPaymentR.Text = a1.cmdexesc().ToString();

                AIO.command = "select sum(expAmount) from Expense where expDate between  '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' ";
                lblTotalExpense.Text = a1.cmdexesc().ToString();




                double TotalPurhcase = 0, TotalPaymentDone = 0, TotalSell = 0, TotalPaymentR = 0, TotalExpense = 0, TotalProfit = 0;

                if (!string.IsNullOrWhiteSpace(lblTotalPurchase.Text))
                    TotalPurhcase = Convert.ToDouble(lblTotalPurchase.Text);
                else
                    lblTotalPurchase.Text = "0";
                if (!string.IsNullOrWhiteSpace(lblTotalPaymentDone.Text))
                    TotalPaymentDone = Convert.ToDouble(lblTotalPaymentDone.Text);
                else
                    lblTotalPaymentDone.Text = "0";
                if (!string.IsNullOrWhiteSpace(lblTotalSell.Text))
                    TotalSell = Convert.ToDouble(lblTotalSell.Text);
                else
                    lblTotalSell.Text = "0";
                if (!string.IsNullOrWhiteSpace(lblTotalPaymentR.Text))
                    TotalPaymentR = Convert.ToDouble(lblTotalPaymentR.Text);
                else
                    lblTotalPaymentR.Text = "0";
                if (!string.IsNullOrWhiteSpace(lblTotalExpense.Text))
                    TotalExpense = Convert.ToDouble(lblTotalExpense.Text);
                else
                    lblTotalExpense.Text = "0";

                TotalProfit = (TotalSell - TotalPurhcase - TotalExpense);
                lblTotalProfit.Text = TotalProfit.ToString();
                if (TotalProfit > 0)
                    lblTotalProfit.ForeColor = Color.Green;
                else if (TotalProfit < 0)
                    lblTotalProfit.ForeColor = Color.Red;
                else
                    lblTotalProfit.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPaymentDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshPayment();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Payment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabGeneral_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bsngeneralsave_Click(object sender, EventArgs e)
        {
            try
            {
                AIO.command = "select pass from GeneralSettings where id=1";
                var temp5 = a1.cmdexesc();

                if (string.IsNullOrWhiteSpace(txtoldpass.Text) || string.IsNullOrWhiteSpace(txtoldpass.Text) || string.IsNullOrWhiteSpace(txtoldpass.Text) || string.IsNullOrWhiteSpace(txtoldpass.Text))
                {
                    MessageBox.Show("Blank is not Allow", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (txtoldpass.Text == temp5.ToString())
                    {
                        if (txtnewpass1.Text == txtnewpass2.Text)
                        {
                            AIO.command = "update GeneralSettings set pass='" + txtnewpass1.Text + "' where id=1";
                            a1.cmdexe();
                            MessageBox.Show("Password changed Successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtoldpass.Clear();
                            txtnewpass1.Clear();
                            txtnewpass2.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Password Does Not Match", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password is Incorrect", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btngeneraltaxsave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(txttax1name.Text) || string.IsNullOrWhiteSpace(txttax2name.Text) || string.IsNullOrWhiteSpace(txttax2percentage.Text) || string.IsNullOrWhiteSpace(txttax2percentages.Text))
                //{

                //}
                //else
                //{
                //    string tax1 = "", tax2 = "";
                //    tax1 = txttax1name.Text.Replace("'", "''");
                //    tax2 = txttax2name.Text.Replace("'", "''");
                //    AIO.command = "update GeneralSettings set tax1name='" + tax1 + "', tax2name='" + tax2 + "',tax1per=" + txttax2percentage.Text + ",tax2per=" + txttax2percentages.Text + " where id=1";
                //    a1.cmdexe();
                //    RefreshGeneralSettings();

                //    MessageBox.Show("Saved Successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void xButtons2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Blank is not allow", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AIO.command = "select pass from GeneralSettings where id=1";
                    var temp4 = a1.cmdexesc();

                    if (temp4.ToString() == textBox2.Text)
                    {
                        menuStrip1.Visible = true;
                        btnHomePage.Visible = true;
                        this.AcceptButton = null;
                        SwitchTabPages(AllTabs.Home);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Pasword", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btngeneralenable_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupBox3.Enabled == true)
                {
                    groupBox3.Enabled = false;
                    btngeneralenable.Text = "Disable";
                }
                else
                {
                    groupBox3.Enabled = true;
                    btngeneralenable.Text = "Enable";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGeneralSettings()
        {
            try
            {
                AIO.command = "select id,pass,tax1name,tax2name,tax1per,tax2per from GeneralSettings";
                var dt = a1.dataload();
                if (dt.Rows.Count > 0 && !DBNull.Value.Equals(dt.Rows[0][0]))
                {
                    //txttax1name.Text = dt.Rows[0]["tax1name"].ToString();
                    //txttax2name.Text = dt.Rows[0]["tax2name"].ToString();
                    //txttax2percentage.Text = dt.Rows[0]["tax1per"].ToString();
                    //txttax2percentages.Text = dt.Rows[0]["tax2per"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.GeneralSettings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTabPages(AllTabs.Bank);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsBank_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvBank.SelectedRows.Count > 0)
                {

                    cmsBank.Items[0].Text = dgvBank.SelectedRows[0].Cells["Name"].Value.ToString();
                    cmsBank.Items[3].Enabled = true;
                    cmsBank.Items[4].Enabled = true;
                }
                else
                {
                    cmsBank.Items[0].Text = "";
                    cmsBank.Items[3].Enabled = false;
                    cmsBank.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xButtons1_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmpaymentreport fr = new frmpaymentreport();
                //string custName = "", payMode = "";
                //if (cmbCustomerName.SelectedIndex > 0)
                //    custName = " and payCustID=" + cmbCustomerName.SelectedIndex;
                //if (cmbPaymentMethod.SelectedIndex > 0)
                //    payMode = " and payMethod='" + cmbPaymentMethod.SelectedItem.ToString() + "'";
                string custName = "", payMode = "", payType = "";
                if (cmbCustomerName.SelectedIndex > 0)
                    custName = " and payCustID=" + CustID[cmbCustomerName.SelectedIndex];
                if (cmbPaymentMethod.SelectedIndex > 0)
                    payMode = " and payMethod='" + cmbPaymentMethod.SelectedItem.ToString() + "'";
                if (cmbPaymentType.SelectedIndex > 0)
                    payType = " and payType='" + cmbPaymentType.SelectedItem.ToString() + "'";
                fr.CID = "select id,(select custName from Customer where id =payCustID) as [pname],payMethod as [pmethod],payType as [ptype],payCheck as [pchequeno],payAmount as [pamount],payDate as [pdate] from Payment as [Payment1] where payDate between '" + dtpPaymentStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPaymentEnd.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + payMode + "" + payType;
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xButtons4_Click(object sender, EventArgs e)
        {
            try
            {
                //AIO.command = "select id,expName as [Name],expAmount as [Amount],expDate as [Date] from Expense where expDate between '" +  dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                //var dt = a1.dataload();
                //dgvPayment.DataSource = dt;
                //dgvPayment.Columns["id"].Visible = false;
                RefreshExpense();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xButtons3_Click(object sender, EventArgs e)
        {
            try
            {
                frmExpenseReport fr = new frmExpenseReport();
                fr.EID = "select expName as [name],expDate as [date],expAmount as [amount] from Expense where expDate between '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransReport_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.TransactionReport);
        }

        private void btnTRShow_Click(object sender, EventArgs e)
        {
            //if (cmbTRCustomerName.SelectedIndex <= 0 && cmbTRType.SelectedIndex <= 0)
            //{
            //AIO.command = "select id,(select custName from Customer) as [Name],payMethod,payType,payCheck,payAmount,payDate,payDesc from Payment where payDate between '" + dtpPaymentStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPaymentEnd.Value.ToString("yyyy-MM-dd") + "'";
            string custName = "", tranType = " and tranType!='Estimate'", sort = "", asc = "";
            if (cmbTRCustomerName.SelectedIndex > 0)
                custName = " and tranCustID=" + CustID[cmbTRCustomerName.SelectedIndex];
            if (cmbTRType.SelectedIndex > 0)
                tranType = " and tranType='" + cmbTRType.SelectedItem.ToString() + "'";
            if (cmbTRSort.SelectedIndex > 0)
                sort = " order by [" + cmbTRSort.SelectedItem.ToString() + "]";
            if (cmbTRSort.SelectedIndex > 0 && cmbTRASC.SelectedIndex > 0)
                asc = " " + cmbTRASC.SelectedItem.ToString();
            AIO.command = "select id,tranNo as [No],(select custName from Customer where id =tranCustID) as [Name],tranType as [Type],tranDate as [Date],tranTotal as [Amount],(tranTax1/100 * tranTotal) as [Tax1],(tranTax2/100 * tranTotal) as [Tax2],tranFinalTotal as [Total] from Trans where custType='" + btnTRCust.Text + "' tranDate between '" + dtpTRFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTRTo.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + tranType + "" + sort + "" + asc;
            var dt = a1.dataload();
            dgvTR.DataSource = dt;
            dgvTR.Columns["id"].Visible = false;


            //}
            //else if (cmbTRCustomerName.SelectedIndex > 0 && cmbTRType.SelectedIndex <= 0)
            //{
            //    string custName = "", tranType = "";
            //    if (cmbTRCustomerName.SelectedIndex > 0)
            //        custName = " and tranCustID=" + cmbTRCustomerName.SelectedIndex;
            //    if (cmbTRType.SelectedIndex > 0)
            //        tranType = " and tranType='" + cmbTRType.SelectedItem.ToString() + "'";
            //    AIO.command = "select id,tranNo as [No],(select custName from Customer where id =tranCustID) as [Name],tranType as [Type],tranDate as [Date],tranTotal as [Amount],(tranTax1/100 * tranTotal) as [Tax1],(tranTax2/100 * tranTotal) as [Tax2],tranFinalTotal as [Total] from Trans where tranDate between '" + dtpTRFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTRTo.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + tranType;
            //    var dt = a1.dataload();
            //    dgvTR.DataSource = dt;
            //    dgvTR.Columns["id"].Visible = false;

            //}
            //else if (cmbTRCustomerName.SelectedIndex > 0 && cmbTRType.SelectedIndex > 0)
            //{
            //    string custName = "", tranType = "";
            //    if (cmbTRCustomerName.SelectedIndex > 0)
            //        custName = " and tranCustID=" + cmbTRCustomerName.SelectedIndex;
            //    if (cmbTRType.SelectedIndex > 0)
            //        tranType = " and tranType='" + cmbTRType.SelectedItem.ToString() + "'";
            //    AIO.command = "select id,tranNo as [No],(select custName from Customer where id =tranCustID) as [Name],tranType as [Type],tranDate as [Date],tranTotal as [Amount],(tranTax1/100 * tranTotal) as [Tax1],(tranTax2/100 * tranTotal) as [Tax2],tranFinalTotal as [Total] from Trans where tranDate between '" + dtpTRFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTRTo.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + tranType;
            //    var dt = a1.dataload();
            //    dgvTR.DataSource = dt;
            //    dgvTR.Columns["id"].Visible = false;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Selection", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnTRPrint_Click(object sender, EventArgs e)
        {
            try
            {
                frmTransactionReport fr = new frmTransactionReport();
                string custName = "", tranType = " and tranType!='Estimate'", sort = "", asc = "";
                if (cmbTRCustomerName.SelectedIndex > 0)
                    custName = " and tranCustID=" + CustID[cmbTRCustomerName.SelectedIndex];
                if (cmbTRType.SelectedIndex > 0)
                    tranType = " and tranType='" + cmbTRType.SelectedItem.ToString() + "'";
                if (cmbTRSort.SelectedIndex > 0)
                    sort = " order by [" + cmbTRSort.SelectedItem.ToString() + "]";
                if (cmbTRSort.SelectedIndex > 0 && cmbTRASC.SelectedIndex > 0)
                    asc = " " + cmbTRASC.SelectedItem.ToString();
                //fr.query = "select id,tranNo as [No],(select custName from Customer where id =tranCustID) as [cname],tranType as [type],tranDate as [date],tranTotal as [amount],(tranTax1/100 * tranTotal) as [tax1],(tranTax2/100 * tranTotal) as [tax2],tranFinalTotal as [total] from Trans where tranDate between '" + dtpTRFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTRTo.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + tranType;
                fr.query = "select id,tranNo as [No],(select custName from Customer where id =tranCustID) as [Name],tranType as [Type],tranDate as [Date],tranTotal as [Amount],(tranTax1/100 * tranTotal) as [Tax1],(tranTax2/100 * tranTotal) as [Tax2],tranFinalTotal as [Total] from Trans where custType='" + btnTRCust.Text + "' tranDate between '" + dtpTRFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTRTo.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + tranType + "" + sort + "" + asc;
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtExpenseSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = txtExpenseSearch.Text.Replace("'", "''");
                if (string.IsNullOrWhiteSpace(txtExpenseSearch.Text))
                    RefreshExpense();
                else
                    AIO.command = "select id,expName as [Name],expAmount as [Amount],expDate as [Date] from Expense where expName like '%" + name + "%' and expDate between '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
                var dt = a1.dataload();
                dgvExpense.DataSource = dt;
                dgvExpense.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnTransType.Text = btnAll.Text;
            btnTranBillView.Visible = false;

            btnTransCustSearch.Text = "Transaction No";
            tranSearchStat = TranSearc.TransNo;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;

            btnPDF.Visible = false;
            RefreshTransaction();

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            btnTransType.Text = btnPurchase.Text;
            //btnTransCustSearch.Text = "Supplier";
            //tranSearchStat = TranSearc.Customer;

            btnTransCustSearch.Text = "Transaction No";
            tranSearchStat = TranSearc.TransNo;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;

            custType = "Supplier";
            btnTranBillView.Visible = false;
            btnPDF.Visible = false;
            custType = supplierToolStripMenuItem.Text;
            RefreshTransaction();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            btnTransType.Text = btnSale.Text;
            //btnTransCustSearch.Text = "Customer";
            //tranSearchStat = TranSearc.Customer;

            btnTransCustSearch.Text = "Transaction No";
            tranSearchStat = TranSearc.TransNo;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;

            custType = "Customer";
            btnTranBillView.Visible = true;
            btnTranBillView.Text = "Generate Bill";
            btnPDF.Visible = false;
            custType = customerToolStripMenuItem.Text;
            RefreshTransaction();
        }

        private void btnEstimate_Click(object sender, EventArgs e)
        {
            btnTransType.Text = btnEstimate.Text;
            //btnTransCustSearch.Text = "Customer";
            //tranSearchStat = TranSearc.Customer;

            btnTransCustSearch.Text = "Transaction No";
            tranSearchStat = TranSearc.TransNo;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            comboBox2.SelectedIndex = -1;

            custType = "Customer";
            btnTranBillView.Visible = true;
            btnTranBillView.Text = "Copy to Sale";
            btnPDF.Visible = true;
            btnPDF.Text = "Generate Print";
            custType = customerToolStripMenuItem.Text;
            RefreshTransaction();
        }

        private void txtTransactionSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "", param = "";
                //if (btnTransType.Text == "All")
                //    query = "";
                ////AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
                //else if (btnTransType.Text == "Purchase")
                //    query = " where tranType='Purchase'";
                ////AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
                //else if (btnTransType.Text == "Sale")
                //    query = " where tranType='Sale'";
                ////AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
                //else if (btnTransType.Text == "Estimate")
                //    query = " where tranType='Estimate'";
                switch (tranSearchStat)
                {
                    case TranSearc.Customer:
                        {

                        }
                        break;
                    case TranSearc.Item:
                        {

                        }
                        break;
                    case TranSearc.TransNo:
                        {

                        }
                        break;
                    default:
                        {
                        }
                        break;
                }

                if (string.IsNullOrWhiteSpace(txtTransactionSearch.Text))
                    param = "";
                else
                    param = " where tranNo like '%" + txtTransactionSearch.Text + "%'";
                AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + param + " order by id DESC";
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    frmMainBillView fr = new frmMainBillView();
                    fr.StartPosition = FormStartPosition.CenterParent;
                    fr.ShowInTaskbar = false;
                    fr.ID = int.Parse(dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString());
                    fr.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.AboutUs);
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custType = supplierToolStripMenuItem.Text;
            btnPayCust.Text = supplierToolStripMenuItem.Text;
            btnTRCust.Text = supplierToolStripMenuItem.Text;
            TabCustomer.Text = supplierToolStripMenuItem.Text;
            RefreshCustomer();
            SwitchTabPages(AllTabs.Customer);
        }

        private void btnPayCust_Click(object sender, EventArgs e)
        {
            if (btnPayCust.Text == customerToolStripMenuItem.Text)
            {
                btnPayCust.Text = supplierToolStripMenuItem.Text;
                btnTRCust.Text = supplierToolStripMenuItem.Text;
                custType = supplierToolStripMenuItem.Text;
                RefreshCustomer();
            }
            else if (btnPayCust.Text == supplierToolStripMenuItem.Text)
            {
                btnPayCust.Text = customerToolStripMenuItem.Text;
                btnTRCust.Text = customerToolStripMenuItem.Text;
                custType = customerToolStripMenuItem.Text;
                RefreshCustomer();
            }
        }

        private void btnTRCust_Click(object sender, EventArgs e)
        {
            if (btnTRCust.Text == customerToolStripMenuItem.Text)
            {
                btnPayCust.Text = supplierToolStripMenuItem.Text;
                btnTRCust.Text = supplierToolStripMenuItem.Text;
                custType = supplierToolStripMenuItem.Text;
                RefreshCustomer();
            }
            else if (btnTRCust.Text == supplierToolStripMenuItem.Text)
            {
                btnPayCust.Text = customerToolStripMenuItem.Text;
                btnTRCust.Text = customerToolStripMenuItem.Text;
                custType = customerToolStripMenuItem.Text;
                RefreshCustomer();
            }
        }

        private void cmsPayment_Opening(object sender, CancelEventArgs e)
        {
            if (dgvPayment.SelectedRows.Count > 0)
            {
                cmsPayment.Items[0].Text = dgvPayment.SelectedRows[0].Cells["id"].Value.ToString();
                cmsPayment.Items[2].Enabled = true;
                cmsPayment.Items[3].Enabled = true;
            }
            else
            {
                cmsPayment.Items[0].Text = "";
                cmsPayment.Items[2].Enabled = false;
                cmsPayment.Items[3].Enabled = false;
            }

        }

        private void dgvCustomer_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvCompany_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvCategory_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvModel_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvBank_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvTC_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvTransaction_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvExpense_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvPayment_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dgvTR_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void deleteToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (dgvPayment.SelectedRows.Count > 0)
            {
                AIO.command = "delete from Payment where id=" + dgvPayment.SelectedRows[0].Cells["id"].Value.ToString();
                a1.cmdexe();
                RefreshPayment();
            }
        }

        private void editToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (dgvPayment.SelectedRows.Count > 0)
            {
                frmPayment fr = new frmPayment();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.PaymentEdit;
                fr.row = ((DataTable)dgvPayment.DataSource).Rows[dgvPayment.SelectedRows[0].Index];
                fr.ShowDialog();

                RefreshPayment();
            }
        }

        private void txtRegSubmit_Click(object sender, EventArgs e)
        {
            ProdReg(txtRegSerial.Text);
        }

        private void tabReg_Click(object sender, EventArgs e)
        {

        }

        private void btnTMSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTMType.Text) || string.IsNullOrWhiteSpace(txtTMTax1Name.Text) || string.IsNullOrWhiteSpace(txtTMTax1.Text))
            {
                MessageBox.Show("You can't leave any field Blank.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTMTax2.Text))
                    txtTMTax2.Text = "0";
                AIO.command = "insert into TaxMaster(tmType,tmTax1Name,tmTax1,tmTax2Name,tmTax2) values('" + txtTMType.Text + "','" + txtTMTax1Name.Text + "'," + txtTMTax1.Text + ",'" + txtTMTax2Name.Text + "'," + txtTMTax2.Text + ")";
                a1.cmdexe();

                txtTMType.Clear();
                txtTMTax1.Clear();
                txtTMTax1Name.Clear();
                txtTMTax2.Clear();
                txtTMTax2Name.Clear();

                RefreshTaxMaster();

            }
        }

        private void RefreshTaxMaster()
        {
            AIO.command = "select id,tmType as [Type],tmTax1Name as [Tax1 Name],tmTax1 as [Tax1],tmTax2Name as [Tax2 Name],tmTax2 as [Tax2] from TaxMaster";
            var dt = a1.dataload();
            dgvTM.DataSource = dt;
            dgvTM.Columns["id"].Visible = false;
        }

        private void cmsTaxMaster_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTM.SelectedRows.Count > 0)
            {
                cmsTaxMaster.Items[0].Text = dgvTM.SelectedRows[0].Cells["Type"].Value.ToString();
                cmsTaxMaster.Items[2].Enabled = true;
            }
            else
            {
                cmsTaxMaster.Items[0].Text = "";
                cmsTaxMaster.Items[2].Enabled = false;
            }
        }

        private void dgvTM_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void taxMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.TaxMaster);
        }


        /// <summary>
        /// To Turn off Flickring
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void deleteToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (dgvTM.SelectedRows.Count > 0)
            {
                AIO.command = "delete from TaxMaster where id=" + dgvTM.SelectedRows[0].Cells["id"].Value.ToString();
                a1.cmdexe();
                RefreshTaxMaster();
            }
        }

        private void btnTransCustSearch_Click(object sender, EventArgs e)
        {
            if (btnTransCustSearch.Text == "Transaction No")
            {
                if (btnTransType.Text == "Purchase")
                {
                    btnTransCustSearch.Text = "Supplier";
                    tranSearchStat = TranSearc.Customer;
                    custType = "Supplier";
                }
                else
                {
                    btnTransCustSearch.Text = "Customer";
                    tranSearchStat = TranSearc.Customer;
                    custType = "Customer";
                }
                comboBox2.Text = "";
                AIO.command = "select c.id,c.custName as [Name] from Customer as c where custType='" + custType + "' order by [Name]";
                var dt = a1.dataload();
                CustIDSearch.Clear();
                comboBox2.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    comboBox2.Items.Add(row["Name"].ToString());
                    CustIDSearch.Add(long.Parse(row["id"].ToString()));
                }
                comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;


            }
            else if (btnTransCustSearch.Text == "Customer")
            {
                if (btnTransType.Text == "Sale" || btnTransType.Text == "Estimate")
                {
                    btnTransCustSearch.Text = "Transaction No";
                    tranSearchStat = TranSearc.TransNo;
                    comboBox2.Items.Clear();
                    comboBox2.Text = "";
                    comboBox2.SelectedIndex = -1;

                }
                else
                {
                    btnTransCustSearch.Text = "Supplier";
                    tranSearchStat = TranSearc.Customer;
                    custType = "Supplier";
                    AIO.command = "select c.id,c.custName as [Name] from Customer as c where custType='" + custType + "' order by [Name]";
                    var dt = a1.dataload();
                    CustIDSearch.Clear();
                    comboBox2.Items.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        comboBox2.Items.Add(row["Name"].ToString());
                        CustIDSearch.Add(long.Parse(row["id"].ToString()));
                    }
                    comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                comboBox2.Text = "";
                
            }
            else
            {
                btnTransCustSearch.Text = "Transaction No";
                tranSearchStat = TranSearc.TransNo;
                comboBox2.Items.Clear();
                comboBox2.Text = "";
            }

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            //if (tranSearchStat == TranSearc.TransNo)
            //{
            //    string query = "", param = "";
            //    if (string.IsNullOrWhiteSpace(comboBox2.Text))
            //    {
            //        //param = " where tranDate between '"+dtpTransFrom.Value.ToString("yyyy-MM-dd")+"' and '"+dtpTransTo.Value.ToString("yyyy-MM-dd")+"'";
            //      if (btnTransType.Text == "All")
            //            param = " where tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
            //        //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
            //        else if (btnTransType.Text == "Purchase")
            //            param = " where tranType='Purchase' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
            //        //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
            //        else if (btnTransType.Text == "Sale")
            //            param = " where tranType='Sale' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
            //        //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
            //        else if (btnTransType.Text == "Estimate")
            //            param = " where tranType='Estimate' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
            //    }
            //    else
            //        param = " where tranNo like '%" + comboBox2.Text + "%' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
            //    AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + param + " order by id DESC";
            //    var dt = a1.dataload();
            //    dgvTransaction.DataSource = dt;
            //    dgvTransaction.Columns["id"].Visible = false;
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tranSearchStat == TranSearc.Customer)
            {
                string query = "", param = "", sort = "", asc = "";

                if (comboBox2.SelectedIndex < 0)
                    param = " where tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                else
                {
                    if (btnTransType.Text == "All")
                    {
                        param = " where tranCustID=" + CustIDSearch[comboBox2.SelectedIndex] + " and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "' ";
                    }
                    else
                    {
                        param = " where tranCustID=" + CustIDSearch[comboBox2.SelectedIndex] + " and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "' and tranType='" + btnTransType.Text + "'";
                    }
                    //query = CustIDSearch[comboBox2.SelectedIndex].ToString();
                    if (cmbTransSort.SelectedIndex > 0)
                        sort = " order by [" + cmbTransSort.SelectedItem.ToString() + "]";
                    if (cmbTransSort.SelectedIndex > 0 && cmbTransASC.SelectedIndex > 0)
                        asc = " " + cmbTransASC.SelectedItem.ToString();
                }
                AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + param + ""+sort+""+asc+"";
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
            }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            if (tranSearchStat == TranSearc.TransNo)
            {
                string query = "", param = "", sort = "", asc = "";
                if (!string.IsNullOrWhiteSpace(comboBox2.Text))
                {
                    //param = " where tranDate between '"+dtpTransFrom.Value.ToString("yyyy-MM-dd")+"' and '"+dtpTransTo.Value.ToString("yyyy-MM-dd")+"'";
                    if (btnTransType.Text == "All")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
                    else if (btnTransType.Text == "Purchase")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranType='Purchase' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
                    else if (btnTransType.Text == "Sale")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranType='Sale' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
                    else if (btnTransType.Text == "Estimate")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranType='Estimate' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    if (btnTransType.Text == "All")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
                    else if (btnTransType.Text == "Purchase")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranType='Purchase' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
                    else if (btnTransType.Text == "Sale")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranType='Sale' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
                    else if (btnTransType.Text == "Estimate")
                        param = " where tranNo like '%" + comboBox2.Text + "%' and tranType='Estimate' and tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                }

                if (cmbTransSort.SelectedIndex > 0)
                    sort = " order by [" + cmbTransSort.SelectedItem.ToString() + "]";
                if (cmbTransSort.SelectedIndex > 0 && cmbTransASC.SelectedIndex > 0)
                    asc = " " + cmbTransASC.SelectedItem.ToString();

                AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + param + ""+sort+""+asc+"";
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
            }
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            frmStockReport fr = new frmStockReport();
            fr.fromDate = dtpFromStock.Value;
            fr.ToDate = dtpToStock.Value;
            fr.StartDate = dtpStartStock.Value;
            fr.StartPosition = FormStartPosition.CenterParent;
            fr.ShowDialog();
        }

        private void dgvHsn_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                frmHsnTax fr = new frmHsnTax();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.HSNAdd;

                fr.ShowDialog();
                RefreshHSN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshHSN()
        {
            
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                frmHsnTax fr = new frmHsnTax();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.HSNEdit;
                fr.ShowDialog();

                RefreshHSN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHsn.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from Customer where id=" + dgvHsn.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }
                RefreshHSN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHsn_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {
                    double payReceive = 0, payDone = 0, tranPurchase = 0, tranSell = 0;
                    string id = dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString();

                    AIO.command = "select sum(payAmount) from Payment where payCustId=" + id + " and payType='Receive'";
                    var tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        payReceive = Convert.ToDouble(tmp);
                    AIO.command = "select sum(payAmount) from Payment where payCustId=" + id + " and payType='Paid'";
                    tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        payDone = Convert.ToDouble(tmp);
                    AIO.command = "select sum(tranFinalTotal) from Trans where TranCustID=" + id + " and tranType='Purchase'";
                    tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        tranPurchase = Convert.ToDouble(tmp);
                    AIO.command = "select sum(tranFinalTotal) from Trans where TranCustID=" + id + " and tranType='Sale'";
                    tmp = a1.cmdexesc();
                    if (!DBNull.Value.Equals(tmp))
                        tranSell = Convert.ToDouble(tmp);

                    //double outstand = (tranPurchase - payDone) - (tranSell - payReceive);
                    double outstand = (tranSell - payReceive) - (tranPurchase - payDone);
                    txtOutstanding.Text = outstand.ToString();
                    txtOutstanding.BackColor = txtOutstanding.BackColor;
                    if (outstand > 0)
                        txtOutstanding.ForeColor = Color.Green;
                    else if (outstand < 0)
                        txtOutstanding.ForeColor = Color.Red;
                    else
                        txtOutstanding.ForeColor = Color.Black;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsHsnMaster_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvHsn.SelectedRows.Count > 0)
                {
                    cmsHsnMaster.Items[0].Text = dgvHsn.SelectedRows[0].Cells["id"].Value.ToString();
                    cmsHsnMaster.Items[3].Enabled = true;
                    cmsHsnMaster.Items[4].Enabled = true;
                }
                else
                {
                    cmsHsnMaster.Items[0].Text = "None";
                    cmsHsnMaster.Items[3].Enabled = false;
                    cmsHsnMaster.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hSNMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.HSNMaster);
        }
    }
}

