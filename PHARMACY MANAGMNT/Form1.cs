using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHARMACY_MANAGMNT
{
    public partial class Form1 : Form
    {
        int valuep = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            valuep += 1;
            bunifuCircleProgressbar1.Value = valuep;
            if (bunifuCircleProgressbar1.Value == 100)
            {
                bunifuCircleProgressbar1.Value = 0;
                timer1.Stop();
               // MessageBox.Show("value is 100","info",MessageBoxButtons.OK);
                this.timer1.Stop();
                timer1.Enabled = false;
                LOGING_FORM form = new LOGING_FORM();
                form.Show();
                this.Hide();
            }
            
          
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
