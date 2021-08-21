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
    public partial class CUSTOMER : Form
    {
        public CUSTOMER()
        {
            InitializeComponent();
        }                                       /*Data Source=Server Name,catalog=DatabaseName */
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True;");
        
        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form M = new Main_Form();
            M.Show();
        }
        public void dataload()
        {
            conn.Open();
            string query = "Select * from Customer";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CustomerTable.DataSource = dt;
            conn.Close();
        }
        public void txtbox_Clear()
        {
            txtCustomerid.Text ="";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
        }
        private void CUSTOMER_Load(object sender, EventArgs e)
        {
            dataload();
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

        private void CustomerTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String C_Id = CustomerTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            String C_Name = CustomerTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            String C_Address= CustomerTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            String C_Contact = CustomerTable.Rows[e.RowIndex].Cells[3].Value.ToString();


            txtCustomerid.Text = C_Id;
            txtName.Text = C_Name;
            txtAddress.Text = C_Address;
            txtContact.Text = C_Contact;

        }

        private void sALESREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SALES_REPORT SE = new SALES_REPORT();
            SE.Show();
        }

        private void chk_Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Btn.Checked == true)
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

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "") { MessageBox.Show("Please Enter Your Name"); }
            else if (txtAddress.Text == "") { MessageBox.Show("Please Enter Your Address"); }
            else if (txtContact.Text == "") { MessageBox.Show("Please Enter Your Contact"); }
            else
            {

                conn.Open();
                String query = "execute dbo.customerinput '" + txtName.Text + "','" + txtAddress.Text + "','" + txtContact.Text + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted!!!!!");
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
                String query = "execute dbo.customerdelete '" +  txtCustomerid.Text + "' ";
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
            String query = "execute dbo.customerupdate '" + txtName.Text + "','" + txtAddress.Text + "','" + txtContact.Text + "','" + txtCustomerid.Text + "' ";
            MessageBox.Show(query);
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Data Updated Sucessfully!!!");
            conn.Close();

            txtbox_Clear();
            dataload();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                dataload();
            }
            else
            {

                string query = "select * from Customer where Customer_Name LIKE '" + txtSearch.Text.ToString() + "%' ";
                SqlDataAdapter Sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                CustomerTable.DataSource = dt;
                conn.Close();
            }
        }
    }
}
