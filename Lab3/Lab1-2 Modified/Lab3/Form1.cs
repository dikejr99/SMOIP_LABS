using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using System.Management;
using Microsoft.VisualBasic;
namespace Lab3
{
    public partial class Form1 : Form
    {
        public List<User> users = new List<User>();
        int try_counter = 3;
        string sn;
        public Form1()
        {
            InitializeComponent();
        }
        [ System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(StringBuilder pwszKLID);
        private void Form1_Load(object sender, EventArgs e)
        {
            string registry_name = Interaction.InputBox("Please input the name of the undressed registry", "Undressed registry");
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
                foreach (ManagementObject mo in moc)
                {

                    sn = mo["SerialNumber"].ToString();

                }
            StringBuilder keyboard = new StringBuilder(9);
            GetKeyboardLayoutName(keyboard);
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string drives_set = "";
            string program_disk = "";
            foreach (DriveInfo d in allDrives)
            {
                drives_set += d.Name + "_";
                if (d.Name[0] == Directory.GetCurrentDirectory()[0])
                {
                    program_disk = "program installed at disk: " + d.Name + " Amount:" + d.TotalSize;
                }
            }
            string KEY = Environment.UserName + "_" + Environment.MachineName + "_" + Directory.GetCurrentDirectory() + "_" +
            Environment.SystemDirectory + "_" + keyboard + "_" + SystemInformation.PrimaryMonitorSize.Width + "_" + drives_set + "_" + program_disk + sn;

            Microsoft.Win32.RegistryKey key;

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\" + registry_name);
            try
            {
                string mm = key.GetValue("KEY").ToString();
                if (!string.Equals(KEY, mm))
                {
                    key.Close();
                    MessageBox.Show("COPYRIGHTS ERROR!\nuser name: " + Environment.UserName + 
                        "\nComputer name: " + Environment.MachineName + "\nWindows folder: " + Directory.GetCurrentDirectory() +
                        "\nWindows system files folder: " + Environment.SystemDirectory +
                        "\nKeyboard: " + keyboard + "\nScreen width: " + SystemInformation.PrimaryMonitorSize.Width + 
                        "\nSet of drives: " + drives_set+ "\nDisk on which program is installed: " + program_disk);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("COPYRIGHTS ERROR!\nuser name: " + Environment.UserName +
                        "\nComputer name: " + Environment.MachineName + "\nWindows folder: " + Directory.GetCurrentDirectory() +
                        "\nWindows system files folder: " + Environment.SystemDirectory +
                        "\nKeyboard: " + keyboard + "\nScreen width: " + SystemInformation.PrimaryMonitorSize.Width +
                        "\nSet of drives: " + drives_set + "\nDisk on which program is installed: " + program_disk);
                this.Close();
            }
            key.Close();

            if (File.Exists("users.json") && (File.ReadAllText("users.json") != "" && File.ReadAllText("users.json") != "[]"))
            {
                string json = File.ReadAllText("users.json");
                users = JsonSerializer.Deserialize<List<User>>(json);
            }
            else
            {
                FileStream fs = File.Create("users.json");
                User admin = new User();
                admin.username = "ADMIN";
                admin.role = "admin";
                admin.password = ""; //HashPassword("ADMIN");
                
                users.Add(admin);
                fs.Close();

                string jsonString = JsonSerializer.Serialize(users);
                File.WriteAllText("users.json", jsonString);
            }
        }

        private void httpsgithubcomElhAyoubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://github.com/Elh-Ayoub");
            MessageBox.Show("URL copied to Clipboard!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            bool not_found = true;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username field is required!");
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.username == username)
                    {
                        not_found = false;
                        if (try_counter == 0)
                        {
                            MessageBox.Show(try_counter + " attempts left! You cannot log in.");
                        }
                        else if (user.is_blocked)
                        {
                            MessageBox.Show("Your account is blocked!");
                        }
                        else if (PasswordHasher.VerifyPassword(password, user.password) || user.password == "")
                        {
                            MessageBox.Show("Logged in successfully!");
                            if (user.role == "admin")
                            {
                                var f_admin = new AdminMode(user);
                                f_admin.Show();
                                this.Hide();
                            }
                            else
                            {
                                var f_user = new UserMode(user);
                                f_user.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            try_counter--;
                            MessageBox.Show("Password incorrect! " + try_counter + " attempts left.");

                            break;
                        }
                    }
                }
                if (not_found)
                {
                    MessageBox.Show("Username not found!");
                }
            }
        }
    }
}
