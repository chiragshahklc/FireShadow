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
    public partial class frmNewTransactionItemsGrid : Form
    {
        AIO a1 = new AIO();
        public string TransNo { get; set; }
        List<long> itemID = new List<long>();
        public FrmCompany Stat { get; set; }
        public FrmCompany thisStat { get; set; }
        public Boolean bool_Labour { get; set; }
        public string tranTYPE { get; set; }
        public DataRow row { get; set; }
        public frmNewTransactionItemsGrid()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshTotal();
                if (thisStat == FrmCompany.itgAdd)
                {

                    if (txtTotal.Text == "0")
                    {
                        MessageBox.Show("Total cant be Zero", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string query = "";
                        if (Stat == FrmCompany.TransAdd)
                            query = " where itgTranNo IS NULL";
                        else if (Stat == FrmCompany.TransEdit)
                            query = " where itgTranID=" + TransNo;


                        bool isItemAdded = false;
                        if (cmbItem.SelectedIndex < 0)
                        {
                            if (string.IsNullOrWhiteSpace(cmbItem.Text))
                            {
                                MessageBox.Show("Item Name can't be Blank.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            AIO.command = "select itgModID from TranItemsGrid" + query;
                            var dt = a1.dataload();
                            foreach (DataRow row in dt.Rows)
                            {
                                if (itemID[cmbItem.SelectedIndex] == Convert.ToInt64(row["itgModID"].ToString()))
                                {
                                    isItemAdded = true;
                                    MessageBox.Show("Item is already been added once. You can't add it again.", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                        if (!isItemAdded)
                        {
                            string itemDESC = rtbDesc.Text.Replace("'", "''");
                            switch (Stat)
                            {
                                case FrmCompany.TransAdd:
                                    {
                                        if (thisStat == FrmCompany.itgAdd)
                                            AIO.command = "insert into TranItemsGrid(itgModID,itgQTY,itgPrice,itgDisc,itgTotal,itgDesc,itgTranType) VALUES(" + itemID[cmbItem.SelectedIndex] + "," + txtqty.Text + "," + txtPrice.Text + "," + txtDisc.Text + "," + txtTotal.Text + ",'" + itemDESC + "','" + tranTYPE + "')";
                                        if (this.thisStat == FrmCompany.itgEdit)
                                            AIO.command = "update TranItemsGrid set itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgDisc=" + txtDisc.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                        a1.cmdexe();

                                    }
                                    break;

                                case FrmCompany.TransEdit:
                                    {
                                        AIO.command = "select tranNo from Trans2 where id=" + TransNo;
                                        var tID = Convert.ToInt32(a1.cmdexesc());

                                        if (thisStat == FrmCompany.itgAdd)
                                            AIO.command = "insert into TranItemsGrid(itgModID,itgTranID,itgTranNo,itgQTY,itgPrice,itgDisc,itgTotal,itgDesc,itgTranType) VALUES(" + itemID[cmbItem.SelectedIndex] + "," + TransNo + "," + tID + "," + txtqty.Text + "," + txtPrice.Text + "," + txtDisc.Text + "," + txtTotal.Text + ",'" + itemDESC + "','" + tranTYPE + "')";
                                        if (this.thisStat == FrmCompany.itgEdit)
                                            AIO.command = "update TranItemsGrid set itgTranNo=" + tID + ",itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgDisc=" + txtDisc.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                        a1.cmdexe();

                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        this.Close();
                    }
                }
                else if (thisStat == FrmCompany.itgEdit)
                {
                    string query = "";
                    if (Stat == FrmCompany.TransAdd)
                        query = " where itgTranNo IS NULL";
                    else if (Stat == FrmCompany.TransEdit)
                        query = " where itgTranID=" + TransNo;

                    //AIO.command = "select itgModID from TranItemsGrid" + query;
                    //var dt = a1.dataload();
                    bool flag = false;
                    if (!flag)
                    {
                        string itemDESC = rtbDesc.Text.Replace("'", "''");
                        AIO.command = "select tranNo from Trans2 where id=" + TransNo;
                        var tID = Convert.ToInt32(a1.cmdexesc());

                        switch (Stat)
                        {
                            case FrmCompany.TransAdd:
                                {
                                    AIO.command = "update TranItemsGrid set itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgDisc=" + txtDisc.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                    a1.cmdexe();
                                }
                                break;

                            case FrmCompany.TransEdit:
                                {
                                    AIO.command = "update TranItemsGrid set itgTranNo=" + tID + ",itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgDisc=" + txtDisc.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                    a1.cmdexe();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    this.Close();
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

        private void frmTransactionItemsGrid_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                //Set Active control on form when Form Load
                this.ActiveControl = cmbItem;
                RefreshItems();
                ////Fill cmbItem combobox with data of items from DB for AutoFill
                //sb.Append("SELECT id, ");
                //sb.Append("itemDesc AS Item ");
                //sb.Append("FROM Items ");
                //sb.Append("ORDER BY itemDesc;");
                //AIO.command = sb.ToString();
                //var dt = a1.dataload();
                //cmbItem.Items.Clear();
                //itemID.Clear();
                //foreach (DataRow row in dt.Rows)
                //{
                //    cmbItem.Items.Add(row["Item"].ToString());
                //    itemID.Add(Convert.ToInt64(row["id"].ToString()));
                //}
                //cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbItem.AutoCompleteSource = AutoCompleteSource.ListItems;

                //Load data if form open in edit mode
                if (thisStat == FrmCompany.itgEdit)
                {
                    cmbItem.SelectedItem = row["Item"].ToString();
                    txtqty.Text = row["QTY"].ToString();
                    txtPrice.Text = row["Price"].ToString();
                    rtbDesc.Text = row["Desc"].ToString();
                    txtCurrStock.Visible = true;
                    RefreshTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtTotal_Leave(object sender, EventArgs e)
        {
            try
            {
                RefreshTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshTotal()
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtqty.Text))
                    txtqty.Text = "1";
                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                    txtPrice.Text = "0";
                if (string.IsNullOrWhiteSpace(txtDisc.Text))
                    txtDisc.Text = "0";
                double price = double.Parse(txtPrice.Text);
                double qty = double.Parse(txtqty.Text);
                double disc = Math.Round(Convert.ToDouble(txtDisc.Text) * qty, 2);
                double total = Math.Round((price * qty) - disc, 2);

                txtTotal.Text = total.ToString();


                //double total = total / (1 + (Convert.ToDouble(txtTax1Percentage.Text) / 100) + (Convert.ToDouble(txtTax2Percentage.Text) / 100));
                //txtPrice.Text = Math.Round(price, 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                RefreshTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtqty_Leave(object sender, EventArgs e)
        {
            try
            {
                RefreshTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbItem_Leave(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                txtCurrStock.Text = "--";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT sum(CASE WHEN tig.itgTranType = 'Purchase' THEN tig.itgQTY ELSE 0 END) -sum(CASE WHEN tig.itgTranType = 'Sale' THEN tig.itgQTY ELSE 0 END) AS Outwards ");
                sb.Append("FROM Items AS i ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS tig ON tig.itgModID = i.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("Trans2 AS t ON t.id = tig.itgTranID ");
                sb.Append("WHERE i.id =" + itemID[cmbItem.SelectedIndex] + " ");
                sb.Append("GROUP BY i.id");
                AIO.command = sb.ToString();


                //AIO.command = "select stock from Model where id=" + itemID[cmbItem.SelectedIndex];
                var x = Convert.ToInt32(a1.cmdexesc());
                txtCurrStock.Text = x.ToString();
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                txtCurrStock.Text = "--";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT sum(CASE WHEN tig.itgTranType = 'Purchase' THEN tig.itgQTY ELSE 0 END) -sum(CASE WHEN tig.itgTranType = 'Sale' THEN tig.itgQTY ELSE 0 END) AS Outwards ");
                sb.Append("FROM Items AS i ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS tig ON tig.itgModID = i.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("Trans2 AS t ON t.id = tig.itgTranID ");
                sb.Append("WHERE i.id =" + itemID[cmbItem.SelectedIndex] + " ");
                sb.Append("GROUP BY i.id");
                AIO.command = sb.ToString();


                //AIO.command = "select stock from Model where id=" + itemID[cmbItem.SelectedIndex];
                var x = Convert.ToInt32(a1.cmdexesc());
                txtCurrStock.Text = x.ToString();
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            frmNewItems fr = new frmNewItems();
            fr.StartPosition = FormStartPosition.CenterParent;
            fr.Stat = FrmCompany.NewItemAdd;
            fr.ShowDialog();
            RefreshItems();
            cmbItem.SelectedItem = cmbItem.Text;
            if (cmbItem.SelectedIndex < 0)
                cmbItem.Text = "";
        }

        private void RefreshItems()
        {
            StringBuilder sb = new StringBuilder();
            //Fill cmbItem combobox with data of items from DB for AutoFill
            sb.Append("SELECT id, ");
            sb.Append("itemDesc AS Item ");
            sb.Append("FROM Items ");
            sb.Append("ORDER BY itemDesc;");
            AIO.command = sb.ToString();
            var dt = a1.dataload();
            cmbItem.Items.Clear();
            itemID.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cmbItem.Items.Add(row["Item"].ToString());
                itemID.Add(Convert.ToInt64(row["id"].ToString()));
            }
            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbItem.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
