using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string startupPath = Environment.CurrentDirectory;
            String path = Environment.CurrentDirectory + "/PasswordManagmentData";
            if(!Directory.Exists(path))
             {
                Directory.CreateDirectory(path);
             }
            DirectoryInfo antiEmptyDirInfo = new DirectoryInfo(path);
            
            if(antiEmptyDirInfo.GetDirectories().Length == 0)
            {
                Application.Run(new RegisterWindow());
            }
            else
            {
                Application.Run(new LoginScreen());
            }
            
        }
    }
}
