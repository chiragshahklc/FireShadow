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
using System.Management;
using System.IO;
using System.Collections;

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
        List<int> lstPaymentModeID = new List<int>();
        List<int> lstTransactionTypeID = new List<int>();
        List<TabPage> allTabs = new List<TabPage>();
        public string custType { get; set; }
        TranSearc tranSearchStat { get; set; }

        public MasterForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void txtAboutCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAboutCompanyEmail_Leave(object sender, EventArgs e)
        {

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
                //Load Payment Mode with default values - Payment
                AIO.command = "select id, pmName from PaymentMode";
                using (var dt = a1.dataload())
                {
                    cmbPaymentMethod.Items.Clear();
                    lstPaymentModeID.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPaymentMethod.Items.Add(row["pmName"].ToString());
                        lstPaymentModeID.Add(int.Parse(row["id"].ToString()));
                    }
                    cmbPaymentMethod.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbPaymentMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }

                //Load Transaction Type with default values - Payment
                AIO.command = "select id, trtName from TranTypes";
                using (var dt = a1.dataload())
                {
                    cmbPaymentType.Items.Clear();
                    lstTransactionTypeID.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPaymentType.Items.Add(row["trtName"].ToString());
                        lstTransactionTypeID.Add(int.Parse(row["id"].ToString()));
                    }
                    cmbPaymentType.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbPaymentType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }

                btnPayCust.Text = customerToolStripMenuItem.Text;
                btnTRCust.Text = customerToolStripMenuItem.Text;
                custType = customerToolStripMenuItem.Text;


                RefreshGeneralSettings();
                refreshbank();
                RefreshCustomer();
                RefreshAboutMe();
                RefreshTransaction();
                RefreshExpense();
                refreshTandD();
                RefreshHSN();
                RefreshNewItem();
                RefreshPayment();
                tabControl1.Visible = false;
                foreach (TabPage page in tabControl1.TabPages)
                {
                    allTabs.Add(page);
                    tabControl1.TabPages.Remove(page);
                }
                tabControl1.Visible = true;

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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCustomer()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT c.id, ");
                sb.Append("c.custName as [Name], ");
                sb.Append("c.custAdd as [Address], ");
                sb.Append("c.custMob as [Mobile], ");
                sb.Append("c.custEmail as [Email], ");
                sb.Append("c.custVatTIN as [GSTIN], ");
                sb.Append("c.custCstNo as [CST No], ");
                sb.Append("c.custPAN as [PAN], ");
                sb.Append("c.custOpenBal, ");
                //From here logic is for customer
                //
                if (custType == "Customer")
                {
                    sb.Append("Round(c.custOpenBal + (coalesce(sum(itg.itgTotal), 0) + coalesce(sum((coalesce(itg.itgTotal, 0) * (h.igst / 100))), 0)) - ( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 2 ");
                    sb.Append(")");
                    sb.Append("-( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 3 ");
                    sb.Append(") ");
                    sb.Append("+( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 1 ");
                    sb.Append("), 0) [Outstanding Balance] ");
                }
                //
                //From Here logic is for supplier
                //
                else if (custType == "Supplier")
                {
                    sb.Append("Round(c.custOpenBal - (coalesce(sum(itg.itgTotal), 0) + coalesce(sum((coalesce(itg.itgTotal, 0) * (h.igst / 100))), 0)) + ( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 1 ");
                    sb.Append(")");
                    sb.Append("+( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 4 ");
                    sb.Append(") ");
                    sb.Append("-( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 2 ");
                    sb.Append("), 0) [Outstanding Balance] ");
                }

                sb.Append("FROM Customer AS c ");
                sb.Append("LEFT JOIN ");
                sb.Append("Trans2 t ON t.tranCustID = c.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS itg ON t.id = itg.itgTranID ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items AS i ON itg.itgModID = i.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("HsnTax AS h ON i.hsnId = h.id ");
                sb.Append("WHERE custType='" + custType + "' ");
                sb.Append("GROUP BY c.custName order by [Name]");
                AIO.command = sb.ToString();

                txtCustSearch.Clear();
                //AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN],c.custOpenBal from Customer as c where custType='" + custType + "' order by [Name]";
                var dt = a1.dataload();
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["id"].Visible = false;
                dgvCustomer.Columns["Address"].Visible = false;
                dgvCustomer.Columns["custOpenBal"].Visible = false;
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

           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Yordle()
        {

            return false;
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //label46.Text = txtAboutCompanyName.Text;
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dgvBank.SelectedRows[0].Cells["id"].Value.ToString() != "1")
                {
                    fr.ShowDialog();
                    refreshbank();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshbank()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT Banks.id,Banks.bnkName as [Name],Banks.bnkBranch as [Branch],Banks.bnkACNo as [AccountNo],Banks.bnkIFSC as [IFSC],Banks.bnkOpeningBalance as [Opening Balance], ");
                sb.Append("(bnkOpeningBalance - sum(case when P1.payType = 1 then P1.payAmount else 0 end) + sum(case when P1.payType = 2 then P1.payAmount else 0 end) - (select coalesce(sum(expAmount), 0) from Expense where expBank = P1.payBank) ) as [Current Balance] ");
                sb.Append("FROM Banks ");
                sb.Append("LEFT JOIN ");
                sb.Append("Payment as P1 ON P1.payBank = Banks.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranTypes T2 ON P1.payType = T2.id ");
                sb.Append("GROUP BY Banks.bnkName;");
                AIO.command = sb.ToString();
                var dt = a1.dataload();
                dgvBank.DataSource = dt;
                dgvBank.Columns["id"].Visible = false;
                dgvBank.Columns["Opening Balance"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewTransaction fr = new frmNewTransaction();
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewTransaction fr = new frmNewTransaction();
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RefreshTransaction()
        {
            try
            {
                txtTransactionSearch.Clear();
                string query = "", sort = "", asc = "", param = "";

                //Basic query
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT T.id AS id, ");
                sb.Append("T.tranNo AS [No.], ");
                sb.Append("T.tranType AS [Type], ");
                sb.Append("C.custName AS [Name], ");
                sb.Append("T.tranDate AS [Date], ");
                sb.Append("sum(TIG.itgTotal) AS [Total], ");
                sb.Append("CASE WHEN T.taxType = 1 THEN Round(sum((TIG.itgTotal) * (H.sgst / 100)), 2) ELSE 0 END AS [SGST], ");
                sb.Append("CASE WHEN T.taxType = 1 THEN Round(sum((TIG.itgTotal) * (H.cgst / 100)), 2) ELSE 0 END AS [CGST], ");
                sb.Append("CASE WHEN T.taxType = 2 THEN Round(sum((TIG.itgTotal) * (H.igst / 100)), 2) ELSE 0 END AS [IGST], ");
                sb.Append("Round(sum(TIG.itgTotal) + sum((TIG.itgTotal) * (H.igst / 100)), 0) AS [Amount], ");
                sb.Append("T.tranInvoice as [Invoice] ");
                sb.Append("FROM Trans2 AS T ");
                sb.Append("LEFT JOIN ");
                sb.Append("Customer AS C ON T.tranCustID = C.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS TIG ON T.id = TIG.itgTranID ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items AS I ON TIG.itgModID = I.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("HsnTax AS H ON I.hsnId = H.id ");

                //Apply search parameters
                if (btnTransCustSearch.Text != "Transaction No")
                {
                    if (comboBox2.SelectedIndex < 0)
                        param = "";
                    else
                    {
                        param = " T.tranCustID=" + CustIDSearch[comboBox2.SelectedIndex] + " and";
                        //query = CustIDSearch[comboBox2.SelectedIndex].ToString();
                    }
                }
                else if (btnTransCustSearch.Text == "Transaction No")
                {
                    param = " T.tranNo like '%" + comboBox2.Text + "%' and";
                }

                //Apply where condition in query
                if (btnTransType.Text == "All")
                    query = " where" + param + " T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                else if (btnTransType.Text == "Purchase")
                    query = " where" + param + " T.tranType='Purchase' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                else if (btnTransType.Text == "Sale")
                    query = " where" + param + " T.tranType='Sale' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                else if (btnTransType.Text == "Estimate")
                    query = " where" + param + " T.tranType='Estimate' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                sb.Append(query);  
                sb.Append("GROUP BY T.id ");
                
                //Apply sorting in query
                if (cmbTransSort.SelectedIndex > 0)
                    sort = " order by [" + cmbTransSort.SelectedItem.ToString() + "] ";
                sb.Append(sort);

                if (cmbTransSort.SelectedIndex > 0 && cmbTransASC.SelectedIndex > 0)
                    asc = " " + cmbTransASC.SelectedItem.ToString() + " ";
                sb.Append(asc);

                AIO.command = sb.ToString();
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;

                RefreshNewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshPayment()
        {
            try
            {


                string custName = "", payMode = "", payType = "", sort = "", asc = "";
                if (cmbCustomerName.SelectedIndex > 0)
                    custName = " and p.payCustID=" + CustID[cmbCustomerName.SelectedIndex];
                if (cmbPaymentMethod.SelectedIndex >= 0)
                    payMode = " and p.payMethod=" + lstPaymentModeID[cmbPaymentMethod.SelectedIndex];
                if (cmbPaymentType.SelectedIndex >= 0)
                    payType = " and p.payType=" + lstTransactionTypeID[cmbPaymentType.SelectedIndex];
                if (cmbPaymentSortby.SelectedIndex > 0)
                    sort = " order by [" + cmbPaymentSortby.SelectedItem.ToString() + "]";
                if (cmbPaymentSortby.SelectedIndex > 0 && cmbPayASC.SelectedIndex > 0)
                    asc = " " + cmbPayASC.SelectedItem.ToString();
                //AIO.command = "select id,(select custName from Customer where id =payCustID) as [Name],payMethod,payMethod as [Payment Mode],payType as [Payment Type],payCheck as [Cheque No],payAmount as [Amount],payDate as [Date],payDesc as [Desc] from Payment as [Payment1] where payDate between '" + dtpPaymentStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPaymentEnd.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + payMode + "" + payType + "" + sort + "" + asc;
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT p.id, ");
                sb.Append("custName AS Name, ");
                sb.Append("p.payMethod, ");
                sb.Append("pmName AS [Payment Mode], ");
                sb.Append("trtName AS [Transaction Type], ");
                sb.Append("p.payCheck AS[Cheque/Transaction No], ");
                sb.Append("p.payAmount AS Amount, ");
                sb.Append("p.payDate AS Date, ");
                sb.Append("p.payDesc AS [Desc] ");
                sb.Append("FROM Payment AS p ");
                sb.Append("LEFT JOIN ");
                sb.Append("Customer ON payCustId = Customer.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("PaymentMode ON payMethod = PaymentMode.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranTypes ON p.payType = TranTypes.id ");
                sb.Append("where p.payDate between '" + dtpPaymentStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPaymentEnd.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + payMode + "" + payType + "" + sort + "" + asc);
                AIO.command = sb.ToString();
                using (var dt = a1.dataload())
                {
                    dgvPayment.DataSource = dt;
                    dgvPayment.Columns["payMethod"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //double payReceive = 0, payDone = 0, tranPurchase = 0, tranSell = 0, openBal = 0;
                    //string id = dgvCustomer.SelectedRows[0].Cells["id"].Value.ToString();

                    //openBal = Convert.ToDouble(dgvCustomer.SelectedRows[0].Cells["custOpenBal"].Value);

                    //AIO.command = "select sum(payAmount) from Payment where payCustId=" + id + " and payType='Receive'";
                    //var tmp = a1.cmdexesc();
                    //if (!DBNull.Value.Equals(tmp))
                    //    payReceive = Convert.ToDouble(tmp);
                    //AIO.command = "select sum(payAmount) from Payment where payCustId=" + id + " and payType='Paid'";
                    //tmp = a1.cmdexesc();
                    //if (!DBNull.Value.Equals(tmp))
                    //    payDone = Convert.ToDouble(tmp);
                    //AIO.command = "select sum(tranFinalTotal) from Trans2 where TranCustID=" + id + " and tranType='Purchase'";
                    //tmp = a1.cmdexesc();
                    //if (!DBNull.Value.Equals(tmp))
                    //    tranPurchase = Convert.ToDouble(tmp);
                    //AIO.command = "select sum(tranFinalTotal) from Trans2 where TranCustID=" + id + " and tranType='Sale'";
                    //tmp = a1.cmdexesc();
                    //if (!DBNull.Value.Equals(tmp))
                    //    tranSell = Convert.ToDouble(tmp);

                    ////double outstand = (tranPurchase - payDone) - (tranSell - payReceive);
                    double outstand = Convert.ToDouble(dgvCustomer.SelectedRows[0].Cells["Outstanding Balance"].Value.ToString());
                    txtOutstanding.Text = dgvCustomer.SelectedRows[0].Cells["Outstanding Balance"].Value.ToString();
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT c.id, ");
                sb.Append("c.custName as [Name], ");
                sb.Append("c.custAdd as [Address], ");
                sb.Append("c.custMob as [Mobile], ");
                sb.Append("c.custEmail as [Email], ");
                sb.Append("c.custVatTIN as [GSTIN], ");
                sb.Append("c.custCstNo as [CST No], ");
                sb.Append("c.custPAN as [PAN], ");
                sb.Append("c.custOpenBal, ");
                //From here logic is for customer
                //
                if (custType == "Customer")
                {
                    sb.Append("Round(c.custOpenBal + (coalesce(sum(itg.itgTotal), 0) + coalesce(sum((coalesce(itg.itgTotal, 0) * (h.igst / 100))), 0)) - ( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 2 ");
                    sb.Append(")");
                    sb.Append("+( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 3 ");
                    sb.Append("), 0) [Outstanding Balance] ");
                }
                //
                //From Here logic is for supplier
                //
                else if (custType == "Supplier")
                {
                    sb.Append("Round(c.custOpenBal - (coalesce(sum(itg.itgTotal), 0) + coalesce(sum((coalesce(itg.itgTotal, 0) * (h.igst / 100))), 0)) + ( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 1 ");
                    sb.Append(")");
                    sb.Append("-( ");
                    sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                    sb.Append("FROM Payment ");
                    sb.Append("WHERE payCustId = c.id AND ");
                    sb.Append("payType = 4 ");
                    sb.Append("), 0) [Outstanding Balance] ");
                }

                sb.Append("FROM Customer AS c ");
                sb.Append("LEFT JOIN ");
                sb.Append("Trans2 t ON t.tranCustID = c.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS itg ON t.id = itg.itgTranID ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items AS i ON itg.itgModID = i.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("HsnTax AS h ON i.hsnId = h.id ");
                sb.Append("WHERE custName like '%" + txtCustSearch.Text + "%' and custType='" + custType + "' ");
                sb.Append("GROUP BY c.custName order by [Name]");
                AIO.command = sb.ToString();







                //if (string.IsNullOrWhiteSpace(txtCustSearch.Text))
                //    AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN],c.custOpenBal from Customer as c where custType='" + custType + "'";
                //else
                //    AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN],c.custOpenBal from Customer as c where custName like '%" + txtCustSearch.Text + "%' and custType='" + custType + "'";
                var dt = a1.dataload();
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns["id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        fr.isPDFMode = false;
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Calculate Purchase
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT sum(itgTotal + itgTotal * (igst / 100)) ");
                sb.Append("FROM Trans2 ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid ON Trans2.id = itgTranID ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items ON itgModID = Items.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("HsnTax ON hsnId = HsnTax.id ");
                sb.Append("WHERE TranDate BETWEEN '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpend.Value.ToString("yyyy-MM-dd") + "' AND ");
                sb.Append("tranType = 'Purchase'");
                AIO.command = sb.ToString();
                lblTotalPurchase.Text = a1.cmdexesc().ToString();

                //Calculate Payment Done
                AIO.command = "select sum(payAmount) from Payment where payDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and payType=1 ";
                lblTotalPaymentDone.Text = a1.cmdexesc().ToString();

                //Calculate Debit Note
                AIO.command = "select sum(payAmount) from Payment where payDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and payType=4 ";
                lblDebitNote.Text = a1.cmdexesc().ToString();

                //Calculate Sale
                sb = new StringBuilder();
                sb.Append("SELECT sum(itgTotal + itgTotal * (igst / 100)) ");
                sb.Append("FROM Trans2 ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid ON Trans2.id = itgTranID ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items ON itgModID = Items.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("HsnTax ON hsnId = HsnTax.id ");
                sb.Append("WHERE TranDate BETWEEN '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpend.Value.ToString("yyyy-MM-dd") + "' AND ");
                sb.Append("tranType = 'Sale'");
                AIO.command = sb.ToString();
                lblTotalSell.Text = a1.cmdexesc().ToString();

                //Calculate Payment Receive
                AIO.command = "select sum(payAmount) from Payment where payDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and payType=2 ";
                lblTotalPaymentR.Text = a1.cmdexesc().ToString();

                //Calculate Credit Note
                AIO.command = "select sum(payAmount) from Payment where payDate between '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' and payType=3 ";
                lblCreditNote.Text = a1.cmdexesc().ToString();

                AIO.command = "select sum(expAmount) from Expense where expDate between  '" + dtpstart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpend.Value.ToString("yyyy-MM-dd") + "' ";
                lblTotalExpense.Text = a1.cmdexesc().ToString();




                double TotalPurhcase = 0, TotalPaymentDone = 0, TotalSell = 0, TotalPaymentR = 0, TotalExpense = 0, TotalProfit = 0, CreditNote = 0, DebitNote=0;

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
                if (!string.IsNullOrWhiteSpace(lblCreditNote.Text))
                    CreditNote = Convert.ToDouble(lblCreditNote.Text);
                else
                    lblCreditNote.Text = "0";
                if (!string.IsNullOrWhiteSpace(lblDebitNote.Text))
                    DebitNote = Convert.ToDouble(lblDebitNote.Text);
                else
                    lblDebitNote.Text = "0";

                TotalProfit = (TotalSell - TotalPurhcase - TotalExpense);
                lblTotalProfit.Text = TotalProfit.ToString();
                if (TotalProfit > 0)
                    lblTotalProfit.ForeColor = Color.GreenYellow;
                else if (TotalProfit < 0)
                    lblTotalProfit.ForeColor = Color.Maroon;
                else
                    lblTotalProfit.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGeneralSettings()
        {
            try
            {
                AIO.command = "select id,pass,OpeningDate from GeneralSettings";
                var dt = a1.dataload();
                if (dt.Rows.Count > 0 && !DBNull.Value.Equals(dt.Rows[0][0]))
                {
                    dtpOpeningDate.Value = Convert.ToDateTime(dt.Rows[0]["OpeningDate"].ToString());
                    AIO.OpeningDate = dtpOpeningDate.Value;
                }

                AIO.command = "select bnkOpeningBalance from Banks where id=1";
                txtOpeningBalanceCash.Text = a1.cmdexesc().ToString();

                //Set Opening Date of Software as minimum date.
                dtpend.MinDate = AIO.OpeningDate;
                dtpPaymentEnd.MinDate = AIO.OpeningDate;
                dtpPaymentStart.MinDate = AIO.OpeningDate;
                dtpstart.MinDate = AIO.OpeningDate;
                dtpTransFrom.MinDate = AIO.OpeningDate;
                dtpTransTo.MinDate = AIO.OpeningDate;
                dtpTRFrom.MinDate = AIO.OpeningDate;
                dtpTRTo.MinDate = AIO.OpeningDate;
                dateTimePicker1.MinDate = AIO.OpeningDate;
                dateTimePicker2.MinDate = AIO.OpeningDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xButtons1_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmpaymentreport fr = new frmpaymentreport();
                string custName = "", payMode = "", payType = "";
                if (cmbCustomerName.SelectedIndex > 0)
                    custName = " and payCustID=" + CustID[cmbCustomerName.SelectedIndex];
                if (cmbPaymentMethod.SelectedIndex > 0)
                    payMode = " and payMethod=" + lstPaymentModeID[cmbPaymentMethod.SelectedIndex];
                if (cmbPaymentType.SelectedIndex > 0)
                    payType = " and payType='" + cmbPaymentType.SelectedItem.ToString() + "'";
                fr.CID = "select id,(select custName from Customer where id =payCustID) as [pname],payMethod as [pmethod],payType as [ptype],payCheck as [pchequeno],payAmount as [pamount],payDate as [pdate] from Payment as [Payment1] where payDate between '" + dtpPaymentStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpPaymentEnd.Value.ToString("yyyy-MM-dd") + "'" + custName + "" + payMode + "" + payType;
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransReport_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.TransactionReport);
        }

        private void btnTRShow_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnPDF.Text = "PDF";
            btnPDF.Visible = true;
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    fr.isPDFMode = true;
                    fr.ID = int.Parse(dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString());
                    fr.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmbCustomerName.Text = "";
                btnTRCust.Text = supplierToolStripMenuItem.Text;
                custType = supplierToolStripMenuItem.Text;
                RefreshCustomer();
            }
            else if (btnPayCust.Text == supplierToolStripMenuItem.Text)
            {
                btnPayCust.Text = customerToolStripMenuItem.Text;
                cmbCustomerName.Text = "";
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
                fr.transID = Convert.ToInt32(dgvPayment.SelectedRows[0].Cells["id"].Value);
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
            //Basic query
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T.id AS id, ");
            sb.Append("T.tranNo AS [No.], ");
            sb.Append("T.tranType AS [Type], ");
            sb.Append("C.custName AS [Name], ");
            sb.Append("T.tranDate AS [Date], ");
            sb.Append("sum(TIG.itgTotal) AS [Total], ");
            sb.Append("CASE WHEN T.taxType = 1 THEN Round(sum((TIG.itgTotal) * (H.sgst / 100)), 2) ELSE 0 END AS [SGST], ");
            sb.Append("CASE WHEN T.taxType = 1 THEN Round(sum((TIG.itgTotal) * (H.cgst / 100)), 2) ELSE 0 END AS [CGST], ");
            sb.Append("CASE WHEN T.taxType = 2 THEN Round(sum((TIG.itgTotal) * (H.igst / 100)), 2) ELSE 0 END AS [IGST], ");
            sb.Append("Round(sum(TIG.itgTotal) + sum((TIG.itgTotal) * (H.igst / 100)), 2) AS [Amount], ");
            sb.Append("T.tranInvoice as [Invoice] ");
            sb.Append("FROM Trans2 AS T ");
            sb.Append("LEFT JOIN ");
            sb.Append("Customer AS C ON T.tranCustID = C.id ");
            sb.Append("LEFT JOIN ");
            sb.Append("TranItemsGrid AS TIG ON T.id = TIG.itgTranID ");
            sb.Append("LEFT JOIN ");
            sb.Append("Items AS I ON TIG.itgModID = I.id ");
            sb.Append("LEFT JOIN ");
            sb.Append("HsnTax AS H ON I.hsnId = H.id ");

            if (tranSearchStat == TranSearc.Customer)
            {
                string query = "", param = "", sort = "", asc = "";

                if (comboBox2.SelectedIndex < 0)
                    param = " where T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                else
                {
                    if (btnTransType.Text == "All")
                    {
                        param = " where T.tranCustID=" + CustIDSearch[comboBox2.SelectedIndex] + " and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "' ";
                    }
                    else
                    {
                        param = " where T.tranCustID=" + CustIDSearch[comboBox2.SelectedIndex] + " and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "' and T.tranType='" + btnTransType.Text + "'";
                    }
                    //query = CustIDSearch[comboBox2.SelectedIndex].ToString();
                    if (cmbTransSort.SelectedIndex > 0)
                        sort = " order by [" + cmbTransSort.SelectedItem.ToString() + "]";
                    if (cmbTransSort.SelectedIndex > 0 && cmbTransASC.SelectedIndex > 0)
                        asc = " " + cmbTransASC.SelectedItem.ToString();
                }

                sb.Append(param + "" + sort + "" + asc + " GROUP BY T.id");
                AIO.command = sb.ToString();
                //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + param + "" + sort + "" + asc + "";
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
            }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            //Basic query
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T.id AS id, ");
            sb.Append("T.tranNo AS [No.], ");
            sb.Append("T.tranType AS [Type], ");
            sb.Append("C.custName AS [Name], ");
            sb.Append("T.tranDate AS [Date], ");
            sb.Append("sum(TIG.itgTotal) AS [Total], ");
            sb.Append("CASE WHEN T.taxType = 1 THEN Round(sum((TIG.itgTotal) * (H.sgst / 100)), 2) ELSE 0 END AS [SGST], ");
            sb.Append("CASE WHEN T.taxType = 1 THEN Round(sum((TIG.itgTotal) * (H.cgst / 100)), 2) ELSE 0 END AS [CGST], ");
            sb.Append("CASE WHEN T.taxType = 2 THEN Round(sum((TIG.itgTotal) * (H.igst / 100)), 2) ELSE 0 END AS [IGST], ");
            sb.Append("Round(sum(TIG.itgTotal) + sum((TIG.itgTotal) * (H.igst / 100)), 2) AS [Amount], ");
            sb.Append("T.tranInvoice as [Invoice] ");
            sb.Append("FROM Trans2 AS T ");
            sb.Append("LEFT JOIN ");
            sb.Append("Customer AS C ON T.tranCustID = C.id ");
            sb.Append("LEFT JOIN ");
            sb.Append("TranItemsGrid AS TIG ON T.id = TIG.itgTranID ");
            sb.Append("LEFT JOIN ");
            sb.Append("Items AS I ON TIG.itgModID = I.id ");
            sb.Append("LEFT JOIN ");
            sb.Append("HsnTax AS H ON I.hsnId = H.id");


            if (tranSearchStat == TranSearc.TransNo)
            {
                string query = "", param = "", sort = "", asc = "";
                if (!string.IsNullOrWhiteSpace(comboBox2.Text))
                {
                    //param = " where tranDate between '"+dtpTransFrom.Value.ToString("yyyy-MM-dd")+"' and '"+dtpTransTo.Value.ToString("yyyy-MM-dd")+"'";
                    if (btnTransType.Text == "All")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
                    else if (btnTransType.Text == "Purchase")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranType='Purchase' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
                    else if (btnTransType.Text == "Sale")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranType='Sale' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
                    else if (btnTransType.Text == "Estimate")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranType='Estimate' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    if (btnTransType.Text == "All")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans";
                    else if (btnTransType.Text == "Purchase")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranType='Purchase' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Purchase'";
                    else if (btnTransType.Text == "Sale")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranType='Sale' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                    //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans where tranType='Sale'";
                    else if (btnTransType.Text == "Estimate")
                        param = " where T.tranNo like '%" + comboBox2.Text + "%' and T.tranType='Estimate' and T.tranDate between '" + dtpTransFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtpTransTo.Value.ToString("yyyy-MM-dd") + "'";
                }

                if (cmbTransSort.SelectedIndex > 0)
                    sort = " order by [" + cmbTransSort.SelectedItem.ToString() + "]";
                if (cmbTransSort.SelectedIndex > 0 && cmbTransASC.SelectedIndex > 0)
                    asc = " " + cmbTransASC.SelectedItem.ToString();

                sb.Append(param + "" + sort + "" + asc + " GROUP BY T.id");
                AIO.command = sb.ToString();
                //AIO.command = "select id,tranNo as [No.],tranType as [Type],(select custName from Customer where id=tranCustID) as [Customer],tranDate as [Date],tranTotal as [Price],((tranTax1/100) * tranTotal) as [Tax1],((tranTax2/100) * tranTotal) as [Tax2],tranFinalTotal as [Total],tranInvoice as [Invoice] from Trans" + param + "" + sort + "" + asc + "";
                var dt = a1.dataload();
                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
            }
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            //frmStockReport fr = new frmStockReport();
            //fr.fromDate = dtpFromStock.Value;
            //fr.ToDate = dtpToStock.Value;
            //fr.StartDate = dtpStartStock.Value;
            //fr.StartPosition = FormStartPosition.CenterParent;
            //fr.ShowDialog();
        }

        private void dgvHsn_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshHSN()
        {
            try
            {
                //AIO.command = "SELECT id,hsnCode as HSN_Code,sgst as SGST,cgst as CGST,igst as IGST ,Desc as Description FROM hsnTax";
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT id, ");
                sb.Append("hsnCode AS HSN_Code, ");
                sb.Append("sgst AS SGST, ");
                sb.Append("cgst AS CGST, ");
                sb.Append("igst AS IGST, ");
                sb.Append("[Desc] AS Description ");
                sb.Append("FROM hsnTax ");
                sb.Append("WHERE hsnCode LIKE '%"+txtHSNSearch.Text+"%' OR ");
                sb.Append("[desc] LIKE '%"+txtHSNSearch.Text+"%' ");
                sb.Append("ORDER BY id");
                AIO.command = sb.ToString();
                var v1 = a1.dataload();
                if (v1 != null)
                {
                    dgvHsn.DataSource = v1;
                    dgvHsn.Columns["id"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                frmHsnTax fr = new frmHsnTax();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.HSNEdit;
                fr.row = ((DataTable)dgvHsn.DataSource).Rows[dgvHsn.SelectedRows[0].Index];
                fr.id = long.Parse(dgvHsn.SelectedRows[0].Cells["id"].Value.ToString());
                fr.ShowDialog();

                RefreshHSN();
                RefreshNewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHsn.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from hsnTax where id=" + dgvHsn.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }
                RefreshHSN();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsHsnMaster_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvHsn.SelectedRows.Count > 0)
                {
                    cmsHsnMaster.Items[0].Text = dgvHsn.SelectedRows[0].Cells["HSN_Code"].Value.ToString();
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
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hSNMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.HSNMaster);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewItems fr = new frmNewItems();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.NewItemAdd;
                fr.ShowDialog();

                RefreshNewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshNewItem()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT I.id,I.itemDesc as Item,H.hsnCode as HSN_Code,U.uom as Unit, ");
                sb.Append("sum(CASE WHEN tig.itgTranType = 'Purchase' THEN tig.itgQTY ELSE 0 END) - sum(CASE WHEN tig.itgTranType = 'Sale' THEN tig.itgQTY ELSE 0 END) AS [Current Stock] ");
                sb.Append("FROM ");
                sb.Append("Items as I LEFT JOIN hsnTax as H ");
                sb.Append("ON I.hsnId = H.id ");
                sb.Append("LEFT JOIN Units as U ");
                sb.Append("ON I.oid = U.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS tig ON tig.itgModID = i.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("Trans2 AS t ON t.id = tig.itgTranID ");
                sb.Append("WHERE I.itemDesc LIKE '%"+txtIMSearch.Text+"%' OR ");
                sb.Append("H.hsnCode LIKE '%"+txtIMSearch.Text+"%' ");
                sb.Append("GROUP BY I.id ");
                sb.Append("ORDER BY I.itemDesc;");
                AIO.command = sb.ToString();
                var v1 = a1.dataload();
                if (v1 != null)
                {
                    dgvItem.DataSource = v1;
                    dgvItem.Columns["id"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewItems fr = new frmNewItems();
                fr.StartPosition = FormStartPosition.CenterParent;
                fr.Stat = FrmCompany.NewItemEdit;
                fr.row = ((DataTable)dgvItem.DataSource).Rows[dgvItem.SelectedRows[0].Index];
                fr.id = long.Parse(dgvItem.SelectedRows[0].Cells["id"].Value.ToString());
                fr.ShowDialog();

                RefreshNewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvItem.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from Items where id=" + dgvItem.SelectedRows[0].Cells["id"].Value.ToString();
                    a1.cmdexe();

                }
                RefreshNewItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsItemMaster_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvItem.SelectedRows.Count > 0)
                {
                    cmsItemMaster.Items[0].Text = dgvItem.SelectedRows[0].Cells["Item"].Value.ToString();
                    cmsItemMaster.Items[3].Enabled = true;
                    cmsItemMaster.Items[4].Enabled = true;
                }
                else
                {
                    cmsItemMaster.Items[0].Text = "None";
                    cmsItemMaster.Items[3].Enabled = false;
                    cmsItemMaster.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchTabPages(AllTabs.ItemMaster);
        }

   

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGeneralCommonEnable_Click(object sender, EventArgs e)
        {
            if (grpGeneralCommon.Enabled == true)
            {
                grpGeneralCommon.Enabled = false;
                btnGeneralCommonEnable.Text = "Disable";
            }
            else
            {
                grpGeneralCommon.Enabled = true;
                btnGeneralCommonEnable.Text = "Enable";
            }
        }

        private void btnGeneralCommonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpeningBalanceCash.Text))
                txtOpeningBalanceCash.Text = "0";
            AIO.command = "update Banks set bnkOpeningBalance="+txtOpeningBalanceCash.Text+" where id=1";
            a1.cmdexe();

            AIO.command = "update GeneralSettings set OpeningDate='"+dtpOpeningDate.Value.ToString("yyyy-MM-dd")+"' where id=1";
            a1.cmdexe();
        }

        private void btnChangePDFFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult res = fbd.ShowDialog();
        }

        private void ledgerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLRReport fr= new frmLRReport();
            fr.StartPosition = FormStartPosition.CenterParent;
            fr.ShowDialog();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmItemReport fr = new frmItemReport();
            fr.StartPosition = FormStartPosition.CenterParent;
            fr.ShowDialog();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReport fr = new frmStockReport();
            fr.StartPosition = FormStartPosition.CenterParent;
            fr.ShowDialog();
        }

        private void txtIMSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshNewItem();
        }

        private void txtHSNSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshHSN();
        }
    }
}

