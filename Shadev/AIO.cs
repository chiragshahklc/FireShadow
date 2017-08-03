using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Shadev
{
    public class AIO
    {
        public static string path = "";
        public static string command = "";
        public static string file = "";
        public static DateTime OpeningDate { get; set; }
        private SQLiteConnection con = new SQLiteConnection("Data Source=" + Path.Combine(AIO.path, AIO.file) + ";foreign keys=true;");//Password=5gs6hf7tjg86sjhfr6hkdg87grfj6ehgfr78lcmksd8;

        public int cmdexe()
        {
            if (string.IsNullOrWhiteSpace(AIO.path))
                throw new ArgumentException("Path to database should not be empty. \r\nPlease set path by using AIO.path", "path");
            if (this.con.State != ConnectionState.Open)
                this.con.Open();
            int num = new SQLiteCommand(AIO.command, this.con).ExecuteNonQuery();
            this.con.Close();
            return num;
        }

        public DataTable dataload()
        {
            //con.Open();
            //con.ChangePassword(string.Empty);

            //con.Close();
            //System.Windows.Forms.Application.Exit();
            if (string.IsNullOrWhiteSpace(AIO.path))
                throw new ArgumentException("Path to database should not be empty. \r\nPlease set path by using AIO.path", "path");
            SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(AIO.command, this.con);
            DataTable dataTable = new DataTable();
            sqLiteDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public object cmdexesc()
        {
            if (string.IsNullOrWhiteSpace(AIO.path))
                throw new ArgumentException("Path to database should not be empty. \r\nPlease set path by using AIO.path", "path");
            if (this.con.State != ConnectionState.Open)
                this.con.Open();
            object obj = new SQLiteCommand(AIO.command, this.con).ExecuteScalar();
            this.con.Close();
            return obj;
        }

        public int cmdexesu()
        {
            if (string.IsNullOrWhiteSpace(AIO.path))
                throw new ArgumentException("Path to database should not be empty. \r\nPlease set path by using AIO.path", "path");
            if (this.con.State != ConnectionState.Open)
                this.con.Open();
            SQLiteCommand sqLiteCommand = new SQLiteCommand(AIO.command, this.con);
            sqLiteCommand.ExecuteNonQuery();
            sqLiteCommand.CommandText = "select last_insert_rowid()";
            int num = int.Parse(sqLiteCommand.ExecuteScalar().ToString());
            this.con.Close();
            return num;
        }
        public void CloseConnection()
        {
            con.Close();
            //con = new SQLiteConnection();
            //con.Dispose();
            //con.Shutdown();
            //con.
        }
    }
}
