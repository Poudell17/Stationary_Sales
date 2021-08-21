using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class SALES_REPORT : Form
    {
        public SALES_REPORT()
        {
            InitializeComponent();
        }                                       /*Data Source=Server Name,catalog=DatabaseName */
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True;");

        private void SALES_REPORT_Load(object sender, EventArgs e)
        {
            txtbox_Clear();
            dataload();
            cmbxdata1();
            cmbxdata2();
        }
        public void dataload()
        {
            conn.Open();
            string query = "execute dbo.SalesTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SalesTable.DataSource = dt;
            conn.Close();
        }
        public void txtbox_Clear()
        {
            txtSalesid.Text = "";
            comproduct.Text = "";
            pkDate.Text = "";
            txtQty.Text = "";
            Comcustomer.Text = "";
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form M = new Main_Form();
            M.Show();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SUPPLIER S = new SUPPLIER();
            S.Show();
        }

        private void pRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRODUCT P = new PRODUCT();
            P.Show();
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PURCHASE PR = new PURCHASE();
            PR.Show();
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER C = new CUSTOMER();
            C.Show();
        }

        private void SalesTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String SA_Id = SalesTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            String SA_prid = SalesTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            String SA_Date = SalesTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            String SA_Qty = SalesTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            String SA_Cusid = SalesTable.Rows[e.RowIndex].Cells[4].Value.ToString();


            txtSalesid.Text = SA_Id;
            comproduct.Text = SA_prid;
            pkDate.Text = SA_Date;
            txtQty.Text = SA_Qty;
            Comcustomer.Text = SA_Cusid;
            
        }
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void cmbxdata1()
        {
            conn.Open();
            string query = "select Customer_Id,Customer_Name from Customer ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Comcustomer.DisplayMember = "Customer_Name";
            Comcustomer.ValueMember = "Customer_Id";
            Comcustomer.DataSource = dt;
            conn.Close();

        }
        public void cmbxdata2()
        {
            conn.Open();
            string query = "select Product_Id,Product_Name from Product ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comproduct.DisplayMember = "Product_Name";
            comproduct.ValueMember = "Product_Id";
            comproduct.DataSource = dt;
            conn.Close();

        }

        private void chkNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNew.Checked == true)
            {
                txtbox_Clear();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                txtbox_Clear();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comproduct.Text == "") { MessageBox.Show("Please Select Product Name"); }
            else if (Comcustomer.Text == "") { MessageBox.Show("Please Select Customer Name"); }
            else if (txtQty.Text == "") { MessageBox.Show("Please Enter Quantity"); }
            else if (pkDate.Text == "") { MessageBox.Show("Please Enter Date"); }
            else
            {

                conn.Open();
                String query = "execute dbo.salesinsert '" + comproduct.SelectedValue + "','" + pkDate.Text+ "','" + txtQty.Text + "','" + Comcustomer.SelectedValue + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Sucessfully!!!!!");
                conn.Close();
                txtbox_Clear();
            }

            dataload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected row..", "Important",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                conn.Open();
                String query = "execute dbo.salesdelete '" + txtSalesid.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data Deleted sucessfully!!");
                conn.Close();

                txtbox_Clear();   //to clear textbox text.
                dataload();
            }
            else
            {
                dataload();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            String query = "execute dbo.salesupdate '" + comproduct.SelectedValue + "','" + pkDate.Text + "','" + txtQty.Text + "','" + Comcustomer.SelectedValue + "','" + txtSalesid.Text + "'  ";
            MessageBox.Show(query);
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Purchased Detail Update Sucessfully!!!");
            conn.Close();

            txtbox_Clear();
            dataload();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            //chkNew.Checked = false;
            txtbox_Clear();
            dataload();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == "")
            {
                dataload();
            }
            else
            {
                //select *from table_name where field_name = datetimepicker_name
                string query = "execute dbo.salesdatesearch '" + dateTimePicker1.Value.ToString() + "' ";
                SqlDataAdapter Sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                SalesTable.DataSource = dt;
                conn.Close();

            }
        }





    }
}
