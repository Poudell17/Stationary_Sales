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
    public partial class SUPPLIER : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True;");
        public SUPPLIER()
        {
            InitializeComponent();
        }
        public void dataload()
        {
            conn.Open();
            string query = "Select * from supplierview";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SupplierTable.DataSource = dt;
            conn.Close();
        }
        public void txtbox_Clear()
        {
            txtSupplierid.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            txtCreatedOn.Text = "";
            txtCreatedBy.Text = "";

        }
        private void SUPPLIER_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            dataload();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String S_Id = SupplierTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            String S_Name = SupplierTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            String S_Addr = SupplierTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            String S_Con = SupplierTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            String S_CrOn = SupplierTable.Rows[e.RowIndex].Cells[4].Value.ToString();
            String S_CrBy = SupplierTable.Rows[e.RowIndex].Cells[5].Value.ToString();
            


            //set
            txtSupplierid.Text = S_Id;
            txtName.Text = S_Name;
            txtAddress.Text = S_Addr;
            txtContact.Text = S_Con;
            txtCreatedOn.Text = S_CrOn;
            txtCreatedBy.Text = S_CrBy;
            // btninsert.Enabled = false;
          

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text == "") { MessageBox.Show("Please Enter Your Name"); }
            else if (txtAddress.Text == "") { MessageBox.Show("Please Enter Your Address"); }
            else if (txtContact.Text == "") { MessageBox.Show("Please Enter Your Contact"); }
            else if (txtCreatedOn.Text == "") { MessageBox.Show("Please Enter when Created"); }
            else if (txtCreatedBy.Text == "") { MessageBox.Show("Please Enter Who Created"); }
            else
            {

                conn.Open();
                String query = "execute dbo.supplierinput '" + txtName.Text + "','" + txtAddress.Text + "','" + txtContact.Text + "','" + txtCreatedOn.Text + "','" + txtCreatedBy.Text + "'";
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
                String query = "execute dbo.supplierdelet '" + txtSupplierid.Text + "' ";
              //  MessageBox.Show(query);
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
            String query = "execute dbo.supplierupdate '"+txtName.Text+"','"+txtAddress.Text+"','"+txtContact.Text+"','"+txtCreatedOn.Text+"','"+txtCreatedBy.Text+"','"+txtSupplierid.Text+"'";
            MessageBox.Show(query);
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Data updated sucessfully!!!");
            conn.Close();

            txtbox_Clear();
            dataload();

        }

        private void Search_Name_KeyUp(object sender, KeyEventArgs e)
        {
            if (Search_Name.Text == "")
            {
                dataload();
            }
            else
            {

                string query = "select * from Supplier where Supplier_Name LIKE '" + Search_Name.Text.ToString() + "%' ";
                SqlDataAdapter Sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                SupplierTable.DataSource = dt;
                conn.Close();
            }

        }

        private void chkNew_CheckedChanged(object sender, EventArgs e)
        {if (chkNew.Checked == true)
            {
                txtbox_Clear();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled= false;  }
        else {
                txtbox_Clear();
                btnUpdate.Enabled=true;
                btnDelete.Enabled=true;
                btnSave.Enabled = false;}

            
        
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form M=new Main_Form();
            M.Show();

        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER C = new CUSTOMER();
            C.Show();
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

        private void sALESREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SALES_REPORT SE = new SALES_REPORT();
            SE.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void headerclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("ERROR 201.", "Important");
           
        }


    }
}
