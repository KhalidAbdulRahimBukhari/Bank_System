namespace MyBankSystemDesktopApp.Users
{
    partial class frmAddUser
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
            this.components = new System.ComponentModel.Container();
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
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.gbPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStreet
            // 
            this.lblStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreet.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStreet.Location = new System.Drawing.Point(382, 177);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(139, 20);
            this.lblStreet.TabIndex = 85;
            this.lblStreet.Text = "Street";
            this.lblStreet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtStreet
            // 
            this.txtStreet.BackColor = System.Drawing.Color.CadetBlue;
            this.txtStreet.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtStreet.Location = new System.Drawing.Point(517, 176);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(176, 23);
            this.txtStreet.TabIndex = 9;
            this.txtStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // lblCity
            // 
            this.lblCity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCity.Location = new System.Drawing.Point(382, 135);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(139, 20);
            this.lblCity.TabIndex = 84;
            this.lblCity.Text = "City";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountry
            // 
            this.lblCountry.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCountry.Location = new System.Drawing.Point(382, 91);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(139, 20);
            this.lblCountry.TabIndex = 83;
            this.lblCountry.Text = "Country";
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPhoneNumber.Location = new System.Drawing.Point(382, 53);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(139, 20);
            this.lblPhoneNumber.TabIndex = 82;
            this.lblPhoneNumber.Text = "Phone Number";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(382, 12);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(139, 20);
            this.lblEmail.TabIndex = 81;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.CadetBlue;
            this.txtCity.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCity.Location = new System.Drawing.Point(517, 134);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(176, 23);
            this.txtCity.TabIndex = 8;
            this.txtCity.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.CadetBlue;
            this.txtCountry.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCountry.Location = new System.Drawing.Point(517, 90);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(176, 23);
            this.txtCountry.TabIndex = 7;
            this.txtCountry.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.CadetBlue;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(517, 52);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(176, 23);
            this.txtPhoneNumber.TabIndex = 6;
            this.txtPhoneNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.CadetBlue;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(517, 11);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(176, 23);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLastName.Location = new System.Drawing.Point(6, 136);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(139, 20);
            this.lblLastName.TabIndex = 90;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPassword.Location = new System.Drawing.Point(6, 51);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(139, 20);
            this.lblPassword.TabIndex = 91;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFirstName.Location = new System.Drawing.Point(6, 89);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(139, 20);
            this.lblFirstName.TabIndex = 89;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.CadetBlue;
            this.txtFirstName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtFirstName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtFirstName.Location = new System.Drawing.Point(141, 88);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(176, 23);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.CadetBlue;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPassword.Location = new System.Drawing.Point(141, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(176, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.CadetBlue;
            this.txtLastName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtLastName.Location = new System.Drawing.Point(141, 135);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(176, 23);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUserName.Location = new System.Drawing.Point(6, 13);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(139, 20);
            this.lblUserName.TabIndex = 93;
            this.lblUserName.Text = "UserName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.CadetBlue;
            this.txtUserName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUserName.Location = new System.Drawing.Point(141, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(176, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // gbPermissions
            // 
            this.gbPermissions.BackColor = System.Drawing.Color.CadetBlue;
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
            this.gbPermissions.Location = new System.Drawing.Point(12, 164);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(319, 249);
            this.gbPermissions.TabIndex = 94;
            this.gbPermissions.TabStop = false;
            this.gbPermissions.Text = "Permissions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Client Management";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.CadetBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.cbUsersLog.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbDeleteUser.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbUpdateUser.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbAddUser.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbShowUsers.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbDeleteClient.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbUpdateclient.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbAddClient.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            this.cbShowClients.CheckedChanged += new System.EventHandler(this.Check_Box_CheckedChanged);
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
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAddUser.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(569, 281);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(189, 57);
            this.btnAddUser.TabIndex = 95;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Green;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(377, 281);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 57);
            this.btnClear.TabIndex = 96;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 416);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.gbPermissions);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserName);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUser";
            this.Text = "frmAddUser";
            this.gbPermissions.ResumeLayout(false);
            this.gbPermissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox gbPermissions;
        private System.Windows.Forms.CheckBox cbFullAccess;
        private System.Windows.Forms.CheckBox cbShowUsers;
        private System.Windows.Forms.CheckBox cbDeleteClient;
        private System.Windows.Forms.CheckBox cbUpdateclient;
        private System.Windows.Forms.CheckBox cbAddClient;
        private System.Windows.Forms.CheckBox cbShowClients;
        private System.Windows.Forms.CheckBox cbUsersLog;
        private System.Windows.Forms.CheckBox cbDeleteUser;
        private System.Windows.Forms.CheckBox cbUpdateUser;
        private System.Windows.Forms.CheckBox cbAddUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClear;
    }
}