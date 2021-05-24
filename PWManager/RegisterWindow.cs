using CsvHelper;
using PWManager.src.Models;
using PWManager.src.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWManager
{
    public partial class RegisterWindow : Form
    {
        String path = Environment.CurrentDirectory + "/PasswordManagmentData";
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string pathwithname = path + '/' + Argon2Util.argon2Hash2Strings(UsernameBox.Text, PasswordBox.Text);
            var dir = Directory.CreateDirectory(pathwithname);
            File.Create(path + '/' + Argon2Util.argon2Hash2Strings(UsernameBox.Text, PasswordBox.Text) + '/' + "data.csv").Dispose();

            using (var writer = new StreamWriter(path + '/' + Argon2Util.argon2Hash2Strings(UsernameBox.Text, PasswordBox.Text) + '/' + "data.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<PasswordManagmentModel>();

            }

            AESUtils.EncryptFile(dir, PasswordBox.Text);

            MessageBox.Show("Registered Succesfully");
    
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PasswordBox.UseSystemPasswordChar = false;
                PasswordBox.PasswordChar = '\0';
            }
            else
            {
                PasswordBox.UseSystemPasswordChar = true;
                PasswordBox.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordBox.Text = Utils.GetRandomString(32);
        }
    }
}
