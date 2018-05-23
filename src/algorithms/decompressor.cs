using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.src.algorithms
{
    class Decompressor : FileDecoder
    {
        private byte[] encodedFile;
        private StringBuilder extension;

        public Decompressor(byte[] encodedFile, StringBuilder extension)
        {
            this.encodedFile = encodedFile;
            this.extension = extension;
        }

        internal byte[] Setup()
        {
            int fileLength = encodedFile.Length;
            int extLength = extension.Length + 1; //cuts escape character
            byte[] fileWithoutExt = new byte[fileLength - extLength]; //what is actually decompressed

            Buffer.BlockCopy(encodedFile, extLength, fileWithoutExt, 0, fileLength - extLength);

            byte[] decompressedFile = DoDecompression(fileWithoutExt);
            return decompressedFile;
        }

        private byte[] DoDecompression(byte[] file)
        {
            return file;
        }
    }
}
