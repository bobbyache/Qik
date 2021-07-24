
using System;
using System.IO;
using System.Collections.Generic;
using System.Net.WebSockets;

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
            IInterpreter interpreter = new Interpreter();
            interpreter.Interpret(script);

            foreach (var placeholder in interpreter.Placeholders)
            {
                dict.Add(new KeyValuePair<string, string>(placeholder, interpreter.GetValueOfPlaceholder(placeholder)));
            }

            return dict.ToArray();
        }
    }
}