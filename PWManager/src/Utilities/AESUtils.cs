using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;

namespace PWManager.src.Utilities
{
    static class AESUtils
    {
        static public void EncryptFile(DirectoryInfo encDir, string password)
        {
                HMACBlake2B blake = new HMACBlake2B(512);

                byte[] salt = Encoding.UTF8.GetBytes(encDir.Name);
                byte[] passwords = blake.ComputeHash(Encoding.UTF8.GetBytes(password));
                RijndaelManaged AES = new RijndaelManaged();
                AES.KeySize = 256;//aes 256 bit encryption c#
                AES.BlockSize = 128;//aes 128 bit encryption c#
                AES.Padding = PaddingMode.PKCS7;
                var key = new Rfc2898DeriveBytes(passwords, salt, 50000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);
                AES.Mode = CipherMode.CFB;

            using (FileStream fsCrypt = new FileStream(encDir.FullName + "/data.aes", FileMode.Create))
            {
                using (CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (FileStream fsIn = new FileStream(encDir.FullName + "/data.csv", FileMode.Open))
                    {
                        byte[] buffer = new byte[1048576];
                        int read;
                        while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cs.Write(buffer, 0, read);
                        }
                    }
                    File.Delete(encDir.FullName + "/data.csv");
                }
            }

        }

        static public void DecryptFile(DirectoryInfo encDir, string password)
        {
            HMACBlake2B blake = new HMACBlake2B(512);

            byte[] salt = Encoding.UTF8.GetBytes(encDir.Name);
            byte[] passwords = blake.ComputeHash(Encoding.UTF8.GetBytes(password));
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;//aes 256 bit encryption c#
            AES.BlockSize = 128;//aes 128 bit encryption c#
            AES.Padding = PaddingMode.PKCS7;
            var key = new Rfc2898DeriveBytes(passwords, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CFB;

            using (FileStream fsCrypt = new FileStream(encDir.FullName + "/data.aes", FileMode.Open))
            {
                using (CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read))
                {

                    using (FileStream fsOut = new FileStream(encDir.FullName + "/data.csv", FileMode.Create))
                    {
                        int read;
                        byte[] buffer = new byte[1048576];
                        while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsOut.Write(buffer, 0, read);
                        }
                    }
                }
                File.Delete(encDir.FullName + "/data.aes");
            }
        }

        static public string EncryptString(DirectoryInfo encDir, string password, string encryptiontarget)
        {
            HMACBlake2B blake = new HMACBlake2B(512);

            byte[] salt = blake.ComputeHash(Encoding.UTF8.GetBytes(encDir.Name));
            byte[] passwords = blake.ComputeHash(Encoding.UTF8.GetBytes(password));
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;//aes 256 bit encryption c#
            AES.BlockSize = 128;//aes 128 bit encryption c#
            AES.Padding = PaddingMode.PKCS7;
            var key = new Rfc2898DeriveBytes(passwords, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CFB;

            byte[] clearByteString = Encoding.UTF8.GetBytes(encryptiontarget);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(memoryStream, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearByteString, 0, clearByteString.Length);
                    cs.Close();
                }
                string returnalstring = Convert.ToBase64String(memoryStream.ToArray());
                return returnalstring;
            }
        }

        static public string DecryptString(DirectoryInfo encDir, string password, string decryptiontarget)
        {
            HMACBlake2B blake = new HMACBlake2B(512);

            byte[] salt = blake.ComputeHash(Encoding.UTF8.GetBytes(encDir.Name));
            byte[] passwords = blake.ComputeHash(Encoding.UTF8.GetBytes(password));
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;//aes 256 bit encryption c#
            AES.BlockSize = 128;//aes 128 bit encryption c#
            AES.Padding = PaddingMode.PKCS7;
            var key = new Rfc2898DeriveBytes(passwords, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CFB;


            byte[] cipherByteString = Convert.FromBase64String(decryptiontarget);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(memoryStream, AES.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherByteString , 0, cipherByteString.Length);
                    cs.Close();
                }
                string returnalstring = Encoding.UTF8.GetString(memoryStream.ToArray());
                return returnalstring;
            }
        }
    }
}
