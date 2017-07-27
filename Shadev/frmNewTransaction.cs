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
    public partial class frmNewTransaction : Form
    {
        AIO a1 = new AIO();
        public FrmCompany Stat { get; set; }
        public string TransType { get; set; }
        public string TransNo { get; set; }
        public string custType { get; set; }
        public string tax1 = "", tax2 = "";
        List<long> custID = new List<long>();
        List<long> bnkID = new List<long>();
        public long id { get; set; }
        public long cID { get; set; }
        public long bID { get; set; }
        List<long> taxID = new List<long>();
        public DateTime date { get; set; }
        public frmNewTransaction()
        {
            try
            {
                InitializeComponent();
                //this.FormBorderStyle = FormBorderStyle.FixedDialog;
                //this.ShowInTaskbar = false;
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
                if (cmbInvoice.SelectedIndex < 0)
                    cmbInvoice.SelectedIndex = 0;

                string delnote = "", terms = "";

                delnote = txtDeliverNote.Text.Replace("'", "''");
                terms = txtTermsOfDelivery.Text.Replace("'", "''");
                switch (Stat)
                {
                    case FrmCompany.TransAdd:
                        {
                            if (!string.IsNullOrWhiteSpace(txtTransactionNo.Text))
                            {
                                string ext = "";
                                if (txtTransactionType.Text == "Purchase")
                                {
                                    ext = " and tranCustID = " + custID[cbmCustomer.SelectedIndex];
                                }
                                AIO.command = "select count(id) from Trans where tranNo='" + txtTransactionNo.Text + "'" + ext;
                                var tmp = Convert.ToInt32(a1.cmdexesc());
                                if (tmp > 0)
                                {
                                    MessageBox.Show("Transaction No is already exist.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //txtTransactionNo.Focus();
                                    break;
                                }
                            }
                            if (cbmCustomer.SelectedIndex < 0)
                            {
                                MessageBox.Show("Customer Must be Select", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (dgvTransaction.Rows.Count <= 0)
                            {
                                MessageBox.Show("At least one item should be added.", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtFinalAmount.Text == "0")
                            {
                                MessageBox.Show("Final Amount can't be zero.", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (cmbBank.SelectedIndex < 0)
                            {
                                MessageBox.Show("Please Select Bank", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                AIO.command = "insert into Trans(tranType,tranNo,tranCustID,tranTotal,tranTax1,tranTax2,tranFinalTotal,tranDate,tranBankID,tranInvoice,tranTax1Name,tranTax2Name) values('" + txtTransactionType.Text + "','" + txtTransactionNo.Text + "'," + custID[cbmCustomer.SelectedIndex] + "," + txtTotal.Text + "," + txtTax1Percentage.Text + "," + txtTax2Percentage.Text + "," + txtFinalAmount.Text + ",'" + dtpTranDate.Value.ToString("yyyy-MM-dd") + "'," + bnkID[cmbBank.SelectedIndex] + ",'" + cmbInvoice.SelectedItem.ToString() + "','" + tax1 + "','" + tax2 + "')";
                                a1.cmdexe();
                                AIO.command = "select id from Trans where tranNo='" + txtTransactionNo.Text + "'";
                                var tmp = Convert.ToInt32(a1.cmdexesc());
                                AIO.command = "update TranItemsGrid set itgTranID=" + tmp + ",itgTranType='" + txtTransactionType.Text + "' where itgTranNo='" + txtTransactionNo.Text + "'";
                                a1.cmdexe();
                                AIO.command = "insert into TranOtherDetails(todDeliveryNote,todSupplierRef,todMOP,todOtherRef,todBuyerNo,todBuyerDated,todDispatchDoc,todDispatchDated,todDispatchThrough,todDestination,todTerms,todTransID) values('" + delnote + "','" + txtSupplierRef.Text + "','" + txtModeOfPayment.Text + "','" + txtOtherReferences.Text + "','" + txtBuerOrderNo.Text + "','" + dtpBuyersOrderNo.Text + "','" + txtDispatchDocNo.Text + "','" + dtpDispatchDocNo.Text + "','" + txtDispatchThrough.Text + "','" + txtDestination.Text + "','" + terms + "'," + tmp + ")";
                                a1.cmdexe();
                                this.Close();
                            }
                        }
                        break;
                    case FrmCompany.TransEdit:
                        {
                            if (cbmCustomer.SelectedIndex < 0)
                            {
                                MessageBox.Show("Customer Must be Select", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (dgvTransaction.Rows.Count <= 0)
                            {
                                MessageBox.Show("At least one item should be added.", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (txtFinalAmount.Text == "0")
                            {
                                MessageBox.Show("Final Amount can't be zero.", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (cmbBank.SelectedIndex < 0)
                            {
                                MessageBox.Show("Please Select Bank", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                AIO.command = "update Trans set tranCustID=" + custID[cbmCustomer.SelectedIndex] + ",tranTotal=" + txtTotal.Text + ",tranTax1=" + txtTax1Percentage.Text + ",tranTax2=" + txtTax2Percentage.Text + ",tranFinalTotal=" + txtFinalAmount.Text + ",tranDate='" + dtpTranDate.Value.ToString("yyyy-MM-dd") + "',tranBankID=" + bnkID[cmbBank.SelectedIndex] + ",tranInvoice='" + cmbInvoice.SelectedItem.ToString() + "' where id=" + id;
                                a1.cmdexe();
                                AIO.command = "update TranItemsGrid set itgTranType='" + txtTransactionType.Text + "' where itgTranNo='" + txtTransactionNo.Text + "'";
                                a1.cmdexe();
                                AIO.command = "update TranOtherDetails set todDeliveryNote='" + delnote + "',todSupplierRef='" + txtSupplierRef.Text + "',todMOP='" + txtModeOfPayment.Text + "',todOtherRef='" + txtOtherReferences.Text + "',todBuyerNo='" + txtBuerOrderNo.Text + "',todBuyerDated='" + dtpBuyersOrderNo.Text + "',todDispatchDoc='" + txtDispatchDocNo.Text + "',todDispatchDated='" + dtpDispatchDocNo.Text + "',todDispatchThrough='" + txtDispatchThrough.Text + "',todDestination='" + txtDestination.Text + "',todTerms='" + terms + "' where todTransID=" + id;
                                a1.cmdexe();
                                this.Close();
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

        private void txtTransactionType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbmCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTax1Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTax1Amount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTax2Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTax2Amount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDiscountPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDiscountRs_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFinalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                cmbInvoice.SelectedIndex = 0;

                //Fill combobox of Customer
                AIO.command = "select id,custName from Customer where custType='" + custType + "'";
                var dt = a1.dataload();
                cbmCustomer.Items.Clear();
                custID.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cbmCustomer.Items.Add(row["custName"].ToString());
                    custID.Add(Convert.ToInt64(row["id"].ToString()));
                }
                cbmCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbmCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.ActiveControl = cbmCustomer;

                //Fill combobox of Tax Type
                AIO.command = "select id,tType from TaxMaster";
                var dtTT = a1.dataload();
                cmbTaxType.Items.Clear();
                taxID.Clear();
                if (dtTT.Rows.Count > 0)
                {
                    foreach (DataRow row in dtTT.Rows)
                    {
                        cmbTaxType.Items.Add(row[1].ToString());
                        taxID.Add(Convert.ToInt64(row[0].ToString()));
                    }
                }
                cmbTaxType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbTaxType.AutoCompleteSource = AutoCompleteSource.ListItems;

                //Fill combobox of Bank
                AIO.command = "select id,bnkName from Banks";
                var dt2 = a1.dataload();
                cmbBank.Items.Clear();
                bnkID.Clear();
                foreach (DataRow row in dt2.Rows)
                {
                    cmbBank.Items.Add(row["bnkName"].ToString());
                    bnkID.Add(Convert.ToInt64(row["id"].ToString()));
                }
                cmbBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbBank.AutoCompleteSource = AutoCompleteSource.ListItems;


                switch (Stat)
                {
                    case FrmCompany.TransAdd:
                        {
                            //AIO.command = "select tax1per from GeneralSettings where id=1";
                            //txtTax1Percentage.Text = a1.cmdexesc().ToString();
                            //AIO.command = "select tax2per from GeneralSettings where id=1";
                            //txtTax2Percentage.Text = a1.cmdexesc().ToString();

                            //AIO.command = "select id,tmType from TaxMaster";
                            //var dtTM = a1.dataload();
                            //if (dtTM.Rows.Count > 0)
                            //{
                            //    foreach (DataRow row in dtTM.Rows)
                            //    {
                            //        cmbTaxType.Items.Add(row[1].ToString());
                            //        taxID.Add(Convert.ToInt64(row[0].ToString()));
                            //    }
                            //}

                            this.Text = TransType + ": Add";
                            txtTransactionType.Text = TransType;
                            if (txtTransactionType.Text == "Estimate")
                            {
                                cmbInvoice.SelectedItem = "Estimate";
                                cmbInvoice.Enabled = false;
                            }
                            //txtTransactionNo.Text = TransNo.ToString();
                            //id = TransNo;
                            RefreshItems();
                        }
                        break;
                    case FrmCompany.TransEdit:
                        {
                            this.Text = TransType + ": Edit";
                            txtTransactionType.Text = TransType;
                            if (txtTransactionType.Text == "Estimate")
                            {
                                cmbInvoice.SelectedItem = "Estimate";
                                cmbInvoice.Enabled = false;
                            }
                            txtTransactionNo.Text = TransNo.ToString();
                            txtTransactionNo.ReadOnly = true;

                            AIO.command = "select tranCustID from Trans where id=" + id;
                            cID = Convert.ToInt64(a1.cmdexesc());
                            AIO.command = "select custType from Customer where id=" + cID;
                            custType = a1.cmdexesc().ToString();
                            AIO.command = "select id,custName from Customer where custType='" + custType + "'";
                            var dt3 = a1.dataload();
                            cbmCustomer.Items.Clear();
                            custID.Clear();
                            foreach (DataRow row in dt3.Rows)
                            {
                                cbmCustomer.Items.Add(row["custName"].ToString());
                                custID.Add(Convert.ToInt64(row["id"].ToString()));
                            }
                            cbmCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cbmCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;


                            cbmCustomer.SelectedIndex = custID.FindIndex(x => x == cID);
                            dtpTranDate.Value = date;

                            AIO.command = "select tranBankID from Trans where id=" + id;
                            bID = Convert.ToInt64(a1.cmdexesc());
                            cmbBank.SelectedIndex = bnkID.FindIndex(x => x == bID);

                            AIO.command = "select tranInvoice from Trans where id=" + id;
                            cmbInvoice.SelectedItem = a1.cmdexesc().ToString();

                            cmbTaxType.Visible = false;
                            //AIO.command = "select tranTax1 from Trans where id=" + id;
                            //txtTax1Percentage.Text = a1.cmdexesc().ToString();

                            //AIO.command = "select tranTax2 from Trans where id=" + id;
                            //txtTax2Percentage.Text = a1.cmdexesc().ToString();



                            RefreshItems();
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTransactionNo.Text))
                {
                    if (cbmCustomer.SelectedIndex < 0)
                    {
                        MessageBox.Show("Select Customer First.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string ext = "";
                        if (txtTransactionType.Text == "Purchase")
                        {
                            ext = " and tranCustID = " + custID[cbmCustomer.SelectedIndex];
                        }
                        AIO.command = "select count(id) from Trans where tranNo='" + txtTransactionNo.Text + "'" + ext;
                        var tmp = Convert.ToInt32(a1.cmdexesc());
                        if (Stat == FrmCompany.TransEdit)
                            tmp = 0;
                        if (tmp > 0)
                        {
                            MessageBox.Show("Transaction No is already exist.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //txtTransactionNo.Focus();
                        }
                        else
                        {
                            frmNewTransactionItemsGrid fr = new frmNewTransactionItemsGrid();
                            fr.StartPosition = FormStartPosition.CenterParent;

                            fr.tranTYPE = txtTransactionType.Text;
                            fr.thisStat = FrmCompany.itgAdd;
                            if (Stat == FrmCompany.TransAdd)
                            {
                                fr.Stat = FrmCompany.TransAdd;
                                fr.TransNo = txtTransactionNo.Text;
                            }
                            else if (Stat == FrmCompany.TransEdit)
                            {
                                fr.Stat = FrmCompany.TransEdit;
                                fr.TransNo = id.ToString();
                            }

                            if (cmbInvoice.SelectedIndex == 2)
                                fr.bool_Labour = true;
                            else
                                fr.bool_Labour = false;
                            fr.ShowDialog();

                            RefreshItems();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Transaction No. Can't be Blank or Null.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsTransaction_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    cmsTransaction.Items[0].Text = dgvTransaction.SelectedRows[0].Cells["Model"].Value.ToString();
                    cmsTransaction.Items[3].Enabled = true;
                    cmsTransaction.Items[4].Enabled = true;
                }
                else
                {
                    cmsTransaction.Items[0].Text = "";
                    cmsTransaction.Items[3].Enabled = false;
                    cmsTransaction.Items[4].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshItems()
        {
            try
            {
                AIO.command = "select todDeliveryNote,todSupplierRef,todMOP,todOtherRef,todBuyerNo,todBuyerDated,todDispatchDoc,todDispatchDated,todDispatchThrough,todDestination,todTerms from TranOtherDetails where todTransID=" + id;
                var tmpdt = a1.dataload();
                if (tmpdt.Rows.Count > 0)
                {
                    txtDeliverNote.Text = tmpdt.Rows[0][0].ToString();
                    txtSupplierRef.Text = tmpdt.Rows[0][1].ToString();
                    txtModeOfPayment.Text = tmpdt.Rows[0][2].ToString();
                    txtOtherReferences.Text = tmpdt.Rows[0][3].ToString();
                    txtBuerOrderNo.Text = tmpdt.Rows[0][4].ToString();
                    dtpBuyersOrderNo.Text = tmpdt.Rows[0][5].ToString();
                    txtDispatchDocNo.Text = tmpdt.Rows[0][6].ToString();
                    dtpDispatchDocNo.Text = tmpdt.Rows[0][7].ToString();
                    txtDispatchThrough.Text = tmpdt.Rows[0][8].ToString();
                    txtDestination.Text = tmpdt.Rows[0][9].ToString();
                    txtTermsOfDelivery.Text = tmpdt.Rows[0][10].ToString();
                }



                string query = "";
                if (this.Stat == FrmCompany.TransAdd)
                    query = "where itgTranNo='" + txtTransactionNo.Text + "'";
                else if (this.Stat == FrmCompany.TransEdit)
                    query = "where itgTranID=" + id;
                //AIO.command = "select id,(select modName from Model where id=itgModID) as [Model],itgTranID,itgQTY as [QTY],Round((itgPrice*itgQTY),2) as [Price],Round(((itgTax1/100)*(itgPrice*itgQTY)),2) as [Tax1],Round(((itgTax2/100)*(itgPrice*itgQTY)),2) as [Tax2],Round((itgTotal*itgQTY),2) as [Total],itgDesc as [Desc] from TranItemsGrid " + query + " order by id ASC";
                AIO.command = "select id,(select itemDesc from Items where id=itgModID) as [Item],itgTranID,itgQTY as [QTY],Round((itgPrice*itgQTY),2) as [Price],Round((itgTotal*itgQTY),2) as [Total],itgDesc as [Desc] from TranItemsGrid " + query + " order by id ASC";
                var dt = a1.dataload();

                dgvTransaction.DataSource = dt;
                dgvTransaction.Columns["id"].Visible = false;
                dgvTransaction.Columns["itgTranID"].Visible = false;

                if (dt.Rows.Count > 0)
                {
                    double price = 0; //, tax1 = 0, tax2 = 0, total = 0
                    int count = dgvTransaction.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        price += Math.Round(Convert.ToDouble(dgvTransaction.Rows[i].Cells["Price"].Value.ToString()), 2);
                        //tax1 += Convert.ToDouble(dgvTransaction.Rows[i].Cells["Tax1"].Value.ToString());
                        //tax2 += Convert.ToDouble(dgvTransaction.Rows[i].Cells["Tax2"].Value.ToString());
                        //total += Convert.ToDouble(dgvTransaction.Rows[i].Cells["Total"].Value.ToString());
                    }

                    txtTotal.Text = price.ToString();
                    txtSGST.Text = Math.Round((price * (double.Parse(txtTax1Percentage.Text)) / 100), 2).ToString();
                    txtCGST.Text = Math.Round((price * (double.Parse(txtTax2Percentage.Text)) / 100), 2).ToString();
                    txtFinalAmount.Text = Math.Round((double.Parse(txtSGST.Text) + double.Parse(txtCGST.Text) + price), 0).ToString();
                }
                else
                {
                    txtTotal.Text = "0";
                    txtSGST.Text = "0";
                    txtCGST.Text = "0";
                    //txtDiscountAmount.Text = "0";
                    //txtDiscountPercentage.Text = "0";
                    // txtDiscountRs.Text = "0";
                    txtFinalAmount.Text = "0";

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
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    AIO.command = "delete from  TranItemsGrid where id=" + dgvTransaction.SelectedRows[0].Cells["id"].Value.ToString() + "";
                    a1.cmdexe();
                }
                RefreshItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTransactionNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTransactionNo.Text))
                {
                    if (cbmCustomer.SelectedIndex < 0)
                    {
                        MessageBox.Show("Select Customer First.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string ext = "";
                        if (txtTransactionType.Text == "Purchase")
                        {
                            ext = " and tranCustID = " + custID[cbmCustomer.SelectedIndex];
                        }
                        AIO.command = "select count(id) from Trans where tranNo='" + txtTransactionNo.Text + "'" + ext;
                        var tmp = Convert.ToInt32(a1.cmdexesc());
                        if (tmp > 0)
                        {
                            MessageBox.Show("Transaction No is already exist.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //txtTransactionNo.Focus();
                        }
                        else
                        {
                            RefreshItems();
                        }
                    }
                }
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
                if (dgvTransaction.SelectedRows.Count > 0)
                {
                    DataRow row = ((DataTable)dgvTransaction.DataSource).Rows[dgvTransaction.SelectedRows[0].Index];
                    frmTransactionItemsGrid fr = new frmTransactionItemsGrid();
                    fr.row = row;
                    fr.Stat = Stat;
                    fr.tranTYPE = txtTransactionType.Text;
                    fr.thisStat = FrmCompany.itgEdit;
                    fr.StartPosition = FormStartPosition.CenterParent;
                    if (Stat == FrmCompany.TransAdd)
                    {
                        fr.Stat = FrmCompany.TransAdd;
                        fr.TransNo = txtTransactionNo.Text;
                    }
                    else if (Stat == FrmCompany.TransEdit)
                    {
                        fr.Stat = FrmCompany.TransEdit;
                        fr.TransNo = id.ToString();
                    }

                    if (cmbInvoice.SelectedIndex == 2)
                        fr.bool_Labour = true;
                    else
                        fr.bool_Labour = false;

                    fr.ShowDialog();
                }
                RefreshItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTransactionNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTransaction_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void cmbInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Stat == FrmCompany.TransAdd && dgvTransaction.Rows.Count <= 0)
            {
                if (cmbInvoice.SelectedIndex == 2)
                {

                    txtTax1Percentage.Text = "0";
                    txtTax2Percentage.Text = "0";
                    RefreshItems();

                }
                else
                {
                    //AIO.command = "select tax1per from GeneralSettings where id=1";
                    //txtTax1Percentage.Text = a1.cmdexesc().ToString();
                    //AIO.command = "select tax2per from GeneralSettings where id=1";
                    //txtTax2Percentage.Text = a1.cmdexesc().ToString();
                    RefreshItems();
                }
            }

            if (txtTransactionType.Text != "Estimate")
            {
                if (cmbInvoice.SelectedItem.ToString() == "Estimate")
                {
                    MessageBox.Show("Your Transaction type is not Estimate.\r\nYou can't select Estimate Invoice type.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbInvoice.SelectedIndex = 0;
                }
            }
        }

        private void cmbTaxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTaxType.SelectedIndex >= 0)
            {
                AIO.command = "select tmTax1 from TaxMaster where id=" + taxID[cmbTaxType.SelectedIndex];
                txtTax1Percentage.Text = a1.cmdexesc().ToString();
                AIO.command = "select tmTax1Name from TaxMaster where id=" + taxID[cmbTaxType.SelectedIndex];
                tax1 = a1.cmdexesc().ToString();
                AIO.command = "select tmTax2 from TaxMaster where id=" + taxID[cmbTaxType.SelectedIndex];
                txtTax2Percentage.Text = a1.cmdexesc().ToString();
                AIO.command = "select tmTax2Name from TaxMaster where id=" + taxID[cmbTaxType.SelectedIndex];
                tax2 = a1.cmdexesc().ToString();
                RefreshItems();
            }
        }
    }
}
