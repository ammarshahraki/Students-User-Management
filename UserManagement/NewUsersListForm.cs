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
using System.Security.AccessControl;
using System.DirectoryServices.AccountManagement;

namespace UserManagement
{
    public enum UserSource { File, Batch }

    public partial class NewUsersListForm : Form
    {
        private UserSource source = UserSource.File;

        public UserSource UserSource { set { source = value; } }

        public NewUsersListForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            if (this.source == UserManagement.UserSource.File)
                fillGridViewFromFile();
            else if (this.source == UserManagement.UserSource.Batch)
                fillGridViewByPattern();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void fillGridViewFromFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                IEnumerable<string> fileLines = System.IO.File.ReadLines(fileDialog.FileName);
                UserNamesPatternDialog userDialog = new UserNamesPatternDialog();
                userDialog.userNoStart = Globals.studentsGroup.Members.Count() + 1;
                userDialog.userCount = fileLines.Count();
                userDialog.userDescription = fileDialog.SafeFileName.Substring(0,fileDialog.SafeFileName.LastIndexOf('.'));
                userDialog.ShowDialog();
                int userID = userDialog.userNoStart;
                foreach (string line in System.IO.File.ReadLines(fileDialog.FileName))
                    dataGridView1.Rows.Add(
                        string.Format("{0}{1:00}", userDialog.usernamePrefix, userID++),
                        line.Replace('\t', ' '),
                        userDialog.userDescription
                        );
            }
            else
            {
                this.Close();
            }
        }

        private void fillGridViewByPattern()
        {
            UserNamesPatternDialog dialog = new UserNamesPatternDialog();
            dialog.ShowDialog();
            if (dialog.result == UserNamesPatternDialog.Result.Cancel)
                this.Close();
            else
                for(int i=dialog.userNoStart; i<=dialog.userNoEnd; i++)
                    dataGridView1.Rows.Add(string.Format("{0}{1:00}", dialog.usernamePrefix, i), "", dialog.userDescription);
        }

        private UserPrincipal createUser(string username, string fullName, string description)
        {
            UserPrincipal user = new UserPrincipal(Globals.context);
            user.Name = username;
            if (fullName != "") user.DisplayName = fullName;
            if (description != "") user.Description = description;
            user.Enabled = true;
            user.PasswordNeverExpires = true;
            user.SetPassword(Globals.defualtPassword);
            user.Save();
            return user;
        }

        private void createWwwDirectory(UserPrincipal user)
        {
            string path = string.Format("{0}\\{1}\\{2}", Globals.wwwRoot, Globals.studentsGroupName, user.Name);
            Directory.CreateDirectory(path);
            DirectorySecurity security = Directory.GetAccessControl(path);
            security.SetOwner(new System.Security.Principal.NTAccount(user.Name));
            security.SetAccessRule(new FileSystemAccessRule(
                user.Name,
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow
                ));
            Directory.SetAccessControl(path, security);
        }

        private void createMySqlUser(string username, string password)
        {
            string query =
                "DROP USER IF EXISTS `{0}`@`%`;"+
                "CREATE USER `{0}`@`%` IDENTIFIED BY '{1}';"+
                "GRANT USAGE ON *.* TO `{0}`;"+
                "GRANT ALL PRIVILEGES ON `{0}\\_%` . * TO `{0}`@`%`;";

            Globals.mysqlQuery(string.Format(query, username, password));
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            GroupPrincipal rdpUsers = GroupPrincipal.FindByIdentity(Globals.context, "Remote Desktop Users");
            GroupPrincipal users = GroupPrincipal.FindByIdentity(Globals.context, "Users");

            WinAPI.ModifyPrivilege(PrivilegeName.SeRestorePrivilege, true);
            WinAPI.ModifyPrivilege(PrivilegeName.SeTakeOwnershipPrivilege, true);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string username = row.Cells[0].Value.ToString();
                    string fullName = row.Cells[1].Value.ToString();
                    string description = row.Cells[2].Value.ToString();
                    if (username != "")
                    {                        
                        try
                        {
                            UserPrincipal user = createUser(username, fullName, description);
                            createWwwDirectory(user);
                            createMySqlUser(user.Name, Globals.defualtPassword);

                            rdpUsers.Members.Add(user);
                            users.Members.Add(user);
                            Globals.studentsGroup.Members.Add(user);

                        }
                        catch(PrincipalExistsException)
                        {
                            MessageBox.Show(string.Format("User {0} Already Exists.", username));
                        }
                    }
                }
            }
            rdpUsers.Save();
            users.Save();
            Globals.studentsGroup.Save();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
