using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.src.algorithms
{
    class Compressor
    {
        private byte[] encodedFile;

        public Compressor(byte[] encodedFile)
        {
            this.encodedFile = encodedFile;
        }
        
        public byte[] DoCompression()
        {
            return encodedFile;
        }
    }
}
