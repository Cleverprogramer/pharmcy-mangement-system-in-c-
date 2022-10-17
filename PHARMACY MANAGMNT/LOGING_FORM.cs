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

namespace PHARMACY_MANAGMNT
{
    public partial class LOGING_FORM : Form
    {
        SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
        DataSet sda;
        public LOGING_FORM()
        {
            InitializeComponent();
           
        }
        

              
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
            SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from USERS1 where user_name='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new MAIN_Form().Show();

            }
            else
            {
                MessageBox.Show("waa khalad user ku ama password!");
            }

        }

        private void LOGING_FORM_Load(object sender, EventArgs e)
        {

        }
    }
}
