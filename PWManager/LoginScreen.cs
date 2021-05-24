using PWManager.src.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWManager
{
    public partial class LoginScreen : Form
    {
        String path = Environment.CurrentDirectory + "/PasswordManagmentData";
        public LoginScreen()
        {
            InitializeComponent();
            DirectoryInfo antiEmptyDirInfo = new DirectoryInfo(path);
            if(antiEmptyDirInfo.GetDirectories().Length == 0)
            {
                new RegisterWindow().Show();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterWindow temp = new RegisterWindow();
            temp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newhash = Argon2Util.argon2Hash2Strings(UsernameBox.Text, PasswordBox.Text);
            DirectoryInfo rootDirectory = new DirectoryInfo(path);

            bool verificationStatus = false;
            foreach(DirectoryInfo Dir in rootDirectory.GetDirectories())
            {
                if(Dir.Name == newhash)
                {
                    verificationStatus = true;
                    AESUtils.DecryptFile(Dir, PasswordBox.Text);
                    new PassWordManageWindowLoggedIn(Dir, PasswordBox.Text).Show();
                }
            }

            if(!verificationStatus)
            {
                MessageBox.Show("Incorrect Username or password !");
            }

        }
    }
}
