using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManagement
{
    public partial class NewPasswordForm : Form
    {
        public NewPasswordForm()
        {
            InitializeComponent();
        }

        public string password
        {
            get { return newPasswordTextBox.Text; }
        }

        public bool randomized 
        {
            get { return randomizedCheckBox.Checked; }
        }

        private void randomizedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            newPasswordTextBox.Enabled = !randomizedCheckBox.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            newPasswordTextBox.Text = newPasswordTextBox.Text.Trim();
            if (randomizedCheckBox.Checked || newPasswordTextBox.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter the new password");
                newPasswordTextBox.Focus();
            }
        }
    }
}
