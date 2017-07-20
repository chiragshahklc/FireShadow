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

namespace Shadev
{
    public partial class frmPayment : Form
    {
        public double OutAmount { get; set; }
        public int custID { get; set; }
        public int transID { get; set; }
        public string custName { get; set; }
        public FrmCompany Stat { get; set; }
        public DataRow row { get; set; }
        AIO a1 = new AIO();
        public frmPayment()
        {
            try
            {
                InitializeComponent();
                //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbmethod.SelectedIndex == 1)
                {
                    if (string.IsNullOrWhiteSpace(txtAmt.Text) || string.IsNullOrWhiteSpace(txtCheckNo.Text) || cmbPayType.SelectedIndex < 0)
                    {
                        MessageBox.Show("Blank is not Allow", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        double RAmount;
                        RAmount = Convert.ToDouble(txtAmt.Text);
                        OutAmount = OutAmount - RAmount;
                        //MessageBox.Show(OutAmount.ToString());
                        string paydesc = rtbDesc.Text.Replace("'", "''");
                        if (Stat == FrmCompany.PaymentAdd)
                            AIO.command = "insert into Payment(payCustId,payMethod,payType,payCheck,payAmount,payDate,payDesc) Values(" + custID + ",'" + cmbmethod.SelectedItem.ToString() + "','" + cmbPayType.SelectedItem.ToString() + "'," + txtCheckNo.Text + "," + txtAmt.Text + ",'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + paydesc + "')";
                        else if (Stat == FrmCompany.PaymentEdit)
                            AIO.command = "update Payment set payMethod='"+cmbmethod.SelectedItem.ToString()+"',payType='"+cmbPayType.SelectedItem.ToString()+"',payCheck="+txtCheckNo.Text+",payAmount="+txtAmt.Text+",payDate='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"',payDesc='"+rtbDesc.Text+"' where id=" + row["id"].ToString();
                        a1.cmdexe();
                        this.Close();
                    }

                }
                else if (cmbmethod.SelectedIndex == 0)
                {
                    if (string.IsNullOrWhiteSpace(txtAmt.Text) || cmbPayType.SelectedIndex < 0)
                    {
                        MessageBox.Show("Blank is not Allow", "Shadevinfotech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        double RAmount;
                        RAmount = Convert.ToDouble(txtAmt.Text);
                        OutAmount = OutAmount - RAmount;
                        string paydesc = rtbDesc.Text.Replace("'", "''");
                        //MessageBox.Show(OutAmount.ToString());
                        if (Stat == FrmCompany.PaymentAdd)
                            AIO.command = "insert into Payment(payCustId,payMethod,payType,payAmount,payDate,payDesc) Values(" + custID + ",'" + cmbmethod.SelectedItem.ToString() + "','" + cmbPayType.SelectedItem.ToString() + "'," + txtAmt.Text + ",'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + paydesc + "')";
                        else if (Stat == FrmCompany.PaymentEdit)
                            AIO.command = "update Payment set payMethod='" + cmbmethod.SelectedItem.ToString() + "',payType='" + cmbPayType.SelectedItem.ToString() + "',payAmount=" + txtAmt.Text + ",payDate='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',payDesc='" + rtbDesc.Text + "' where id=" + row["id"].ToString();
                        a1.cmdexe();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                if (Stat == FrmCompany.PaymentAdd)
                {
                    txtCustomer.Text = custName;
                    if (Convert.ToInt32(OutAmount) > 0)
                    {
                        textBox1.BackColor = Color.White;
                        textBox1.ForeColor = Color.Green;
                        textBox1.Text = OutAmount.ToString(); ;
                    }
                    else if (Convert.ToInt32(OutAmount) < 0)
                    {
                        textBox1.BackColor = Color.White;
                        textBox1.ForeColor = Color.Red;
                        textBox1.Text = OutAmount.ToString(); ;
                    }
                    else
                    {
                        textBox1.BackColor = Color.White;
                        textBox1.ForeColor = Color.Black;
                        textBox1.Text = OutAmount.ToString();
                    }
                }
                else if (Stat == FrmCompany.PaymentEdit)
                {
                    textBox1.Text = "";
                    txtCustomer.Text = row["Name"].ToString();
                    custName = row["Name"].ToString();
                    cmbmethod.SelectedItem = row["Cash Mode"].ToString();
                    cmbPayType.SelectedItem = row["Payment Type"].ToString();
                    txtCheckNo.Text = row["Cheque No"].ToString();
                    txtAmt.Text = row["Amount"].ToString();
                    rtbDesc.Text = row["Desc"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(row["Date"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbmethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbmethod.SelectedIndex == 1)
                {
                    txtAmt.Enabled = true;
                    txtCheckNo.Enabled = true;
                }
                else
                {
                    txtAmt.Enabled = true;
                    txtCheckNo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
    }
}
