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
        public string DoCompression()
        {
            FrequencyTable frequency = new FrequencyTable();
            Dictionary<string, int> frequencyTable = frequency.BuildFrequencyTable(encodedFile);

            HuffmanTree tree = new HuffmanTree();
            HuffmanNodes fullTree = tree.BuildTree(frequencyTable, frequency);
            IDictionary<string, string> binaryValues = tree.AssignCode();
            binaryValues[binaryValues.First().Key] = "0"; //Stops eliminating first value

            foreach (KeyValuePair<string, string> kvp in binaryValues)
            {
                Console.WriteLine((kvp.Key == "\n" ? "EOF" : kvp.Key.ToString()) + ":\t" + kvp.Value);
            }


            string final = handleHuffmanFile(binaryValues);
            return final;
        }

        public string handleHuffmanFile(IDictionary<string, string> file)
        {
            byte[] huffEncoded;

            StringBuilder sb = new StringBuilder(); // for testing
            for (int i = 0; i < encodedFile.Length; i++)
            {
                string currentChar = Convert.ToChar(encodedFile[i]).ToString();
                string code = file[currentChar]; //gets binary equivalent
                sb.Append(code);
            }


            return sb.ToString();
        }

    }
}
