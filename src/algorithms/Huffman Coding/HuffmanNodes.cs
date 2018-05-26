using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    class HuffmanNodes
    {
        public HuffmanNodes Parent { get; set; }
        public HuffmanNodes Left { get; set; }
        public HuffmanNodes Right { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
        

      
        private IDictionary<string, int> dict;

        public HuffmanNodes()
        {
            
        }

        public HuffmanNodes(IDictionary<string, int> dict)
        {
            this.dict = dict;
        }

       

        public void BuildNodes()
        {
          
        }
  
        //public KeyValuePair<string, int> AddToList()
        //{
            
        //    KeyValuePair<string, int> getFirst = dict.First();
        //    dict.Remove(getFirst.Key);
            
        //    return getFirst;
        //}


    }

}
