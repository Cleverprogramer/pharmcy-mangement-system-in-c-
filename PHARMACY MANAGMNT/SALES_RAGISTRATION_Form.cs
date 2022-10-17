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
    public partial class SALES_RAGISTRATION_Form : Form
    {
        SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public SALES_RAGISTRATION_Form()
        {
            InitializeComponent();
            displaydata();
        }
        private void displaydata()
        {
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("select * from SALES", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void SALES_RAGISTRATION_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox2.Text == "")
            {
                MessageBox.Show("FADLAN QOR MAGACA WA MUHIIM", "BUUXI MEESHA BANAAN");
            }
            else
                cmd = new SqlCommand("insert into SALES(name,drugs,quantity,price,total,discownt,[amount due],payment,balance,sales_date)values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@1", textBox2.Text);
            cmd.Parameters.AddWithValue("@2", textBox3.Text);
            cmd.Parameters.AddWithValue("@3", textBox4.Text);
            cmd.Parameters.AddWithValue("@4", textBox5.Text);
            cmd.Parameters.AddWithValue("@5", textBox10.Text);
            cmd.Parameters.AddWithValue("@6", textBox9.Text);
            cmd.Parameters.AddWithValue("@7", textBox8.Text);
            cmd.Parameters.AddWithValue("@8", textBox7.Text);
            cmd.Parameters.AddWithValue("@9", textBox6.Text);
            cmd.Parameters.AddWithValue("@10", dateTimePicker1.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data has been saved");
            displaydata();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
              if (textBox1.Text == "")
            {
                MessageBox.Show(" FADLAN DOORO XOGTA AAD UPDATING GAREENEESO...", "SOO DOORAO....");
            }
            else
            {
                SqlCommand cmdupdate = new SqlCommand("update SALES set name='" + textBox2.Text + "',drugs='" + textBox3.Text + "',quantity='" + textBox4.Text + "',price='" + textBox5.Text + "',total='" + textBox10.Text + "',discownt='" + textBox9.Text + "',[amount due]='" + textBox8.Text + "',payment='" + textBox7.Text + "',balance='" + textBox6.Text + "',sales_date='" + dateTimePicker1.Value + "'where Sales_id=" + textBox1.Text + "", con);


                con.Open();
                cmdupdate.ExecuteNonQuery();
                MessageBox.Show("date has been update", "updating record");
                displaydata();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
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
                    SqlCommand cmdel = new SqlCommand("delete from SALES where Sales_id=" + textBox1.Text + "", con);
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
                    textBox10.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";


                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Sales_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["drugs"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["price"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["total"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["discownt"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["amount due"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["payment"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["balance"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["sales_date"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            adapter = new SqlDataAdapter("select * from SALES where ( name like '" + textBox11.Text + "%')or (Sales_id like'" + textBox11.Text + "%')", con);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        }
    }



