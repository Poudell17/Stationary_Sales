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
    public partial class PURCHASE : Form
    {
        public PURCHASE()
        {
            InitializeComponent();
        }                                       /*Data Source=Server Name,catalog=DatabaseName */
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True;");
        
        private void PurchaseTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String PH_Id = PurchaseTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            String PH_Date = PurchaseTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            String PH_Rate = PurchaseTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            String PH_Supplierid = PurchaseTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            String PH_Qty = PurchaseTable.Rows[e.RowIndex].Cells[4].Value.ToString();
            String PH_Purchaseid = PurchaseTable.Rows[e.RowIndex].Cells[5].Value.ToString();


            txtProductid.Text = PH_Id;
            picDate.Text = PH_Date;
            txtQuantity.Text = PH_Qty;
            txtRate.Text = PH_Rate;
            cbxsupplier.Text = PH_Supplierid;
            txtPurchaseid.Text = PH_Purchaseid;
        }
        public void dataload()
        {
            conn.Open();
            string query = "execute dbo.PurchaseTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PurchaseTable.DataSource = dt;
            conn.Close();
        }
        public void txtbox_Clear()
        {
            txtProductid.Text = "";
            picDate.Text = "";
            txtQuantity.Text = "";
            txtRate.Text = "";
            txtPurchaseid.Text = "";
            cbxsupplier.Text = "";
            picsearch.Text = "";
        }
        private void PURCHASE_Load(object sender, EventArgs e)
        {
            dataload();
            productcmbx();
            suppliercmbx();
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER C = new CUSTOMER();
            C.Show();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form M = new Main_Form();
            M.Show();
        }

        private void pRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRODUCT P = new PRODUCT();
            P.Show();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SUPPLIER S = new SUPPLIER();
            S.Show();
        }

        private void sALESREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SALES_REPORT SE = new SALES_REPORT();
            SE.Show();
        }


        public void productcmbx()
        {
            conn.Open();
            string query = "select Product_Id,Product_Name from Product ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtProductid.DataSource = dt;
            txtProductid.DisplayMember = "Product_Name";
            txtProductid.ValueMember = "Product_Id";
            conn.Close();
        }
        public void suppliercmbx()
        {
            conn.Open();
            string query = "select Supplier_Id,Supplier_Name from Supplier ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            cbxsupplier.DataSource = ds;
            cbxsupplier.DisplayMember = "Supplier_Name";
            cbxsupplier.ValueMember = "Supplier_Id";
            conn.Close();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductid.Text == "") { MessageBox.Show("Please Select Product Name"); }
            else if (txtQuantity.Text == "") { MessageBox.Show("Please Enter Quantity"); }
            else if (txtRate.Text == "two") { MessageBox.Show("Please Enter Rate in number"); }
            else if (picDate.Text == "") { MessageBox.Show("Please Enter Date"); }
            else if (cbxsupplier.Text == "") { MessageBox.Show("Please Select Supplier"); }
            else
            {

                conn.Open();
                String query = "execute dbo.purchaseinput '" + txtProductid.SelectedValue + "','" + picDate.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + cbxsupplier.SelectedValue + "' ";
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
                String query = "execute dbo.purchasedelet '" + txtPurchaseid.Text + "' ";
              //  MessageBox.Show(query); display all the data with query
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Purchased Detail Delete sucessfully!!");
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
            String query = "execute dbo.purchaseupdate '" + txtProductid.SelectedValue + "','" + picDate.Text + "','" + txtQuantity.Text + "','" + txtRate.Text + "','" + cbxsupplier.SelectedValue + "','" + txtPurchaseid.Text + "'  ";
            MessageBox.Show(query);
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Purchased Detail Update Sucessfully!!!");
            conn.Close();

            txtbox_Clear();
            dataload();

        }

        private void picsearch_ValueChanged(object sender, EventArgs e)
        {
            if (picsearch.Text == "")
            {
                dataload();
            }
            else
            {
                //select *from table_name where field_name = datetimepicker_name
                string query = "execute dbo.datesearch '" + picsearch.Value.ToString() + "' ";
                SqlDataAdapter Sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                PurchaseTable.DataSource = dt;
                conn.Close();
                
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            chNew.Checked = false;
            txtbox_Clear();
            dataload();
        }

        private void chNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chNew.Checked == true)
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


    }
}
