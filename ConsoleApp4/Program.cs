using System;

namespace ConsoleApp4
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter exit to exit interpreter");
            Console.WriteLine("+, -, *, / are supported");
            Console.WriteLine("Just enter the variable to write its value");

            InterpreterBuilder
                .GetInterpreter(args)
                .StartProcessing("Exit");

            Console.WriteLine("Press any key to exit the application...");
            Console.ReadKey(true);
        }
    }
}
