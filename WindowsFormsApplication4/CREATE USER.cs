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
    public partial class CREATE_USER : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True;");
      
        public CREATE_USER()
        {
            InitializeComponent();
        }
        public void dataload()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("execute dbo.Usertable", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public void comborole()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Role_Name,Role_Id from User_Role", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comrole.DisplayMember = "Role_Name";
            comrole.ValueMember = "Role_Id";
            comrole.DataSource = dt;
            conn.Close();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Form M = new Main_Form();
            M.Show();
        }

        private void pRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            PRODUCT P = new PRODUCT();
            P.Show();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SUPPLIER S = new SUPPLIER();
            S.Show();
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            CUSTOMER C = new CUSTOMER();
            C.Show();
        }

        private void sALESREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            SALES_REPORT sr = new SALES_REPORT();
            sr.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            PURCHASE Pr = new PURCHASE();
            Pr.Show();
        }

        private void eXITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CREATE_USER_Load(object sender, EventArgs e)
        {
            dataload();
            comborole();
            comrole.Enabled = false;
            btnrol.Visible = false;
            assignrole();
            comUsername.Visible = false;
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(chkassign.Checked==true){
                dataGridView2.SendToBack();
                comrole.Enabled = true;
                btnrol.Visible = true;
                comUsername.Visible = true;
                txtname.Enabled = false;
                txtpassword.Enabled = false;
                txtemail.Enabled = false;
                chkactive.Enabled = false;
                datecreated.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                comUsername.Visible = false;
                comrole.Enabled = false;
                txtname.Enabled = true;
                txtpassword.Enabled = true;
                txtemail.Enabled = true;
                chkactive.Enabled = true;
                datecreated.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                btnrol.Visible = false;
            }
        }
        public void txtbox_clr()
        {
            txtname.Clear();
            txtpassword.Clear();
            txtemail.Clear();
            txtusername.Clear();
            datecreated.Text = null;

        }
        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "") { MessageBox.Show("Please Enter your Name"); }
            else if (txtemail.Text == "") { MessageBox.Show("Please Enter Your Email"); }
            else if (txtusername.Text == "") { MessageBox.Show("Please Enter Your UserName"); }
            else if (txtpassword.Text == "") { MessageBox.Show("Password Required"); }
            else 
            {
                var b = txtpassword.Text.ToString();
                conn.Open();
                string a = "execute dbo.inputdatauserinfo '"+txtname.Text+"','"+txtemail+"','"+txtusername+"','"+txtpassword+"','"+chkactive.Text+"','"+datecreated.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(a,conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted Sucessfully!!!");
                conn.Close();
                txtbox_clr();
            }
            dataload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String U_Id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String U_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String U_Mail = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String U_UName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //String U_Password = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String U_Isactive = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String U_Crton = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            String U_Rol = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
             
            txtuserid.Text = U_Id;
            txtname.Text = U_Name;
            txtemail.Text = U_Mail;
            txtusername.Text = U_UName;
          //  txtpassword.Text = U_Password;
            chkactive.Text = U_Isactive;
            datecreated.Text = U_Crton;
            comrole.Text = U_Rol;
        }

        private void chkactive_CheckedChanged(object sender, EventArgs e)
        {
            var a=1;
            var b=0;
            if (chkactive.Checked == true) { chkactive.Text = a.ToString(); }
            else { chkactive.Text = b.ToString(); }
        }
        public void assignrole()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select User_Id,UserName from User_Info", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comUsername.DisplayMember = "UserName";
            comUsername.ValueMember = "User_Id";
            comUsername.DataSource = dt;
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected row..", "Important",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                conn.Open();
                string inforoletable = "Delete from Info_Role where User_Id='" + txtuserid.Text + "' ";
                SqlDataAdapter sd = new SqlDataAdapter(inforoletable, conn);
                sd.SelectCommand.ExecuteNonQuery();

                String query = "Delete  from User_Info where (User_Id='" + txtuserid.Text + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();

                MessageBox.Show("User Detail Delete sucessfully!!");
                conn.Close();

                txtbox_clr();   //to clear textbox text.
                dataload();
            }
            else
            {
                dataload();
            }
        }

        private void btnrol_Click(object sender, EventArgs e)
        {
            conn.Open();
            string a = "insert into Info_Role values('" + comUsername.SelectedValue + "','" + comrole.SelectedValue + "',NEWID())";
            SqlDataAdapter sda = new SqlDataAdapter(a, conn);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Assign Sucessfully!!!");
            conn.Close();
            txtbox_clr();
            dataload();   
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text =="")
            {
                DialogResult result = MessageBox.Show("Keep My Previous Password.", "Important",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    conn.Open();//password naphathaune.
                    String query = "execute dbo.userpassword '" + txtuserid.Text + "','" + txtname.Text + "','" + txtemail.Text + "','" + txtusername.Text + "','" + chkactive.Text + "','" + datecreated.Text + "'";
                    MessageBox.Show(query);

                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    sda.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Detail Update Sucessfully!!!");
                    conn.Close();

                    txtbox_clr();
                    dataload();
                }
                else
                {
                    dataload();
                }
            }
            else
            {
                conn.Open();
                String query = "execute dbo.updateusertable '" + txtuserid.Text + "','" + txtname.Text + "','" + txtemail.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + chkactive.Text + "','" + datecreated.Text + "'";
                MessageBox.Show(query);
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Detail Update Sucessfully!!!");
                conn.Close();

                txtbox_clr();
                dataload();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.BringToFront();
            
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.datatable", conn);
            sda.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String U_Id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            String U_Name = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            String U_Mail = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            String U_UName = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            String U_Password = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            String U_Isactive = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            String U_Crton = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            

            txtuserid.Text = U_Id;
            txtname.Text = U_Name;
            txtemail.Text = U_Mail;
            txtusername.Text = U_UName;
            txtpassword.Text = U_Password;
            chkactive.Text = U_Isactive;
            datecreated.Text = U_Crton;
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            dataload();
            txtbox_clr();
            dataGridView1.BringToFront();

        }
        


    }
}
