using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLevelRSASignature.src
{
    public partial class FirstLevelRSA : Form
    {

        TcpClient client = new TcpClient();
        Int32 port = 13000;
        readonly IPAddress ServerIp = IPAddress.Parse("192.168.1.179");

        private RSAParameters publicKey;
        private RSAParameters privateKey;

        private void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
            }
        }

        private byte[] SignData(byte[] hashOfDataToSign)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return rsaFormatter.CreateSignature(hashOfDataToSign);
            }
        }

        private bool VerifySignature(byte[] hashOfDataToSign, byte[] signature)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(publicKey);

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");

                return rsaDeformatter.VerifySignature(hashOfDataToSign, signature);
            }
        }

        public FirstLevelRSA()
        {
            InitializeComponent();
        }

        private void FirstLevelRSA_Load(object sender, EventArgs e)
        {

        }

        private void Message1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                byte[] hashedDocument;

                using (var sha256 = SHA256.Create())
                {
                    hashedDocument = sha256.ComputeHash(Encoding.UTF8.GetBytes(textBox1.Text));
                }

                AssignNewKey();

                richTextBox1.Text = Convert.ToBase64String(SignData(hashedDocument));
            }
            else
            {
                richTextBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string publickeymodulus = Convert.ToBase64String(publicKey.Modulus);
            string publickeyexponent = Convert.ToBase64String(publicKey.Exponent);

            try
            {
                client.Connect(ServerIp, port);
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
                {

                    Byte[] messageData = System.Text.Encoding.UTF8.GetBytes(textBox1.Text + Environment.NewLine);
                    Byte[] signatureData = System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text + Environment.NewLine);                    
                    Byte[] publicKeyParams = System.Text.Encoding.UTF8.GetBytes(publickeymodulus + Environment.NewLine + publickeyexponent + Environment.NewLine);
                    NetworkStream stream = client.GetStream();
                    
                    stream.Write(messageData, 0, messageData.Length);
                    stream.Write(signatureData, 0, signatureData.Length);
                    stream.Write(publicKeyParams, 0, publicKeyParams.Length);

                    stream.Close();
                }
            }
            catch (Exception err)
            {
                if(err is ObjectDisposedException)
                {
                    client = new TcpClient();
                    button1_Click(sender, e);
                }
                else
                {
                  MessageBox.Show("Connection Error:" + err);
                }
                

            }
        }
    }
}
