using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace EncryptionDecryption
{
    public partial class StegonagraphyForm : Form
    {
        //Pixel data and image attributes.
        //Bitmap is an object used to work with images defined by pixel data...
        private Bitmap bmp = null;
        string actualRole;
        string loggedInUsername;
        public StegonagraphyForm(string role, string username)
        {
            loggedInUsername = username;
            actualRole = role;
            InitializeComponent();    
        }

        private void OpenImageMenuOption_Click(object sender, EventArgs e)
        {
            //OpenFileDialog open_dialog = new OpenFileDialog();

            ////Filter file formats so user cant choose wrong file...
            //open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            //if (open_dialog.ShowDialog() == DialogResult.OK)
            //{
            //    MainPictureBox.Image = Image.FromFile(open_dialog.FileName);
            //}
        }

        private void SaveImageMenuOption_Click(object sender, EventArgs e)
        {
            //SaveFileDialog save_dialog = new SaveFileDialog();

            ////Save image as png, cant save as anything else...
            ////Why png? that allows the original data to be perfectly reconstructed from the compressed data
            //save_dialog.Filter = "PNG Image|*.png";

            //if (save_dialog.ShowDialog() == DialogResult.OK)
            //{
            //    bmp.Save(save_dialog.FileName, ImageFormat.Png);
            //    secretMessageBox.Text = null;
            //    MessageBox.Show("Successfully Saved Encoded Image!", "Success!");
            //}
        }

        private void HideMessageButton_Click(object sender, EventArgs e)
        {
            //If clever clogs try to encode nothing by backspacing after getting encode button enabled recheck for null message!...
            //if (secretMessageBox.Text == (""))
            //{
            //    MessageBox.Show("Please Write a Secret Message to be Encoded into the Image!", "Warning!");

            //    return;
            //}

            //else
            //{
            HideMessageButton.Enabled = false;

            //Open file for encoding...
            OpenFileDialog open_dialog = new OpenFileDialog();

                //Filter file formats so user cant choose wrong file...
                open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

                if (open_dialog.ShowDialog() == DialogResult.OK)
                {
                    MainPictureBox.Image = Image.FromFile(open_dialog.FileName);
                }
                else
                {
                    MessageBox.Show("No Image Provided to Encode!", "Error!");
                    return;
                }

                bmp = (Bitmap)MainPictureBox.Image;
                string SecretMessage = secretMessageBox.Text;
                bmp = Stegnography.embedText(SecretMessage, bmp);

            SaveFileDialog save_dialog = new SaveFileDialog();

            //Save image as png, cant save as anything else...
            //Why png? that allows the original data to be perfectly reconstructed from the compressed data...
            save_dialog.Filter = "PNG Image|*.png";

            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmp.Save(save_dialog.FileName, ImageFormat.Png);
                }
                catch (Exception exp)
                {
                    // Log what you need from here.
                    //throw new InvalidOperationException("", exp);
                    MessageBox.Show("You cannot replace another image file when encoding! \nPlease choose a valid location to save your encoded image", "Error when Encoding!");
                    HideMessageButton.Enabled = true;
                    return;
                }
                secretMessageBox.Text = null;
                MessageBox.Show("Successfully Encoded and Saved Message into Image!", "Success!");
                MainPictureBox.Image = null;

            }

            else
            {
                MessageBox.Show("Not a Valid Save Location!", "Please Try Again");
                return;
            }
            

        }

        private void ExtractMessageButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open_dialog = new OpenFileDialog();

            //Filter file formats so user cant choose wrong file...
            open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                MainPictureBox.Image = Image.FromFile(open_dialog.FileName);
                MessageBox.Show("Message Successfully Decoded!");
                key_Save.Enabled = true;
                groupBox1.Text = "Decoded Message";
                groupBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("No Image Provided to Decode!", "Error!");
                return;
            }

            bmp = (Bitmap)MainPictureBox.Image;

            string SecretMessage = Stegnography.extractText(bmp);

            secretMessageBox.Text = SecretMessage;

            // We transition four properties simulataneously here:
            // - The two labels' text is changed.
            // - The two labels' colors are changed.

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SecretMessageBox_TextChanged(object sender, EventArgs e)
        {
            //If there is nothing in hidden message dont let them encode!
            if (secretMessageBox.Text != null)
            {
                HideMessageButton.Enabled = true;
            }

            if (secretMessageBox.Text == "")
            {
                HideMessageButton.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu m1 = new Menu(actualRole, loggedInUsername);
            Admin a1 = new Admin(actualRole, loggedInUsername);
            StegonagraphyForm stegForm = new StegonagraphyForm(actualRole, loggedInUsername);

            //Trying to make it go back to admin panel if admin...
            if (stegForm.actualRole == "Admin")
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

        private void resetButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox1.Text = "Message to be Encoded";
            secretMessageBox.Text = "";
            secretMessageBox.Enabled = true;
            HideMessageButton.Enabled = false;
            MainPictureBox.Image = null;
            
        }

        private void key_Save_Click(object sender, EventArgs e)
        {
            if (secretMessageBox.Text != "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text Document|*.txt";
                //save.ShowDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    //string path = @"C:\Users\Yasin Amin\Desktop\Key.txt";
                    string path;
                    path = save.FileName;

                    // Create a file to write to.
                    string messageSave = secretMessageBox.Text;
                    File.WriteAllText(path, messageSave);
                    MessageBox.Show("Message has been saved to location provided!", "Message Saved Successfully!");
                    key_Save.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No Message to save!", "Error Saving Message!");
            }
        }
    }
}
