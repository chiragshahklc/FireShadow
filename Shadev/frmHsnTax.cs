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
    public partial class frmHsnTax : Form
    {
        AIO A1;
        public FrmCompany Stat { get; set; }
        static int TempId = -1;
        public frmHsnTax()
        {
            InitializeComponent();
            A1 = new AIO();
            //dgvHsn.ReadOnly = true;
            //dgvHsn.AllowUserToAddRows = false;
            //dgvHsn.AllowUserToDeleteRows = false;
            //dgvHsn.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnSave.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                txtCGST.Clear();
                txtHsnCode.Clear();
                txtIGST.Clear();
                txtSGST.Clear();
                rtbDesc.Clear();
                //btnDelete.Enabled = false;
                //btnUpdate.Enabled = false;
                //btnDelete.Enabled = false;
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (Stat)
            {
                case FrmCompany.HSNAdd:
                    {

                    }
                    break;
                case FrmCompany.HSNEdit:
                    {

                    }
                    break;
                default:
                    break;
            }

            //try
            //{
            //    if (!string.IsNullOrWhiteSpace(txtCGST.Text) || !string.IsNullOrWhiteSpace(txtHsnCode.Text) || !string.IsNullOrWhiteSpace(txtIGST.Text) || !string.IsNullOrWhiteSpace(txtSGST.Text))
            //    {
            //        AIO.command = "INSERT INTO hsnTax(hsnCode,cgst,sgst,igst,Desc) VALUES(" + txtHsnCode.Text + "," + txtCGST.Text + " , " + txtSGST.Text + "," + txtIGST.Text + "," + rtbDesc.Text + ")";
            //        A1.cmdexe();
            //        MessageBox.Show("Item Inserted", "FireShadow", MessageBoxButtons.OK);

            //        //btnDelete.Enabled = true;
            //        //btnUpdate.Enabled = true;
            //        //btnDelete.Enabled = true;
            //        btnSave.Enabled = false;
            //        DataRefresh();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Blank is Not Allow", "FireShadow", MessageBoxButtons.OK);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCGST.Text) || !string.IsNullOrWhiteSpace(txtHsnCode.Text) || !string.IsNullOrWhiteSpace(txtIGST.Text) || !string.IsNullOrWhiteSpace(txtSGST.Text))
                {
                    if (TempId != -1)
                    {
                        AIO.command = "UPDATE hsnTax SET hsnCode = " + txtHsnCode.Text + ",cgst = " + txtCGST.Text + " , sgst = " + txtSGST.Text + ", igst = " + txtIGST.Text + ",Desc = " + rtbDesc.Text + " WHERE id = " + TempId + " ";
                        A1.cmdexe();
                        MessageBox.Show("Item Updated", "FireShadow", MessageBoxButtons.OK);
                        DataRefresh();
                    }
                    else
                    {
                        MessageBox.Show("Select Any Value Please", "FireShadow", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    MessageBox.Show("Blank is Not Allow", "FireShadow", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TempId != -1)
                {
                    AIO.command = "DELETE FROM hsnTax WHERE id = " + TempId + "";
                    A1.cmdexe();
                    MessageBox.Show("Item Deleted", "FireShadow", MessageBoxButtons.OK);
                    DataRefresh();
                }
                else
                {
                    MessageBox.Show("Select Any Value Please", "FireShadow", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void DataRefresh()
        {
            try
            {
                AIO.command = "SELECT id,hsnCode as HSN_Code,sgst as SGST,cgst as CGST,igst as IGST ,Desc as Description FROM hsnTax";
                var v1 = A1.dataload();
                if (v1 == null)
                {
                    //dgvHsn.DataSource = v1;
                    //dgvHsn.Columns["id"].Visible = false;
                }
                txtCGST.Clear();
                txtHsnCode.Clear();
                txtIGST.Clear();
                txtSGST.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvHsn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //TempId = Convert.ToInt32(dgvHsn.SelectedRows[0].Cells["id"].Value.ToString());
                //txtCGST.Text = dgvHsn.SelectedRows[0].Cells["CGST"].Value.ToString();
                //txtHsnCode.Text = dgvHsn.SelectedRows[0].Cells["HSN_Code"].Value.ToString();
                //txtIGST.Text = dgvHsn.SelectedRows[0].Cells["IGST"].Value.ToString();
                //txtSGST.Text = dgvHsn.SelectedRows[0].Cells["SGST"].Value.ToString();
                //rtbDesc.Text = dgvHsn.SelectedRows[0].Cells["Description"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmHsnTax_Load(object sender, EventArgs e)
        {
            try
            {
                DataRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
