using StringEvaluator;
using StringLiterator.Read;
using StringLiterator.Write;

namespace ConsoleApp4 {
    public class Interpreter
    {
        private readonly IStringWriter writer;
        private readonly IStringReader reader;
        private readonly StringsEvaluator evaluator; 
        public Interpreter(IStringReader reader, IStringWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            evaluator = new StringsEvaluator();
        }
        public void StartProcessing(string exitString)
        {
            var evalString = reader.ReadString() ?? string.Empty;
            while (evalString != exitString)
            {
                if (evalString.StartsWith("Run "))
                {
                    InterpreterBuilder
                        .GetInterpreter(new []{"File", evalString.Split(' ')[1]})
                        .StartProcessing(string.Empty);
                }

                evaluator.EvaluateString(evalString);
                evalString = reader.ReadString() ?? string.Empty;
            }

            foreach (var parameter in evaluator.Parameters)
            {
                writer.WriteLine($"{parameter.Key} = {parameter.Value}");
            }
        }
    }
}
