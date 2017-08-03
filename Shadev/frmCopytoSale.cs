using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadev
{
    public partial class frmCopytoSale : Form
    {
        AIO a1 = new AIO();
        public int estID { get; set; }
        public List<long> custID = new List<long>();
        public List<long> taxID = new List<long>();
        static string tax1Name="", tax2name="";
        public frmCopytoSale()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTransNo.Text) || cmbCustName.SelectedIndex < 0 || cmbTaxType.SelectedIndex < 0)
                    MessageBox.Show("Please Fill all Details!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {



                    // Tax
                    ////AIO.command = "select tax1name,tax2name from GeneralSettings where id=1";
                    //var dt3 = a1.dataload();
                    //string delnote = "", terms = "", tax1 = "", tax2 = "";
                    //tax1 = dt3.Rows[0]["tax1name"].ToString();
                    //tax2 = dt3.Rows[0]["tax2name"].ToString();

                    // All
                    AIO.command = "select count(id) from Trans where tranNo='" + txtTransNo.Text + "'";
                    var x = Convert.ToInt32(a1.cmdexesc());
                    if (x != 0)
                    {
                        MessageBox.Show("Transaction No. is already exist.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //AIO.command = "insert into Trans(tranNo,tranDate,tranType,tranInvoice) values('" + txtTransNo.Text + "','" + dtpTransDate.Value.ToString("yyyy-MM-dd") + "','Sale','Retail Invoice')";
                        //a1.cmdexe();
                        //AIO.command = "select id from Trans where tranNo='" + txtTransNo.Text + "'";
                        //var id = Convert.ToInt32(a1.cmdexesc());
                        //AIO.command = "update Trans set tranCustID=OD.tranCustID,tranTotal=OD.tranTotal,tranTax1=OD.tranTax1,tranTax2=OD.tranTax2,tranFinalTotal=OD.tranFinalTotal,tranBankID=OD.tranBankID,tranTax1Name=OD.tranTax1Name,tranTax2Name=OD.tranTax2Name from (select tranCustID,tranTotal,tranTax1,tranTax2,tranFinalTotal,tranBankID,tranTax1Name,tranTax2Name from Trans where id=" + estID+") as OD where id="+id;
                        AIO.command = "insert into Trans(tranCustID,tranTotal,tranTax1,tranTax2,tranFinalTotal,tranBankID,tranTax1Name,tranTax2Name,tranNo,tranDate,tranType,tranInvoice) select " + custID[cmbCustName.SelectedIndex] + ",tranTotal,"+txtTax1Percentage.Text+","+txtTax2Percentage.Text+",tranFinalTotal,tranBankID,'"+tax1Name+"','"+tax2name+"','" + txtTransNo.Text + "','" + dtpTransDate.Value.ToString("yyyy-MM-dd") + "','Sale','Retail Invoice' from Trans where id=" + estID;
                        a1.cmdexe();
                        AIO.command = "select id from Trans where tranNo='" + txtTransNo.Text + "'";
                        var id = Convert.ToInt32(a1.cmdexesc());
                        AIO.command = "insert into TranItemsgrid(itgModID,itgQTY,itgPrice,itgTax1,itgTax2,itgTotal,itgDesc,itgTranNo,itgTranID,itgTranType) select itgModID,itgQTY,itgPrice,itgTax1,itgTax2,itgTotal,itgDesc,'" + txtTransNo.Text + "'," + id + ",'Sale' from TranItemsGrid where itgTranID=" + estID;
                        a1.cmdexe();
                        AIO.command = "insert into TranOtherDetails(todTransID) values(" + id + ")";
                        a1.cmdexe();

                        MessageBox.Show("Sale for Transaction No. " + txtTransNo.Text + " is Generated.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCopytoSale_Load(object sender, EventArgs e)
        {
            dtpTransDate.MinDate = AIO.OpeningDate;

            //Fill Customer Name Combobox
            AIO.command = "select id,custName from Customer where custType='Customer'";
            var dt = a1.dataload();

            cmbCustName.Items.Clear();
            custID.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cmbCustName.Items.Add(row["custName"].ToString());
                custID.Add(Convert.ToInt64(row["id"].ToString()));
            }
            cmbCustName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustName.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Fill Tax Type
            AIO.command = "select id,tmType from TaxMaster";
            var dtTM = a1.dataload();
            if (dtTM.Rows.Count > 0)
            {
                foreach (DataRow row in dtTM.Rows)
                {
                    cmbTaxType.Items.Add(row[1].ToString());
                    taxID.Add(Convert.ToInt64(row[0].ToString()));
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
                tax1Name = a1.cmdexesc().ToString();
                AIO.command = "select tmTax2 from TaxMaster where id=" + taxID[cmbTaxType.SelectedIndex];
                txtTax2Percentage.Text = a1.cmdexesc().ToString();
                AIO.command = "select tmTax2Name from TaxMaster where id=" + taxID[cmbTaxType.SelectedIndex];
                tax2name = a1.cmdexesc().ToString();
            }
        }
    }
}
