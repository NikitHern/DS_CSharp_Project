using System.IO;

namespace StringLiterator.Read.Implementations
{
    public class FileStringReader : IStringReader
    {
        private readonly StreamReader readStream;
        public FileStringReader(string filePath)
        {
            readStream = new StreamReader(filePath);
        }
        public string ReadString()
        {
            return readStream.ReadLine() ?? string.Empty;
        }
    }
}
