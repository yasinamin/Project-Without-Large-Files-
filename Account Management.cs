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
using System.Text.RegularExpressions;


//https://www.youtube.com/watch?v=TIAOr2S6-SY&index=3&t=738s&list=FLiWPYUUiBE53H7_IwRo4C5g
//Need to watch video below to help updated account management form...
//https://www.youtube.com/watch?v=EvnjxYpwbvc&list=FLiWPYUUiBE53H7_IwRo4C5g&index=1
namespace EncryptionDecryption
{
    public partial class Account_Management : Form
    {
        //Release mode use....
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Accounts.mdf; Integrated Security = True;");

        //Debug Mode...
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");

        string actualRole;
        string loggedInUsername;
        bool validInput = false;
        public Account_Management(string role, string username)
        {
            loggedInUsername = username;
            actualRole = role;
            InitializeComponent();
        }

        private void Account_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Account_Management_Load(object sender, EventArgs e)
        {
            //Hide passwords...
            txtPassword.UseSystemPasswordChar = true;
            confirmPasswordTextBox.UseSystemPasswordChar = true;

            //Dont let any user change anyones privilege unless its owner... (admin)
            if (loggedInUsername == "admin")
            {
                roleComboBox.Enabled = true;
            }
            else
            {
                roleComboBox.Enabled = false;
            }

                //Set username...
                usernameLabel.Text += loggedInUsername;
            //Set Status...
            accountStatusLabel.Text += actualRole;

            //Update our grid and clear and fill out meaning UPDATE our combo...
            display_data();
            fillSelectUserComboBox();

            //Fill Role and T&C Combos...
            string admin = "Admin";
            string client = "Client";
            string dontshowtandc = "dontshow";
            string showtandc = "show";

            roleComboBox.Items.Add(admin);
            roleComboBox.Items.Add(client);
            termsComboBox.Items.Add(showtandc);
            termsComboBox.Items.Add(dontshowtandc);

            termsComboBox.SelectedItem = "show";
            termsComboBox.Enabled = false;

        }



        public void fillSelectUserComboBox()
        {
            //Clear Selected user combo box...
            selectedUserComboBox.Items.Clear();
            selectedUserComboBox.Items.Add("");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
            cmd.CommandText = "SELECT * FROM Login";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                selectedUserComboBox.Items.Add(dr["Username"]).ToString();
            }
            con.Close();
        }

        public static bool checkPassword(string password)
        {
            bool validPassword = false;
            //The.{ 8,15} (REGEX)
            //can be made more restrictive if you wish(for example, you could change it to \S{ 8,15}
            //to disallow whitespace), but remember that doing so will reduce the strength of your password scheme.
            Regex valid = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            if (valid.IsMatch(password))

                validPassword = true;

                 return validPassword;
        }

        public static bool checkUsername(string username)
        {
            bool validUsername = false;
            //https://www.sitepoint.com/web-foundations/using-regular-expressions-to-check-string-length/
            //{2,} no second number so then there is no limit to max size but there is min size..
            Regex valid = new Regex(@"^[a-zA-Z]{2,}$");

            if (valid.IsMatch(username))

                validUsername = true;

            return validUsername;
        }

        public void inputValidation()
        {

            if (checkUsername(txtUsername.Text.ToString()) == false)
            {
                MessageBox.Show("Check username requirements!", "Invalid Username!");
                return;
            }
            else if (checkPassword(txtPassword.Text.ToString()) == false)
            {
                MessageBox.Show("Check password requirements!", "Invalid Password!");
                return;
            }
            else if (roleComboBox.Text.ToString() == "")
            {
                MessageBox.Show("Please Select a Role!", "No Role Chosen!");
                return;
            }
            else if (termsComboBox.Text.ToString() == "")
            {
                MessageBox.Show("Please Choose to Show/Dont Show Terms!", "Terms Status Not Chosen!");
                return;
            }
            else if (confirmPasswordTextBox.Text != txtPassword.Text)
            {
                MessageBox.Show("Please re-enter the same password in the confirm password field!", "Password Confirmation Error!");
                return;
            }

            validInput = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            inputValidation();

            if (validInput == true)
            {
                
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Login VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + roleComboBox.Text + "' ,'" + termsComboBox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    display_data();
                    fillSelectUserComboBox();

                    //CAN MAKE THIS INTO A FUNCTIONS TO CLEAR ALL CONTENTS OF BOXES... can save space and more efficiency
                    int clearCombo = -1;

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    confirmPasswordTextBox.Text = "";
                    roleComboBox.SelectedIndex = clearCombo;
                    termsComboBox.SelectedIndex = clearCombo;

                    MessageBox.Show("Account Created!", "Success!");
                }
                catch (SqlException exp)
                {
                    // Log what you need from here.
                    //throw new InvalidOperationException("", exp);
                    MessageBox.Show("Duplicate Usernames are not allowed! All usernames must be unique!", "Account Creation Error!");
                    con.Close();
                }
            }

            //Reset Bool
            validInput = false;
        }

        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Login";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(loggedInUsername == selectedUserComboBox.Text)
            {
                MessageBox.Show("You cannot delete your own account whilst logged in! \n\n Note: You can contact an existing admin to delete your account", "Error");
            }

            else if (selectedUserComboBox.Text == "")
            {
                MessageBox.Show("Please Select a User to Delete!", "No User Chosen To Delete!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " +selectedUserComboBox.Text+ "'s account? \nNOTE: All keys will be lost with the account FOREVER!!!", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //Delete Account!
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE From Login where Username= '" + selectedUserComboBox.SelectedItem.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Delete All Keys of User...
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE From Keys where Username= '" + selectedUserComboBox.SelectedItem.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    int clearCombo = -1;
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    confirmPasswordTextBox.Text = "";
                    roleComboBox.SelectedIndex = clearCombo;
                    termsComboBox.SelectedIndex = clearCombo;
                    selectedUserComboBox.Text = "";
                    display_data();
                    fillSelectUserComboBox();

                    MessageBox.Show("Account Deleted Successfully!", "Success!");

                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu m1 = new Menu(actualRole, loggedInUsername);
            Admin a1 = new Admin(actualRole, loggedInUsername);
            encdec encdecForm = new encdec(actualRole, loggedInUsername);
            Account_Management accountForm = new EncryptionDecryption.Account_Management(actualRole, loggedInUsername);

            //Trying to make it go back to admin panel if admin...
            if (accountForm.actualRole == "Admin")
            {
                this.Hide();
                a1.ShowDialog();
            }
            else
            {
                this.Hide();
                m1.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            inputValidation();

            if (validInput == true)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Login set Username= '" + txtUsername.Text + "',Password='" + txtPassword.Text + "',Role='" + roleComboBox.Text + "',Terms='" + termsComboBox.Text + "' where Username='" + selectedUserComboBox.SelectedItem.ToString() + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    display_data();
                    fillSelectUserComboBox();

                    int clearCombo = -1;

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    confirmPasswordTextBox.Text = "";
                    roleComboBox.SelectedIndex = clearCombo;
                    termsComboBox.SelectedIndex = clearCombo;

                    MessageBox.Show("Account Successfully Updated!", "Success!");
                }
                catch (SqlException exp)
                {
                    // Log what you need from here.
                    //throw new InvalidOperationException("", exp);
                    MessageBox.Show("Duplicate Usernames are not allowed! All usernames must be unique!", "Account Update Error!");
                    con.Close();
                }

            }

            //Reset Bool
            validInput = false;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If user selected is not empty...
            if (selectedUserComboBox.Text != "")
            {
                showPasswordCheckBox.Checked = false;
                txtUsername.Enabled = false;
                confirmPasswordTextBox.Text="";
                termsComboBox.Enabled = true;
                //If logged in user is owner...
                if (loggedInUsername == "admin")
                {
                    roleComboBox.Enabled = true;
                    usernameHintLabel.Text = "(Usernames are unique and binded with the keys and cannot be change!)";
                    termsHintLabel.Text = "";
                    btnInsert.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {       //If user is anyone but the owner (clients)
                    if (selectedUserComboBox.Text == "admin" && loggedInUsername != "admin")
                    {
                        txtPassword.Enabled = false;
                        confirmPasswordTextBox.Enabled = false;
                        termsComboBox.Enabled = false;
                        termsHintLabel.Text = "";
                    }
                    else if (selectedUserComboBox.Text != "admin")
                    {
                        confirmPasswordTextBox.Enabled = true;
                        txtPassword.Enabled = true;
                        roleComboBox.Enabled = false;
                        btnInsert.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        termsComboBox.Enabled = true;
                        usernameHintLabel.Text = "(Usernames are unique and binded with the keys and cannot be change!)";
                        termsHintLabel.Text = "";

                    }
                }
                
            }
            else if (selectedUserComboBox.Text == "")
            {
                //Clear Items in fields...
                int clearCombo = -1;

                txtUsername.Enabled = true;
                txtUsername.Text = "";
                txtPassword.Text = "";
                confirmPasswordTextBox.Text = "";
                roleComboBox.SelectedIndex = clearCombo;
                termsHintLabel.Text = "(A New user must read the terms and conditions to use this program!)";
                termsComboBox.SelectedItem = "show";
                termsComboBox.Enabled = false;

                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtUsername.Enabled = true;


                if (loggedInUsername == "admin")
                {
                    roleComboBox.Enabled = true;
                }
                else
                {
                    roleComboBox.Enabled = false;
                }
            }

            if (selectedUserComboBox.Text == "admin")
            {
                MessageBox.Show("You cannot delete this account as this is the database admins account", "Note");
                btnDelete.Enabled = false;
            }
            else if (selectedUserComboBox.Text != "admin")
            {
                btnDelete.Enabled = true;
            }


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
                cmd.CommandText = "SELECT * FROM Login where Username='" + selectedUserComboBox.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtUsername.Text = dr["Username"].ToString();
                    //Dont show admins the password...
                    //txtPassword.Text = dr["Password"].ToString();
                    roleComboBox.Text = dr["Role"].ToString();
                    termsComboBox.Text = dr["Terms"].ToString();
                }
                con.Close();
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void termsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckBox.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                confirmPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                confirmPasswordTextBox.UseSystemPasswordChar = true;
            }

        }
    }
}
