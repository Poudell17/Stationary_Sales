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
    public partial class LOGIN : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q5OTVD7;Initial Catalog=Stationary_Sales;Integrated Security=True");

        public LOGIN()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             SqlCommand sqlcmd = new SqlCommand("Authenticateuser", conn);

            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
            sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            sqlcmd.Parameters.Add("@mesg", SqlDbType.VarChar, 200);
            sqlcmd.Parameters["@mesg"].Direction = ParameterDirection.Output;

            conn.Open();
            var res = sqlcmd.ExecuteNonQuery();
            String status = sqlcmd.Parameters["@mesg"].Value.ToString();

            if (status == "Logged in Successfully")
            {
                label3.Text = status;
                this.Hide();
                Main_Form M = new Main_Form();
                M.Show();
               
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = status;
            }
            conn.Close();
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }



    }
}
