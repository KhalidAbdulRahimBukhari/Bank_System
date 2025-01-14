namespace MyBankSystemDesktopApp.Users
{
    partial class frmUpdateUser
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
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.gbPermissions = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsersLog = new System.Windows.Forms.CheckBox();
            this.cbDeleteUser = new System.Windows.Forms.CheckBox();
            this.cbUpdateUser = new System.Windows.Forms.CheckBox();
            this.cbAddUser = new System.Windows.Forms.CheckBox();
            this.cbShowUsers = new System.Windows.Forms.CheckBox();
            this.cbDeleteClient = new System.Windows.Forms.CheckBox();
            this.cbUpdateclient = new System.Windows.Forms.CheckBox();
            this.cbAddClient = new System.Windows.Forms.CheckBox();
            this.cbShowClients = new System.Windows.Forms.CheckBox();
            this.cbFullAccess = new System.Windows.Forms.CheckBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.gbPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.btnUpdateUser.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.Location = new System.Drawing.Point(585, 277);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(189, 57);
            this.btnUpdateUser.TabIndex = 116;
            this.btnUpdateUser.Text = "Update User";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // gbPermissions
            // 
            this.gbPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.gbPermissions.Controls.Add(this.label2);
            this.gbPermissions.Controls.Add(this.label1);
            this.gbPermissions.Controls.Add(this.cbUsersLog);
            this.gbPermissions.Controls.Add(this.cbDeleteUser);
            this.gbPermissions.Controls.Add(this.cbUpdateUser);
            this.gbPermissions.Controls.Add(this.cbAddUser);
            this.gbPermissions.Controls.Add(this.cbShowUsers);
            this.gbPermissions.Controls.Add(this.cbDeleteClient);
            this.gbPermissions.Controls.Add(this.cbUpdateclient);
            this.gbPermissions.Controls.Add(this.cbAddClient);
            this.gbPermissions.Controls.Add(this.cbShowClients);
            this.gbPermissions.Controls.Add(this.cbFullAccess);
            this.gbPermissions.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbPermissions.ForeColor = System.Drawing.Color.White;
            this.gbPermissions.Location = new System.Drawing.Point(28, 160);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(319, 249);
            this.gbPermissions.TabIndex = 115;
            this.gbPermissions.TabStop = false;
            this.gbPermissions.Text = "Permissions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Client Management";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(180, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "User Management";
            // 
            // cbUsersLog
            // 
            this.cbUsersLog.BackColor = System.Drawing.Color.DarkGray;
            this.cbUsersLog.Location = new System.Drawing.Point(183, 223);
            this.cbUsersLog.Name = "cbUsersLog";
            this.cbUsersLog.Size = new System.Drawing.Size(118, 20);
            this.cbUsersLog.TabIndex = 11;
            this.cbUsersLog.Text = "Users Log";
            this.cbUsersLog.UseVisualStyleBackColor = false;
            // 
            // cbDeleteUser
            // 
            this.cbDeleteUser.BackColor = System.Drawing.Color.DarkGray;
            this.cbDeleteUser.Location = new System.Drawing.Point(183, 197);
            this.cbDeleteUser.Name = "cbDeleteUser";
            this.cbDeleteUser.Size = new System.Drawing.Size(118, 20);
            this.cbDeleteUser.TabIndex = 10;
            this.cbDeleteUser.Text = "Delete User";
            this.cbDeleteUser.UseVisualStyleBackColor = false;
            // 
            // cbUpdateUser
            // 
            this.cbUpdateUser.BackColor = System.Drawing.Color.DarkGray;
            this.cbUpdateUser.Location = new System.Drawing.Point(183, 171);
            this.cbUpdateUser.Name = "cbUpdateUser";
            this.cbUpdateUser.Size = new System.Drawing.Size(118, 20);
            this.cbUpdateUser.TabIndex = 9;
            this.cbUpdateUser.Text = "Update User";
            this.cbUpdateUser.UseVisualStyleBackColor = false;
            // 
            // cbAddUser
            // 
            this.cbAddUser.BackColor = System.Drawing.Color.DarkGray;
            this.cbAddUser.Location = new System.Drawing.Point(183, 145);
            this.cbAddUser.Name = "cbAddUser";
            this.cbAddUser.Size = new System.Drawing.Size(118, 20);
            this.cbAddUser.TabIndex = 8;
            this.cbAddUser.Text = "AddUser";
            this.cbAddUser.UseVisualStyleBackColor = false;
            // 
            // cbShowUsers
            // 
            this.cbShowUsers.BackColor = System.Drawing.Color.DarkGray;
            this.cbShowUsers.Location = new System.Drawing.Point(183, 119);
            this.cbShowUsers.Name = "cbShowUsers";
            this.cbShowUsers.Size = new System.Drawing.Size(118, 20);
            this.cbShowUsers.TabIndex = 5;
            this.cbShowUsers.Text = "Show Users";
            this.cbShowUsers.UseVisualStyleBackColor = false;
            // 
            // cbDeleteClient
            // 
            this.cbDeleteClient.BackColor = System.Drawing.Color.DarkGray;
            this.cbDeleteClient.Location = new System.Drawing.Point(15, 195);
            this.cbDeleteClient.Name = "cbDeleteClient";
            this.cbDeleteClient.Size = new System.Drawing.Size(118, 20);
            this.cbDeleteClient.TabIndex = 4;
            this.cbDeleteClient.Text = "Delete Client";
            this.cbDeleteClient.UseVisualStyleBackColor = false;
            // 
            // cbUpdateclient
            // 
            this.cbUpdateclient.BackColor = System.Drawing.Color.DarkGray;
            this.cbUpdateclient.Location = new System.Drawing.Point(15, 169);
            this.cbUpdateclient.Name = "cbUpdateclient";
            this.cbUpdateclient.Size = new System.Drawing.Size(118, 20);
            this.cbUpdateclient.TabIndex = 3;
            this.cbUpdateclient.Text = "Update Client";
            this.cbUpdateclient.UseVisualStyleBackColor = false;
            // 
            // cbAddClient
            // 
            this.cbAddClient.BackColor = System.Drawing.Color.DarkGray;
            this.cbAddClient.Location = new System.Drawing.Point(15, 143);
            this.cbAddClient.Name = "cbAddClient";
            this.cbAddClient.Size = new System.Drawing.Size(118, 20);
            this.cbAddClient.TabIndex = 2;
            this.cbAddClient.Text = "Add Client";
            this.cbAddClient.UseVisualStyleBackColor = false;
            // 
            // cbShowClients
            // 
            this.cbShowClients.BackColor = System.Drawing.Color.DarkGray;
            this.cbShowClients.Location = new System.Drawing.Point(15, 117);
            this.cbShowClients.Name = "cbShowClients";
            this.cbShowClients.Size = new System.Drawing.Size(118, 20);
            this.cbShowClients.TabIndex = 1;
            this.cbShowClients.Text = "Show Clients";
            this.cbShowClients.UseVisualStyleBackColor = false;
            // 
            // cbFullAccess
            // 
            this.cbFullAccess.BackColor = System.Drawing.Color.IndianRed;
            this.cbFullAccess.Location = new System.Drawing.Point(15, 39);
            this.cbFullAccess.Name = "cbFullAccess";
            this.cbFullAccess.Size = new System.Drawing.Size(98, 30);
            this.cbFullAccess.TabIndex = 0;
            this.cbFullAccess.Text = "Full Access";
            this.cbFullAccess.UseVisualStyleBackColor = false;
            this.cbFullAccess.CheckedChanged += new System.EventHandler(this.cbFullAccess_CheckedChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUserName.Location = new System.Drawing.Point(22, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(139, 20);
            this.lblUserName.TabIndex = 114;
            this.lblUserName.Text = "UserName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLastName.Location = new System.Drawing.Point(22, 132);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(139, 20);
            this.lblLastName.TabIndex = 112;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPassword.Location = new System.Drawing.Point(22, 47);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(139, 20);
            this.lblPassword.TabIndex = 113;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFirstName.Location = new System.Drawing.Point(22, 85);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(139, 20);
            this.lblFirstName.TabIndex = 111;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtFirstName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFirstName.ForeColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(157, 84);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 23);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(157, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(176, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtLastName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtLastName.ForeColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(157, 131);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(176, 23);
            this.txtLastName.TabIndex = 3;
            // 
            // lblStreet
            // 
            this.lblStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStreet.Location = new System.Drawing.Point(398, 173);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(139, 20);
            this.lblStreet.TabIndex = 110;
            this.lblStreet.Text = "Street";
            this.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStreet
            // 
            this.txtStreet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtStreet.ForeColor = System.Drawing.Color.White;
            this.txtStreet.Location = new System.Drawing.Point(533, 172);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(176, 23);
            this.txtStreet.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCity.Location = new System.Drawing.Point(398, 131);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(139, 20);
            this.lblCity.TabIndex = 109;
            this.lblCity.Text = "City";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountry
            // 
            this.lblCountry.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCountry.Location = new System.Drawing.Point(398, 87);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(139, 20);
            this.lblCountry.TabIndex = 108;
            this.lblCountry.Text = "Country";
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPhoneNumber.Location = new System.Drawing.Point(398, 49);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(139, 20);
            this.lblPhoneNumber.TabIndex = 107;
            this.lblPhoneNumber.Text = "Phone Number";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(398, 8);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(139, 20);
            this.lblEmail.TabIndex = 106;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtCity.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCity.ForeColor = System.Drawing.Color.White;
            this.txtCity.Location = new System.Drawing.Point(533, 130);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(176, 23);
            this.txtCity.TabIndex = 7;
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtCountry.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCountry.ForeColor = System.Drawing.Color.White;
            this.txtCountry.Location = new System.Drawing.Point(533, 86);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(176, 23);
            this.txtCountry.TabIndex = 6;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtPhoneNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.White;
            this.txtPhoneNumber.Location = new System.Drawing.Point(533, 48);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(176, 23);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(47)))));
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(533, 7);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(176, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // cbUserName
            // 
            this.cbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUserName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(159, 9);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(176, 25);
            this.cbUserName.TabIndex = 117;
            this.cbUserName.SelectedIndexChanged += new System.EventHandler(this.cbUserName_SelectedIndexChanged);
            // 
            // frmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 416);
            this.ControlBox = false;
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.gbPermissions);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtEmail);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpdateUser";
            this.Text = "frmEditUser";
            this.Load += new System.EventHandler(this.frmEditUser_Load);
            this.gbPermissions.ResumeLayout(false);
            this.gbPermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.GroupBox gbPermissions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbUsersLog;
        private System.Windows.Forms.CheckBox cbDeleteUser;
        private System.Windows.Forms.CheckBox cbUpdateUser;
        private System.Windows.Forms.CheckBox cbAddUser;
        private System.Windows.Forms.CheckBox cbShowUsers;
        private System.Windows.Forms.CheckBox cbDeleteClient;
        private System.Windows.Forms.CheckBox cbUpdateclient;
        private System.Windows.Forms.CheckBox cbAddClient;
        private System.Windows.Forms.CheckBox cbShowClients;
        private System.Windows.Forms.CheckBox cbFullAccess;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cbUserName;
    }
}