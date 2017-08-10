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
    public partial class frmExpenseReport : Form
    {
        public string EID { get; set; }
        public frmExpenseReport()
        {
            InitializeComponent();
        }

        private void frmExpenseReport_Load(object sender, EventArgs e)
        {
            try
            {
                
                ExpenseReport rpt = new ExpenseReport();
                dsCommon ds = new dsCommon();

                SQLiteConnection con = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AIO.path, AIO.file) + ";foreign keys=true;");//;foreign keys=true;Password=5gs6hf7tjg86sjhfr6hkdg87grfj6ehgfr78lcmksd8;

                AIO.command =EID;
                SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "Expense1");


                rpt.SetDataSource(ds);
                 crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
