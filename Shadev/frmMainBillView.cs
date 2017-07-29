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
using System.IO;

namespace Shadev
{
    public partial class frmMainBillView : Form
    {

        AIO a1 = new AIO();   
        public int ID { get; set; }
        public frmMainBillView()
        {
            InitializeComponent();
        }

        private void frmMainBillView_Load(object sender, EventArgs e)
        {

            try
            {
                rptMainBill2 rpt = new rptMainBill2();
                dsCommon ds = new dsCommon();


                SQLiteConnection con = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AIO.path, AIO.file) + ";foreign keys=true;");//Password=5gs6hf7tjg86sjhfr6hkdg87grfj6ehgfr78lcmksd8;

                AIO.command = "select abtComName as [Name],abtComAdd as [Add],abtComMob as [Mob],abtComEmail as [Email],abtVatTIN as [TIN],abtCstNo as [CST],abtPAN as [PAN],abtCIN as [CIN],abtEsta as [Esta] from AboutMe as [AM]";
                SQLiteDataAdapter da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "AM");

                AIO.command = "select tranNo as[No],tranDate as [Date],tranInvoice as [Invoice] from Trans as [T] where id=" + ID;
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "Trans2");

                //AIO.command = "select id,itgQTY as [qty],itgPrice as [price],itgDesc as [desc] from TranItemsGrid where itgTranID=" + ID + " order by id asc";
                //da = new SQLiteDataAdapter(AIO.command, con);
                //da.Fill(ds, "TG");

                AIO.command = "select tcVal as [val] from TermsCond";
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "TC");

                AIO.command = "select bnkName as [name],bnkBranch as [branch],bnkACNo as [acno],bnkIFSC as [ifsc] from Banks where id=(select tranBankID from Trans where id=" + ID + ")";
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "Bank");

                AIO.command = "select custName as [name],custAdd as [add],custMob as [mob],custEmail as [email],custVatTIN as [vat],custCstNo as [cst],custPAN as [pan] from Customer where id=(select tranCustID from Trans where id=" + ID + ")";
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "Cust");

                AIO.command = "select todDeliveryNote as [tod1],todSupplierRef as [tod2],todMOP as [tod3],todOtherRef as [tod4],todBuyerNo as [tod5],todBuyerDated as [tod6],todDispatchDoc as [tod7],todDispatchDated as [tod8],todDispatchThrough as [tod9],todDestination as [tod10],todTerms as [tod11] from TranOtherDetails where todTransID=" + ID;
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "TOD");
                //AIO.command = "select itgModID from TranItemsGrid where itgTranID="+ID;
                //var dt = a1.dataload();
                //string models = "";
                //foreach (DataRow row in dt.Rows)
                //{
                //    models += row["itgModID"].ToString()+",";
                //}
                //models = models.Remove(models.Length - 1, 1);

                //AIO.command = "select modCatID from model where id in (" + models + ")";
                //var dt2 = a1.dataload();
                //string coms = "";
                //foreach (DataRow row in dt2.Rows)
                //{
                //    coms += coms + row["modCatID"].ToString() + ",";
                //}
                //coms = coms.Remove(coms.Length - 1, 1);

                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT I.itemDesc AS [Item], ");
                sb.Append("H.hsnCode AS [HSN], ");
                sb.Append("T.itgPrice AS [Price], ");
                sb.Append("T.itgQTY AS [QTY], ");
                sb.Append("T.itgTotal AS [Total], ");
                sb.Append("Round(T.itgTotal * (H.sgst / 100), 2) AS [SGST], ");
                sb.Append("Round(T.itgTotal * (H.cgst / 100), 2) AS [CGST], ");
                sb.Append("Round(T.itgTotal * (H.igst / 100), 2) AS [IGST],");
                sb.Append("Round(T.itgTotal + T.itgTotal * (H.igst / 100), 2) AS [Amount], ");
                sb.Append("T.itgDesc AS [Desc] ");
                sb.Append("FROM TranItemsGrid AS T ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items AS I ON T.itgModID = I.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("HsnTax AS H ON I.hsnId = H.id ");
                sb.Append("WHERE T.itgTranID=" + ID + " ");
                sb.Append("ORDER BY T.id ASC");
                AIO.command = sb.ToString();
                //AIO.command = "select (select comName from Company where id=(select catComID from Category where id=modCatID)) as [com],modName as [mod],itgQTY as [qty],itgPrice as [price],itgDesc as [desc] from model as m left join TranItemsGrid as tg on m.id=tg.itgModID  where m.id in (select itgModID from TranItemsGrid where itgTranID=" + ID + ") and tg.itgTranID=" + ID +" order by tg.id ASC";
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "ITG");

                sb = new StringBuilder();
                sb.Append("SELECT group_concat(DISTINCT(h.hsnCode)) as [code], ");
                sb.Append("h.sgst AS [SGST], ");
                sb.Append("h.cgst AS [CGST], ");
                sb.Append("h.igst AS [IGST], ");
                sb.Append("sum(itg.itgPrice * itg.itgQTY * (h.sgst / 100)) AS [TAX] ");
                sb.Append("FROM HsnTax AS h ");
                sb.Append("LEFT JOIN ");
                sb.Append("Items AS i ON i.hsnId = h.id ");
                sb.Append("LEFT JOIN ");
                sb.Append("TranItemsGrid AS itg ON itg.itgModID = i.id ");
                sb.Append("WHERE itg.itgTranID ="+ ID + " ");
                sb.Append("GROUP BY h.sgst");
                AIO.command = sb.ToString();
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "HSN");

                AIO.command = "select tax1name,tax2name from GeneralSettings";
                da = new SQLiteDataAdapter(AIO.command, con);
                da.Fill(ds, "General");
                //ParameterFieldDefinitions crParameterFieldDefinitions;
                //ParameterFieldDefinition crParameterFieldDefinition;
                //ParameterValues crParameterValues = new ParameterValues();
                //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                //crParameterDiscreteValue.Value = "Purchase";
                //crParameterFieldDefinitions = rpt.DataDefinition.ParameterFields;
                //crParameterFieldDefinition = crParameterFieldDefinitions["reportType"];
                //crParameterValues = crParameterFieldDefinition.CurrentValues;

                //crParameterValues.Clear();
                //crParameterValues.Add(crParameterDiscreteValue);
                //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                //rpt.SetParameterValue(0, "Purchase");
                rpt.SetDataSource(ds);
                rpt.Refresh();
                //rpt.ExportToDisk(ExportFormatType.PortableDocFormat, Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) ,@"\Report\tmpExport.pdf"));
                //string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Fire Shadow";
                //rpt.ExportToDisk(ExportFormatType.PortableDocFormat, System.IO.Path.Combine(path,ds.Tables["Trans"].Rows[0]["No"].ToString()) + ".pdf");
                crvMainBill.ReportSource = rpt;
                crvMainBill.RefreshReport();
                
                //crvMainBill.ExportReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
