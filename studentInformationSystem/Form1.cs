using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentInformationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void txt_userName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_userName.Text))
            {
                e.Cancel = true;
                txt_userName.Focus();
                errorProvider1.SetError(txt_userName, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt_userName, "");
            }
        }

        private void txt_password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                e.Cancel = true;
                txt_password.Focus();
                errorProvider2.SetError(txt_password, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txt_password, "");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            } 
        }
    }
}
