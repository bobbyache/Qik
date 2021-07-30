
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.Console
{
    //TODO: Implement the new QikProjectFile structure and start thinking
    // about how it can be implemented.
    public class MainHost : IAppHost
    {
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private Dictionary<string, PlaceholderTerminal> terminalDictionary = new Dictionary<string, PlaceholderTerminal>();
        private Dictionary<string, string> fragmentsDictionary = new Dictionary<string, string>();

        public MainHost(IProjectFile projectFile, IFileFunctions fileFunctions)
        {
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
        }

        public string GetJsonInputInterface(string path)
        {
            return "";
        }

        public void Generate(string path)
        {
            terminalDictionary.Clear();

            var project = projectFile.Read(path);
            
            foreach(var processor in project.Processors)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), processor.ScriptFile);
                var script = fileFunctions.ReadTextFile(fullPath);
                terminalDictionary.Add(processor.Id, GetTerminal(processor.Id, script));
            }

            foreach (var frag in project.Fragments)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), frag.Path);
                var templateText = fileFunctions.ReadTextFile(fullPath);

                foreach (var processorId in frag.Processors)
                {
                    if (frag.Processors.Contains(processorId) && terminalDictionary.ContainsKey(processorId))
                    {
                        var terminal = terminalDictionary[processorId];

                        foreach (var placeholder in terminal.Placeholders)
                        {
                            templateText = templateText.Replace(placeholder, terminal.GetValue(placeholder));
                        }
                    }
                }
                fragmentsDictionary.Add(frag.Id, templateText);
            }

            
            foreach (var document in project.Documents)
            {
                StringBuilder builder = new StringBuilder();
                foreach(var structure in document.Structure)
                {
                    if (fragmentsDictionary.ContainsKey(structure))
                    {
                        builder.AppendLine(fragmentsDictionary[structure]);
                    }
                }
                
                foreach (var outputPath in document.OutputFilePaths)
                {
                    fileFunctions.WriteTextFile(GetInferredFilePath(path, outputPath), builder.ToString());
                }
            }
        }

        private PlaceholderTerminal GetTerminal(string id, string script)
        {
            var interpreter = new Interpreter();
            var functionFactory = new FunctionFactory();
            var symbolTerminal = interpreter.Interpret(functionFactory, script);
            var terminal = new PlaceholderTerminal(id, symbolTerminal);
            
            return terminal;
        }
        
        private string GetInferredFilePath(string projectFilePath, string filePath)
        {
            if (Path.IsPathRooted(filePath))
                return filePath;
            else
                return Path.Combine(Path.GetDirectoryName(projectFilePath), filePath);
        }
    }
}
