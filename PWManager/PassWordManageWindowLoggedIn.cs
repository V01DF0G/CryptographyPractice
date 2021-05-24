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
using System.Linq;

namespace PWManager
{
    public partial class PassWordManageWindowLoggedIn : Form
    {
        public List<PasswordManagmentModel> modelList;
        public string storedPassword = "";
        public DirectoryInfo storedDirectoryInfo;

        public PassWordManageWindowLoggedIn(DirectoryInfo encDir, string password)
        {
            InitializeComponent();

            storedPassword = password;
            storedDirectoryInfo = encDir;           
            UpdatePWList();
            
        }

        public void UpdatePWList()
        {
            flowLayoutPanel1.Controls.Clear();

            using (TextReader fileReader = File.OpenText(storedDirectoryInfo.FullName + "/data.csv"))            
            {
                var csv = new CsvReader(fileReader,CultureInfo.InvariantCulture,false);

                csv.Read();
                csv.ReadHeader();

                modelList = csv.GetRecords<PasswordManagmentModel>().ToList();
            }

            if (modelList != null)
            {
                foreach (var model in modelList)
                {
                    flowLayoutPanel1.Controls.Add(new PasswordManagerControl(this,model));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new NewPasswordForm(this,storedDirectoryInfo).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdatePWList();
        }

        private void PassWordManageWindowLoggedIn_Load(object sender, EventArgs e)
        {

        }

        private void PasswordManagerWindow_Closed(object sender, FormClosedEventArgs e)
        {
            AESUtils.EncryptFile(storedDirectoryInfo, storedPassword);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            DecryptBtn.Visible = false;
            var model = modelList.Where(modelx => modelx.Name == SearchBox.Text).FirstOrDefault();
            if (model != null)
            {
                panel1.Controls.Add(new PasswordManagerControl(this, model, true));
                DecryptBtn.Visible = true;
            }
            else
            {
                MessageBox.Show("Not found");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            PasswordManagerControl ats = (PasswordManagerControl)panel1.Controls[0];
            ats.PWPasswordBox.Text = AESUtils.DecryptString(storedDirectoryInfo, storedPassword, ats.PWPasswordBox.Text);
        }
    }
}
