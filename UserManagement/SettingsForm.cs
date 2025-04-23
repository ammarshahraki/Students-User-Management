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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            wwwRootTextBox.Text = Globals.wwwRoot;
            mysqlFilePathTextBox.Text = Globals.mysqlFile;
            mysqlUserTextBox.Text = Globals.mysqlUser;
            mysqlPasswordTextBox.Text = Globals.mysqlPassword;
            studentsGroupTextBox.Text = Globals.studentsGroupName;
            defualtPasswordTextBox.Text = Globals.defualtPassword;
        }

        private void wwwRootBrowsButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = wwwRootTextBox.Text;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                wwwRootTextBox.Text = dialog.SelectedPath;
        }

        private void mysqlFileBrowsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Mysql Application (mysql.exe)|mysql.exe|Applications (*.exe)|*.exe|All Files (*.*)|*.*";
            dialog.InitialDirectory = mysqlFilePathTextBox.Text.Substring(0, mysqlFilePathTextBox.Text.LastIndexOf('\\'));
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                mysqlFilePathTextBox.Text = dialog.FileName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Globals.wwwRoot = wwwRootTextBox.Text;
            Globals.mysqlFile = mysqlFilePathTextBox.Text;
            Globals.mysqlUser = mysqlUserTextBox.Text;
            Globals.mysqlPassword = mysqlPasswordTextBox.Text;
            Globals.studentsGroupName = studentsGroupTextBox.Text;
            Globals.defualtPassword = defualtPasswordTextBox.Text;
            this.Close();
        }
    }
}
