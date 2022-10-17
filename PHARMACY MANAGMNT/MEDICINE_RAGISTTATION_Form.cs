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
    public partial class MEDICINE_RAGISTTATION_Form : Form
    {
        SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public MEDICINE_RAGISTTATION_Form()
        {
            InitializeComponent();
            displaydata();
        }
        private void displaydata()
        {
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("select * from medicine_registration4", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void MEDICINE_RAGISTTATION_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("FADLAN QOR MAGACA WA MUHIIM", "BUUXI MEESHA BANAAN");
            }
            else
                cmd = new SqlCommand("insert into medicine_registration4 (name_of_medicine,type_of_medicine,No_of_tablets,Location_of_tablets,issued_date,Exp_date,side_effect,uses_of_medicine,sales_price)values(@1,@2,@3,@4,@5,@6,@7,@8,@9)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@1", textBox2.Text);
            cmd.Parameters.AddWithValue("@2", textBox3.Text);
            cmd.Parameters.AddWithValue("@3", textBox4.Text);
            cmd.Parameters.AddWithValue("@4", textBox5.Text);
            cmd.Parameters.AddWithValue("@5", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@6", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@7", textBox6.Text);
            cmd.Parameters.AddWithValue("@8", textBox8.Text);
            cmd.Parameters.AddWithValue("@9", textBox7.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data has been saved");
            displaydata();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Reference_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["name_of_medicine"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["type_of_medicine"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["No_of_tablets"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Location_of_tablets"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["issued_date"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["Exp_date"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["side_effect"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["uses_of_medicine"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["sales_price"].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(" FADLAN DOORO XOGTA AAD UPDATING GAREENEESO...", "SOO DOORAO....");
            }
            else
            {
                SqlCommand cmdupdate = new SqlCommand("update medicine_registration4 set name_of_medicine='" + textBox2.Text + "',type_of_medicine='" + textBox3.Text + "',No_of_tablets='" + textBox4.Text + "',Location_of_tablets='" + textBox5.Text + "',issued_date='" + dateTimePicker1.Value + "',Exp_date='" + dateTimePicker2.Value + "',side_effect='" + textBox6.Text + "',uses_of_medicine='" + textBox8.Text + "',sales_price='" + textBox7.Text + "' where Reference_id=" + textBox1.Text + "", con);
                con.Open();
                cmdupdate.ExecuteNonQuery();
                MessageBox.Show("date has been update", "updating record");
                displaydata();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                con.Close();

            }
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
                    SqlCommand cmdel = new SqlCommand("delete from medicine_registration4 where Reference_id=" + textBox1.Text + "", con);
                    con.Open();
                    cmdel.ExecuteNonQuery();
                    MessageBox.Show("data has been deleted");
                    displaydata();
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from medicine_registration4 where (name_of_medicine like '" + textBox9.Text + "%')or (Reference_id like'" + textBox9.Text + "%')", con);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
