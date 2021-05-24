using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.src.Utilities
{
    
    static class Argon2Util
    {
       static private byte[] salt = Encoding.UTF8.GetBytes("8e8cb4d6a24620181bbec9546ad0f3cf");


        static public string argon2Hash2Strings(string a, string b)
        {
            string ab = a + b;

            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(ab));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 16;
            argon2.Iterations = 32;
            argon2.MemorySize = 512;

            StringBuilder hash = new StringBuilder();

            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(argon2.GetBytes(32));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }

        static public string argon2HashString(string a)
        {
            string ab = a;

            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(ab));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 16;
            argon2.Iterations = 32;
            argon2.MemorySize = 512;

            StringBuilder hash = new StringBuilder();

            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(argon2.GetBytes(32));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
