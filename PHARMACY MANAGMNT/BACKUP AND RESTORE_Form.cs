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
    public partial class BACKUP_AND_RESTORE_Form : Form
    {
        SqlConnection con = new SqlConnection(@"data source=API\SQLEXPRESS;initial catalog=PHARMACY MANAGEMNT SYSTEM1;integrated security=true");
        public BACKUP_AND_RESTORE_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("please enter backup file location", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cmd = "BACKUP DATABASE [" + database + "]TO DISK='" + textBox1.Text + "//" + "database" + "-" + DateTime.Now.ToString("yyyy-mm-dd--hh-mm-ss") + ".bak'";
                con.Open();
                SqlCommand command = new SqlCommand(cmd, con);
                command.ExecuteNonQuery();
                MessageBox.Show("your database has been backed up", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                button2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dlg.FileName;
                button4.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("please enter backup file location", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                con.Open();
                string str1 = string.Format("ALTER database [" + database + "]SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, con);
               

                string str2 = "USE MASTER RESTORE DATABASE[" + database + "]FROM DISK='" + textBox4.Text + "'WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, con);
               

                string str3 = string.Format("ALTER database [" + database + "]SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("your database has been restored", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                button3.Enabled = false;
            }
            try
            {
              

            }
            catch
            {

            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void BACKUP_AND_RESTORE_Form_Load(object sender, EventArgs e)
        {

        }

        private void Database_tools_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}