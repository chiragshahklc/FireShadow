using Microsoft.Reporting.WinForms;
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
    public partial class temp : Form
    {
        AIO a1 = new AIO();
        public temp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AIO.command = "select id,tranNo from Trans where tranType='Sale' and length(tranNo)=3  and tranNo like '%L'";
            //var dt = a1.dataload();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string x = dt.Rows[i]["tranNo"].ToString();
            //    //x = x.Substring(0,3);
            //    AIO.command = "update Trans set tranNo='0000" + x + "' where id=" + dt.Rows[i]["id"].ToString();
            //    a1.cmdexe();

            //}
            //MessageBox.Show("Done");

            AIO.command = "select abtComName as [comName],abtComMob as [comMob], abtComEmail as [comEmail], abtPAN as [comPAN], abtVatTIN as [comTIN] from AboutMe as [Company]";
            var dt = a1.dataload();

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "Company";
            rds.Value = dt;

            reportViewer1.Refresh();
            reportViewer1.LocalReport.DataSources.Add(rds);
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "Shadev.mrStockReport.rdlc";
            
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void temp_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
