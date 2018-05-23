using System;
using System.Security.Cryptography;
using System.Text;

namespace Test.src.algorithms
{
    class Encryptor
    {
        private byte[] encodedFile;

        public Encryptor(byte[] encodedFile)
        {
            this.encodedFile = encodedFile;
        }


        internal byte[] SetupEncrypt(string pass)
        {
            string salt = GenerateSalt();
           
            string finalKey = pass + "'\'" + salt; //slash used as escape char

            byte[] encrypted = PerformEncryption(pass, finalKey);

            return encrypted;
        }

        private byte[] PerformEncryption(string pass, string finalKey)
        {
            throw new NotImplementedException();

            
        }
       
        private string GenerateSalt()
        {
            string salt = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                salt += random.Next();
            }
            return salt;
        }
    }
}
