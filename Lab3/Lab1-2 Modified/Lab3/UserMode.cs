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
    public partial class UserMode : Form
    {
        User auth;
        public List<User> users = new List<User>();
        public UserMode(User auth)
        {
            InitializeComponent();
            this.auth = auth;
            welcomeMsg.Text = "Welcome back! " + auth.username;
            GetUsers();
        }

        private void UserMode_Load(object sender, EventArgs e)
        {

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

        private void passwordProtectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Type of password protection:  Password encryption.");
        }

        private void passwordRestrictionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The presence of Latin letters and symbols of the Cyrillic alphabet.");
        }

        private void Save_OnClick(object sender, EventArgs e)
        {
            string currentPass = txtCurrPass.Text;
            string new_pass = txtNewPass.Text;
            string new_pass_confirm = txtConfirmPass.Text;
            User user;
            if (auth.password == "" && currentPass == "")
            {
                if(new_pass == new_pass_confirm)
                {
                    if (!auth.disable_restrictions)
                    {
                        new_pass = ApplyRestictions(new_pass);
                    }
                    string hashedPass = PasswordHasher.HashPassword(new_pass);
                    user = users.Find(u => u.username == auth.username);
                    user.password = hashedPass;
                    SetUsers();

                    //Logout
                    this.auth = null;
                    var f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password not confirmed!");
                }
            }
            else
            {
                //user have password
                if(PasswordHasher.VerifyPassword(currentPass, auth.password))
                {
                    if (new_pass == new_pass_confirm)
                    {
                        if(!auth.disable_restrictions){
                            new_pass = ApplyRestictions(new_pass);
                        }

                        string hashedPass = PasswordHasher.HashPassword(new_pass);
                        user = users.Find(u => u.username == auth.username);
                        user.password = hashedPass;
                        SetUsers();
                        //Logout
                        this.auth = null;
                        var f1 = new Form1();
                        f1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Password not confirmed!");
                    }
                }
                else
                {
                    MessageBox.Show("Password incorrect!");
                }
            }
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
        public string ApplyRestictions(string password)
        {
            string new_pass = password;
            for (int i = 0; i < new_pass.Length; i++)
            {
                if (!Char.IsLetter(new_pass[i]))
                {
                    new_pass = new_pass.Replace(new_pass[i], 'A');
                }
            }
            return new_pass;
        }

        private void UserMode_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(auth.role == "admin")
            {
                var f_admin = new AdminMode(auth);
                f_admin.Show();
                this.Hide();
            }
        }
    }
}
