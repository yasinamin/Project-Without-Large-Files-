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
    public partial class TandC : Form
    {
        //Release mode use....
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Accounts.mdf; Integrated Security = True;");

        //Debug Mode...
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");
        string actualrole;
        string loggedinUsername;
        public TandC(string role, string username)
        {
            loggedinUsername = username;
            actualrole = role;
            InitializeComponent();
        }

        private void TandC_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TandC_Load(object sender, EventArgs e)
        {

        }

        private void checkboxtandc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxtandc.Checked == true)
            {
                btnContinue.Enabled = true;
            }
            else
            {
                btnContinue.Enabled = false;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if (dontShowAgainCheckBox.Checked == true)
            {
                string TermsDontShow = "dontshow";
                //string emp = null;
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //Few hours of problems came to the role was the whole string "Logged in as ..." 
                    //This never let it worked now its works after chaning role to just one word which is the role itself...
                    //FOUND BUG HERE WE ARE TAKING ROLE AS USERNAME.. WE NEED TO GET USERNAME.. FIXED...
                    cmd.CommandText = "UPDATE Login SET Terms= '" + TermsDontShow + "' WHERE Username = '" + loggedinUsername + "'";

                    //cmd.CommandText = "UPDATE Login SET Terms='" + TermsDontShow + "' WHERE Username = '" + actualrole + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //its case sensitve  no so make sure you have the tables and colums in correct case as database 
                    //change it back to varchar
                }


                catch (SqlException exp)
                {
                    // Log what you need from here.
                    //throw new InvalidOperationException("", exp);
                    MessageBox.Show("Please ensure the LocalDb database thats came with the program (Accounts.mdf) exists where the program has been installed", "Database Connection Error !");
                }
            }

            if (checkboxtandc.Checked == true)
            {
                Menu clientMenu = new Menu(actualrole, loggedinUsername);
                Admin adminMenu = new Admin(actualrole, loggedinUsername);
                TandC tandcForm = new EncryptionDecryption.TandC(actualrole, loggedinUsername);

                //Show admin panel when admin logs in...
                if (actualrole == "Admin")
                {
                    this.Hide();
                    adminMenu.ShowDialog();
                }
                //If normal client user show the client form...
                else
                {
                    this.Hide();
                    clientMenu.ShowDialog();
                }
            }

        }

        private void dontShowAgainTxtBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
