﻿using System;
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
    public partial class frmNewItems : Form
    {

        AIO A1;
        public FrmCompany Stat { get; set; }
        List<long> UnitId = new List<long>();
        List<long> HSNId = new List<long>();
        List<string> lstHSNDesc = new List<string>();
        public long id { get; set; }

        public DataRow row { get; set; }

        public frmNewItems()
        {
            InitializeComponent();
            A1 = new AIO();
            //dgvItem.AllowUserToAddRows = false;
            //dgvItem.AllowUserToDeleteRows = false;
            //dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvItem.ReadOnly = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Stat)
                {
                    case FrmCompany.NewItemAdd:
                        {
                            if (!string.IsNullOrWhiteSpace(txtItemDescription.Text) || cmbUnit.SelectedIndex != 0)
                            {
                                AIO.command = "INSERT into Items(itemDesc,hsnId,oid) VALUES('" + txtItemDescription.Text + "'," + HSNId[comboBox1.SelectedIndex] + "," + UnitId[cmbUnit.SelectedIndex] + ")";
                                A1.cmdexe();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Blank is Not Allow", "FireShadow", MessageBoxButtons.OK);
                            }

                        }
                        break;
                    case FrmCompany.NewItemEdit:
                        {
                            if (!string.IsNullOrWhiteSpace(txtItemDescription.Text) || cmbUnit.SelectedIndex != 0)
                            {
                                if (row != null)
                                {
                                    AIO.command = " Update Items SET itemDesc = '" + txtItemDescription.Text + "',hsnId = " + HSNId[comboBox1.SelectedIndex] + ",oid = " + UnitId[cmbUnit.SelectedIndex] + " WHERE id = " + id + " ";
                                    A1.cmdexe();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please Select any Data", "Fire Shadow", MessageBoxButtons.OK);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Blank is Not Allow", "FireShadow", MessageBoxButtons.OK);
                            }

                        }
                        break;
                    default:
                        break;



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        private void frmNewItems_Load(object sender, EventArgs e)
        {

            try
            {
                StringBuilder sb = new StringBuilder();

                //Fill combobox of Units
                AIO.command = "SELECT id,uom from Units";
                var dt = A1.dataload();
                cmbUnit.Items.Clear();
                UnitId.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbUnit.Items.Add(row["uom"].ToString());
                    UnitId.Add(Convert.ToInt64(row["id"].ToString()));
                }
                cmbUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbUnit.AutoCompleteSource = AutoCompleteSource.ListItems;

                //Fill combobox of HSNCodes
                sb.Append("SELECT id, ");
                sb.Append("hsnCode, ");
                sb.Append("[desc] ");
                sb.Append("FROM HsnTax ");
                sb.Append("ORDER BY hsnCode;");
                AIO.command = sb.ToString();
                var dt1 = A1.dataload();
                comboBox1.Items.Clear();
                HSNId.Clear();
                lstHSNDesc.Clear();
                foreach (DataRow row in dt1.Rows)
                {
                    comboBox1.Items.Add(row["hsnCode"].ToString());
                    HSNId.Add(Convert.ToInt64(row["id"].ToString()));
                    lstHSNDesc.Add(row["desc"].ToString());
                }
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;


                switch (Stat)
                {
                    case FrmCompany.NewItemAdd:
                        {
                            this.Text = "Item: Add";

                        }
                        break;
                    case FrmCompany.NewItemEdit:
                        {
                            this.Text = "Item: Edit";
                            if (!DBNull.Value.Equals(row[0]))
                            {
                                txtItemDescription.Text = row["Item"].ToString();
                                cmbUnit.SelectedItem = row["Unit"].ToString();
                                comboBox1.SelectedItem = row["HSN_Code"].ToString();
                            }
                        }
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                txtHSNDesc.Text = lstHSNDesc[comboBox1.SelectedIndex];
            }
        }

        private void RefreshHSN()
        {
            StringBuilder sb = new StringBuilder();
            //Fill combobox of HSNCodes
            sb.Append("SELECT id, ");
            sb.Append("hsnCode, ");
            sb.Append("[desc] ");
            sb.Append("FROM HsnTax ");
            sb.Append("ORDER BY hsnCode;");
            AIO.command = sb.ToString();
            var dt1 = A1.dataload();
            comboBox1.Items.Clear();
            HSNId.Clear();
            lstHSNDesc.Clear();
            foreach (DataRow row in dt1.Rows)
            {
                comboBox1.Items.Add(row["hsnCode"].ToString());
                HSNId.Add(Convert.ToInt64(row["id"].ToString()));
                lstHSNDesc.Add(row["desc"].ToString());
            }
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnHSNAdd_Click(object sender, EventArgs e)
        {
            frmHsnTax fr = new frmHsnTax();
            fr.StartPosition = FormStartPosition.CenterParent;
            fr.Stat = FrmCompany.HSNAdd;
            fr.ShowDialog();
            RefreshHSN();
            comboBox1.SelectedItem = comboBox1.Text;
            if (comboBox1.SelectedIndex < 0)
                comboBox1.Text = "";
        }

    
    }
}
