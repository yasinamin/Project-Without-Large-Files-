using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EncryptionDecryption
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            this.Hide();
            loginform.ShowDialog();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            FaceRecognitionLoginForm faceRecognitionForm = new FaceRecognitionLoginForm();

            this.Hide();
            faceRecognitionForm.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {


            //Server status...
            //Debug Mode...
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");

            //Clear Selected user combo box...
            try
            {
                con.Open();
                onlineStatus.Visible = true;
                con.Close();
            }
            catch
            {
                offlineStatus.Visible = true;
            }

        }
    }
}
