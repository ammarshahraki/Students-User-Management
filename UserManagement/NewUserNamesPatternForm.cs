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
    public partial class UserNamesPatternDialog : Form
    {
        public enum Result { OK, Cancel }

        private Result _result = Result.Cancel;
        private int _count;

        public Result result { get { return _result; } }
        public string usernamePrefix { get { return prefixTextBox.Text; } }
        public string userDescription { 
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }
        public int userNoStart 
        { 
            get { return int.Parse(fromTextBox.Text); }
            set { fromTextBox.Text = value.ToString(); }
        }
        public int userNoEnd { get { return int.Parse(toTextBox.Text); } }
        public int userCount
        {
            set 
            {
                _count = value;
                toTextBox.Enabled = false;
                fromTextBox_TextChanged(null, null);
            }
        }

        public UserNamesPatternDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this._result = Result.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this._result = Result.Cancel;
            this.Close();
        }

        private void fromTextBox_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (toTextBox.Enabled == false && int.TryParse(fromTextBox.Text, out n))
                toTextBox.Text = (n + _count - 1).ToString();
        }

    }
}
