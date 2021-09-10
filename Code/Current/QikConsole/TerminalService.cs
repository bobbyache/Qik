using System;
using System.IO;
using CygSoft.Qik.Functions;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.QikConsole
{
    public class TerminalService
    {
        private Dictionary<string, PlaceholderTerminal> terminalDictionary = new Dictionary<string, PlaceholderTerminal>();

        public string[] Terminals { get => terminalDictionary.Keys.ToArray(); }

        public TerminalService(IFileFunctions fileFunctions, string path, Project project)
        {
            BuildTerminalDictionary(path, project, 
                fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.")
            );
        }
        public string Execute(string processorId, string templateText)
        {
            if (terminalDictionary.ContainsKey(processorId))
            {
                var terminal = terminalDictionary[processorId];
                foreach (var placeholder in terminal.Placeholders)
                {
                    templateText = templateText.Replace(placeholder, terminal.GetValue(placeholder));
                }
            }

            return templateText;
        }

        private void BuildTerminalDictionary(string path, Project project, IFileFunctions fileFunctions)
        {
            foreach(var processor in project.Processors)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), processor.ScriptFile);
                var script = fileFunctions.ReadTextFile(fullPath);
                terminalDictionary.Add(processor.Id, GetTerminal(processor.Id, script));
            }
        }

        private PlaceholderTerminal GetTerminal(string id, string script)
        {
            var interpreter = new Interpreter();
            var functionFactory = new FunctionFactory();
            var symbolTerminal = interpreter.Interpret(functionFactory, script);
            var terminal = new PlaceholderTerminal(id, symbolTerminal, "@{", "}");
            
            return terminal;
        }
    }
}
