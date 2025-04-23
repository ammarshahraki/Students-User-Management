using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.IO;
using System.Security.AccessControl;
using System.DirectoryServices.AccountManagement;

namespace UserManagement
{
    static class Globals
    {
        private static PrincipalContext _context = new PrincipalContext(ContextType.Machine);
        private static GroupPrincipal _studentsGroup = null;

        // ------------------------------------------------------------------------------------------------------------
        public static PrincipalContext context
        {
            get { return _context; }
        }

        // ------------------------------------------------------------------------------------------------------------
        public static string wwwRoot
        {
            get { return loadSettings("wwwRoot"); }
            set { saveSettings("wwwRoot", value); }
        }

        // ------------------------------------------------------------------------------------------------------------
        public static string mysqlFile
        {
            get { return loadSettings("mysqlFile"); }
            set { saveSettings("mysqlFile", value); }
        }
        public static string mysqlUser {
            get { return loadSettings("mysqlUser"); }
            set { saveSettings("mysqlUser", value); }
        }
        public static string mysqlPassword {
            get { return loadSettings("mysqlPassword"); }
            set { saveSettings("mysqlPassword", value); }
        }

        // ------------------------------------------------------------------------------------------------------------
        public static void refreshStudentsGroup()
        {
            _studentsGroup = GroupPrincipal.FindByIdentity(Globals.context, Globals.studentsGroupName);
            if (_studentsGroup == null)
            {
                _studentsGroup = new GroupPrincipal(Globals.context);
                _studentsGroup.Name = Globals.studentsGroupName;
                _studentsGroup.Description = "گروه پیش فرض دانش آموزان";
                _studentsGroup.Save();
                setPriviledges();
            }
        }
        public static string studentsGroupName { 
            get { return "Students"; }
            set { saveSettings("studentsGroupName", value); }
        }
        public static GroupPrincipal studentsGroup
        {
            get { if (_studentsGroup == null)refreshStudentsGroup(); return _studentsGroup; }
        }
        public static string defualtPassword
        {
            get { return loadSettings("defualtPassword"); }
            set { saveSettings("defualtPassword", value); }
        }

        // ------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------
        private static string loadSettings(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)
                return ConfigurationManager.AppSettings[key].ToString();
            else
                return Properties.Settings.Default[key].ToString();
        }

        private static void saveSettings(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        // ------------------------------------------------------------------------------------------------------------
        public static void setPriviledges()
        {
            DirectorySecurity security = Directory.GetAccessControl("C:\\");
            security.SetAccessRule(new FileSystemAccessRule(
                Globals.studentsGroup.Name,
                FileSystemRights.Write,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Deny
                ));
            security.SetAccessRule(new FileSystemAccessRule(
                "ALL APPLICATION PACKAGES",
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow
                ));
            Directory.SetAccessControl("C:\\", security);

            string usersWwwRoot = string.Format("{0}\\{1}", Globals.wwwRoot, Globals.studentsGroupName);
            if (!Directory.Exists(usersWwwRoot))
                Directory.CreateDirectory(usersWwwRoot);
            DirectorySecurity security1 = Directory.GetAccessControl(usersWwwRoot);
            security1.SetAccessRule(new FileSystemAccessRule(
                Globals.studentsGroup.Name,
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Deny
                ));
            Directory.SetAccessControl(usersWwwRoot, security1);
        }

        // ------------------------------------------------------------------------------------------------------------
        public static void mysqlQuery(string query)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            if(Globals.mysqlPassword == "")
                startInfo.Arguments = string.Format("/C {0} -u{1} -e \"{2}\"", Globals.mysqlFile, Globals.mysqlUser, query);
            else
                startInfo.Arguments = string.Format("/C {0} -u{1} -p{2} -e \"{3}\"", Globals.mysqlFile, Globals.mysqlUser, Globals.mysqlPassword, query);
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
