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
                            query = " where itgTranNo='" + TransNo + "'";
                        else if (Stat == FrmCompany.TransEdit)
                            query = " where itgTranID=" + TransNo;


                        bool flag = false;
                        if (cmbItem.SelectedIndex < 0)
                        {
                            if (string.IsNullOrWhiteSpace(cmbItem.Text))
                            {
                                MessageBox.Show("Item Name can't be Blank.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                //    AIO.command = "insert into Model(modName,modCatID) values('" + cmbItem.Text + "'," + catID[cmbCategory.SelectedIndex] + ")";
                                //    a1.cmdexe();
                                //    string model = cmbItem.Text;
                                //    if (cmbCategory.SelectedIndex >= 0)
                                //    {
                                //        AIO.command = "select id,modName from Model where modCatID=" + catID[cmbCategory.SelectedIndex];
                                //        var dt = a1.dataload();

                                //        cmbModel.Items.Clear();
                                //        modID.Clear();
                                //        foreach (DataRow row in dt.Rows)
                                //        {
                                //            cmbModel.Items.Add(row["modName"].ToString());
                                //            modID.Add(long.Parse(row["id"].ToString()));
                                //        }

                                //        cmbModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                                //        cmbModel.AutoCompleteSource = AutoCompleteSource.ListItems;
                                //    }

                                //    cmbModel.SelectedItem = model;
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
                                    flag = true;
                                    MessageBox.Show("Item is already been added once. You can't add it again.", "ShadevInfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                        if (!flag)
                        {
                            string itemDESC = rtbDesc.Text.Replace("'", "''");
                            switch (Stat)
                            {
                                case FrmCompany.TransAdd:
                                    {
                                        if (thisStat == FrmCompany.itgAdd)
                                            AIO.command = "insert into TranItemsGrid(itgModID,itgTranNo,itgQTY,itgPrice,itgTotal,itgDesc,itgTranType) VALUES(" + itemID[cmbItem.SelectedIndex] + ",'" + TransNo + "'," + txtqty.Text + "," + txtPrice.Text + "," + txtTotal.Text + ",'" + itemDESC + "','" + tranTYPE + "')";
                                        if (this.thisStat == FrmCompany.itgEdit)
                                            AIO.command = "update TranItemsGrid set itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                        a1.cmdexe();

                                    }
                                    break;

                                case FrmCompany.TransEdit:
                                    {
                                        if (thisStat == FrmCompany.itgAdd)
                                            AIO.command = "insert into TranItemsGrid(itgModID,itgTranID,itgQTY,itgPrice,itgTotal,itgDesc,itgTranType) VALUES(" + itemID[cmbItem.SelectedIndex] + "," + TransNo + "," + txtqty.Text + "," + txtPrice.Text + "," + txtTotal.Text + ",'" + itemDESC + "','" + tranTYPE + "')";
                                        if (this.thisStat == FrmCompany.itgEdit)
                                            AIO.command = "update TranItemsGrid set itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
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
                        query = " where itgTranNo='" + TransNo + "'";
                    else if (Stat == FrmCompany.TransEdit)
                        query = " where itgTranID=" + TransNo;

                    //AIO.command = "select itgModID from TranItemsGrid" + query;
                    //var dt = a1.dataload();
                    bool flag = false;
                    if (!flag)
                    {
                        string itemDESC = rtbDesc.Text.Replace("'", "''");
                        switch (Stat)
                        {
                            case FrmCompany.TransAdd:
                                {
                                    //AIO.command = "update TranItemsGrid set itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                    AIO.command = "update TranItemsGrid set itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                    a1.cmdexe();
                                }
                                break;

                            case FrmCompany.TransEdit:
                                {
                                    //AIO.command = "update TranItemsGrid set itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                                    AIO.command = "update TranItemsGrid set itgModID=" + itemID[cmbItem.SelectedIndex] + " ,itgQTY=" + txtqty.Text + ",itgPrice=" + txtPrice.Text + ",itgTotal=" + txtTotal.Text + " ,itgDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
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

        private void frmTransactionItemsGrid_Load(object sender, EventArgs e)
        {
            try
            {
                //Set Active control on form when Form Load
                this.ActiveControl = cmbItem;

                //Fill cmbItem combobox with data of items from DB for AutoFill
                AIO.command = "select  id,itemDesc as [Item] from Items";
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
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void cmbComapny_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbComapny.SelectedIndex >= 0)
        //        {
        //            AIO.command = "select id,catName from Category where catComID=" + comID[cmbComapny.SelectedIndex];
        //            var dt = a1.dataload();

        //            cmbCategory.Items.Clear();
        //            catID.Clear();
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                cmbCategory.Items.Add(row["catName"].ToString());
        //                catID.Add(long.Parse(row["id"].ToString()));
        //            }

        //            cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //            cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbCategory.SelectedIndex >= 0)
        //        {
        //            AIO.command = "select id,modName from Model where modCatID=" + catID[cmbCategory.SelectedIndex];
        //            var dt = a1.dataload();

        //            cmbModel.Items.Clear();
        //            modID.Clear();
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                cmbModel.Items.Add(row["modName"].ToString());
        //                modID.Add(long.Parse(row["id"].ToString()));
        //            }

        //            cmbModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //            cmbModel.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            try
            {
                RefreshTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                double price = double.Parse(txtPrice.Text);
                double qty = double.Parse(txtqty.Text);
                double total = Math.Round(price * qty, 2);
                txtTotal.Text = total.ToString();


                //double total = total / (1 + (Convert.ToDouble(txtTax1Percentage.Text) / 100) + (Convert.ToDouble(txtTax2Percentage.Text) / 100));
                //txtPrice.Text = Math.Round(price, 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void txtTax1Percentage_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RefreshTotal();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void txtTax2Percentage_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RefreshTotal();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                RefreshTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //MessageBox.Show(cmbModel.SelectedIndex.ToString());
        //        if (cmbModel.SelectedIndex < 0)
        //        {
        //            txtCurrStock.Text = "--";
        //        }
        //        else
        //        {
        //            AIO.command = "select stock from Model where id=" + modID[cmbModel.SelectedIndex];
        //            var x = Convert.ToInt32(a1.cmdexesc());
        //            txtCurrStock.Text = x.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void cmbItem_Leave(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex < 0)
            {
                txtCurrStock.Text = "--";
            }
            else
            {
                AIO.command = "select stock from Model where id=" + itemID[cmbItem.SelectedIndex];
                var x = Convert.ToInt32(a1.cmdexesc());
                txtCurrStock.Text = x.ToString();
            }
        }
    }
}
