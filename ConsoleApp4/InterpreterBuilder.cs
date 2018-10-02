using System;
using System.Collections.Generic;
using StringEvaluator;
using StringLiterator.Read.Implementations;
using StringLiterator.Write.Implementations;

namespace ConsoleApp4
{
    public static class InterpreterBuilder
    {
        public static Interpreter GetInterpreter(string[] arguments)
        {
            if (arguments.Length == 0)
                throw new Exception("You must enter a work mode");

            switch (arguments[0].ToLowerInvariant())
            {
                case WorkModes.Console:
                    return new Interpreter(new ConsoleStringReader(), new ConsoleWriter(), new StringsEvaluator(new Dictionary<string, double>()));

                case WorkModes.File:
                {
                    if (arguments.Length < 2)
                    {
                        throw new Exception("If you choose File work mode you have to enter the file path");
                    }

                    return new Interpreter(new FileStringReader(arguments[1]), new ConsoleWriter(), new StringsEvaluator(new Dictionary<string, double>()));
                }

                default:
                    throw new NotImplementedException("This work mode is currenntly not implemented");
            }
        }
        public static Interpreter GetInterpreter(string[] arguments, Dictionary<string, double> dictionary)
        {
            if (arguments.Length == 0)
                throw new Exception("You must enter a work mode");

            switch (arguments[0].ToLowerInvariant())
            {
                case WorkModes.Console:
                    return new Interpreter(new ConsoleStringReader(), new ConsoleWriter(), new StringsEvaluator(dictionary));

                case WorkModes.File:
                {
                    if (arguments.Length < 2)
                    {
                        throw new Exception("If you choose File work mode you have to enter the file path");
                    }

                    return new Interpreter(new FileStringReader(arguments[1]), new ConsoleWriter(), new StringsEvaluator(dictionary));
                }

                default:
                    throw new NotImplementedException("This work mode is currenntly not implemented");
            }
        }
    }
}
