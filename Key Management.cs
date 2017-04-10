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
    public partial class Key_Management : Form
    {
        //Release mode use....
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Accounts.mdf; Integrated Security = True;");

        //Debug Mode...
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");

        string actualRole;
        string loggedInUsername;
        public Key_Management(string role, string username)
        {
            loggedInUsername = username;
            actualRole = role;
            InitializeComponent();
        }

        private void Key_Management_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Key_Management_Load(object sender, EventArgs e)
        {

            //Set username...
            usernameLabel.Text += loggedInUsername;
            //Set Status...
            accountStatusLabel.Text += actualRole;

            //Fill Selected key combo box...
            fillSelectedKeyComboBox();

            //Fill Grid...
            display_data();

        }

        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Keys WHERE Username ='" + loggedInUsername + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
            Menu m1 = new Menu(actualRole, loggedInUsername);
            Admin a1 = new Admin(actualRole, loggedInUsername);
            //encdec encdecForm = new encdec(actualRole, loggedInUsername);

            //Trying to make it go back to admin panel if admin...
            if (actualRole == "Admin")
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
        public void fillSelectedKeyComboBox()
        {
            //Clear Selected user combo box...
            keyComboBox.Items.Clear();
            keyComboBox.Items.Add("");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
            cmd.CommandText = "SELECT * FROM Keys where Username='" + loggedInUsername + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                //Here we are using string manipulation to remove _userloggedin from keyname users dont need to see that...
                //Last index of is any part of the string after and including _ to remove everything after _ it would be  IndexOf("/")+1); instead...

                //keyComboBox.Items.Add(dr["KeyName"]).ToString();

                //String manipulation working like a charm now...
                var keyName = dr["KeyName"].ToString();
                keyComboBox.Items.Add(keyName = keyName.Remove(keyName.LastIndexOf(".")));
            }
            con.Close();

        }

        private void selectedUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (keyComboBox.Text != "")
            {
                keyTextBox.Enabled = false;
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else if (keyComboBox.Text == "")
            {
                keyTextBox.Enabled = true;
                btnInsert.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
            cmd.CommandText = "SELECT * FROM Keys where Username='" + loggedInUsername + "' AND KeyName ='" + keyComboBox.Text + ".yas_" + loggedInUsername + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {

                //keyNameTextBox.Text = dr["KeyName"].ToString();
                //String manipulation working like a charm now...
                var keyName = dr["KeyName"].ToString();
                keyNameTextBox.Text = keyName.Remove(keyName.IndexOf("."));

                keyTextBox.Text = dr["Key"].ToString();

            }
            
            con.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (keyNameTextBox.Text == "")
            {
                MessageBox.Show("Key Name cannot be empty!", "Incorrect Key Name");
            }
            else if (keyTextBox.Text == "")
            {
                MessageBox.Show("Key cannot be empty!", "Incorrect Key");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Keys VALUES ('" + loggedInUsername + "','" + keyNameTextBox.Text + ".yas_" + loggedInUsername + "','" + keyTextBox.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    display_data();
                    fillSelectedKeyComboBox();

                    //CAN MAKE THIS INTO A FUNCTIONS TO CLEAR ALL CONTENTS OF BOXES... can save space and more efficiency
                    int clearCombo = -1;

                    keyNameTextBox.Text = "";
                    keyTextBox.Text = "";
                    keyComboBox.SelectedIndex = clearCombo;

                    MessageBox.Show("Key Created!", "Success!");
                }
                catch (SqlException exp)
                {
                    // Log what you need from here.
                    //throw new InvalidOperationException("", exp);
                    MessageBox.Show("Duplicate Key Names are not allowed! All Key Names must be unique!", "Key Creation Error!");
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Keys set Username= '" + loggedInUsername + "',KeyName='" + keyNameTextBox.Text +"_"+ loggedInUsername + "' where Username='" + loggedInUsername + "' AND KeyName ='" + keyComboBox.Text+ ".yas_" + loggedInUsername + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                display_data();
                fillSelectedKeyComboBox();

                int clearCombo = -1;

                keyComboBox.SelectedIndex = clearCombo;
                keyNameTextBox.Text = "";
                keyTextBox.Text = "";

                MessageBox.Show("Key Successfully Updated!", "Success!");
           
                btnInsert.Enabled = true;
                keyTextBox.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete key " + keyComboBox.Text + "? \nNOTE: The key will be deleted FOREVER!!!", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE From Keys where Username= '" + loggedInUsername + "' AND KeyName ='" + keyComboBox.Text + ".yas_" + loggedInUsername + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                int clearCombo = -1;
                keyNameTextBox.Text = "";
                keyTextBox.Text = "";
                keyComboBox.SelectedIndex = clearCombo;
                keyComboBox.Text = "";
                display_data();
                fillSelectedKeyComboBox();

                btnInsert.Enabled = true;
                keyTextBox.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Key Deleted Successfully!", "Success!");
            }
            else if (dialogResult == DialogResult.No)
            {
                dialogResult = DialogResult.Cancel;
            }

        }

        private void keyNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
