using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace Lab3
{
    public partial class AdminMode : Form
    {
        User auth;
        public List<User> users = new List<User>();
        DataTable dt = new DataTable();
        DataRow dr;
        public AdminMode(User auth)
        {
            InitializeComponent();
            this.auth = auth;

        }

        private void AdminMode_Load(object sender, EventArgs e)
        {
            usersListPanel.Visible = false;
            dt.Columns.Add("Id");
            dt.Columns.Add("Username");
            dt.Columns.Add("Role");
            dt.Columns.Add("Blocked");
            dt.Columns.Add("Restrictions");
            
        }

        private void httpsgithubcomElhAyoubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("https://github.com/Elh-Ayoub");
            MessageBox.Show("URL copied to Clipboard!!");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.auth = null;
            var f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void UpdatePassword_OnClick(object sender, EventArgs e)
        {
            var f_user = new UserMode(auth);
            f_user.Show();
            this.Hide();
        }
        private void GoBackBtn_OnClick(object sender, EventArgs e)
        {
            usersListPanel.Visible = false;
            welcomePanel.Visible = true;
        }
        private void UserListBtn_OnClick(object sender, EventArgs e)
        {
            usersListPanel.Visible = true;
            welcomePanel.Visible = false;
            dt.Rows.Clear();
            GetUsers();
            DisplayUsers();
        }
        public void DisplayUsers()
        {
            int i = 1;
            foreach(var user in users)
            {
                dr = dt.NewRow();
                dr[0] = i;
                dr[1] = user.username;
                dr[2] = user.role;
                dr[3] = (user.is_blocked) ? ("yes") : ("no");
                dr[4] = (user.disable_restrictions) ? ("disabled") : ("enabled");
                dt.Rows.Add(dr);
                i++;
            }
            UsersDataGrid.DataSource = dt;
            UsersDataGrid.Columns["Id"].ReadOnly = true;
            UsersDataGrid.Rows[0].ReadOnly = true;
        }
        public void GetUsers()
        {
            string json = File.ReadAllText("users.json");
            users = JsonSerializer.Deserialize<List<User>>(json);
        }

        public void SetUsers()
        {
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText("users.json", jsonString);
        }

        private void SaveChanges_OnClick(object sender, EventArgs e)
        {
            List<User> new_users = new List<User>();
            foreach(DataRow row in dt.Rows)
            {                
                if (!string.IsNullOrEmpty(row[1].ToString()) && !usernameExist(new_users, row[1].ToString()))
                {
                    User user;
                    int index = (!string.IsNullOrEmpty(row[0].ToString())) ? int.Parse(row[0].ToString()) : (-1);
                    if (index <= users.Count() && index != -1)
                    {
                        user = users[index - 1];
                        user.username = row[1].ToString();
                        user.role = (row[2].ToString() == "admin") ? ("admin") : ("user");
                        user.is_blocked = (row[3].ToString() == "yes");
                        user.disable_restrictions = (row[4].ToString() == "disabled");
                        new_users.Add(user);
                    }
                    else
                    {
                        user = new User();
                        user.username = row[1].ToString();
                        user.password = "";
                        user.role = (row[2].ToString() == "admin") ? ("admin") : ("user");
                        user.is_blocked = (row[3].ToString() == "yes");
                        user.disable_restrictions = (row[4].ToString() == "disabled");
                        new_users.Add(user);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR! username duplicated or row without username inputted!");
                }                
            }
            users = new_users;
            SetUsers();
            usersListPanel.Visible = true;
            welcomePanel.Visible = false;
            dt.Rows.Clear();
            GetUsers();
            DisplayUsers();
        }

        public bool usernameExist(List<User> c_users, string username)
        {
            bool exist = false;
            foreach(var user in c_users)
            {
                if (user.username == username)
                {
                    exist = true;
                }
            }
            return exist;
        }
        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Type of password protection:  Password encryption.");
        }
        private void passwordRestrictionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The presence of Latin letters and symbols of the Cyrillic alphabet.");
        }

        private void UsersDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
