using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Console.WriteLine("1. Compression");
            Console.WriteLine("2. Decompression");
            //   Console.WriteLine("3. Encrypt");
            //   Console.WriteLine("4. Decrypt");
            int choice = Int32.Parse(Console.ReadLine());
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (choice == 1 || choice == 3)
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileDir = fileDialog.FileName;
                    string onlyFileName = Path.GetFileNameWithoutExtension(fileDir);
                    string extension = Path.GetExtension(fileDir);
                    string path = Path.GetDirectoryName(fileDir);

                    src.FileEncoder fileHandle = new src.FileEncoder(path, onlyFileName, extension, fileDir, choice);
                    fileHandle.ReadFile();
                }
                

                
            }
            else if (choice == 2 || choice == 4)
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileDir = fileDialog.FileName;
                    string onlyFileName = Path.GetFileNameWithoutExtension(fileDir);
                    string extension = Path.GetExtension(fileDir);
                    string path = Path.GetDirectoryName(fileDir);

                    src.FileDecoder fileDecode = new src.FileDecoder(path, onlyFileName, fileDir, choice);
                    fileDecode.ReadFile();
                }
            }
            Console.ReadLine();
        }
    }
}
