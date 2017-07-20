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
using System.Data.SQLite;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Shadev
{
    public partial class frmpaymentreport : Form
    {
        List<long> CustID = new List<long>();
        public string CID { get; set; }
        AIO a1 = new AIO();
        public frmpaymentreport()
        {
            InitializeComponent();
        }

        private void crvPyamentReport_Load(object sender, EventArgs e)
        {

        }
        private void RefreshCustomer()
        {
            try
            {
                AIO.command = "select c.id,c.custName as [Name],c.custAdd as [Address],c.custMob as [Mobile],c.custEmail as [Email],c.custVatTIN as [VAT TIN],c.custCstNo as [CST No],c.custPAN as [PAN] from Customer as c";
                var dt = a1.dataload();
             


                

                CustID.Clear();
                
                CustID.Add(-1);
                foreach (DataRow row in dt.Rows)
                {
                   
                    CustID.Add(long.Parse(row["id"].ToString()));
                }

               

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            

        }

        private void frmpaymentreport_Load(object sender, EventArgs e)
        {
            try
            {
               // RefreshCustomer();
                PaymentReport rpt = new PaymentReport();
                dsCommon ds = new dsCommon();

                SQLiteConnection con = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AIO.path, AIO.file) + ";foreign keys=true;");//Password=5gs6hf7tjg86sjhfr6hkdg87grfj6ehgfr78lcmksd8;

                AIO.command = CID;
                SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "Payment1");

                AIO.command = "select abtComName as [Name],abtComAdd as [Add],abtComMob as [Mob],abtComEmail as [Email],abtVatTIN as [TIN],abtCstNo as [CST],abtPAN as [PAN],abtCIN as [CIN],abtEsta as [Esta] from AboutMe as [AM]";
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "AM");

                rpt.SetDataSource(ds);
                crvPyamentReport.ReportSource = rpt;
                crvPyamentReport.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
