using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadev
{
    public enum FrmCompany : int
    {
        CompanyAdd = 1,
        CompanyEdit = 2,
        CompanyDelete = 3,
        CategoryAdd = 4,
        CategoryEdit = 5,
        CategoryDelete = 6,
        ModelAdd = 7,
        ModelEdit = 8,
        ModelDelete = 9,
        BankAdd = 10,
        BankEdit = 11,
        BankDelete = 12,
        CustAdd = 13,
        CustEdit = 14,
        CustDelete = 15,
        TermsAdd = 16,
        TermsEdit = 17,
        TransAdd = 18,
        TransEdit = 19,
        itgAdd = 20,
        itgEdit = 21,
        PaymentAdd = 22,
        PaymentEdit = 23,
        HSNAdd = 24,
        HSNEdit = 25,
        NewItemAdd = 26,
        NewItemEdit = 27
    }

    public enum AllTabs : int
    {
        Model,
        Customer,
        AboutMe,
        Bank,
        TermsAndCondition,
        Transaction,
        Expense,
        Home,
        Payment,
        Login,
        GeneralSettings,
        TransactionReport,
        AboutUs,
        Registration,
        HSNMaster,
        ItemMaster
    }

    public enum TranSearc : int
    {
        TransNo = 1,
        Customer = 2,
        Item = 3
    }
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AIO.path = @"D:\Arcane Mastery\Souma's Wikia\ShadevBil\Shadev\Shadev\DB\";
            //SqliteDbAIO.AIO.path = @"F:\";
            AIO.path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            AIO.file = "Data.fs";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MasterForm());
        }
    }
}
