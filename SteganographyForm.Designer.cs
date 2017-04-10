namespace EncryptionDecryption
{
    partial class StegonagraphyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StegonagraphyForm));
            this.HideMessageButton = new System.Windows.Forms.Button();
            this.ExtractMessageButton = new System.Windows.Forms.Button();
            this.secretMessageBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.key_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HideMessageButton
            // 
            this.HideMessageButton.Enabled = false;
            this.HideMessageButton.Location = new System.Drawing.Point(567, 392);
            this.HideMessageButton.Name = "HideMessageButton";
            this.HideMessageButton.Size = new System.Drawing.Size(251, 61);
            this.HideMessageButton.TabIndex = 3;
            this.HideMessageButton.Text = "Encode Message to an Image";
            this.HideMessageButton.UseVisualStyleBackColor = true;
            this.HideMessageButton.Click += new System.EventHandler(this.HideMessageButton_Click);
            // 
            // ExtractMessageButton
            // 
            this.ExtractMessageButton.Location = new System.Drawing.Point(567, 477);
            this.ExtractMessageButton.Name = "ExtractMessageButton";
            this.ExtractMessageButton.Size = new System.Drawing.Size(251, 60);
            this.ExtractMessageButton.TabIndex = 4;
            this.ExtractMessageButton.Text = "Decode an Image";
            this.ExtractMessageButton.UseVisualStyleBackColor = true;
            this.ExtractMessageButton.Click += new System.EventHandler(this.ExtractMessageButton_Click);
            // 
            // secretMessageBox
            // 
            this.secretMessageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secretMessageBox.Location = new System.Drawing.Point(3, 16);
            this.secretMessageBox.Name = "secretMessageBox";
            this.secretMessageBox.Size = new System.Drawing.Size(381, 145);
            this.secretMessageBox.TabIndex = 0;
            this.secretMessageBox.Text = "";
            this.secretMessageBox.TextChanged += new System.EventHandler(this.SecretMessageBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secretMessageBox);
            this.groupBox1.Location = new System.Drawing.Point(25, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 164);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message to be Encoded";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Location = new System.Drawing.Point(196, 35);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(468, 297);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 75);
            this.button1.TabIndex = 6;
            this.button1.Text = "Back to Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(25, 35);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(113, 75);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset Session";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // key_Save
            // 
            this.key_Save.Enabled = false;
            this.key_Save.Location = new System.Drawing.Point(418, 430);
            this.key_Save.Name = "key_Save";
            this.key_Save.Size = new System.Drawing.Size(101, 60);
            this.key_Save.TabIndex = 18;
            this.key_Save.Text = "Save Decoded Message";
            this.key_Save.UseVisualStyleBackColor = true;
            this.key_Save.Click += new System.EventHandler(this.key_Save_Click);
            // 
            // StegonagraphyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 585);
            this.Controls.Add(this.key_Save);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExtractMessageButton);
            this.Controls.Add(this.HideMessageButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(858, 624);
            this.Name = "StegonagraphyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Steganography";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button HideMessageButton;
        private System.Windows.Forms.Button ExtractMessageButton;
        private System.Windows.Forms.RichTextBox secretMessageBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button key_Save;
    }
}

