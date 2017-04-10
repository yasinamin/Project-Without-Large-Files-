using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionDecryption
{
    public partial class Menu : Form
    {
        string actualRole;
        string loggedInUsername;
        //Here we will recieve our users role if either a client or admin...
        public Menu(string role, string username)
        {
            loggedInUsername = username;
            actualRole = role;
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            //Create new instance of the class then show the form...
            StegonagraphyForm textFileEncryptor = new StegonagraphyForm(actualRole, loggedInUsername);
            //Hide our current form...
            this.Hide();
            textFileEncryptor.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            accountLoggedIn.Text += loggedInUsername;
            accountStatusLabel.Text += actualRole;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            encdec stegForm = new EncryptionDecryption.encdec(actualRole, loggedInUsername);
            this.Hide();
            stegForm.ShowDialog();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Project is being worked on by Yasin Amin ", "About");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome welcomeForm = new Welcome();
            this.Hide();
            welcomeForm.Show();
            MessageBox.Show("You have successfully been logged out!", "Logout Success!");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void keyManagementButton_Click(object sender, EventArgs e)
        {
            //Create new instance of the class then show the form...
            Key_Management keyManagementForm = new Key_Management(actualRole, loggedInUsername);
            
            //Hide our current form...
            this.Hide();
            keyManagementForm.ShowDialog();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the user is closing the form with the UI then just minimize dont exit program...
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
