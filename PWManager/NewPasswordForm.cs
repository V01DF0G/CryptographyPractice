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
using CsvHelper;
using PWManager.src.Models;
using PWManager.src.Utilities;

namespace PWManager
{
    public partial class NewPasswordForm : Form
    {
        private DirectoryInfo direct;
        private PassWordManageWindowLoggedIn instancestored;
        public NewPasswordForm(PassWordManageWindowLoggedIn instance ,DirectoryInfo dir)
        {
            direct = dir;
            instancestored = instance;
            InitializeComponent();
        }

        private void NewPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordManagmentModel model = new PasswordManagmentModel { Name = NameBox.Text, Password = AESUtils.EncryptString(direct, instancestored.storedPassword, PasswordBox.Text), Application = ApplicationBox.Text, Comment = CommentBox.Text };
            using (var writer = File.AppendText(direct.FullName + "/data.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                writer.WriteLine();
                csv.WriteRecord(model);
            }
            instancestored.UpdatePWList();
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PasswordBox.Text = Utils.GetRandomString(32);
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
    }
}
