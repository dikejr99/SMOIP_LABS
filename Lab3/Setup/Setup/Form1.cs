using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace Setup
{
    public partial class Form1 : Form
    {
        bool isChosen = false;
        string sn;
        byte[] ALL;
        string dir_path = "C:\\Users\\Lenovo\\Desktop\\SMoIP_Labs\\Lab3\\Lab1-2 Modified\\Lab3\\bin\\Debug\\";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //label1.Text = "";
            //ALL = File.ReadAllBytes(dir_path + "Lab3.exe");
            //ALL = ALL.Concat(ALL2).ToArray();
            //string[] A = new string[ALL.Length + 1];

            //A[0] = "byte[] ALL = { ";
            //for (int i = 1; i < A.Length; i++)
            //{
            //    A[i] = "0x" + ALL[i - 1].ToString("x") + ",";
            //}
           // File.WriteAllLines("tat.txt", A);
           // File.WriteAllBytes("Lab3.exe", ALL);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Path selected: " + folderBrowserDialog1.SelectedPath + "\\Lab3";
                isChosen = true;
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(StringBuilder pwszKLID);
        private void Install_Click(object sender, EventArgs e)
        {
            if (isChosen)
            {
                //File.WriteAllBytes(folderBrowserDialog1.SelectedPath + "\\Lab3.exe", ALL);
                install();
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                if (moc.Count != 0)
                    foreach (ManagementObject mo in mc.GetInstances())
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
                    if (d.Name[0] == folderBrowserDialog1.SelectedPath[0])
                    {
                        program_disk = "program installed at disk: " + d.Name + " Amount:" + d.TotalSize;
                    }
                }
                string KEY = Environment.UserName + "_" + Environment.MachineName + "_" + folderBrowserDialog1.SelectedPath + "\\Lab3" + "_" +
                Environment.SystemDirectory + "_" + keyboard + "_" + SystemInformation.PrimaryMonitorSize.Width + "_" + drives_set + "_" + program_disk + sn;
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("El-Haddadi");
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\El-Haddadi", true);
                key.SetValue("KEY", KEY, Microsoft.Win32.RegistryValueKind.String);
                key.Close();
                MessageBox.Show("Installation Success");
            }
            else MessageBox.Show("Intsallation path not selected! Please select one.");
        }

        private void install()
        {
            DirectoryInfo d = new DirectoryInfo(dir_path);
            string path = folderBrowserDialog1.SelectedPath + "\\Lab3\\";
            FileInfo[] Files = d.GetFiles("*.*");
            Directory.CreateDirectory(path);
            foreach (FileInfo file in Files)
            {
                if (file.Name.IndexOf(".xml") > -1) continue;

                byte[] curr_file = File.ReadAllBytes(dir_path + file.Name);
                File.WriteAllBytes(path + file.Name, curr_file);
            }
        }
    }
}