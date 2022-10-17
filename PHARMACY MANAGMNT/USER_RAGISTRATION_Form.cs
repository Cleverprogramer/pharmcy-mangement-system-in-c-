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
    public partial class USER_RAGISTRATION_Form : Form
    {

        SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public USER_RAGISTRATION_Form()
        {
            InitializeComponent();
            displaydata();
        }
        private void displaydata()
        {
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("select * from USERS1", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void USER_RAGISTRATION_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("FADLAN QOR MAGACA WA MUHIIM", "BUUXI MEESHA BANAAN");
            }
            else
                cmd = new SqlCommand("insert into USERS1 (user_name,password,confirm_password,user_type,secret_question,secret_answer)values(@1,@2,@3,@4,@5,@6)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@1", textBox2.Text);
            cmd.Parameters.AddWithValue("@2", textBox3.Text);
            cmd.Parameters.AddWithValue("@3", textBox4.Text);
            cmd.Parameters.AddWithValue("@4", textBox8.Text);
            cmd.Parameters.AddWithValue("@5", textBox7.Text);
            cmd.Parameters.AddWithValue("@6", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data has been saved");
            displaydata();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("update USERS1 set user_name='" + textBox2.Text + "',password='" + textBox3.Text + "',confirm_password='" + textBox4.Text + "',user_type='" + textBox8.Text + "',secret_question='" + textBox7.Text + "',secret_answer='" + textBox5.Text + "'where User_id=" + textBox1.Text + "", con);
            con.Open();
            cmdupdate.ExecuteNonQuery();
            MessageBox.Show("date has been update", "updating record");
            displaydata();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("FADLAN DOORO XOGTA AAD MASAXAYSO");
            }
            else
            {
                DialogResult d = MessageBox.Show("MAHUBTA INAD DELETE GARAYNAYSO XOGTAN", "DELETE STATEMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (d == DialogResult.Yes)
                {
                    SqlCommand cmdel = new SqlCommand("delete from USERS1 where User_id=" + textBox1.Text + "", con);
                    con.Open();
                    cmdel.ExecuteNonQuery();
                    MessageBox.Show("data has been deleted");
                    displaydata();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox5.Text = "";

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["User_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["user_name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["password"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["confirm_password"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["user_type"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["secret_question"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["secret_answer"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from USERS1 where (user_name like '" + textBox11.Text + "%')or (User_id like'" + textBox11.Text + "%')", con);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
