using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

namespace EncryptionDecryption
{

    public partial class encdec : System.Windows.Forms.Form
    {
        //Release mode use....
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = " + Application.StartupPath + @"\Accounts.mdf; Integrated Security = True;");

        //Debug Mode...
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");

        string key;
        string actualRole;
        string loggedInUsername;
        public static int argumentsPassed;
        public static List<String> commandLineArguments = new List<string>();


        public encdec(string role, string username)
        {
            loggedInUsername = username;
            actualRole = role;
            InitializeComponent();
            key = generateKey();


        }

        private string generateKey()
        {
            // Create a new DESCryptoServiceProvider object
            // to generate a key and initialization vector (IV).

            //DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            AesCryptoServiceProvider aesCrypto = new AesCryptoServiceProvider();

            //Create key of size 256 which will be 16/32 characters long...
            //aesCrypto.BlockSize = 128;
            //aesCrypto.KeySize = 256;

            //aesCrypto.GenerateKey();
            //AesCryptoServiceProvider.Create();

            //AesCryptoServiceProvider.Create();
            //return ASCIIEncoding.ASCII.GetString(desCrypto.Key);

            //Has to be ascii to save to DB...
            return System.Text.UTF8Encoding.Unicode.GetString(aesCrypto.Key);
        }

        private void button1_Click(object sender, EventArgs e)
        {




            //If not right clicked to open program...
            if (contextFilePath.Text == "")
            {

                //Open File to be Encrypted Location...
                OpenFileDialog open = new OpenFileDialog();
                //Text on left is the name of the file extension that i will be filtering there after | then the actual format with dot
                //open.Filter = "All Valid Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.txt;*.pdf;*.mp4;*.flv; |Text Documents (*.txt)|*.txt |PDF (*.pdf*)|*.pdf";


                if (open.ShowDialog() == DialogResult.OK)
                {

                    //txtLocalEncFile.Text = open.FileName;
                    string localEncFile = open.FileName;
                    string fileNameOnly = open.SafeFileName;

                    //Fixes selecting a already encrypted file... We want to keep file extension...
                    //if (open.SafeFileName.Contains("."))
                    //{
                    //    fileNameOnly = open.SafeFileName.Remove(open.SafeFileName.LastIndexOf("."));
                    //}

                    //Open Save File Location...
                    SaveFileDialog save = new SaveFileDialog();
                    //if (save.ShowDialog() == DialogResult.OK)
                    //{
                    //localEncFile = localEncFile.Remove(localEncFile.LastIndexOf("\\"));
                    string newEncFile = localEncFile.Remove(localEncFile.LastIndexOf("\\")) + "\\" + fileNameOnly + ".yas";
                    encrypt(localEncFile, newEncFile, key);

                    //}
                    //else
                    //{
                    //User pressed cancel
                    // MessageBox.Show("Please Choose a valid save Location & a Valid File name!");
                    //txtLocalEncFile.Text = null;
                    //}
                }

                else
                {
                    //User pressed cancel
                    MessageBox.Show("No File Selected to Encrypt!");
                }
            }


            //If the program was opened by right click service
            else if (contextFilePath.Text != "")
            {

                //Need a proper way to find out if this is a folder or not...
                if (contextFilePath.Text.Contains(".") == false)
                {
                    try
                    {
                        string fileNameOnly = Path.GetFullPath(contextFilePath.Text) + (".zip");

                        ZipFile.CreateFromDirectory(contextFilePath.Text, fileNameOnly, CompressionLevel.Fastest, true);

                        contextFilePath.Text = contextFilePath.Text + (".zip");

                        btnEncrypt.PerformClick();

                    }
                    catch
                    {

                    }

                }

                string localEncFile = contextFilePath.Text;

                //.Remove(localEncFile.LastIndexOf(".")) Removed from line below because we want to keep the file extension after decryption...
                string newEncFile = localEncFile + ".yas";

                encrypt(localEncFile, newEncFile, key);

                //TEMP DISABLED...
                //We want to clear our args and restart program hidden...
                //https://msdn.microsoft.com/en-us/library/system.diagnostics.processstartinfo.windowstyle(v=vs.110).aspx
                //ProcessStartInfo executablePath = new ProcessStartInfo(Application.ExecutablePath);
                //executablePath.WindowStyle = ProcessWindowStyle.Minimized;
                //Process.Start(executablePath);

                //EXIT after context encryption...
                Application.ExitThread();

                //http://stackoverflow.com/questions/779405/how-do-i-restart-my-c-sharp-winform-application

                //We can start program by doing this so we can clean our commandline arguments...
                //System.Diagnostics.Process.Start(Application.ExecutablePath);


            }



        }

        // Encrypt text to a file using the file name, key, and IV ( initialization vector ).
        private void encrypt(string input, string output, string strHash)
        {
            try
            {
                if (input.Contains(".zip"))
                {
                    //Debugging...
                    //MessageBox.Show("Its a zip deleting original folder...");

                    //Delete original folder after encryption...
                    string originalFolder = contextFilePath.Text.Remove(contextFilePath.Text.LastIndexOf("."));
                    Directory.Delete(originalFolder , true);
                }

                //Prepare streams for input output of file...
                FileStream inStream, outStream;

                //Defines a stream that links data streams to cryptographic transformations.
                CryptoStream CryStream;

                //Defines a wrapper object to access the cryptographic service provider (CSP) version of the TripleDES algorithm
                //TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
                AesCryptoServiceProvider AES = new AesCryptoServiceProvider();

                //Computes the MD5 hash value for the input data using the implementation provided by the cryptographic service provider (CSP)
                //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();

                byte[] byteHash, byteText;

                //Read and Write to files Streams...
                inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(output, FileMode.Create, FileAccess.Write);

                // Computes the hash value for the specified Stream object.
                //byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
                byteHash = sha.ComputeHash(UnicodeEncoding.Unicode.GetBytes(strHash));

                //Read all bytes in file...
                byteText = File.ReadAllBytes(input);

                //Releases all resources used by the HashAlgorithm class
                sha.Clear();

                //Gets or sets the secret key for the TripleDES algorithm.(Inherited from TripleDES.)
                //TDC.Key = byteHash;
                AES.Key = byteHash;

                //Gets or sets the mode for operation of the symmetric algorithm.(Inherited from SymmetricAlgorithm.)
                //TDC.Mode = CipherMode.ECB;
                //The simplest of the encryption modes is the Electronic Codebook (ECB) mode. The message is divided into blocks, and each block is encrypted separately.
                AES.Mode = CipherMode.ECB;
                //There are many disadvantages of ECB like detection when inserting blocks into encrypted, and does not completely encrypt into randomness
                //It has many repitions of blocks so can be broken one cipher text block at a time... 
                //CBC and CTR are alternatives to be looked at ...

                //// Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                //CryStream = new CryptoStream(outStream, TDC.CreateEncryptor(), CryptoStreamMode.Write);
                CryStream = new CryptoStream(outStream, AES.CreateEncryptor(), CryptoStreamMode.Write);

                //Amount of bytes been read from the file..
                int bytesRead;

                //Length of the file variable so we can read read untill file finishes...
                long length, position = 0;
                length = inStream.Length;

                //We will keep reading untill the end (Read below how)...
                while (position < length)
                {
                    //Read from begining till the length of the text meaning till the end...
                    bytesRead = inStream.Read(byteText, 0, byteText.Length);

                    //Update position and we are in a while loop to keep reading untill we reach the end..
                    position += bytesRead;

                    //// Write the byte array to the crypto stream and flush it.
                    CryStream.Write(byteText, 0, bytesRead);

                    //This is so we dont miss any block in the file left so everything is read...
                    CryStream.FlushFinalBlock();

                }

                // Close the streams and
                // close the file.
                inStream.Close();
                outStream.Close();

                string filename = Path.GetFileName(input);

                //Save key to database...
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //Few hours of problems came to the role was the whole string "Logged in as ..." 
                    //This never let it worked now its works after chaning role to just one word which is the role itself...
                    http://stackoverflow.com/questions/20859787/html-symbols-are-being-displayed-as-a-question-mark-in-sql-server-database
                         //Used N to indicate unicode chars...
                    cmd.CommandText = "INSERT INTO Keys VALUES ('" + loggedInUsername + "','" + filename + ".yas" + "_" + loggedInUsername + "',N'" + key + "')";

                    //cmd.CommandText = "UPDATE Login SET Terms='" + TermsDontShow + "' WHERE Username = '" + actualrole + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //its case sensitve  no so make sure you have the tables and colums in correct case as database 
                    //change it back to varchar

                    //saveKeyToDB.Enabled = false;
                    //keyNameTextBox.Enabled = false;
                    MessageBox.Show("Key Succesfully Saved to Database!", "Key Saved!");
                    //updateComboBox();

                    MessageBox.Show("The File " + filename + " Has Been Successfully Encrypted!", "Successfully Encrypted File!");

                    //Create new key on each encryption which will give us new keys when encryting batch of files...
                    //Had problems because i put this before enc for some reason its meant to always be after that we reset
                    key = generateKey();

                    File.Delete(input);

                   


                }

                


                catch (SqlException exp)
                {
                    // Log what you need from here.
                    //throw new InvalidOperationException("", exp);
                    MessageBox.Show("Duplicate key names are not allowed! , Please choose a file name which has not been used before on your account", "Error Saving Key to Database !");
                    con.Close();

                    //Rollback and clean failed encryption file...
                    File.Delete(output);
                    return;
                }


                //TEMP DISABLED GIVING OPTION TO DELETE ORIGINAL FILE...
                //DialogResult dialogResult = MessageBox.Show("Do you want to delete the original file " + filename + "?\nYou wont be able to get the original file back once deleted!!!", "Are you sure?", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    //DELETE ORGINAL NEED TO MAKE THIS AFTER SUCCESFUL ENCRYPTION ASK USER IF THEY WANT TO DELETE ORIGINAL...
                //    File.Delete(input);

                //    //Message to user on success
                //    MessageBox.Show("The File " + filename + " Has Been Successfully Encrypted!", "Successfully Encrypted File!");
                //}
                //else if (dialogResult == DialogResult.No)
                //{

                //    //Message to user on success
                //    MessageBox.Show("The File " + filename + " Has Been Successfully Encrypted!", "Successfully Encrypted File!");
                //}

                //key_Save.Enabled = true;
                //keyNameTextBox.Enabled = true;

                ////Show encdec key...
                //txtEncDecKey.Text = key;

                ////Reset the filenames on success...
                //txtLocalEncFile.Text = null;
                //txtNewEncFile.Text = null;

            }

            catch (Exception ex)
            {
                MessageBox.Show("You cant encrypt an encrypted/decrypted file! \nOr else you already have encrypted version of this file in this directory!", "Error Encrypting File!");

            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {


            //Count the commandlineargs...Need a smarter number than 10000...
            try
            {
                for (argumentsPassed = 0; argumentsPassed < 10000; argumentsPassed++)
                {
                    string argscounter = Path.GetFullPath(Environment.GetCommandLineArgs()[argumentsPassed]);

                    //File Path...
                    //contextFilePath.Text = argscounter.ToString();

                    //How many arguments...
                    contextFilePath2.Text = argumentsPassed.ToString();
                }
            }
            catch
            {
                //Reason why we have to minus 1 is because we dont want to add the [0] because that is the exe path in cmndlineargs...
                argumentsPassed--;
            }


            //Create a vector like in c# a list...

            for (int i = 1; i <= argumentsPassed; i++)
            {
                commandLineArguments.Add(Path.GetFullPath(Environment.GetCommandLineArgs()[i]));
            }

            //string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);

            //Get command file path...
            //string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
            //testing.Text = path;

            //Get command file path...

            for (int i = 0; i <= argumentsPassed; i++)
            {
                try
                {   //var args = Environment.GetCommandLineArgs()[1].ToString(); //0 will be the executable path which is our program the 1 is our context menu selected file path...
                    //Instead of shortcuts lets keep it clean and get full path... (RELEASE)
                    //string path = Path.GetFullPath(Environment.GetCommandLineArgs()[1]);
                    //contextFilePath.Text = path;

                    //Debugging commdlinesargs...
                    //string secondContextPathTest = Path.GetFullPath(Environment.GetCommandLineArgs()[2]);
                    //contextFilePath2.Text = secondContextPathTest;

                    //Debugging...
                    //contextFilePath.Text = @"C:\Users\Yasin Amin\Desktop\Test Files\Test File.yas";

                    //Use our list now as context filepath...
                    contextFilePath.Text = commandLineArguments[i];


                if (contextFilePath.Text.Contains(".yas"))
                    {
                        string localDecFile = contextFilePath.Text;
                        string newDecFile = localDecFile.Remove(localDecFile.LastIndexOf("."));
                        string decKeyName = localDecFile.Substring(localDecFile.LastIndexOf("\\") + 1);
                        SaveFileDialog save = new SaveFileDialog();

                        try
                        {
                            con.Open();
                            //string dbKey;
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            //Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
                            //The reason why i did AND KeyName ='" + keysComboBox.SelectedItem.ToString() +"_"+loggedInUsername + "'"; is because when using string manipulation we remove _userloggedin
                            //But now because we have remove that _userloggedin we need to concatenate the keyname with the username...
                            cmd.CommandText = "SELECT [Key] FROM Keys WHERE Username='" + loggedInUsername + "' AND KeyName ='" + decKeyName + "_" + loggedInUsername + "'";
                            SqlDataReader myreader;

                            myreader = cmd.ExecuteReader();
                            currentKey.Text = cmd.ToString();
                            while (myreader.Read())
                            {
                                key = myreader.GetString(0);
                            }
                            con.Close();

                            //Set found key to public key...
                            //key = Key.ToString();
                            //txtKeyOpen.Text = dbKey;
                            btnDecrypt.Enabled = true;
                            //key = txtKeyOpen.Text;
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("An Error Has Occured When Trying to Find Decryption!");
                        }

                        decrypt(localDecFile, newDecFile, key);
                        //Reset Form Fields...
                        currentKey.Text = key.ToString();

                        //After context decryption...
                        Application.ExitThread();

                    }
                    else if (contextFilePath.Text != ".yas")
                    {
                        btnEncrypt.PerformClick();

                    }


                }
                catch (Exception ex)
                {
                    contextFilePath.Text = "";
                    this.Show();
                    //return;
                }

            }


            //Show current key...
            currentKey.Text = key.ToString();

            //Initial key load when form is loaded...
            //Release Mode Trying to get the users installation directory...
            //string installationDirectory = Application.StartupPath + @"\Accounts.mdf"; // get directory of programs start... So we take directory and add the db name...

            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select * from Keys where Username=('" + loggedInUsername + "')";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //Here we are using string manipulation to remove _userloggedin from keyname users dont need to see that...
            //    //Last index of is any part of the string after and including _ to remove everything after _ it would be  IndexOf("/")+1); instead...

            //    var keyName = dr["KeyName"].ToString();
            //    keysComboBox.Items.Add(keyName = keyName.ToString().Remove(keyName.LastIndexOf("_")));
            //    //keysComboBox.Items.Add(dr["KeyName"].ToString());
            //}
            //con.Close();

            //Hide form...
            //this.Close();

            //Hide...
            //this.Hide();
        }



        //public void updateComboBox()
        //{
        //    //Remove all existing items to clean up and avoid doubles...
        //    keysComboBox.Items.Clear();

        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "Select * from Keys where Username=('" + loggedInUsername + "')";
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //Same like we used for loading the form we are again using string manipulation...
        //        //keysComboBox.Items.Add(dr["KeyName"].ToString());

        //        //String Manipulation...
        //        var keyName = dr["KeyName"].ToString();
        //        keysComboBox.Items.Add(keyName = keyName.ToString().Remove(keyName.LastIndexOf("_")));
        //    }
        //    con.Close();
        //}

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            //open.ShowDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                //txtLocalDecFile.Text = open.FileName;
                string localDecFile = open.FileName;
                string nameOnly = Path.GetFileNameWithoutExtension(localDecFile);
                SaveFileDialog save = new SaveFileDialog();


                //save.ShowDialog();
                //if (save.ShowDialog() == DialogResult.OK)
                //{
                string newDecFile = localDecFile.Remove(localDecFile.LastIndexOf("\\")) + "\\" + nameOnly;
                //txtNewDecFile.Text = save.FileName;

                //Set decryption key using filename...
                try
                {
                    con.Open();
                    //string dbKey;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
                    //The reason why i did AND KeyName ='" + keysComboBox.SelectedItem.ToString() +"_"+loggedInUsername + "'"; is because when using string manipulation we remove _userloggedin
                    //But now because we have remove that _userloggedin we need to concatenate the keyname with the username...
                    cmd.CommandText = "SELECT [Key] FROM Keys WHERE Username='" + loggedInUsername + "' AND KeyName ='" + nameOnly + ".yas" + "_" + loggedInUsername + "'";
                    SqlDataReader myreader;

                    myreader = cmd.ExecuteReader();
                    currentKey.Text = cmd.ToString();
                    while (myreader.Read())
                    {
                        key = myreader.GetString(0);
                    }
                    con.Close();

                    //Set found key to public key...
                    //key = Key.ToString();
                    //txtKeyOpen.Text = dbKey;
                    btnDecrypt.Enabled = true;
                    //key = txtKeyOpen.Text;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An Error Has Occured When Trying to Find Decryption!");
                }

                decrypt(localDecFile, newDecFile, key);
                //Reset Form Fields...
                currentKey.Text = key.ToString();
                //txtEncDecKey.Text = "";
                //keyNameTextBox.Text = "";
                //txtKeyOpen.Text = "";

                //int resetCombo = -1;
                //keysComboBox.SelectedIndex = resetCombo;

                //}
                //else
                //{
                //    MessageBox.Show("Please Choose a valid save Location & a Valid File name!");
                //    //txtLocalDecFile.Text = null;
                //}
            }

            else
            {
                //User pressed cancel
                MessageBox.Show("No File Selected to Decrypt!");

            }
        }



        //Remember Decryption is excatly the same as encrpytion but using the decryptor provided by cryto library...
        //I will no comment this until the end because its not needed and is repetitive...
        // Decrypt text to a file using the file name, key, and IV ( initialization vector ).
        private void decrypt(string input, string output, string strHash)
        {
            try
            {

                FileStream inStream, outStream;
                CryptoStream CryStream;
                //TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
                AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
                //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();


                byte[] byteHash, byteTexto;

                inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

                //byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
                //strHash = System.IO.File.ReadAllText(@"C:\Users\Yasin Amin\Desktop\Key.txt"); This line is no longer needed because we are reading from txtfileforkey...
                byteHash = sha.ComputeHash(UnicodeEncoding.Unicode.GetBytes(strHash));


                byteTexto = File.ReadAllBytes(input);

                sha.Clear();

                //TDC.Key = byteHash;
                //TDC.Mode = CipherMode.ECB;

                AES.Key = byteHash;
                AES.Mode = CipherMode.ECB;

                //CryStream = new CryptoStream(outStream, TDC.CreateDecryptor(), CryptoStreamMode.Write);
                CryStream = new CryptoStream(outStream, AES.CreateDecryptor(), CryptoStreamMode.Write);

                int bytesRead;
                long length, position = 0;
                length = inStream.Length;

                while (position < length)
                {
                    bytesRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                    position += bytesRead;

                    CryStream.Write(byteTexto, 0, bytesRead);

                    //This is so we dont miss any block in the file left so everything is read...
                    CryStream.FlushFinalBlock();

                }

                inStream.Close();
                outStream.Close();

                string filename = Path.GetFileName(input);

                //Message to user on success

                MessageBox.Show("The File " + filename + " Has Been Successfully Decrypted!", "Successfully Decrypted File!");

                if (output.Contains(".zip"))
                {
                    ZipFile.ExtractToDirectory(output, output.Remove(output.LastIndexOf("\\")));
                    File.Delete(output);

                }

                //Delete encrypted file which has now succesfully been decrypted...
                File.Delete(input);
                //txtLocalDecFile.Text = null;
                //txtNewDecFile.Text = null;

            }

            catch (Exception ex)
            {
                MessageBox.Show("An Error Has Occured When Trying to Decrypt File!");
            }
        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a project being worked being worked on by Yasin Amin ");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewEncFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu m1 = new Menu(actualRole, loggedInUsername);
            this.Hide();
            m1.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit this window? \n(All unsaved keys will be lost forever!)", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Menu m1 = new Menu(actualRole, loggedInUsername);
                Admin a1 = new Admin(actualRole, loggedInUsername);
                encdec encdecForm = new encdec(actualRole, loggedInUsername);

                //Trying to make it go back to admin panel if admin...
                if (encdecForm.actualRole == "Admin")
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
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //No longer needed as it makes things too confusing and too many buttons...
        //private void key_Save_Click(object sender, EventArgs e)
        //{

        //if (key != "")
        //{
        //    SaveFileDialog save = new SaveFileDialog();
        //    save.Filter = "Text Document|*.txt";
        //    //save.ShowDialog();
        //    if (save.ShowDialog() == DialogResult.OK)
        //    {
        //        //string path = @"C:\Users\Yasin Amin\Desktop\Key.txt";
        //        string path;
        //        path = save.FileName;

        //        // Create a file to write to.
        //        string keySave = key;
        //        File.WriteAllText(path, keySave);
        //        MessageBox.Show("Key has been saved to location provided!", "Key Saved Successfully!");
        //        key_Save.Enabled = false;
        //    }
        //}
        //else
        //{
        //    MessageBox.Show("Encrypt a file to compute a key to save!", "No key computed!");
        //}

        // }

        //No longer needed as it makes things too confusing and too many buttons...
        // private void key_Open_Click(object sender, EventArgs e)
        //{
        //OpenFileDialog open = new OpenFileDialog();
        //open.Filter = "Text Document (*.txt)|*.txt";
        //if (open.ShowDialog() == DialogResult.OK)
        //{
        //    string path;
        //    path = open.FileName;
        //    //string path = @"C:\Users\Yasin Amin\Desktop\Key.txt";
        //    key = File.ReadAllText(path);
        //    txtKeyOpen.Text = key;
        //    btnDecrypt.Enabled = true;
        //}
        //else
        //{
        //    MessageBox.Show("Invalid key location!", "Error locating Key");
        //}
        //}

        private void txtEncDecKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLocalDecFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void sayKeyToDB_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    con.Open();
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    //Few hours of problems came to the role was the whole string "Logged in as ..." 
            //    //This never let it worked now its works after chaning role to just one word which is the role itself...
            //    http://stackoverflow.com/questions/20859787/html-symbols-are-being-displayed-as-a-question-mark-in-sql-server-database
            //    //Used N to indicate unicode chars...
            //    cmd.CommandText = "INSERT INTO Keys VALUES ('" + loggedInUsername + "','" + keyNameTextBox.Text + "_" + loggedInUsername+ "',N'" + key + "','" + input + "')";

            //    //cmd.CommandText = "UPDATE Login SET Terms='" + TermsDontShow + "' WHERE Username = '" + actualrole + "'";
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    //its case sensitve  no so make sure you have the tables and colums in correct case as database 
            //    //change it back to varchar

            //    saveKeyToDB.Enabled = false;
            //    keyNameTextBox.Enabled = false;
            //    MessageBox.Show("Key Succesfully Saved to Database!", "Key Saved!");
            //    updateComboBox();

            //}


            //catch (SqlException exp)
            //{
            //    // Log what you need from here.
            //    //throw new InvalidOperationException("", exp);
            //    MessageBox.Show("Duplicate key names are not allowed! , Please choose a unique key name", "Error Saving Key to Database !");
            //    con.Close();
            //}

        }

        private void keyNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //if (keyNameTextBox.Text != "")
            //{
            //    saveKeyToDB.Enabled = true;
            //}

            //if (keyNameTextBox.Text == "")
            //{
            //    saveKeyToDB.Enabled = false;
            //}

        }

        private void keysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (keysComboBox.SelectedItem!=null)
            //{
            //    openKeyFromDBButton.Enabled = true;
            //}

        }

        private void openKeyFromDBButton_Click(object sender, EventArgs e)
        {
            //con.Open();
            //string dbKey;
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            ////Have to use Key in square brackeys because key is a reserved keyword, so you must use square brackets to make it explicit that you mean the object named "Key"...
            ////The reason why i did AND KeyName ='" + keysComboBox.SelectedItem.ToString() +"_"+loggedInUsername + "'"; is because when using string manipulation we remove _userloggedin
            ////But now because we have remove that _userloggedin we need to concatenate the keyname with the username...
            //cmd.CommandText = "SELECT [Key] FROM Keys WHERE Username='" + loggedInUsername + "' AND KeyName ='" + keysComboBox.SelectedItem.ToString() + "_" + loggedInUsername+ "'";
            //SqlDataReader myreader;

            //myreader = cmd.ExecuteReader();
            //dbKey = cmd.ToString();
            //while (myreader.Read())
            //{
            //    dbKey = myreader.GetString(0);
            //}
            //con.Close();

            ////txtKeyOpen.Text = dbKey;
            //btnDecrypt.Enabled = true;
            ////key = txtKeyOpen.Text;

        }

        private void btnResetKey_Click(object sender, EventArgs e)
        {
            key = generateKey();

            //Reset Form Fields...
            currentKey.Text = key.ToString();
            //txtEncDecKey.Text = "";
            //keyNameTextBox.Text = "";
            //txtKeyOpen.Text = "";
        }

        private void currentKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKeyOpen_TextChanged(object sender, EventArgs e)
        {

        }

        private void encdec_FormClosing(object sender, FormClosingEventArgs e)
        {

            //If the user is closing the form with the UI then just minimize dont exit program...
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }


            //No longer needed as user wont be doing anything its all easy for them...
            //DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit? \nAll unsaved keys will be lost!", "Warning!", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    Application.ExitThread();
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //formclosing event made ^^^^^^ .cancel meaning user has canceled it is = to true...
            //    e.Cancel = true;
            //}
        }

        private void currentKeyLabel_Click(object sender, EventArgs e)
        {

        }
    }
}