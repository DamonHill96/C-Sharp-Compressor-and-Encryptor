using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.src
{
    class FileDecoder
    {
        private string path;
        private string name;

        private string dir;
        private int choice;

        public FileDecoder()
        {
           
        }

        public FileDecoder(string path, string name, string dir, int choice)
        {
            this.path = path;
            this.name = name;
            this.dir = dir;
            this.choice = choice;
        }

        internal void ReadFile()

        {
            try
            {
                byte[] encodedFile = GetFileBytes();
                StringBuilder extension = GetExtension(encodedFile);
                if (choice == 2) // Decompress
                {
                    algorithms.Decompressor decompressor = new algorithms.Decompressor(encodedFile, extension);
                    byte[] file = decompressor.Setup();
                    SaveDecodedFile(file, extension.ToString());
                }
            } catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        //is done for both anyway
        private StringBuilder GetExtension(byte[] file)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++) // should never be more than 10. Hopefully.
            {
                if (file[i] != 94) //anything but escape char ^
                {
                    sb.Append(Convert.ToChar(file[i]).ToString());
                }
                else
                {
                    return sb;
                }
            }
            throw new KeyNotFoundException(); // if failure

        }

        private byte[] GetFileBytes()
        {

            return File.ReadAllBytes(dir);
        }
        
        protected void SaveDecodedFile(byte[] decodedFile, string ext)
        {
            try
            {
                Console.WriteLine(path + name + ext);
                File.WriteAllBytes(path + "\\" + name + ext, decodedFile);
                Console.WriteLine("Writing Complete");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

    }
}
