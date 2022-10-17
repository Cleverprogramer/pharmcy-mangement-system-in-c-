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
    public partial class MAIN_Form : Form
    {
        public MAIN_Form()
        {
            InitializeComponent();
        }

        private void pATEINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NEW_PATIENT_REGISTRATION_Form().Show();
        }

        private void MAIN_Form_Load(object sender, EventArgs e)
        {

        }

        private void mEDICNEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MEDICINE_RAGISTTATION_Form().Show();
        }

        private void lABORATORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LABORATORY_REGISTRATION_Form().Show();
        }

        private void sALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SALES_RAGISTRATION_Form().Show();
        }

        private void eMPLOYEEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EMPALOYEE_RAGISTRATION_Form().Show();
        }

        private void uSERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new USER_RAGISTRATION_Form().Show();
        }

        private void bACKUPTESTOREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BACKUP_AND_RESTORE_Form().Show();
        }

        private void pATEINTREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PATIENT_REPORTS_Form().Show();
        }

        private void mEDICNEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MEDICINE_REPORT_Form().Show();
        }

        private void lABORATORYREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LABORATORY_REPORT_Form().Show();
        }

        private void sALESREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SALES_REPORTY_Form().Show();
        }

        private void uSERSREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new USERS_REPORT_Form().Show();
        }

        private void eMPLOYEEREPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EMPLOYEE_REPORT_Form().Show();
        }

        private void sHUTDOWNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("MA HUBTAA INAD XIDHO","close application",MessageBoxButtons.YesNo)==DialogResult.Yes)
            { this.Close();
            }
             
                
            
           
        }

        private void wORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void cALCULATORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pIRNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EXCEL.EXE");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
