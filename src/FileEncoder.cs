using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.src
{
    //ASCII Encoder
    class FileEncoder
    {
        private string dir; // C:/users/documents/test.txt
        private string path; // C:/users/documents
        private string name; // test.txt
        private string extension; // .txt
        private int choice;
        public FileEncoder(string path, string name, string extension, string dir, int choice)
        {
            this.path = path;
            this.name = name;
            this.extension = extension + "^"; //used as escape character
            this.dir = dir;
            this.choice = choice;
        }

        internal void ReadFile()
        {
            byte[] encodedFile = CreateByteArray();
            if (choice == 1) //compression
            {
               
                algorithms.HuffmanCompressor compressor = new algorithms.HuffmanCompressor(encodedFile);
              string compressedFile = compressor.DoCompression();
              SaveEncodedFile(compressedFile, ".cmp");
            }
            else // 3 - encrypt
            {
                Console.WriteLine("Please enter a password");
                string pass = Console.ReadLine();
                algorithms.Encryptor encryptor = new algorithms.Encryptor(encodedFile);
                byte[] encryptedFile = encryptor.SetupEncrypt(pass);
              //  SaveEncodedFile(encryptedFile, ".enc");
            }
          
            

        }

        private byte[] CreateByteArray()
        {
            byte[] encodedExtension = Encoding.ASCII.GetBytes(extension.ToCharArray());
            byte[] encodedFile = GetFileBytes();
          
            return CombineBytes(encodedExtension, encodedFile);
        }

        private byte[] CombineBytes(byte[] ext, byte[] encFile)
        {
        // encoded file hides the extension too
            byte[] newResult = new byte[ext.Length + encFile.Length];
            Buffer.BlockCopy(ext, 0, newResult, 0, ext.Length);
            Buffer.BlockCopy(encFile, 0, newResult, ext.Length, encFile.Length);
            return newResult;
        }

        private void SaveEncodedFile(string file, string ext)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                int size = file.Length / 8;
               
                Console.WriteLine(path + name + ext);
                
                while (size % 8 != 0)
                {
                    file.PadLeft(1);
                    size++;
                   
                }

                byte[] arr = new byte[size];
                
                for (int i = 0; i < size / 8; i++) {
                   
                    var test = file.Substring(i * 8, 8);
                    arr[i] = Convert.ToByte(test, 2);
                }
                fs = new FileStream(path + "\\"+name+ext, FileMode.Create);
                
                bw = new BinaryWriter(fs);
                bw.Write(arr);
                Console.WriteLine("Writing Complete");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }

     

        private byte[] GetFileBytes()
        {
            
            return File.ReadAllBytes(dir);
        }

        
    }
}
