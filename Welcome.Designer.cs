namespace EncryptionDecryption
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.loginFaceRecButton = new System.Windows.Forms.Button();
            this.loginCredentialsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.serverStatusLabel = new System.Windows.Forms.Label();
            this.onlineStatus = new System.Windows.Forms.Label();
            this.offlineStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginFaceRecButton
            // 
            this.loginFaceRecButton.Location = new System.Drawing.Point(136, 247);
            this.loginFaceRecButton.Name = "loginFaceRecButton";
            this.loginFaceRecButton.Size = new System.Drawing.Size(255, 83);
            this.loginFaceRecButton.TabIndex = 4;
            this.loginFaceRecButton.Text = "Login Using Face Recognition";
            this.loginFaceRecButton.UseVisualStyleBackColor = true;
            this.loginFaceRecButton.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // loginCredentialsButton
            // 
            this.loginCredentialsButton.Location = new System.Drawing.Point(447, 247);
            this.loginCredentialsButton.Name = "loginCredentialsButton";
            this.loginCredentialsButton.Size = new System.Drawing.Size(255, 83);
            this.loginCredentialsButton.TabIndex = 5;
            this.loginCredentialsButton.Text = "Login Using Credentials";
            this.loginCredentialsButton.UseVisualStyleBackColor = true;
            this.loginCredentialsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "Welcome To Yas Face-Cryption";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(302, 368);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(255, 83);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // serverStatusLabel
            // 
            this.serverStatusLabel.AutoSize = true;
            this.serverStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.serverStatusLabel.Location = new System.Drawing.Point(591, 520);
            this.serverStatusLabel.Name = "serverStatusLabel";
            this.serverStatusLabel.Size = new System.Drawing.Size(111, 16);
            this.serverStatusLabel.TabIndex = 8;
            this.serverStatusLabel.Text = "Database Status:";
            // 
            // onlineStatus
            // 
            this.onlineStatus.AutoSize = true;
            this.onlineStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineStatus.ForeColor = System.Drawing.Color.Green;
            this.onlineStatus.Location = new System.Drawing.Point(708, 520);
            this.onlineStatus.Name = "onlineStatus";
            this.onlineStatus.Size = new System.Drawing.Size(82, 16);
            this.onlineStatus.TabIndex = 9;
            this.onlineStatus.Text = "Connected";
            this.onlineStatus.Visible = false;
            // 
            // offlineStatus
            // 
            this.offlineStatus.AutoSize = true;
            this.offlineStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offlineStatus.ForeColor = System.Drawing.Color.Red;
            this.offlineStatus.Location = new System.Drawing.Point(708, 520);
            this.offlineStatus.Name = "offlineStatus";
            this.offlineStatus.Size = new System.Drawing.Size(110, 16);
            this.offlineStatus.TabIndex = 10;
            this.offlineStatus.Text = "Not Connected";
            this.offlineStatus.Visible = false;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 585);
            this.Controls.Add(this.offlineStatus);
            this.Controls.Add(this.onlineStatus);
            this.Controls.Add(this.serverStatusLabel);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginCredentialsButton);
            this.Controls.Add(this.loginFaceRecButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 624);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(858, 624);
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginFaceRecButton;
        private System.Windows.Forms.Button loginCredentialsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label serverStatusLabel;
        private System.Windows.Forms.Label onlineStatus;
        private System.Windows.Forms.Label offlineStatus;
    }
}