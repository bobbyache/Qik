
using System.Collections.Generic;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.Console
{
    public interface IScriptInterpreter
    {
        KeyValuePair<string, string>[] GetPlaceholderLookups(string script);
    }

    public class ScriptInterpreter : IScriptInterpreter
    {
        public KeyValuePair<string, string>[] GetPlaceholderLookups(string script)
        {
            var dict = new List<KeyValuePair<string, string>>();
            var interpreter = new Interpreter();
            var functionFactory = new FunctionFactory();
            var symbolTerminal = interpreter.Interpret(functionFactory, script);

            foreach (var symbol in symbolTerminal.Symbols)
            {
                var output = symbolTerminal.GetValue(symbol);
                var placeholder = "@{" + symbol.Replace("@", "") + "}" ;

                dict.Add(new KeyValuePair<string, string>(placeholder, output));
            }

            return dict.ToArray();
        }
    }
}