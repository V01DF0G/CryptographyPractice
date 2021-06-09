using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondLevelRSASignature.src
{
    public partial class SecondLevelRSA : Form
    {
        private RSAParameters publicKey;
        private RSAParameters privateKey;
        TcpListener server = new TcpListener(IPAddress.Parse("192.168.1.179"), 13000);


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

        public SecondLevelRSA()
        {
            InitializeComponent();

            string receivedMessage = "";
            string receivedSignature = "";
            

            (new Task(() =>
            {
                try
                {
                    server.Start();
                    Byte[] bytes = new Byte[1024];
                    String data = null;
                    while (true)
                    {
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Waiting for connection");
                        StreamReader sr = new StreamReader(client.GetStream());
                        try
                        {
                            receivedMessage = sr.ReadLine(); 
                            receivedSignature = sr.ReadLine(); 
                            publicKey.Modulus = Convert.FromBase64String(sr.ReadLine()); 
                            publicKey.Exponent = Convert.FromBase64String(sr.ReadLine());
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Could not make out received message: " + e);
                        }
                        finally
                        {
                            this.BeginInvoke(new MethodInvoker(delegate { this.textBox1.Text = receivedMessage; this.richTextBox1.Text = receivedSignature; this.Verify.Enabled = true; }));

                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Fatal Server error" + err);
                }
                finally
                {
                }
            })).Start();
        }


        private void Message1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SecondLevelRSA_Load(object sender, EventArgs e)
        {

        }

        private void Verify_Click(object sender, EventArgs e)
        {
            byte[] hashedDocument;

            using (var sha256 = SHA256.Create())
            {
                hashedDocument = sha256.ComputeHash(Encoding.UTF8.GetBytes(textBox1.Text));
            }

            var verified = VerifySignature(hashedDocument, Convert.FromBase64String(richTextBox1.Text));

            if(verified)
            {
                MessageBox.Show("Verified succesfully and received data is correct!");
            }
            else
            {
                MessageBox.Show("Data has not been verified succesfully and received data is not correct!");
            }
        }
    }
}
