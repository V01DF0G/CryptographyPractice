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
    public partial class PasswordManagerControl : UserControl
    {
        PassWordManageWindowLoggedIn Targetedinstance;
        PasswordManagmentModel storedModel;
        public PasswordManagerControl(PassWordManageWindowLoggedIn instance, PasswordManagmentModel model, bool encrypted = false)
        {
            Targetedinstance = instance;
            storedModel = model;
            InitializeComponent();
            PWNameBox.Text = model.Name;
            if (!encrypted)
                PWPasswordBox.Text = AESUtils.DecryptString(instance.storedDirectoryInfo, instance.storedPassword, model.Password);
            else
                PWPasswordBox.Text = model.Password;
            PWApplicationBox.Text = model.Application;
            PWCommentBox.Text = model.Comment;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(PWPasswordBox.Text);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            Targetedinstance.modelList.Remove(storedModel);

            using (var writer = new StreamWriter(Targetedinstance.storedDirectoryInfo.FullName + "/data.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Targetedinstance.modelList);
            }
            Targetedinstance.UpdatePWList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                PWPasswordBox.UseSystemPasswordChar = false;
                PWPasswordBox.PasswordChar = '\0';
            }
            else
            {
                PWPasswordBox.UseSystemPasswordChar = true;
                PWPasswordBox.PasswordChar = '*';
            }
        }
    }
}
