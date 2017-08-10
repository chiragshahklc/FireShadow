using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


namespace Shadev
{
    public partial class frmLRReport : Form
    {
        AIO a1 = new AIO();
        public int ID { get; set; }
        public List<int> lstCustomerID = new List<int>();

        public frmLRReport()
        {
            InitializeComponent();
        }

        private void frmLRReport_Load(object sender, EventArgs e)
        {
            fromDate.MinDate = AIO.OpeningDate;
            toDate.MinDate = AIO.OpeningDate;

            RefreshCustomer();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCustomerName.SelectedIndex >= 0)
                {
                    LrReport cr = new LrReport();
                    dsLreport LR = new dsLreport();
                    SQLiteConnection con = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AIO.path, AIO.file) + ";foreign keys=true;");

                    DataTable xDT = new DataTable("Dates");

                    DataColumn xDC = new DataColumn();
                    xDC.DataType = System.Type.GetType("System.DateTime");
                    xDC.ColumnName = "From";
                    xDT.Columns.Add(xDC);

                    xDC = new DataColumn();
                    xDC.DataType = System.Type.GetType("System.DateTime");
                    xDC.ColumnName = "To";
                    xDT.Columns.Add(xDC);


                    DataRow dr = xDT.NewRow();
                    dr["From"] = fromDate.Value;
                    dr["To"] = toDate.Value;
                    xDT.Rows.Add(dr);

                    LR.Tables.Remove("Dates");
                    LR.Tables.Add(xDT);

                    AIO.command = "select abtComName as [Name],abtComAdd as [Add],abtComMob as [Mob],abtComEmail as [Email],abtVatTIN as [TIN],abtCstNo as [CST],abtPAN as [PAN],abtCIN as [CIN],abtEsta as [Esta] from AboutMe as [AM]";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
                    da.Fill(LR, "AM");



                    StringBuilder ss = new StringBuilder();


                    ss.Append("SELECT custName as Name, ");
                    ss.Append("tranDate AS Date, ");
                    ss.Append("sum(itgTotal + (itgTotal * (igst / 100))) AS Debit, ");
                    ss.Append("'0' AS Credit, ");
                    ss.Append("tranNo as InvoiceID, ");
                    ss.Append("tranInvoice as InvType ");
                    ss.Append("FROM Trans2 ");
                    ss.Append("LEFT JOIN ");
                    ss.Append("TranItemsGrid ON Trans2.id = itgTranID ");
                    ss.Append("LEFT JOIN ");
                    ss.Append("Items ON itgModID = Items.id ");
                    ss.Append("LEFT JOIN ");
                    ss.Append("HsnTax ON hsnId = HsnTax.id ");
                    ss.Append("LEFT JOIN ");
                    ss.Append("Customer ON tranCustID = Customer.id ");
                    ss.Append("WHERE tranDate BETWEEN '" + fromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + toDate.Value.ToString("yyyy-MM-dd") + "' AND Customer.id="+lstCustomerID[cmbCustomerName.SelectedIndex] + " ");
                    ss.Append("GROUP BY Trans2.id, ");
                    ss.Append("custName ");
                    ss.Append("UNION ");
                    ss.Append("SELECT custName as Name, ");
                    ss.Append("payDate as Date, ");
                    ss.Append("'0', ");
                    ss.Append("payAmount as Debit, ");
                    ss.Append("payment.id as InvoiceID, ");
                    ss.Append("trtName as InvType ");
                    ss.Append("FROM Payment ");
                    ss.Append("LEFT JOIN ");
                    ss.Append("Customer ON payCustId = Customer.id ");
                    ss.Append("LEFT JOIN ");
                    ss.Append("TranTypes ON TranTypes.id=payType ");
                    ss.Append("WHERE payDate BETWEEN '" + fromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + toDate.Value.ToString("yyyy-MM-dd") + "' AND payCustId="+lstCustomerID[cmbCustomerName.SelectedIndex] + " ");
                    ss.Append("ORDER BY Date;");
                    AIO.command = ss.ToString();


                    SQLiteDataAdapter da2 = new SQLiteDataAdapter(AIO.command, con);
                    da2.Fill(LR, "LR");


                    cr.SetDataSource(LR);
                    cr.Refresh();
                    crvLrReport.ReportSource = cr;
                    crvLrReport.RefreshReport();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPayCust_Click(object sender, EventArgs e)
        {
            if (btnPayCust.Text == "Customer")
            {
                btnPayCust.Text = "Supplier";
                cmbCustomerName.Text = "";
                //btnTRCust.Text = supplierToolStripMenuItem.Text;
                //custType = supplierToolStripMenuItem.Text;
                RefreshCustomer();
            }
            else if (btnPayCust.Text == "Supplier")
            {
                btnPayCust.Text = "Customer";
                cmbCustomerName.Text = "";
                //btnTRCust.Text = customerToolStripMenuItem.Text;
                //custType = customerToolStripMenuItem.Text;
                RefreshCustomer();
            }
        }

        private void RefreshCustomer()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT c.id, ");
            sb.Append("c.custName as [Name] ");
            sb.Append("FROM Customer AS c ");
            sb.Append("WHERE custType='"+btnPayCust.Text+"' ORDER BY Name ASC");
            AIO.command = sb.ToString();
            var dt = a1.dataload();

            lstCustomerID.Clear();
            cmbCustomerName.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cmbCustomerName.Items.Add(row["Name"].ToString());
                lstCustomerID.Add(int.Parse(row["id"].ToString()));
            }
            cmbCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
    }
}
