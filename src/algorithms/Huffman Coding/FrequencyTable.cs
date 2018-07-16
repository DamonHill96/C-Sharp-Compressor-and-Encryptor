using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    class FrequencyTable
    {
        private IDictionary<string, int> dict { get; set; } = new Dictionary<string, int>();
        public Queue<HuffmanNodes> queue { get; set; } = new Queue<HuffmanNodes>();
        public int count { get; set; }
        
        public Dictionary<string, int> Sort()
        {
            //Sorts for priority
            IOrderedEnumerable<KeyValuePair<string, int>> sortedDict = from entry in dict orderby entry.Value descending select entry;

            return sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public Dictionary<string, int> BuildFrequencyTable(byte[] file)
        {

            for (int i = 0; i < file.Length; i++)
            {
                string currentChar = Convert.ToChar(file[i]).ToString();

                // If it's already been done
                if (dict.ContainsKey(currentChar))
                {
                    dict[currentChar] = dict[currentChar] + 1;

                }
                else //Add it in

                {
                    dict.Add(currentChar, 1);
                };

            }       
            return Sort(); //Sort table and return to Compressor


        }
        public KeyValuePair<string, int> Dequeue()
        {
            //Remove and return from dictionary
            KeyValuePair<string, int> first = dict.First();
            dict.Remove(first.Key);
            return first;
        }

        internal void Enqueue(HuffmanNodes huffmanNodes)
        {
            count++;
            queue.Enqueue(huffmanNodes);
        }

        public int DictionaryLength()
        {
            return dict.Count();
        }

        public void ClearDictionary()
        {
            dict.Clear();
        }
    }
}
