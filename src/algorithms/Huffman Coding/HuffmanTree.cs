using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    class HuffmanTree
    {
        private HuffmanNodes root;

        public HuffmanTree()

        {

        }

        public HuffmanNodes BuildTree(IEnumerable<KeyValuePair<string, int>> freq, FrequencyTable frequencyTable)
        {
            int count = frequencyTable.DictionaryLength();


            foreach (KeyValuePair<string, int> pair in freq)
            {
                frequencyTable.Enqueue(new HuffmanNodes { Key = pair.Key, Value = pair.Value }); // moves into the queue

            }
            Queue<HuffmanNodes> q = frequencyTable.queue;

            while (frequencyTable.count > 1) //while there's still elements
            {
                HuffmanNodes n1 = frequencyTable.queue.Dequeue();
                frequencyTable.count--;
                HuffmanNodes n2 = frequencyTable.queue.Dequeue();
                frequencyTable.count--;
                var n3 = new HuffmanNodes { Left = n1, Right = n2, Value = n1.Value + n2.Value }; //adds together
                n1.Parent = n3;
                n2.Parent = n3;
                frequencyTable.Enqueue(n3);
            }
            q = frequencyTable.queue;
            root = frequencyTable.queue.Dequeue();
            return root;
        }

        public IDictionary<string, string> AssignCode()
        {
            IDictionary<string, string> code = new Dictionary<string, string>();
            Encode(root, "", code);
            return code;
        }

        private void Encode(HuffmanNodes root, string path, IDictionary<string, string> code)
        {
            if (root.Left != null) // if there's something there
            {
                Encode(root.Left, path + "0", code);
                Encode(root.Right, path + "1", code);
            }
            else
            {

                int index = RemoveZero(path);

                code.Add(root.Key, path.Substring(index));
            }
        }

        private int RemoveZero(string path)
        {
            char[] arr = path.ToCharArray();
            // Cuts out excess 0
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 48) // looks for 0
                {
                    continue;
                }
                else
                {
                    return i;

                }

            }
            return 0;

        }
    }
}
