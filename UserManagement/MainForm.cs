using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.DirectoryServices.AccountManagement;

namespace UserManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            refresh_user_list();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Globals.refreshStudentsGroup();
            refresh_user_list();
        }

        private void refresh_user_list()
        {
            listView1.Items.Clear();
            foreach (Principal member in Globals.studentsGroup.Members)
                listView1.Items.Add(new ListViewItem(new string[] { member.Name, member.DisplayName, member.Description }));
        }

        private void deleteMySqlUser(string username)
        {
            string query = string.Format(@"DROP USER IF EXISTS `{0}`@`%`;", username);
            string command = string.Format("/C mysql -uroot -e \"{0}\"", query);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = string.Format("/C {0} -uroot -e \"{1}\"", Globals.mysqlFile, query);
            process.StartInfo = startInfo;
            process.Start();
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select the user you want to delete.", "Select Users");
                return;
            }
            DialogResult result = MessageBox.Show("Do you want to delete the selected users?", "Are You Shore?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                statusbarProgressBar.Maximum = listView1.CheckedItems.Count;
                statusbarProgressBar.Value = 0;
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Checked)
                    {
                        UserPrincipal user = UserPrincipal.FindByIdentity(Globals.context, item.Text);
                        string path = string.Format("{0}\\{1}\\{2}", Globals.wwwRoot, Globals.studentsGroupName, user.Name);
                        if (Directory.Exists(path)) Directory.Delete(path, true);
                        deleteMySqlUser(user.Name);
                        user.Delete();
                        statusbarProgressBar.Value++;
                    }
                }
                Globals.refreshStudentsGroup();
                refresh_user_list();
            }
        }

        private void newButton_ButtonClick(object sender, EventArgs e)
        {
            newButton.DropDown.SetBounds(this.Right, this.Left, 100, 100);
            newButton.DropDown.Show();
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUsersListForm addUserForm = new NewUsersListForm();
            addUserForm.UserSource = UserSource.File;
            addUserForm.ShowDialog(this);
            refresh_user_list();
        }

        private void usingPrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUsersListForm addUserForm = new NewUsersListForm();
            addUserForm.UserSource = UserSource.Batch;
            addUserForm.ShowDialog(this);
            refresh_user_list();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
        }

        private void setPasswordButton_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select the user(s).", "Select Users");
            }
            else
            {
                NewPasswordForm form = new NewPasswordForm();
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    statusbarLabel.Text = "Setting Passwords:";
                    statusbarProgressBar.Maximum = listView1.CheckedItems.Count;
                    statusbarProgressBar.Value = 0;
                    if (form.randomized)
                    {
                        Random rnd = new Random();
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        dialog.Filter = "CSV (*.csv)|csv";
                        dialog.FileName = "password.csv";
                        dialog.DefaultExt = "csv";
                        dialog.AddExtension = true;
                        dialog.ShowDialog();
                        StreamWriter stream = new StreamWriter(dialog.FileName);
                        foreach (ListViewItem item in listView1.CheckedItems)
                        {
                            string newpass = rnd.Next(1000, 9999).ToString();

                            UserPrincipal user = UserPrincipal.FindByIdentity(Globals.context, item.Text);
                            user.SetPassword(newpass);
                            user.Save();

                            stream.WriteLine("{0},{1},{2}", user.Name, user.DisplayName, newpass);
                            statusbarProgressBar.Value++;
                        }
                        stream.Close();
                    }
                    else
                    {
                        foreach (ListViewItem item in listView1.CheckedItems)
                        {
                            UserPrincipal user = UserPrincipal.FindByIdentity(Globals.context, item.Text);
                            user.SetPassword(form.password);
                            user.Save();
                            statusbarProgressBar.Value++;
                        }
                    }
                    //todo: set mysql password
                }
            }
        }
    }
}
