using System;

namespace StringLiterator.Write.Implementations
{
    public class ConsoleWriter : IStringWriter
    {
        public void WriteLine(string line)
        {
           Console.WriteLine(line);
        }
    }
}
