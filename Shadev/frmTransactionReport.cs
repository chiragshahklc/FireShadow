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
    public partial class frmTransactionReport : Form
    {
        public string query { get; set; }
        public frmTransactionReport()
        {
            InitializeComponent();
        }

        private void frmTransactionReport_Load(object sender, EventArgs e)
        {
            TransactionReport rpt = new TransactionReport();
            dsCommon ds = new dsCommon();

            SQLiteConnection con = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AIO.path, AIO.file) + ";foreign keys=true;");//Password=5gs6hf7tjg86sjhfr6hkdg87grfj6ehgfr78lcmksd8;

            AIO.command = query;
            SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
            da.Fill(ds, "TR");

            AIO.command = "select abtComName as [Name],abtComAdd as [Add],abtComMob as [Mob],abtComEmail as [Email],abtVatTIN as [TIN],abtCstNo as [CST],abtPAN as [PAN],abtCIN as [CIN],abtEsta as [Esta] from AboutMe as [AM]";
            da = new SQLiteDataAdapter(AIO.command, con);
            da.Fill(ds, "AM");

            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();
        }
    }
}
