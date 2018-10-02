using System;

namespace StringLiterator.Read.Implementations
{
    public class ConsoleStringReader : IStringReader
    {
        public string ReadString()
        {
            return Console.ReadLine();
        }
    }
}
