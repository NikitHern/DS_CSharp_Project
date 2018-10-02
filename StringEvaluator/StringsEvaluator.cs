using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace StringEvaluator
{
    public class StringsEvaluator
    {
        public IDictionary<string, double> Parameters { get; }

        public StringsEvaluator()
        {
            Parameters = new Dictionary<string, double>();
        }

        public void EvaluateString(string stringExpression)
        {
            if (string.IsNullOrEmpty(stringExpression))
            {
                return;
            }

            var trimmedStringExpression = stringExpression.Trim();

            if (!stringExpression.Contains("=") && Parameters.ContainsKey(trimmedStringExpression))
            {
                Console.WriteLine($"{trimmedStringExpression} = {Parameters[trimmedStringExpression]}");
                return;
            }

            var strings = stringExpression.Split('=');

            var assignableParameter = strings[0].Trim();
            var expression = strings[1].Trim();

            var expressionMembers = expression.Split('+', '-', '/', '*');
            foreach (var member in expressionMembers)
            {
                if (string.IsNullOrEmpty(member)) continue;
                var trimmedMember = member.Trim();
                if (double.TryParse(trimmedMember, out var _)) continue;
                if (Parameters.TryGetValue(trimmedMember, out var value))
                {
                    expression = expression.Replace(trimmedMember, value.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    throw new Exception($"Unexpected identifier {trimmedMember}");
                }
            }

            var result = new DataTable().Compute(expression, "");
            Parameters[assignableParameter] = Convert.ToDouble(result);
        }
    }
}
