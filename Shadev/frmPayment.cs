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
    public partial class frmPayment : Form
    {
        public double OutAmount { get; set; }
        public int custID { get; set; }
        public int transID { get; set; }
        public string custName { get; set; }
        public FrmCompany Stat { get; set; }
        //public DataRow row { get; set; }
        List<int> lstPaymentModeID = new List<int>();
        List<int> lstTransacionTypeID = new List<int>();
        List<int> lstBankID = new List<int>();
        AIO a1 = new AIO();
        public frmPayment()
        {
            try
            {
                InitializeComponent();
                //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbmethod.SelectedIndex < 0)
                    cmbmethod.SelectedIndex = 2;//Cash

                if (cmbmethod.SelectedIndex != 2) //Bank Transfer=0, Cheque=1
                {
                    if (string.IsNullOrWhiteSpace(txtAmt.Text))
                    {
                        MessageBox.Show("Amount can't be blank.", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtCheckNo.Text))
                        {
                            MessageBox.Show("Cheque/Transaction no. can't be blank.", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (cmbPayType.SelectedIndex < 0)
                            {
                                MessageBox.Show("Must select transaction type.", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (cmbBank.SelectedIndex < 0)
                                {
                                    MessageBox.Show("Please select bank.", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    double RAmount;
                                    RAmount = Convert.ToDouble(txtAmt.Text);
                                    OutAmount = OutAmount - RAmount;
                                    string paydesc = rtbDesc.Text.Replace("'", "''");
                                    if (Stat == FrmCompany.PaymentAdd)
                                        AIO.command = "insert into Payment(payCustId,payMethod,payType,payCheck,payAmount,payDate,payDesc,payBank) Values(" + custID + "," + lstPaymentModeID[cmbmethod.SelectedIndex] + "," + lstTransacionTypeID[cmbPayType.SelectedIndex] + "," + txtCheckNo.Text + "," + txtAmt.Text + ",'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + paydesc + "'," + lstBankID[cmbBank.SelectedIndex] + ")";
                                    else if (Stat == FrmCompany.PaymentEdit)
                                        AIO.command = "update Payment set payMethod=" + lstPaymentModeID[cmbmethod.SelectedIndex] + ",payType=" + lstTransacionTypeID[cmbPayType.SelectedIndex] + ",payCheck=" + txtCheckNo.Text + ",payAmount=" + txtAmt.Text + ",payDate='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',payDesc='" + rtbDesc.Text + "',payBank=" + lstBankID[cmbBank.SelectedIndex] + " where id=" + transID;
                                    a1.cmdexe();
                                    this.Close();
                                }
                            }
                        }
                    }

                }
                else if (cmbmethod.SelectedIndex == 2) //Cash=2
                {
                    if (string.IsNullOrWhiteSpace(txtAmt.Text) || cmbPayType.SelectedIndex < 0)
                    {
                        MessageBox.Show("Blank is not Allow", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        double RAmount;
                        RAmount = Convert.ToDouble(txtAmt.Text);
                        OutAmount = OutAmount - RAmount;
                        string paydesc = rtbDesc.Text.Replace("'", "''");
                        if (Stat == FrmCompany.PaymentAdd)
                            AIO.command = "insert into Payment(payCustId,payMethod,payType,payAmount,payDate,payDesc,payBank,payCheck) Values(" + custID + "," + lstPaymentModeID[cmbmethod.SelectedIndex] + "," + lstTransacionTypeID[cmbPayType.SelectedIndex] + "," + txtAmt.Text + ",'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + paydesc + "',1,NULL)";
                        else if (Stat == FrmCompany.PaymentEdit)
                            AIO.command = "update Payment set payMethod=" + lstPaymentModeID[cmbmethod.SelectedIndex] + ",payType=" + lstTransacionTypeID[cmbPayType.SelectedIndex] + ",payAmount=" + txtAmt.Text + ",payDate='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',payDesc='" + rtbDesc.Text + "',payBank=1,payCheck=NULL where id=" + transID;
                        a1.cmdexe();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                var custType = "";
                dateTimePicker1.MinDate = AIO.OpeningDate;

                //Load Payment Mode with default values
                AIO.command = "select id, pmName from PaymentMode";
                using (var dt = a1.dataload())
                {
                    cmbmethod.Items.Clear();
                    lstPaymentModeID.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbmethod.Items.Add(row["pmName"].ToString());
                        lstPaymentModeID.Add(int.Parse(row["id"].ToString()));
                    }
                    cmbmethod.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbmethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbmethod.SelectedIndex = 2; //Cash
                }

                //Load Bank combobox with all banks
                AIO.command = "select id,bnkName from Banks where id<>1";
                using (var dt = a1.dataload())
                {
                    cmbBank.Items.Clear();
                    lstBankID.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbBank.Items.Add(row["bnkName"].ToString());
                        lstBankID.Add(int.Parse(row["id"].ToString()));
                    }
                    cmbBank.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }



                if (Stat == FrmCompany.PaymentAdd)
                {
                    txtCustomer.Text = custName;


                    AIO.command = "select custType from Customer where id=" + custID;
                    custType = a1.cmdexesc().ToString();

                    //Load Transaction Type with default values
                    AIO.command = "select id,trtName from TranTypes";
                    using (var dt2 = a1.dataload())
                    {
                        cmbPayType.Items.Clear();
                        lstTransacionTypeID.Clear();
                        foreach (DataRow row in dt2.Rows)
                        {
                            //cmbPayType.Items.Add(row["trtName"].ToString());
                            //lstTransacionTypeID.Add(int.Parse(row["id"].ToString()));
                            if (custType == "Customer")
                            {
                                if (int.Parse(row["id"].ToString()) != 4)
                                {
                                    cmbPayType.Items.Add(row["trtName"].ToString());
                                    lstTransacionTypeID.Add(int.Parse(row["id"].ToString()));
                                }
                            }
                            else if (custType == "Supplier")
                            {
                                if (int.Parse(row["id"].ToString()) != 3)
                                {
                                    cmbPayType.Items.Add(row["trtName"].ToString());
                                    lstTransacionTypeID.Add(int.Parse(row["id"].ToString()));
                                }
                            }
                        }
                        cmbPayType.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cmbPayType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    }
                }
                else if (Stat == FrmCompany.PaymentEdit)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT p.id, ");
                    sb.Append("c.id as cid, ");
                    sb.Append("c.custName AS Name, ");
                    sb.Append("pmName AS [Payment Mode], ");
                    sb.Append("trtName AS [Transaction Type], ");
                    sb.Append("p.payCheck AS [Cheque No], ");
                    sb.Append("Banks.id AS bnkid, ");
                    sb.Append("p.payAmount AS Amount, ");
                    sb.Append("p.payDate AS Date, ");
                    sb.Append("p.payDesc AS [Desc] ");
                    sb.Append("FROM Payment AS p ");
                    sb.Append("LEFT JOIN ");
                    sb.Append("Customer AS c ON payCustId = c.id ");
                    sb.Append("LEFT JOIN ");
                    sb.Append("PaymentMode ON payMethod = PaymentMode.id ");
                    sb.Append("LEFT JOIN ");
                    sb.Append("TranTypes ON p.payType = TranTypes.id ");
                    sb.Append("LEFT JOIN ");
                    sb.Append("banks ON p.payBank = Banks.id ");
                    sb.Append("where p.id=" + transID);
                    AIO.command = sb.ToString();


                    using (var dt = a1.dataload())
                    {
                        textBox1.Text = "";
                        txtCustomer.Text = dt.Rows[0]["Name"].ToString();
                        custName = dt.Rows[0]["Name"].ToString();
                        custID = Convert.ToInt32(dt.Rows[0]["cid"].ToString());
                        cmbmethod.SelectedItem = dt.Rows[0]["Payment Mode"].ToString();
                        cmbBank.SelectedIndex = lstBankID.FindIndex(x => x == Convert.ToInt32(dt.Rows[0]["bnkid"].ToString()));

                        AIO.command = "select custType from Customer where id=" + custID;
                        custType = a1.cmdexesc().ToString();
                        //Load Transaction Type with default values
                        AIO.command = "select id,trtName from TranTypes";
                        using (var dt2 = a1.dataload())
                        {
                            cmbPayType.Items.Clear();
                            lstTransacionTypeID.Clear();
                            foreach (DataRow row in dt2.Rows)
                            {
                                //cmbPayType.Items.Add(row["trtName"].ToString());
                                //lstTransacionTypeID.Add(int.Parse(row["id"].ToString()));
                                if (custType == "Customer")
                                {
                                    if (int.Parse(row["id"].ToString()) != 4)
                                    {
                                        cmbPayType.Items.Add(row["trtName"].ToString());
                                        lstTransacionTypeID.Add(int.Parse(row["id"].ToString()));
                                    }
                                }
                                else if (custType == "Supplier")
                                {
                                    if (int.Parse(row["id"].ToString()) != 3)
                                    {
                                        cmbPayType.Items.Add(row["trtName"].ToString());
                                        lstTransacionTypeID.Add(int.Parse(row["id"].ToString()));
                                    }
                                }
                            }
                            cmbPayType.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cmbPayType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        }


                        cmbPayType.SelectedItem = dt.Rows[0]["Transaction Type"].ToString();
                        txtCheckNo.Text = dt.Rows[0]["Cheque No"].ToString();
                        txtAmt.Text = dt.Rows[0]["Amount"].ToString();
                        rtbDesc.Text = dt.Rows[0]["Desc"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["Date"].ToString());



                        //From here logic is for customer
                        //
                        sb = new StringBuilder();
                        if (custType == "Customer")
                        {
                            sb.Append("SELECT Round(c.custOpenBal + (coalesce(sum(itg.itgTotal), 0) + coalesce(sum((coalesce(itg.itgTotal, 0) * (h.igst / 100))), 0)) - ( ");
                            sb.Append("SELECT coalesce(sum(payAmount), 0) ");
                            sb.Append("FROM Payment ");
                            sb.Append("WHERE payCustId = c.id AND ");
                            sb.Append("payType = 2 ");
                            sb.Append(") ");
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
                            sb.Append("), 0) as [Outstanding Balance] ");
                        }
                        //
                        //From Here logic is for supplier
                        //
                        else if (custType == "Supplier")
                        {
                            sb.Append("SELECT Round(c.custOpenBal - (coalesce(sum(itg.itgTotal), 0) + coalesce(sum((coalesce(itg.itgTotal, 0) * (h.igst / 100))), 0)) + ( ");
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
                            sb.Append("), 0) as [Outstanding Balance] ");
                        }
                        //

                        sb.Append("FROM Customer AS c ");
                        sb.Append("LEFT JOIN ");
                        sb.Append("Trans2 t ON t.tranCustID = c.id ");
                        sb.Append("LEFT JOIN ");
                        sb.Append("TranItemsGrid AS itg ON t.id = itg.itgTranID ");
                        sb.Append("LEFT JOIN ");
                        sb.Append("Items AS i ON itg.itgModID = i.id ");
                        sb.Append("LEFT JOIN ");
                        sb.Append("HsnTax AS h ON i.hsnId = h.id ");
                        sb.Append("WHERE c.id='" + custID + "' ");
                        sb.Append("GROUP BY c.custName");
                        AIO.command = sb.ToString();
                        OutAmount = Convert.ToDouble(a1.cmdexesc());
                    }
                }

                if (Convert.ToInt32(OutAmount) > 0)
                {
                    textBox1.BackColor = Color.White;
                    textBox1.ForeColor = Color.Green;
                    textBox1.Text = OutAmount.ToString(); ;
                }
                else if (Convert.ToInt32(OutAmount) < 0)
                {
                    textBox1.BackColor = Color.White;
                    textBox1.ForeColor = Color.Red;
                    textBox1.Text = OutAmount.ToString(); ;
                }
                else
                {
                    textBox1.BackColor = Color.White;
                    textBox1.ForeColor = Color.Black;
                    textBox1.Text = OutAmount.ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbmethod.SelectedIndex != 2) //Bank Transfer=0, Cheque=1
                {
                    txtAmt.Enabled = true;
                    txtCheckNo.Enabled = true;
                    cmbBank.Enabled = true;
                }
                else //Cash=2
                {
                    txtAmt.Enabled = true;
                    txtCheckNo.Enabled = false;
                    cmbBank.Enabled = false;
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
