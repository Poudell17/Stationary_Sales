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
    public partial class Main_Form : Form
    {

        public Main_Form()
        {
            InitializeComponent();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SUPPLIER S = new SUPPLIER();
            S.Show();

        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

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

        private void cOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER C = new CUSTOMER();
            C.Show();
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

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            CREATE_USER cd = new CREATE_USER();
            cd.Show();
        }
    }
}
