namespace EncryptionDecryption
{
    partial class Account_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account_Management));
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.tandcshowlabel = new System.Windows.Forms.Label();
            this.selectedUserComboBox = new System.Windows.Forms.ComboBox();
            this.selectUserLabel = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.termsComboBox = new System.Windows.Forms.ComboBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.accountStatusLabel = new System.Windows.Forms.Label();
            this.passwordHintLabel = new System.Windows.Forms.Label();
            this.usernameHintLabel = new System.Windows.Forms.Label();
            this.termsHintLabel = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(213, 501);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(424, 501);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(91, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(608, 229);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(279, 326);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(177, 20);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Role";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(279, 354);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(177, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(718, 23);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(112, 62);
            this.btnMenu.TabIndex = 9;
            this.btnMenu.Text = "Back to Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // tandcshowlabel
            // 
            this.tandcshowlabel.AutoSize = true;
            this.tandcshowlabel.Location = new System.Drawing.Point(134, 440);
            this.tandcshowlabel.Name = "tandcshowlabel";
            this.tandcshowlabel.Size = new System.Drawing.Size(139, 13);
            this.tandcshowlabel.TabIndex = 15;
            this.tandcshowlabel.Text = "Show Terms and Conditions";
            this.tandcshowlabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // selectedUserComboBox
            // 
            this.selectedUserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedUserComboBox.FormattingEnabled = true;
            this.selectedUserComboBox.Location = new System.Drawing.Point(279, 299);
            this.selectedUserComboBox.Name = "selectedUserComboBox";
            this.selectedUserComboBox.Size = new System.Drawing.Size(177, 21);
            this.selectedUserComboBox.TabIndex = 1;
            this.selectedUserComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // selectUserLabel
            // 
            this.selectUserLabel.AutoSize = true;
            this.selectUserLabel.Location = new System.Drawing.Point(88, 302);
            this.selectUserLabel.Name = "selectUserLabel";
            this.selectUserLabel.Size = new System.Drawing.Size(187, 13);
            this.selectUserLabel.TabIndex = 17;
            this.selectUserLabel.Text = "Select Existing User to Delete/Update";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(317, 501);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // roleComboBox
            // 
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(279, 408);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(177, 21);
            this.roleComboBox.TabIndex = 4;
            this.roleComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // termsComboBox
            // 
            this.termsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termsComboBox.FormattingEnabled = true;
            this.termsComboBox.Location = new System.Drawing.Point(279, 437);
            this.termsComboBox.Name = "termsComboBox";
            this.termsComboBox.Size = new System.Drawing.Size(177, 21);
            this.termsComboBox.TabIndex = 5;
            this.termsComboBox.SelectedIndexChanged += new System.EventHandler(this.termsComboBox_SelectedIndexChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(13, 23);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(77, 13);
            this.usernameLabel.TabIndex = 18;
            this.usernameLabel.Text = "Logged in as : ";
            this.usernameLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // accountStatusLabel
            // 
            this.accountStatusLabel.AutoSize = true;
            this.accountStatusLabel.Location = new System.Drawing.Point(187, 23);
            this.accountStatusLabel.Name = "accountStatusLabel";
            this.accountStatusLabel.Size = new System.Drawing.Size(89, 13);
            this.accountStatusLabel.TabIndex = 19;
            this.accountStatusLabel.Text = "Account Status : ";
            this.accountStatusLabel.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // passwordHintLabel
            // 
            this.passwordHintLabel.AutoSize = true;
            this.passwordHintLabel.Location = new System.Drawing.Point(462, 357);
            this.passwordHintLabel.Name = "passwordHintLabel";
            this.passwordHintLabel.Size = new System.Drawing.Size(382, 13);
            this.passwordHintLabel.TabIndex = 20;
            this.passwordHintLabel.Text = "(Must be 8-15 Characters with an upper, lower case letter a number and symbol)";
            // 
            // usernameHintLabel
            // 
            this.usernameHintLabel.AutoSize = true;
            this.usernameHintLabel.Location = new System.Drawing.Point(462, 329);
            this.usernameHintLabel.Name = "usernameHintLabel";
            this.usernameHintLabel.Size = new System.Drawing.Size(249, 13);
            this.usernameHintLabel.TabIndex = 21;
            this.usernameHintLabel.Text = "(Must be 2+ letters a-z/A-Z, no numbers or symbols)";
            // 
            // termsHintLabel
            // 
            this.termsHintLabel.AutoSize = true;
            this.termsHintLabel.Location = new System.Drawing.Point(462, 440);
            this.termsHintLabel.Name = "termsHintLabel";
            this.termsHintLabel.Size = new System.Drawing.Size(330, 13);
            this.termsHintLabel.TabIndex = 22;
            this.termsHintLabel.Text = "(A New user must read the terms and conditions to use this program!)";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(279, 382);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(177, 20);
            this.confirmPasswordTextBox.TabIndex = 23;
            this.confirmPasswordTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Confirm Password";
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Location = new System.Drawing.Point(465, 384);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(189, 17);
            this.showPasswordCheckBox.TabIndex = 25;
            this.showPasswordCheckBox.Text = "Show Password (Do this privately!)";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            this.showPasswordCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Account_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 585);
            this.Controls.Add(this.showPasswordCheckBox);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.termsHintLabel);
            this.Controls.Add(this.usernameHintLabel);
            this.Controls.Add(this.passwordHintLabel);
            this.Controls.Add(this.accountStatusLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.termsComboBox);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.selectUserLabel);
            this.Controls.Add(this.selectedUserComboBox);
            this.Controls.Add(this.tandcshowlabel);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 624);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(858, 624);
            this.Name = "Account_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account_Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Account_Management_FormClosed);
            this.Load += new System.EventHandler(this.Account_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label tandcshowlabel;
        private System.Windows.Forms.ComboBox selectedUserComboBox;
        private System.Windows.Forms.Label selectUserLabel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.ComboBox termsComboBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label accountStatusLabel;
        private System.Windows.Forms.Label passwordHintLabel;
        private System.Windows.Forms.Label usernameHintLabel;
        private System.Windows.Forms.Label termsHintLabel;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
    }
}