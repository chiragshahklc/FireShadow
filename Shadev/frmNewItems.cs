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
    public partial class frmNewItems : Form
    {

        static int TempId = -1;
        AIO A1;
        List<long> UnitId = new List<long>();

        public frmNewItems()
        {
            InitializeComponent();
            A1 = new AIO();
            dgvItem.AllowUserToAddRows = false;
            dgvItem.AllowUserToDeleteRows = false;
            dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItem.ReadOnly = true;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtItemDescription.Text) || cmbUnit.SelectedIndex != 0)
                {
                    AIO.command = "INSERT into Items(itemDesc,hsnId,oid) VALUES('" + txtItemDescription.Text + "',," + UnitId[cmbUnit.SelectedIndex] + ")";
                    A1.cmdexe();
                    MessageBox.Show("Item Inserted", "FireShadow", MessageBoxButtons.OK);
                    DataRefresh();
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtItemDescription.Text) || cmbUnit.SelectedIndex != 0)
                {
                    if (TempId != -1)
                    {
                        AIO.command = " Update Items SET itemDesc = '" + txtItemDescription.Text + "',hsnId = " + txtItemDescription.Text + ",oid = " + UnitId[cmbUnit.SelectedIndex] + " WHERE id = " + TempId + " ";
                        A1.cmdexe();
                        MessageBox.Show("Item Inserted", "FireShadow", MessageBoxButtons.OK);
                        DataRefresh();
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
                    AIO.command = "DELETE FROM Items Where id = " + TempId + "";
                    A1.cmdexe();
                    MessageBox.Show("Item Inserted", "FireShadow", MessageBoxButtons.OK);
                    DataRefresh();
                }
                else
                {
                    MessageBox.Show("Please Select any Data", "Fire Shadow", MessageBoxButtons.OK);
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
                AIO.command = "SELECT id,itemDesc,hsnId,oid FROM Items";
                var v1 = A1.dataload();
                if (v1 == null)
                {
                    dgvItem.DataSource = v1;
                    dgvItem.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
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
                DataRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TempId = Convert.ToInt32(dgvItem.SelectedRows[0].Cells["id"].Value.ToString());
                txtItemDescription.Text = dgvItem.SelectedRows[0].Cells["itemDesc"].ToString();
                cmbUnit.SelectedIndex = Convert.ToInt32(dgvItem.SelectedRows[0].Cells["oid"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
