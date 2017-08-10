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
    public partial class frmStockReport : Form
    {
        AIO a1 = new AIO();
        public DateTime StartDate { get; set; }
        public frmStockReport()
        {
            InitializeComponent();
        }
        private void frmStockReport_Load(object sender, EventArgs e)
        {
            StartDate = AIO.OpeningDate;
            fromDate.MinDate = AIO.OpeningDate;
            ToDate.MinDate = AIO.OpeningDate;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rptStockReport rpt = new rptStockReport();
            dsStock ds = new dsStock();
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
            dr["To"] = ToDate.Value;
            xDT.Rows.Add(dr);

            ds.Tables.Remove("Dates");
            ds.Tables.Add(xDT);


            AIO.command = "select abtComName as [Name],abtComMob as [Mob],abtComEmail as [Email],abtPAN as [PAN],abtVatTIN as [TIN],abtComAdd as [Add] from AboutMe as [Company]";
            SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
            da.Fill(ds, "Company");

            //AIO.command = "SELECT (SELECT comName || ' ' || M.modName FROM Company WHERE id = (SELECT catComID FROM Category WHERE id = M.modCatID)) AS Name, sum(CASE WHEN T.itgTranType = 'Purchase' THEN T.itgQTY ELSE 0 END) AS [Inwards], sum(CASE WHEN T.itgTranType = 'Sale' THEN T.itgQTY ELSE 0 END) AS [Outwards] FROM Model AS M LEFT JOIN TranItemsGrid AS T ON M.id == T.itgModID where T.itgTranID in (SELECT Trans.id from Trans where Trans.tranDate between '"+fromDate.ToString("yyyy-MM-dd")+"' and '"+ToDate.ToString("yyyy-MM-dd")+"') GROUP BY modName order by Name";


            StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT cp.comName || ' ' || m.modName AS Name, ");
            //sb.Append("sum(CASE WHEN tig.itgTranType = 'Purchase' THEN tig.itgQTY ELSE 0 END) AS [Inwards], ");
            //sb.Append("sum(CASE WHEN tig.itgTranType = 'Sale' THEN tig.itgQTY ELSE 0 END) AS [Outwards] ");
            //sb.Append("FROM model AS m ");
            //sb.Append("LEFT JOIN ");
            //sb.Append("Category AS c ON m.modCatID = c.id ");
            //sb.Append("LEFT JOIN ");
            //sb.Append("Company AS cp ON c.catComID = cp.id ");
            //sb.Append("LEFT JOIN ");
            //sb.Append("TranItemsGrid AS tig ON tig.itgModID = m.id ");
            //sb.Append("LEFT JOIN ");
            //sb.Append("Trans AS t ON t.id = tig.itgTranID ");
            //sb.Append("WHERE t.tranDate BETWEEN '" + fromDate.ToString("yyyy-MM-dd") + "' AND '" + ToDate.ToString("yyyy-MM-dd") + "' ");
            //sb.Append("GROUP BY name;");
            //AIO.command = sb.ToString();

            //da = new SQLiteDataAdapter(AIO.command, con);
            //da.Fill(ds, "Items");

            sb = new StringBuilder();
            sb.Append("SELECT itemDesc AS Name, ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Purchase' AND ");
            sb.Append("(t.tranDate BETWEEN '" + fromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") + "') THEN tig.itgQTY ELSE 0 END) AS [Inwards], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Purchase' AND ");
            sb.Append("(t.tranDate BETWEEN '" + fromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") + "') THEN tig.itgTotal ELSE 0 END) AS [InwardsTotal], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Sale' AND ");
            sb.Append("(t.tranDate BETWEEN '" + fromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") + "') THEN tig.itgQTY ELSE 0 END) AS [Outwards], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Sale' AND ");
            sb.Append("(t.tranDate BETWEEN '" + fromDate.Value.ToString("yyyy-MM-dd") + "' AND '" + ToDate.Value.ToString("yyyy-MM-dd") + "') THEN tig.itgTotal ELSE 0 END) AS [OutwardsTotal], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Purchase' AND ");
            sb.Append("(t.tranDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + fromDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "') THEN tig.itgQTY ELSE 0 END) AS [OldIn], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Purchase' AND ");
            sb.Append("(t.tranDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + fromDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "') THEN tig.itgTotal ELSE 0 END) AS [OldInTotal], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Sale' AND ");
            sb.Append("(t.tranDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + fromDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "') THEN tig.itgQTY ELSE 0 END) AS [OldOut], ");
            sb.Append("sum(CASE WHEN tig.itgTranType = 'Sale' AND ");
            sb.Append("(t.tranDate BETWEEN '" + StartDate.ToString("yyyy-MM-dd") + "' AND '" + fromDate.Value.AddDays(-1).ToString("yyyy-MM-dd") + "') THEN tig.itgQTY ELSE 0 END) AS [OldOutTotal] ");
            sb.Append("FROM Items AS m ");
            sb.Append("LEFT JOIN ");
            sb.Append("TranItemsGrid AS tig ON tig.itgModID = m.id ");
            sb.Append("LEFT JOIN ");
            sb.Append("Trans2 AS t ON t.id = tig.itgTranID ");
            sb.Append("GROUP BY name; ");

            AIO.command = sb.ToString();

            da = new SQLiteDataAdapter(AIO.command, con);
            da.Fill(ds, "Items");

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();
        }
    }
}
