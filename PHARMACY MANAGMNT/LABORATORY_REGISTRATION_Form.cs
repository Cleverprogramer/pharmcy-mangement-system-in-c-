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
    public partial class LABORATORY_REGISTRATION_Form : Form
    {
        SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public LABORATORY_REGISTRATION_Form()
        {
            InitializeComponent();
            displaydata();
        }
        private void displaydata()
        {
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("select * from Labarotry", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void LABORATORY_REGISTRATION_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("FADLAN QOR MAGACA WA MUHIIM", "BUUXI MEESHA BANAAN");
            }
            else
                cmd = new SqlCommand("insert into Labarotry(Patient_name,Lab_info,ward_on,Blood_group,age,date,gender)values(@1,@2,@3,@4,@5,@6,@7)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@1", textBox2.Text);
            cmd.Parameters.AddWithValue("@2", textBox3.Text);
            cmd.Parameters.AddWithValue("@3", textBox4.Text);
            cmd.Parameters.AddWithValue("@4", textBox5.Text);
            cmd.Parameters.AddWithValue("@5", textBox6.Text);
            cmd.Parameters.AddWithValue("@6", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@7", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data has been saved");
            displaydata();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.ResetText();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Patient_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Patient_name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Lab_info"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["ward_on"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Blood_group"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["age"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["date"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["gender"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(" FADLAN DOORO XOGTA AAD UPDATING GAREENEESO...", "SOO DOORAO....");
            }
            else
            {
                SqlCommand cmdupdate = new SqlCommand("update Labarotry set Patient_name='" + textBox2.Text + "',Lab_info='" + textBox3.Text + "',ward_on='" + textBox4.Text + "',Blood_group='" + textBox5.Text + "',age='" + textBox6.Text + "',date='" + dateTimePicker1.Value + "',gender='" + comboBox1.Text + "' where Patient_id=" + textBox1.Text + "", con);
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
                comboBox1.ResetText();
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
                    SqlCommand cmdel = new SqlCommand("delete from Labarotry where patient_id=" + textBox1.Text + "", con);
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
                    comboBox1.ResetText();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
           adapter = new SqlDataAdapter("select * from Labarotry where (Patient_Name like '" + textBox9.Text + "%')or ( patient_id like'" + textBox9.Text + "%')", con);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}