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

namespace Shadev
{
    public partial class frmItemReport : Form
    {
        AIO a1 = new AIO();
        public int ID { get; set; }
        public List<int> lstItemsID = new List<int>();
        public frmItemReport()
        {
            InitializeComponent();
        }

        private void frmItemReport_Load(object sender, EventArgs e)
        {
            dtpFrom.MinDate = AIO.OpeningDate;
            dtmTo.MinDate = AIO.OpeningDate;

            AIO.command = "select id,ItemDesc from Items";
            var dt = a1.dataload();
            lstItemsID.Clear();
            cmbItemName.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cmbItemName.Items.Add(row["ItemDesc"].ToString());
                lstItemsID.Add(int.Parse(row["id"].ToString()));
            }
            cmbItemName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedIndex >= 0)
            {
                rptItem cr = new rptItem();
                ItemReport IR = new ItemReport();
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
                dr["From"] = dtpFrom.Value;
                dr["To"] = dtmTo.Value;
                xDT.Rows.Add(dr);

                IR.Tables.Remove("Dates");
                IR.Tables.Add(xDT);


                AIO.command = "select abtComName as [Name],abtComAdd as [Add],abtComMob as [Mob],abtComEmail as [Email],abtVatTIN as [TIN],abtCstNo as [CST],abtPAN as [PAN],abtCIN as [CIN],abtEsta as [Esta] from AboutMe as [AM]";
                SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(IR, "AM");



                StringBuilder ss = new StringBuilder();

                ss.Append("SELECT itemDesc as Name, ");
                ss.Append("T2.tranDate as Date, ");
                ss.Append("case when T1.itgTranType = 'Purchase' then T1.itgQTY else 0 end as inward, ");
                ss.Append("case when T1.itgTranType = 'Purchase' then T1.itgPrice else 0 end as [inward price], ");
                ss.Append("case when T1.itgTranType = 'Purchase' then(T1.itgPrice * T1.itgQTY)  else 0 end as [inward Total], ");
                ss.Append("case when T1.itgTranType = 'Sale' then T1.itgQTY else 0 end as outward, ");
                ss.Append("case when T1.itgTranType = 'Sale' then T1.itgPrice else 0 end as [outward price], ");
                ss.Append("case when T1.itgTranType = 'Sale' then(T1.itgPrice * T1.itgQTY)  else 0 end as [outward Total], ");
                ss.Append("T2.tranNo as No, ");
                ss.Append("T1.itgTranType as Type ");
                ss.Append("FROM Items ");
                ss.Append("LEFT JOIN ");
                ss.Append("TranItemsGrid as T1 ON Items.id = T1.itgModID ");
                ss.Append("LEFT JOIN ");
                ss.Append("Trans2 as T2 ON T1.itgTranID = T2.id ");
                ss.Append("where Items.id = '" + lstItemsID[cmbItemName.SelectedIndex] + "'and tranDate between '" + dtpFrom.Value.ToString("yyyy - MM - dd") + "' and '" + dtmTo.Value.ToString("yyyy-MM-dd") + "' ");
                ss.Append("GROUP BY T2.id");


                AIO.command = ss.ToString();


                SQLiteDataAdapter da2 = new SQLiteDataAdapter(AIO.command, con);
                da2.Fill(IR, "ItemReport");


                cr.SetDataSource(IR);
                cr.Refresh();
                crvItemReport.ReportSource = cr;
                crvItemReport.RefreshReport();

            }

        }
    }
}
