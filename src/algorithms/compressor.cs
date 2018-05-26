using Huffman_Coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.src.algorithms
{
    class HuffmanCompressor
    {
        private byte[] encodedFile;
        

        public HuffmanCompressor(byte[] encodedFile)
        {
            this.encodedFile = encodedFile;
        }
        //Huffman Coding
        public byte[] DoCompression()
        {
            FrequencyTable frequency = new FrequencyTable();
            Dictionary<string,int> frequencyTable = frequency.BuildFrequencyTable(encodedFile);

            HuffmanTree huffmanTree = new HuffmanTree(frequencyTable, frequency);
            var compressedFile = huffmanTree.AssignCode();
            compressedFile[compressedFile.First().Key] = "0"; //Stops eliminating first value

            foreach (KeyValuePair<string, string> kvp in compressedFile)
            {
                Console.WriteLine((kvp.Key == "\n" ? "EOF" : kvp.Key.ToString()) + ":\t" + kvp.Value);
            }


            handleHuffmanFile(compressedFile);
            return encodedFile;
        }

        public byte[] handleHuffmanFile(IDictionary<string,string> file)
        {
            byte[] huffEncoded;
            StringBuilder sb = new StringBuilder(); // for testing
            for (int i = 0; i < encodedFile.Length; i++)
            {
                string currentChar = Convert.ToChar(encodedFile[i]).ToString();
                string code = file[currentChar]; //gets binary equivalent
                sb.Append(code);
            }
            Console.WriteLine(sb.ToString());
            
            return null;
        }       
        
    }
}
