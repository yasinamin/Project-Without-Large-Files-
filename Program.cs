using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;

namespace EncryptionDecryption
{
    static class Program
    {
        [STAThread]

        static void Main(params string[] Arguments)
        {
            Welcome welcomeForm = new Welcome();
            bool bInstanceFlag;

            Mutex MyApplicationMutex = new Mutex(true, "MyApp_Mutex", out bInstanceFlag);

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            if (!bInstanceFlag)
            {
                SingleInstanceApplication.Run(welcomeForm, NewInstanceHandler);
            }
            else
            {
                SingleInstanceApplication.Run(welcomeForm, NewInstanceHandler);
                welcomeForm.Close();
            }
        }

        public static void NewInstanceHandler(object sender, StartupNextInstanceEventArgs e)
        {

            //loginForm.AddItem = e.CommandLine[1];

            MessageBox.Show(e.CommandLine[1]);

            e.BringToForeground = false;
        }

        public class SingleInstanceApplication : WindowsFormsApplicationBase
        {
            private SingleInstanceApplication()
            {
                base.IsSingleInstance = true;
            }

            public static void Run(Form f, StartupNextInstanceEventHandler startupHandler)
            {
                SingleInstanceApplication app = new SingleInstanceApplication();
                app.MainForm = f;
                app.StartupNextInstance += startupHandler;
                app.Run(Environment.GetCommandLineArgs());
            }
        }
    }
}

















///// <summary>
///// The main entry point for the application.
///// </summary>
//[STAThread]
//static void Main()
//{
//    bool instanceCountOne = false;

//    using (Mutex mtex = new Mutex(true, "MyRunningApp", out instanceCountOne))
//    {
//        if (instanceCountOne)
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Login("Admin", "admin"));
//            mtex.ReleaseMutex();
//        }
//        else
//        {

//            MessageBox.Show("An instance of this application is already running in the taskbar", "Note");
//            mtex.ReleaseMutex();

//            Environment.GetCommandLineArgs();

//            //Trying to pass the loggedinusername and role to new instance of the program so dont have to sign in again...
//        }
//    }

//}