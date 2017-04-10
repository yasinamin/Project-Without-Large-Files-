using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EncryptionDecryption
{
    public partial class Admin : Form
    {
        public static string actualRole;
        public static string loggedInUsername;
        bool logoutButtonClicked = false;

        //Here we will recieve our users role if either a client or admin...
        public Admin(string role, string username)
        {
            loggedInUsername = username;
            actualRole = role;
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            StegonagraphyForm textFileEncryptor = new StegonagraphyForm(actualRole, loggedInUsername);
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
            MessageBox.Show("This Project is being worked on by Yasin Amin ", "About"); // testing git
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread;
            logoutButtonClicked = true;
            //ActiveForm.Close();
            this.Close();

            thread = new Thread(opennewform);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            Application.ExitThread();

        }

        private void opennewform()
        {
            Application.Run(new Welcome());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Account_Management accountManagementForm = new Account_Management(actualRole, loggedInUsername);
            this.Hide();
            accountManagementForm.Show();
        }

        private void accountLoggedIn_Click(object sender, EventArgs e)
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

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (logoutButtonClicked == true)
            {
                logoutButtonClicked = false;
                MessageBox.Show("You have successfully been logged out!", "Logout Success!");
                return;
            }


            //If the user is closing the form with the UI then just minimize dont exit program...
            if (e.CloseReason == CloseReason.UserClosing)
            {
                    e.Cancel = true;
                    Hide();
            }

        }

        private void faceRecButton_Click(object sender, EventArgs e)
        {
            FaceRecognitionLoginForm loginForm = new FaceRecognitionLoginForm();
            FaceRecognitionTrainingForm trainingForm = new FaceRecognitionTrainingForm(loginForm, actualRole, loggedInUsername);

            this.Hide();
            trainingForm.Show();
            
        }
    }
}
