
using System;

namespace CygSoft.Qik
{
    // TODO: The Generator should not be in here. Replacement and output is really not a concern for the Qik engine.
    public class Generator : IGenerator
    {
        // TODO: Instead of passing in an interpreter, should just pass in the processed placeholder output.
        public string Generate(IInterpreter interpreter, string templateText)
        {
            if (interpreter is null) throw new ArgumentNullException($"{nameof(interpreter)} cannot be null.");

            if (String.IsNullOrWhiteSpace(templateText))
                return "";

            var input = templateText;

            foreach (var symbol in interpreter.Symbols)
            {
                var output = interpreter.GetValueOfSymbol(symbol);
                var placeholder = "@{" + symbol.Replace("@", "") + "}" ;
                input = input.Replace(placeholder, output);
            }

            return input;
        }
    }
}
