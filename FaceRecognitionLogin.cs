using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Win32.SafeHandles;
using System.Security;

namespace EncryptionDecryption
{
    public partial class FaceRecognitionLoginForm : Form
    {

        string contextFilePath;
        int argumentsPassed;
        int counter = 0;

        //Debug Mode...
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + @"C:\Users\Yasin Amin\Desktop\Project\Project\Accounts.mdf" + "; Integrated Security = True;");

        public static string actualRole;
        public static string loggedInUsername;
        string terms;

        #region variables
        Image<Bgr, Byte> currentFrame; //current image aquired from webcam for display
        Image<Gray, byte> result, TrainedFace = null; //used to store the result image and trained face
        Image<Gray, byte> gray_frame = null; //grayscale current image aquired from webcam for processing

        Capture grabber; //This is our capture variable

        public CascadeClassifier Face = new CascadeClassifier(Application.StartupPath + "/Cascades/haarcascade_frontalface_default.xml");//Our face detection method 

        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5); //Our fount for writing within the frame

        int NumLabels;

        //Classifier with default training location
        Classifier_Train Eigen_Recog = new Classifier_Train();

        #endregion

        public FaceRecognitionLoginForm()
        {

            InitializeComponent();

            //Load of previus trainned faces and labels for each image

            if (Eigen_Recog.IsTrained)
            {
                message_bar.Text = "Training Data loaded";
            }
            else
            {
                message_bar.Text = "No training data found, please train program using Train menu option";
            }
            initialise_capture();

        }

        //Open training form and pass this
        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stop Camera
            stop_capture();

            //OpenForm
            FaceRecognitionTrainingForm TF = new FaceRecognitionTrainingForm(this, "","");
            TF.Show();
        }
        public void retrain()
        {

            Eigen_Recog = new Classifier_Train();
            if (Eigen_Recog.IsTrained)
            {
                message_bar.Text = "Training Data loaded";
            }
            else
            {
                message_bar.Text = "No training data found, please train program using Train menu option";
            }
        }




        //Camera Start Stop
        public void initialise_capture()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            if (parrellelToolStripMenuItem.Checked)
            {
                Application.Idle += new EventHandler(FrameGrabber_Parrellel);
            }
            else
            {
                Application.Idle += new EventHandler(FrameGrabber_Standard);
            }
        }
        private void stop_capture()
        {
            if (parrellelToolStripMenuItem.Checked)
            {
                Application.Idle -= new EventHandler(FrameGrabber_Parrellel);
            }
            else
            {
                Application.Idle -= new EventHandler(FrameGrabber_Standard);
            }
            if (grabber != null)
            {
                grabber.Dispose();
            }
        }

        //Multiple Faces...
        //Process Frame
        void FrameGrabber_Standard(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                for (int i = 0; i < facesDetected.Length; i++)// (Rectangle face_found in facesDetected)
                {
                    //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                    //of the background noise
                    facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                    facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                    facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                    facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                    result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //result = gray_frame.Copy(facesDetected[i]).Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    result._EqualizeHist();
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                    if (Eigen_Recog.IsTrained)
                    {
                        string name = Eigen_Recog.Recognise(result);
                        int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.Gray));
                        ADD_Face_Found(result, name, match_value);
                    }
                }
                //Show the faces procesed and recognized
                image_PICBX.Image = currentFrame.ToBitmap();
            }
        }

        void FrameGrabber_Parrellel(object sender, EventArgs e)

        {
                //Get the current frame form capture device
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            //Clear_Faces_Found();

            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();
                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                Parallel.For(0, facesDetected.Length, i =>
                    {
                        try
                        {
                            facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                            facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                            facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                            facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                            result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                            result._EqualizeHist();
                            //draw the face detected in the 0th (gray) channel with blue color
                            currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                            if (Eigen_Recog.IsTrained)
                            {
                                string name = Eigen_Recog.Recognise(result);
                                int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                                //Draw the label for each face detected and recognized
                                currentFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.White));
                                ADD_Face_Found(result, name, match_value);

                                //For being able to open another form and carry on with normal application...
                                //public void dosomething()
                                //{
                                //    //stop the aquasition
                                //    Application.Idle -= new EventHandler(FrameGrabber_Parrellel);
                                //    //do whatever you want to
                                //    //start it again
                                //    Application.Idle += new EventHandler(FrameGrabber_Parrellel);
                                //}

                                //If the face of the user whos name has been selected is found...

                                

                                    if (selectedUserComboBox.SelectedItem.ToString() == name)
                                {

                                        currentFrame.Draw(counter.ToString(), ref font, new Point(facesDetected[i].X - 5, facesDetected[i].Y - 5), new Bgr(Color.White));
                                        //Stop camera and stop loop~! otherwise infinite form loop...
                                        if (counter == 0)
                                        {
                                            stop_capture();
                                            this.Hide();
                                            string dontshowtandc = "dontshow";
                                            string admin = "Admin";
                                            string client = "Client";
                                            string role = actualRole;

                                            //Send userloggedin and status to all forms...
                                            Menu menuForm = new EncryptionDecryption.Menu(role, name);
                                            Admin adminForm = new EncryptionDecryption.Admin(role, name);
                                            encdec encdecForm = new EncryptionDecryption.encdec(role, name);
                                            Account_Management accountForm = new EncryptionDecryption.Account_Management(role, name);
                                            Key_Management keyForm = new EncryptionDecryption.Key_Management(role, name);
                                            StegonagraphyForm stegForm = new EncryptionDecryption.StegonagraphyForm(role, name);
                                            TandC tandcForm = new EncryptionDecryption.TandC(role, name);


                                            if (role == admin && terms == dontshowtandc)
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
                                            else if (role == admin && terms != dontshowtandc)
                                            {
                                                this.Hide();
                                                tandcForm.ShowDialog();
                                            }

                                            else if (role == client && terms == dontshowtandc)
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
                                            else if (role == client && terms != dontshowtandc)
                                            {
                                                this.Hide();
                                                tandcForm.ShowDialog();
                                            }

                                        }

                                }
                            }

                        }
                        catch
                        {
                            //do nothing as parrellel loop buggy
                            //No action as the error is useless, it is simply an error in 
                            //no data being there to process and this occurss sporadically 
                        }
                    });
                //Show the faces procesed and recognized
                image_PICBX.Image = currentFrame.ToBitmap();
            }
        }


        //ADD Picture box and label to a panel for each face
        int faces_count = 0;
        int faces_panel_Y = 0;
        int faces_panel_X = 0;

        void Clear_Faces_Found()
        {
            this.Faces_Found_Panel.Controls.Clear();
            faces_count = 0;
            faces_panel_Y = 0;
            faces_panel_X = 0;
        }
        void ADD_Face_Found(Image<Gray, Byte> img_found, string name_person, int match_value)
        {
            PictureBox PI = new PictureBox();
            PI.Location = new Point(faces_panel_X, faces_panel_Y);
            PI.Height = 80;
            PI.Width = 80;
            PI.SizeMode = PictureBoxSizeMode.StretchImage;
            PI.Image = img_found.ToBitmap();
            Label LB = new Label();
            LB.Text = name_person + " " + match_value.ToString();
            LB.Location = new Point(faces_panel_X, faces_panel_Y + 80);
            //LB.Width = 80;
            LB.Height = 15;

            this.Faces_Found_Panel.Controls.Add(PI);
            this.Faces_Found_Panel.Controls.Add(LB);
            faces_count++;
            if (faces_count == 2)
            {
                faces_panel_X = 0;
                faces_panel_Y += 100;
                faces_count = 0;
            }
            else faces_panel_X += 85;

            if (Faces_Found_Panel.Controls.Count > 10)
            {
                Clear_Faces_Found();
            }

        }

        //Menu Opeartions
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void singleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parrellelToolStripMenuItem.Checked = false;
            singleToolStripMenuItem.Checked = true;
            Application.Idle -= new EventHandler(FrameGrabber_Parrellel);
            Application.Idle += new EventHandler(FrameGrabber_Standard);
        }
        private void parrellelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parrellelToolStripMenuItem.Checked = true;
            singleToolStripMenuItem.Checked = false;
            Application.Idle -= new EventHandler(FrameGrabber_Standard);
            Application.Idle += new EventHandler(FrameGrabber_Parrellel);

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog();
            //As there is no identification in files to recogniser type we will set the extension ofthe file to tell us
            switch (Eigen_Recog.Recognizer_Type)
            {
                case ("EMGU.CV.LBPHFaceRecognizer"):
                    SF.Filter = "LBPHFaceRecognizer File (*.LBPH)|*.LBPH";
                    break;
                case ("EMGU.CV.FisherFaceRecognizer"):
                    SF.Filter = "FisherFaceRecognizer File (*.FFR)|*.FFR";
                    break;
                case ("EMGU.CV.EigenFaceRecognizer"):
                    SF.Filter = "EigenFaceRecognizer File (*.EFR)|*.EFR";
                    break;
            }
            if (SF.ShowDialog() == DialogResult.OK)
            {
                Eigen_Recog.Save_Eigen_Recogniser(SF.FileName);
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OF = new OpenFileDialog();
            OF.Filter = "EigenFaceRecognizer File (*.EFR)|*.EFR|LBPHFaceRecognizer File (*.LBPH)|*.LBPH|FisherFaceRecognizer File (*.FFR)|*.FFR";
            if (OF.ShowDialog() == DialogResult.OK)
            {
                Eigen_Recog.Load_Eigen_Recogniser(OF.FileName);
            }
        }

        //Unknow Eigen face calibration
        private void Eigne_threshold_txtbxChanged(object sender, EventArgs e)
        {
            try
            {
                Eigen_Recog.Set_Eigen_Threshold = 0;//Math.Abs(Convert.ToInt32(Eigne_threshold_txtbx.Text));
                message_bar.Text = "Eigen Threshold Set";
            }
            catch
            {
                message_bar.Text = "Error in Threshold input please use int";
            }
        }

        private void eigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu items
            fisherToolStripMenuItem.Checked = false;
            lBPHToolStripMenuItem.Checked = false;

            Eigen_Recog.Recognizer_Type = "EMGU.CV.EigenFaceRecognizer";
            Eigen_Recog.Retrain();
        }

        private void fisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu items
            lBPHToolStripMenuItem.Checked = false;
            eigenToolStripMenuItem.Checked = false;

            Eigen_Recog.Recognizer_Type = "EMGU.CV.FisherFaceRecognizer";
            Eigen_Recog.Retrain();
        }

        private void image_PICBX_Click(object sender, EventArgs e)
        {

        }

        private void FaceRecognitionLoginForm_Load(object sender, EventArgs e)
        {
            stop_capture();
            //Count the commandlineargs... Need a smarter number than 10000...
            try
            {
                for (argumentsPassed = 0; argumentsPassed < 10000; argumentsPassed++)
                {
                    string argscounter = Path.GetFullPath(Environment.GetCommandLineArgs()[argumentsPassed]);

                    //File Path...
                    //testing.Text = argscounter.ToString();

                    //How many arguments...
                    argumentsPassedTextBox.Text = argumentsPassed.ToString();
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


            fillSelectUserComboBox();
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
                //actualRole = (dr["Role"].ToString());
                //terms = (dr["Terms"].ToString());

            }
            con.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.DestroyHandle();
            this.Close();

            Welcome welcomeForm = new Welcome();
            welcomeForm.ShowDialog();
        }

        private void selectedUserComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedUserComboBox.Enabled = false;

            //Enable camera...
            initialise_capture();

            //Clear Selected user combo box...
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
                actualRole = (dr["Role"].ToString());
                terms = (dr["Terms"].ToString());
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stop_capture();
            grabber.Stop();
            grabber.Dispose();
            this.Close();

            FaceRecognitionLoginForm faceForm = new FaceRecognitionLoginForm();
            faceForm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lBPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncheck other menu items
            fisherToolStripMenuItem.Checked = false;
            eigenToolStripMenuItem.Checked = false;

            Eigen_Recog.Recognizer_Type = "EMGU.CV.LBPHFaceRecognizer";
            Eigen_Recog.Retrain();
        }
    }
}
