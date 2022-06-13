namespace Lab3
{
    partial class AdminMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMode));
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.welcomeMsg = new System.Windows.Forms.Label();
            this.UpdatePassword = new System.Windows.Forms.Button();
            this.UserListBtn = new System.Windows.Forms.Button();
            this.usersListPanel = new System.Windows.Forms.Panel();
            this.save_changes = new System.Windows.Forms.Button();
            this.GoBackBtn = new System.Windows.Forms.Button();
            this.UsersDataGrid = new System.Windows.Forms.DataGridView();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developedByAyoubElHaddadiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupKH919IeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordRestrictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpsgithubcomElhAyoubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.welcomePanel.SuspendLayout();
            this.usersListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomePanel
            // 
            this.welcomePanel.Controls.Add(this.welcomeMsg);
            this.welcomePanel.Controls.Add(this.UpdatePassword);
            this.welcomePanel.Controls.Add(this.UserListBtn);
            this.welcomePanel.Location = new System.Drawing.Point(0, 39);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(876, 457);
            this.welcomePanel.TabIndex = 15;
            // 
            // welcomeMsg
            // 
            this.welcomeMsg.AutoSize = true;
            this.welcomeMsg.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMsg.Location = new System.Drawing.Point(259, 104);
            this.welcomeMsg.Name = "welcomeMsg";
            this.welcomeMsg.Size = new System.Drawing.Size(354, 41);
            this.welcomeMsg.TabIndex = 14;
            this.welcomeMsg.Text = "Welcome back! ADMIN";
            // 
            // UpdatePassword
            // 
            this.UpdatePassword.BackColor = System.Drawing.Color.DarkGray;
            this.UpdatePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UpdatePassword.FlatAppearance.BorderSize = 3;
            this.UpdatePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.UpdatePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePassword.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UpdatePassword.Location = new System.Drawing.Point(45, 248);
            this.UpdatePassword.Name = "UpdatePassword";
            this.UpdatePassword.Size = new System.Drawing.Size(351, 68);
            this.UpdatePassword.TabIndex = 13;
            this.UpdatePassword.Text = "Update password";
            this.UpdatePassword.UseVisualStyleBackColor = false;
            this.UpdatePassword.Click += new System.EventHandler(this.UpdatePassword_OnClick);
            // 
            // UserListBtn
            // 
            this.UserListBtn.BackColor = System.Drawing.Color.DarkGray;
            this.UserListBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserListBtn.FlatAppearance.BorderSize = 3;
            this.UserListBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.UserListBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UserListBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserListBtn.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserListBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserListBtn.Location = new System.Drawing.Point(523, 248);
            this.UserListBtn.Name = "UserListBtn";
            this.UserListBtn.Size = new System.Drawing.Size(292, 68);
            this.UserListBtn.TabIndex = 12;
            this.UserListBtn.Text = "Users list";
            this.UserListBtn.UseVisualStyleBackColor = false;
            this.UserListBtn.Click += new System.EventHandler(this.UserListBtn_OnClick);
            // 
            // usersListPanel
            // 
            this.usersListPanel.Controls.Add(this.save_changes);
            this.usersListPanel.Controls.Add(this.GoBackBtn);
            this.usersListPanel.Controls.Add(this.UsersDataGrid);
            this.usersListPanel.Location = new System.Drawing.Point(0, 39);
            this.usersListPanel.Name = "usersListPanel";
            this.usersListPanel.Size = new System.Drawing.Size(872, 457);
            this.usersListPanel.TabIndex = 15;
            // 
            // save_changes
            // 
            this.save_changes.BackColor = System.Drawing.Color.DarkGray;
            this.save_changes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.save_changes.FlatAppearance.BorderSize = 3;
            this.save_changes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.save_changes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.save_changes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_changes.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_changes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.save_changes.Location = new System.Drawing.Point(573, 385);
            this.save_changes.Name = "save_changes";
            this.save_changes.Size = new System.Drawing.Size(242, 57);
            this.save_changes.TabIndex = 10;
            this.save_changes.Text = "Save changes";
            this.save_changes.UseVisualStyleBackColor = false;
            this.save_changes.Click += new System.EventHandler(this.SaveChanges_OnClick);
            // 
            // GoBackBtn
            // 
            this.GoBackBtn.BackColor = System.Drawing.Color.DarkGray;
            this.GoBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GoBackBtn.FlatAppearance.BorderSize = 3;
            this.GoBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.GoBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoBackBtn.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBackBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GoBackBtn.Location = new System.Drawing.Point(45, 385);
            this.GoBackBtn.Name = "GoBackBtn";
            this.GoBackBtn.Size = new System.Drawing.Size(242, 57);
            this.GoBackBtn.TabIndex = 9;
            this.GoBackBtn.Text = "Go back";
            this.GoBackBtn.UseVisualStyleBackColor = false;
            this.GoBackBtn.Click += new System.EventHandler(this.GoBackBtn_OnClick);
            // 
            // UsersDataGrid
            // 
            this.UsersDataGrid.AllowUserToOrderColumns = true;
            this.UsersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UsersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UsersDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.UsersDataGrid.Location = new System.Drawing.Point(12, 16);
            this.UsersDataGrid.Name = "UsersDataGrid";
            this.UsersDataGrid.RowHeadersWidth = 51;
            this.UsersDataGrid.RowTemplate.Height = 24;
            this.UsersDataGrid.Size = new System.Drawing.Size(852, 352);
            this.UsersDataGrid.TabIndex = 0;
            this.UsersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGrid_CellContentClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.developedByAyoubElHaddadiToolStripMenuItem,
            this.groupKH919IeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(81, 32);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // developedByAyoubElHaddadiToolStripMenuItem
            // 
            this.developedByAyoubElHaddadiToolStripMenuItem.Name = "developedByAyoubElHaddadiToolStripMenuItem";
            this.developedByAyoubElHaddadiToolStripMenuItem.Size = new System.Drawing.Size(399, 32);
            this.developedByAyoubElHaddadiToolStripMenuItem.Text = "Developed by: Ayoub El-Haddadi";
            // 
            // groupKH919IeToolStripMenuItem
            // 
            this.groupKH919IeToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.groupKH919IeToolStripMenuItem.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.groupKH919IeToolStripMenuItem.Name = "groupKH919IeToolStripMenuItem";
            this.groupKH919IeToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.groupKH919IeToolStripMenuItem.Size = new System.Drawing.Size(401, 32);
            this.groupKH919IeToolStripMenuItem.Text = "Group: KH 919 i.e   -  Variant: 8";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passwordToolStripMenuItem,
            this.passwordRestrictionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(399, 32);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            this.passwordToolStripMenuItem.Size = new System.Drawing.Size(301, 32);
            this.passwordToolStripMenuItem.Text = "Password protection";
            this.passwordToolStripMenuItem.Click += new System.EventHandler(this.passwordToolStripMenuItem_Click);
            // 
            // passwordRestrictionsToolStripMenuItem
            // 
            this.passwordRestrictionsToolStripMenuItem.Name = "passwordRestrictionsToolStripMenuItem";
            this.passwordRestrictionsToolStripMenuItem.Size = new System.Drawing.Size(301, 32);
            this.passwordRestrictionsToolStripMenuItem.Text = "Password restrictions";
            this.passwordRestrictionsToolStripMenuItem.Click += new System.EventHandler(this.passwordRestrictionsToolStripMenuItem_Click);
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.httpsgithubcomElhAyoubToolStripMenuItem});
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(91, 32);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            // 
            // httpsgithubcomElhAyoubToolStripMenuItem
            // 
            this.httpsgithubcomElhAyoubToolStripMenuItem.Name = "httpsgithubcomElhAyoubToolStripMenuItem";
            this.httpsgithubcomElhAyoubToolStripMenuItem.Size = new System.Drawing.Size(379, 32);
            this.httpsgithubcomElhAyoubToolStripMenuItem.Text = "https://github.com/Elh-Ayoub";
            this.httpsgithubcomElhAyoubToolStripMenuItem.Click += new System.EventHandler(this.httpsgithubcomElhAyoubToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(88, 32);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.gitHubToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AdminMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(872, 503);
            this.Controls.Add(this.usersListPanel);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminMode";
            this.Text = "Admin mode";
            this.Load += new System.EventHandler(this.AdminMode_Load);
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.usersListPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Panel usersListPanel;
        private System.Windows.Forms.DataGridView UsersDataGrid;
        private System.Windows.Forms.Label welcomeMsg;
        private System.Windows.Forms.Button UpdatePassword;
        private System.Windows.Forms.Button UserListBtn;
        private System.Windows.Forms.Button GoBackBtn;
        private System.Windows.Forms.Button save_changes;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developedByAyoubElHaddadiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupKH919IeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem httpsgithubcomElhAyoubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordRestrictionsToolStripMenuItem;
    }
}