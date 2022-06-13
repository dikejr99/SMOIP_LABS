namespace Lab1
{
    partial class UserMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMode));
            this.button1 = new System.Windows.Forms.Button();
            this.txtCurrPass = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developedByAyoubElHaddadiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupKH919IeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.httpsgithubcomElhAyoubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeMsg = new System.Windows.Forms.Label();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordProtectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordRestrictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(252, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(292, 57);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Save_OnClick);
            // 
            // txtCurrPass
            // 
            this.txtCurrPass.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrPass.Location = new System.Drawing.Point(415, 132);
            this.txtCurrPass.Name = "txtCurrPass";
            this.txtCurrPass.PasswordChar = '*';
            this.txtCurrPass.Size = new System.Drawing.Size(336, 40);
            this.txtCurrPass.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Location = new System.Drawing.Point(42, 131);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(299, 41);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Current password: ";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(415, 204);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(336, 40);
            this.txtNewPass.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(42, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 41);
            this.label1.TabIndex = 9;
            this.label1.Text = "New password: ";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(415, 278);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(336, 40);
            this.txtConfirmPass.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(42, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 41);
            this.label2.TabIndex = 11;
            this.label2.Text = "Confirm new password: ";
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
            this.menuStrip1.Size = new System.Drawing.Size(808, 36);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
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
            // welcomeMsg
            // 
            this.welcomeMsg.AutoSize = true;
            this.welcomeMsg.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMsg.Location = new System.Drawing.Point(271, 53);
            this.welcomeMsg.Name = "welcomeMsg";
            this.welcomeMsg.Size = new System.Drawing.Size(240, 32);
            this.welcomeMsg.TabIndex = 14;
            this.welcomeMsg.Text = "Welcome back! User";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passwordProtectionToolStripMenuItem,
            this.passwordRestrictionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(399, 32);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // passwordProtectionToolStripMenuItem
            // 
            this.passwordProtectionToolStripMenuItem.Name = "passwordProtectionToolStripMenuItem";
            this.passwordProtectionToolStripMenuItem.Size = new System.Drawing.Size(301, 32);
            this.passwordProtectionToolStripMenuItem.Text = "Password protection";
            this.passwordProtectionToolStripMenuItem.Click += new System.EventHandler(this.passwordProtectionToolStripMenuItem_Click);
            // 
            // passwordRestrictionsToolStripMenuItem
            // 
            this.passwordRestrictionsToolStripMenuItem.Name = "passwordRestrictionsToolStripMenuItem";
            this.passwordRestrictionsToolStripMenuItem.Size = new System.Drawing.Size(301, 32);
            this.passwordRestrictionsToolStripMenuItem.Text = "Password restrictions";
            this.passwordRestrictionsToolStripMenuItem.Click += new System.EventHandler(this.passwordRestrictionsToolStripMenuItem_Click);
            // 
            // UserMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(808, 455);
            this.Controls.Add(this.welcomeMsg);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCurrPass);
            this.Controls.Add(this.txtPassword);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserMode";
            this.Text = "Update password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserMode_FormClosed);
            this.Load += new System.EventHandler(this.UserMode_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCurrPass;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developedByAyoubElHaddadiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupKH919IeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem httpsgithubcomElhAyoubToolStripMenuItem;
        private System.Windows.Forms.Label welcomeMsg;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordProtectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordRestrictionsToolStripMenuItem;
    }
}