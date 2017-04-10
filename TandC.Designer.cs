namespace EncryptionDecryption
{
    partial class TandC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TandC));
            this.checkboxtandc = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.dontShowAgainCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkboxtandc
            // 
            this.checkboxtandc.AutoSize = true;
            this.checkboxtandc.Location = new System.Drawing.Point(272, 429);
            this.checkboxtandc.Name = "checkboxtandc";
            this.checkboxtandc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkboxtandc.Size = new System.Drawing.Size(282, 17);
            this.checkboxtandc.TabIndex = 0;
            this.checkboxtandc.Text = "I Accept all terms and conditions for using this program";
            this.checkboxtandc.UseVisualStyleBackColor = true;
            this.checkboxtandc.CheckedChanged += new System.EventHandler(this.checkboxtandc_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(181, 139);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(455, 249);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Terms and Conditions For Using this Program:";
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(375, 474);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // dontShowAgainCheckBox
            // 
            this.dontShowAgainCheckBox.AutoSize = true;
            this.dontShowAgainCheckBox.Location = new System.Drawing.Point(357, 451);
            this.dontShowAgainCheckBox.Name = "dontShowAgainCheckBox";
            this.dontShowAgainCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dontShowAgainCheckBox.Size = new System.Drawing.Size(111, 17);
            this.dontShowAgainCheckBox.TabIndex = 4;
            this.dontShowAgainCheckBox.Text = "Don\'t Show Again";
            this.dontShowAgainCheckBox.UseVisualStyleBackColor = true;
            this.dontShowAgainCheckBox.CheckedChanged += new System.EventHandler(this.dontShowAgainTxtBox_CheckedChanged);
            // 
            // TandC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 585);
            this.Controls.Add(this.dontShowAgainCheckBox);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkboxtandc);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 624);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(858, 624);
            this.Name = "TandC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terms and Conditions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TandC_FormClosed);
            this.Load += new System.EventHandler(this.TandC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxtandc;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.CheckBox dontShowAgainCheckBox;
    }
}