namespace EncryptionDecryption
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.addRemoveButton = new System.Windows.Forms.Button();
            this.accountLoggedIn = new System.Windows.Forms.Label();
            this.accountStatusLabel = new System.Windows.Forms.Label();
            this.keyManagementButton = new System.Windows.Forms.Button();
            this.faceRecButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnEncrypt.Location = new System.Drawing.Point(80, 245);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(248, 77);
            this.btnEncrypt.TabIndex = 15;
            this.btnEncrypt.Text = "Steganography";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(80, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 77);
            this.button1.TabIndex = 16;
            this.button1.Text = "Encrypt/Decrypt Files";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.Transparent;
            this.logoutButton.Location = new System.Drawing.Point(678, 60);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(133, 44);
            this.logoutButton.TabIndex = 17;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // addRemoveButton
            // 
            this.addRemoveButton.BackColor = System.Drawing.Color.Transparent;
            this.addRemoveButton.Location = new System.Drawing.Point(497, 153);
            this.addRemoveButton.Name = "addRemoveButton";
            this.addRemoveButton.Size = new System.Drawing.Size(248, 77);
            this.addRemoveButton.TabIndex = 18;
            this.addRemoveButton.Text = "Add/Remove Accounts";
            this.addRemoveButton.UseVisualStyleBackColor = false;
            this.addRemoveButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // accountLoggedIn
            // 
            this.accountLoggedIn.AutoSize = true;
            this.accountLoggedIn.Location = new System.Drawing.Point(12, 60);
            this.accountLoggedIn.Name = "accountLoggedIn";
            this.accountLoggedIn.Size = new System.Drawing.Size(74, 13);
            this.accountLoggedIn.TabIndex = 19;
            this.accountLoggedIn.Text = "Logged in as: ";
            this.accountLoggedIn.Click += new System.EventHandler(this.accountLoggedIn_Click);
            // 
            // accountStatusLabel
            // 
            this.accountStatusLabel.AutoSize = true;
            this.accountStatusLabel.Location = new System.Drawing.Point(149, 59);
            this.accountStatusLabel.Name = "accountStatusLabel";
            this.accountStatusLabel.Size = new System.Drawing.Size(86, 13);
            this.accountStatusLabel.TabIndex = 20;
            this.accountStatusLabel.Text = "Account Status: ";
            // 
            // keyManagementButton
            // 
            this.keyManagementButton.BackColor = System.Drawing.Color.Transparent;
            this.keyManagementButton.Location = new System.Drawing.Point(497, 245);
            this.keyManagementButton.Name = "keyManagementButton";
            this.keyManagementButton.Size = new System.Drawing.Size(248, 77);
            this.keyManagementButton.TabIndex = 21;
            this.keyManagementButton.Text = "Key Management";
            this.keyManagementButton.UseVisualStyleBackColor = false;
            this.keyManagementButton.Click += new System.EventHandler(this.keyManagementButton_Click);
            // 
            // faceRecButton
            // 
            this.faceRecButton.BackColor = System.Drawing.Color.Transparent;
            this.faceRecButton.Location = new System.Drawing.Point(298, 352);
            this.faceRecButton.Name = "faceRecButton";
            this.faceRecButton.Size = new System.Drawing.Size(248, 77);
            this.faceRecButton.TabIndex = 22;
            this.faceRecButton.Text = "Face Recognition Data";
            this.faceRecButton.UseVisualStyleBackColor = false;
            this.faceRecButton.Click += new System.EventHandler(this.faceRecButton_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 585);
            this.Controls.Add(this.faceRecButton);
            this.Controls.Add(this.keyManagementButton);
            this.Controls.Add(this.accountStatusLabel);
            this.Controls.Add(this.accountLoggedIn);
            this.Controls.Add(this.addRemoveButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 624);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(858, 624);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button addRemoveButton;
        private System.Windows.Forms.Label accountLoggedIn;
        private System.Windows.Forms.Label accountStatusLabel;
        private System.Windows.Forms.Button keyManagementButton;
        private System.Windows.Forms.Button faceRecButton;
    }
}