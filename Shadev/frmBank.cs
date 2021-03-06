﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SqliteDbAIO;

namespace Shadev
{
    public partial class frmBank : Form
    {
        public FrmCompany Stat { get; set; }
        AIO a1 = new AIO();
        public DataRow row { get; set; }
        public long id { get; set; }
        public frmBank()
        {

            InitializeComponent();

            this.ShowInTaskbar = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void xButtons1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtBankName.Text.Replace("'", "''");
                if (!string.IsNullOrWhiteSpace(txtBankName.Text))
                {
                    switch (Stat)
                    {
                        case FrmCompany.BankAdd:
                            {
                                AIO.command = "INSERT INTO  Banks(bnkname,bnkACNo,bnkBranch,bnkIFSC) VALUES('" + name + "'," + txtACNO.Text + ",'" + txtBankBranch.Text + "','" + txtBankIFSC.Text + "')";
                                a1.cmdexe();
                                this.Close();
                            }
                            break;
                        case FrmCompany.BankEdit:
                            {
                                AIO.command = "update Banks  set bnkname='" + name + "',bnkACNo=" + txtACNO.Text + ",bnkBranch='" + txtBankBranch.Text + "',bnkIFSC='" + txtBankIFSC.Text + "' where id=" + id;
                                a1.cmdexe();
                                this.Close();
                            }
                            break;

                        default:
                            break;
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public bool a { get; set; }

        private void txtBankName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBank_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Stat)
                {

                    case FrmCompany.BankAdd:
                        {
                            this.Text = "Bank: Add";
                        }
                        break;

                    case FrmCompany.BankEdit:
                        {
                            this.Text = "Bank: Edit";
                            txtBankName.Text = row["Name"].ToString();
                            txtBankBranch.Text = row["Branch"].ToString();
                            txtACNO.Text = row["AccountNo"].ToString();
                            txtBankIFSC.Text = row["IFSC"].ToString();
                            id = Convert.ToInt64(row["id"].ToString());
                        }
                        break;

                    default:
                        break;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
