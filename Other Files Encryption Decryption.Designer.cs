namespace EncryptionDecryption
{
    partial class encdec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(encdec));
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuButton = new System.Windows.Forms.Button();
            this.btnResetKey = new System.Windows.Forms.Button();
            this.currentKeyLabel = new System.Windows.Forms.Label();
            this.currentKey = new System.Windows.Forms.TextBox();
            this.contextFilePath = new System.Windows.Forms.TextBox();
            this.contextFilePathLabel = new System.Windows.Forms.Label();
            this.contextFilePath2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnEncrypt.Location = new System.Drawing.Point(275, 225);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(279, 71);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Open File to Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.Transparent;
            this.btnDecrypt.Location = new System.Drawing.Point(275, 322);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(279, 74);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "Open File to Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
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
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Transparent;
            this.menuButton.Location = new System.Drawing.Point(660, 64);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(156, 71);
            this.menuButton.TabIndex = 14;
            this.menuButton.Text = "Back to Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // btnResetKey
            // 
            this.btnResetKey.Location = new System.Drawing.Point(52, 64);
            this.btnResetKey.Name = "btnResetKey";
            this.btnResetKey.Size = new System.Drawing.Size(141, 53);
            this.btnResetKey.TabIndex = 31;
            this.btnResetKey.Text = "Reset Session + Key";
            this.btnResetKey.UseVisualStyleBackColor = true;
            this.btnResetKey.Click += new System.EventHandler(this.btnResetKey_Click);
            // 
            // currentKeyLabel
            // 
            this.currentKeyLabel.AutoSize = true;
            this.currentKeyLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.currentKeyLabel.Location = new System.Drawing.Point(91, 125);
            this.currentKeyLabel.Name = "currentKeyLabel";
            this.currentKeyLabel.Size = new System.Drawing.Size(62, 13);
            this.currentKeyLabel.TabIndex = 32;
            this.currentKeyLabel.Text = "Current Key";
            this.currentKeyLabel.Click += new System.EventHandler(this.currentKeyLabel_Click);
            // 
            // currentKey
            // 
            this.currentKey.Enabled = false;
            this.currentKey.Location = new System.Drawing.Point(12, 141);
            this.currentKey.Name = "currentKey";
            this.currentKey.Size = new System.Drawing.Size(215, 20);
            this.currentKey.TabIndex = 33;
            this.currentKey.TextChanged += new System.EventHandler(this.currentKey_TextChanged);
            // 
            // contextFilePath
            // 
            this.contextFilePath.Location = new System.Drawing.Point(107, 166);
            this.contextFilePath.Name = "contextFilePath";
            this.contextFilePath.Size = new System.Drawing.Size(624, 20);
            this.contextFilePath.TabIndex = 35;
            this.contextFilePath.Visible = false;
            // 
            // contextFilePathLabel
            // 
            this.contextFilePathLabel.AutoSize = true;
            this.contextFilePathLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.contextFilePathLabel.Location = new System.Drawing.Point(366, 141);
            this.contextFilePathLabel.Name = "contextFilePathLabel";
            this.contextFilePathLabel.Size = new System.Drawing.Size(117, 13);
            this.contextFilePathLabel.TabIndex = 34;
            this.contextFilePathLabel.Text = "Context Menu File Path";
            this.contextFilePathLabel.Visible = false;
            // 
            // contextFilePath2
            // 
            this.contextFilePath2.Location = new System.Drawing.Point(107, 199);
            this.contextFilePath2.Name = "contextFilePath2";
            this.contextFilePath2.Size = new System.Drawing.Size(624, 20);
            this.contextFilePath2.TabIndex = 36;
            this.contextFilePath2.Visible = false;
            // 
            // encdec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 585);
            this.Controls.Add(this.contextFilePath2);
            this.Controls.Add(this.contextFilePath);
            this.Controls.Add(this.contextFilePathLabel);
            this.Controls.Add(this.currentKey);
            this.Controls.Add(this.currentKeyLabel);
            this.Controls.Add(this.btnResetKey);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 624);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(858, 624);
            this.Name = "encdec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption & Decryption";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.encdec_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button btnResetKey;
        private System.Windows.Forms.Label currentKeyLabel;
        private System.Windows.Forms.TextBox currentKey;
        private System.Windows.Forms.TextBox contextFilePath;
        private System.Windows.Forms.Label contextFilePathLabel;
        private System.Windows.Forms.TextBox contextFilePath2;
    }
}

