using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

namespace EncryptionDecryption
{
    public partial class Login : Form
    {
        string contextFilePath;
        int argumentsPassed;

        string role;
        string loggedInUsername;
        string tandcStatus;

        public Login()
        {
            InitializeComponent();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            

            //Doesnt work atm need it remove the context view in explorer after quiting program...
            //Registry.ClassesRoot.DeleteSubKey(@"*\shell\Yasin's Encryptor");
            //Registry.ClassesRoot.DeleteSubKeyTree(@"*\shell");

            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(loggedInUsername, role);

            //FOR ICONS WHEN U RIGHT CLICK OPEN WITH MY PROGRAM ONCE ALL .YAS will become my icon... NO NEED for these keys.. i think...

            //How it works it literally create then edit or create again untill you want to add in that directory like belows icon...
            //For folders dont use * just use \shell...
            //RegistryKey key;

            //////Encryption context menu...
            //key = Registry.ClassesRoot.CreateSubKey(@".yas");
            //key.SetValue("", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key.SetValue("Icon", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key.SetValue("DefaultIcon", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key.SetValue("Default", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");

            //key = Registry.ClassesRoot.CreateSubKey(@".yas\DefaultIcon");
            //key.SetValue("", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key.SetValue("Icon", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key.SetValue("DefaultIcon", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key.SetValue("Default", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");





            //////key.SetValue("", "Encrypt|Decrypt with YasEnc");
            ////////Will need to change icon file location when putting program in release mode...

            //key = Registry.ClassesRoot.CreateSubKey(@"*\shell\Yasin's Encryptor\command");
            //key.SetValue("",Application.ExecutablePath + " %1" + " %*");

            //Run this on later build of this program to get rid of contextmenu item fomr explorer by deleting shell keys...
            //Registry.ClassesRoot.DeleteSubKeyTree(@".YAS\shell");


            //Count the commandlineargs... Need a smarter number than 10000...
            try
            {
                for (argumentsPassed = 0; argumentsPassed < 10000; argumentsPassed++)
                {
                    string argscounter = Path.GetFullPath(Environment.GetCommandLineArgs()[argumentsPassed]);

                    //File Path...
                    testing.Text = argscounter.ToString();

                    //How many arguments...
                    testtwo.Text = argumentsPassed.ToString();
                }
            }
            catch
            {
                //Reason why we have to minus 1 is because we dont want to add the [0] because that is the exe path in cmndlineargs...
                argumentsPassed--;
            }

            //Create a vector like in c# a list...
            List<String> commandLineArguments = new List<string>();

            for (int i = 1; i <= argumentsPassed; i++)
            {
                commandLineArguments.Add(Path.GetFullPath(Environment.GetCommandLineArgs()[i]));
            }

            //Test file path from an arguments debug... Over here 0 will be exe path too rmmba...
            //testThree.Text = commandLineArguments[1];




            //Get command file path...
            //string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
            //testing.Text = path;

            //http://stackoverflow.com/questions/27088510/implement-explorer-contextmenu-and-pass-multiple-files-to-one-program-instance
            //Method 1 here works to get multiple arguments but the problem is we have to deal with many have been sent etc...
            //string pathTWO = Path.GetFullPath(Environment.GetCommandLineArgs()[2]);
            //testtwo.Text = pathTWO;

            //string pathThree = Path.GetFullPath(Environment.GetCommandLineArgs()[3]);
            //testThree.Text = pathThree;

            //Decryption context menu...
            //key = Registry.ClassesRoot.CreateSubKey(@".yas");
            //key = Registry.ClassesRoot.CreateSubKey(@".yas\DefaultIcon");
            //key.SetValue("", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key = Registry.ClassesRoot.CreateSubKey(@".yas\shell");
            //key = Registry.ClassesRoot.CreateSubKey(@".yas\shell\Yasin's Encrpytor");
            //key.SetValue("", "Decrypt with Yasin's Encryptor");
            //key.SetValue("Icon", @"C:\Users\Yasin Amin\Desktop\Project\Project\Graphicloads-Flat-Finance-Lock.ico");
            //key = Registry.ClassesRoot.CreateSubKey(@".yas\shell\Yasin's Encrpytor\command");
            //key.SetValue("", Application.ExecutablePath + "%1");
            //key.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This will change according to name and file installation directory...
            //string installationDirectory = (@"C:\Program Files (x86)\Yasin Amin\Installer\Accounts.mdf");

            //Debug
            //string installationDirectory = (@"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf");

            //Upgraded localdb to 2016 was using 2012 for some reason... Below is new string for 2016
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf"; Integrated Security = True; Connect Timeout = 30

            //Trying to get the users installation directory...
            //string appFileName = Environment.GetCommandLineArgs()[0]; // Get location of exe...

            //Release mode use....
            //string installationDirectory = Application.StartupPath + @"\Accounts.mdf"; // get directory of programs start... So we take directory and add the db name...

            //Application.ExecutablePath(includes filename)
            //Application.StartupPath(not includes filename) 
            //Debug Mode DB location... (Textbox Deleted)
            //DBLocation.Text = installationDirectory;

            //Below is the connection string when using SQL Express
            //(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + installationDirectory + "; Integrated Security=True;Connect Timeout=30;User Instance=True;");

            //REMEMBER TO CHANGE THIS BELOW WHEN MAKING ANY CHANGES AT ALL TO DATABASE (REALISING WE ARE USING INSTALLED DIRECTORY DB EVEN IN DEBUG!)
            //Connection to the database using the installation directory string I made above...
            try
            {

                //Release mode use....
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Accounts.mdf; Integrated Security = True;");

                //Debug Mode...
                SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");

                //Data adapter to be able to fetch the data from the table...
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Role FROM Login WHERE Username='" + txt_UserName.Text + "' AND Password ='" + txt_Password.Text + "'", con);

            //Initializes a new instance of the DataTable class with no arguments...
            DataTable dt = new DataTable();

            //Adds or refreshes rows in the Database...
            //Need to add exception handling for database connection...
            //try
            //{
            sda.Fill(dt);
            // }
            //catch (InvalidCastException e)
            // {
            //    MessageBox.Show("Error Connecting to Database! Please check database location", "Failed Connecting to Database");
            // }
           

            //Because our query is returning only one row, If you run sql server manager and execue your query you would get one row...
            if (dt.Rows.Count == 1)
            {
                    foreach (DataRow dr in dt.Rows)
                    {
                        role = dr["Role"].ToString();


                        //If we do get that one row which means match the username password with what user gave us then its successful login...
                        MessageBox.Show("You have successfully logged in!", "Login Success!");

                        //Sending username everywhere...
                         string username = txt_UserName.Text;


                        //Send userloggedin and status to all forms...
                        Menu menuForm = new EncryptionDecryption.Menu(role,username);
                        Admin adminForm = new EncryptionDecryption.Admin(role,username);
                        encdec encdecForm = new EncryptionDecryption.encdec(role, username);
                        Account_Management accountForm = new EncryptionDecryption.Account_Management(role, username);
                        Key_Management keyForm = new EncryptionDecryption.Key_Management(role, username);
                        StegonagraphyForm stegForm = new EncryptionDecryption.StegonagraphyForm(role, username);
                        TandC tandcForm = new EncryptionDecryption.TandC(role, username);

                        //http://stackoverflow.com/questions/20743121/how-can-i-get-sql-result-into-a-string-variable
                        //Read the tandc status and show forms accordingly...
                        
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT Terms FROM Login WHERE Username='" + txt_UserName.Text + "' AND Password ='" + txt_Password.Text + "'";
                        SqlDataReader myreader;

                        con.Open();
                        myreader = cmd.ExecuteReader();
                        tandcStatus = cmd.ToString();
                        while (myreader.Read())
                        {
                            tandcStatus = myreader.GetString(0);

                        }
                        con.Close();

                        //Take the username of the person who is logged in for temp so we can log in via this when using taskbar...
                        loggedInUsername = txt_UserName.Text;


                        //Show admin panel when admin logs in...
                        //True means user doesnt want to see tandc again...
                        string dontshowtandc = "dontshow";
                        string admin = "Admin";
                        string client = "Client";

                        if (role == admin && tandcStatus == dontshowtandc)
                        {
                            this.Hide();
                            try
                            {
                                //Instead of shortcuts lets keep it clean and get full path... (RELEASE)
                                string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
                                contextFilePath = path;

                                //Debugging...
                                //contextFilePath = @"C:\Users\Yasin Amin\Desktop\Test Files\Test Video.flv";
                            }

                            catch (Exception ex)
                            {
                                contextFilePath = "";
                            }

                            if (contextFilePath == "")
                            {
                                adminForm.ShowDialog();
                            }
                            else if (contextFilePath != "")
                            {
                                //For context view temporarily we will take users directly to enc/dec...
                                //adminForm.ShowDialog();
                                encdecForm.ShowDialog();
                            }



                        }
                        else if (role == admin && tandcStatus != dontshowtandc)
                        {
                            this.Hide();
                            tandcForm.ShowDialog();
                        }

                        else if (role == client && tandcStatus == dontshowtandc)
                        {
                            this.Hide();
                            try
                            {
                                //Instead of shortcuts lets keep it clean and get full path... (RELEASE)
                                string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
                                contextFilePath = path;

                                //Debugging...
                                //contextFilePath = @"C:\Users\Yasin Amin\Desktop\Test Files\Test Video.flv";
                            }

                            catch (Exception ex)
                            {
                                contextFilePath = "";
                            }

                            if (contextFilePath == "")
                            {
                                menuForm.ShowDialog();
                            }
                            else if (contextFilePath != "")
                            {
                                //For context view temporarily we will take users directly to enc/dec...
                                //adminForm.ShowDialog();
                                encdecForm.ShowDialog();
                            }

                        }
                        else if (role == client && tandcStatus != dontshowtandc)
                        {
                            this.Hide();
                            tandcForm.ShowDialog();
                        }
                    }

                }
            //If no rows have been returned after executing the SQL query then username pass does not match meaning its a incorrect...
            else
            {
                MessageBox.Show("Incorrect Username and Password!", "Login Error!");

                    //Reset our loggedinusername because its not correct so its useless...
                    loggedInUsername = null;
                    

                //If the username/password is incorrec then highlight the txtbox with the length of txt already inputted.

                //Selection meaning highlighting of text will start from the the begining of the word...
                txt_UserName.SelectionStart = 0;
                //And to be able to highlight whole field we will higihlight the whole length of the text field...
                txt_UserName.SelectionLength = txt_UserName.Text.Length;
                //Same with the password field...
                txt_Password.SelectionStart = 0;
                txt_Password.SelectionLength = txt_Password.Text.Length;
            }

            con.Close();

            }
            catch (SqlException exp)
            {
                // Log what you need from here.
                //throw new InvalidOperationException("", exp);
                MessageBox.Show("Please ensure the LocalDb database thats came with the program (Accounts.mdf) exists where the program has been installed", "Database Connection Error !");
            }
        }
    

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            //So users cant visibly see the password we will make the input into an asterisk...
            txt_Password.PasswordChar = '*';
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
        }

        private void tandctxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        //    //Menu menuForm = new EncryptionDecryption.Menu("", "");
        //    //Admin adminForm = new EncryptionDecryption.Admin("", "");
        //    if (loggedInUsername == null || role == null)
        //    {
        //        MessageBox.Show("User not logged in!", "Please Login");
        //        Show();
        //    }

        //    if (loggedInUsername != null && role != null)
        //    {

        //        //Send userloggedin and status to all forms...
        //        Menu menuForm = new EncryptionDecryption.Menu(role, loggedInUsername);
        //        Admin adminForm = new EncryptionDecryption.Admin(role, loggedInUsername);
        //        encdec encdecForm = new EncryptionDecryption.encdec(role, loggedInUsername);
        //        Account_Management accountForm = new EncryptionDecryption.Account_Management(role, loggedInUsername);
        //        Key_Management keyForm = new EncryptionDecryption.Key_Management(role, loggedInUsername);
        //        StegonagraphyForm stegForm = new EncryptionDecryption.StegonagraphyForm(role, loggedInUsername);
        //        TandC tandcForm = new EncryptionDecryption.TandC(role, loggedInUsername);

        //        //Sending the trainer the current users name and role... Name to save picture and role to go back to right menu...
        //        //FaceRecognitionLoginForm facerecLoginForm = new EncryptionDecryption.FaceRecognitionLoginForm(role, loggedInUsername);
        //        //FaceRecognitionTrainingForm trainingForm = new EncryptionDecryption.FaceRecognitionTrainingForm(facerecLoginForm, role, loggedInUsername);

        //        //This works...
        //        //MessageBox.Show("Logged in Username: " + loggedInUsername + "\nLogged in Role: " + role);

        //        //Trying to see if we can reuse above code...
        //        //Show admin panel when admin logs in...
        //        //True means user doesnt want to see tandc again...
        //        string dontshowtandc = "dontshow";
        //        string admin = "Admin";
        //        string client = "Client";

        //        if (role == admin && tandcStatus == dontshowtandc)
        //        {
        //            this.Hide();
        //            try
        //            {
        //                //Instead of shortcuts lets keep it clean and get full path... (RELEASE)
        //                string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
        //                contextFilePath = path;

        //                //Debugging...
        //                //contextFilePath = @"C:\Users\Yasin Amin\Desktop\Test Files\Test Video.flv";
        //            }

        //            catch (Exception ex)
        //            {
        //                contextFilePath = "";
        //            }

        //            if (contextFilePath == "")
        //            {
        //                adminForm.ShowDialog();
        //            }
        //            else if (contextFilePath != "")
        //            {
        //                //For context view temporarily we will take users directly to enc/dec...
        //                //adminForm.ShowDialog();
        //                encdecForm.ShowDialog();
        //            }



        //        }
        //        else if (role == admin && tandcStatus != dontshowtandc)
        //        {
        //            this.Hide();
        //            tandcForm.ShowDialog();
        //        }

        //        else if (role == client && tandcStatus == dontshowtandc)
        //        {
        //            this.Hide();
        //            try
        //            {
        //                //Instead of shortcuts lets keep it clean and get full path... (RELEASE)
        //                string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
        //                contextFilePath = path;

        //                //Debugging...
        //                //contextFilePath = @"C:\Users\Yasin Amin\Desktop\Test Files\Test Video.flv";
        //            }

        //            catch (Exception ex)
        //            {
        //                contextFilePath = "";
        //            }

        //            if (contextFilePath == "")
        //            {
        //                menuForm.ShowDialog();
        //            }
        //            else if (contextFilePath != "")
        //            {
        //                //For context view temporarily we will take users directly to enc/dec...
        //                //adminForm.ShowDialog();
        //                encdecForm.ShowDialog();
        //            }

        //        }
        //        else if (role == client && tandcStatus != dontshowtandc)
        //        {
        //            this.Hide();
        //            tandcForm.ShowDialog();
        //        }

        //        WindowState = FormWindowState.Normal;
        //    }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the user is closing the form with the UI then just minimize dont exit program...
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Can have dont have to ask Li...
            //Delete context menu in windows explorer...
            //Registry.ClassesRoot.DeleteSubKeyTree(@"*\shell");

            //Fixed the multiple minimized icon in taskbar problem...
            minimizedIcon.Dispose();

            Application.ExitThread();
            
        }

        private void testtwo_TextChanged(object sender, EventArgs e)
        {

        }

        private void testing_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcomeForm = new Welcome();
            welcomeForm.ShowDialog();
        }
    }
}
