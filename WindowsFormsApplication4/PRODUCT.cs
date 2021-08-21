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
    public partial class PRODUCT : Form
    {
        public PRODUCT()
        {
            InitializeComponent();
        }                                       /*Data Source=Server Name,catalog=DatabaseName */
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True;");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            dataload();

        }
        public void dataload()
        {
            conn.Open();
            string query = "Select * from Product";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ProductTable.DataSource = dt;
            conn.Close();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Form M = new Main_Form();
            M.Show();
        }
        public void txtbox_Clear()
        {//clear all field
            txtProductid.Text = "";
            txtProductName.Text = "";
            comSize.Text = "";
            txtBrand.Text = "";
            comUOM.Text = "";
            txtMinStok.Text = "";
            txtSalesPrice.Text = "";

        }

        private void ChkDis_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDis.Checked == true)
            {
                txtbox_Clear();   //to clear textbox
                            
                btnSave.Enabled = true; //enable>btn
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            else { btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
            }
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER C = new CUSTOMER();
            C.Show();
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PURCHASE PR = new PURCHASE();
            PR.Show();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SUPPLIER S = new SUPPLIER();
            S.Show();
        }

        private void ProductTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String P_Id = ProductTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            String P_Name = ProductTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            String P_Size = ProductTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            String P_Brand = ProductTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            String P_UOM = ProductTable.Rows[e.RowIndex].Cells[4].Value.ToString();
            String P_MinStok = ProductTable.Rows[e.RowIndex].Cells[5].Value.ToString();
            String P_Salesprice = ProductTable.Rows[e.RowIndex].Cells[6].Value.ToString();


            txtProductid.Text = P_Id;
            txtProductName.Text = P_Name;
            comSize.Text = P_Size;
            txtBrand.Text = P_Brand;
            comUOM.Text = P_UOM;
            txtMinStok.Text = P_MinStok;
            txtSalesPrice.Text = P_Salesprice;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "") { MessageBox.Show("Please Enter Product Name"); }
            else if (comSize.Text == "") { MessageBox.Show("Please select Size"); }
            else if (txtBrand.Text == "") { MessageBox.Show("Please Enter Brand"); }
            else if (comUOM.Text == "") { MessageBox.Show("Please Enter UOM"); }
            else if (txtMinStok.Text == "") { MessageBox.Show("Please Enter Stock"); }
            else if (txtSalesPrice.Text == "") { MessageBox.Show("Please Enter SalesPrice"); }
            else
            {

                conn.Open();
                String query = "execute dbo.productinsert '" + txtProductName.Text + "','" + comSize.Text + "','" + txtBrand.Text + "','" + comUOM.Text + "','" + txtMinStok.Text + "','" + txtSalesPrice.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data Inserted!!!!!");
                conn.Close();
                txtbox_Clear();
            }

            dataload();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            String query = "execute dbo.productupdate '"+txtProductName.Text+"','"+comSize.Text+"','"+txtBrand.Text+"','"+comUOM.Text+"','"+txtMinStok.Text+"','"+txtSalesPrice.Text+"','"+txtProductid.Text+"'";
            MessageBox.Show(query);
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Data Updated Sucessfully!!!");
            conn.Close();

            txtbox_Clear();
            dataload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected row..", "Important",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                conn.Open();
                String query = "execute dbo.productdelete '" + txtProductid.Text + "' ";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                dataload();
            }
            else
            {

                string query = "select * from Product where Product_Name LIKE '" + txtSearch.Text.ToString() + "%' ";
                SqlDataAdapter Sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                ProductTable.DataSource = dt;
                conn.Close();
            }
        }


    }
}
