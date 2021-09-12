
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.QikConsole
{
    public class OutputGenerator : IOutputGenerator
    {
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private Dictionary<string, string> fragmentsDictionary = new Dictionary<string, string>();

        public OutputGenerator(IProjectFile projectFile, IFileFunctions fileFunctions)
        {
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
        }

        public void Generate(string path)
        {
            fragmentsDictionary = new Dictionary<string, string>();
            var project = projectFile.Read(path);
            
            GenerateFragments(path, project);
            GenerateDocuments(path, project);
        }

        public void GenerateFragments(string path, Project project)
        {
            var scriptPath = Path.Combine(Path.GetDirectoryName(path), project.ScriptPath);
            var script = fileFunctions.ReadTextFile(scriptPath);
            var interpreter = new Interpreter();
            var symbolTerminal = interpreter.Interpret(new FunctionFactory(), script);
            var terminal = new PlaceholderTerminal(symbolTerminal, "@{", "}");
            
            foreach (var frag in project.Fragments)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), frag.Path);
                var templateText = fileFunctions.ReadTextFile(fullPath);

                foreach (var placeholder in terminal.Placeholders)
                {
                    templateText = templateText.Replace(placeholder, terminal.GetValue(placeholder));
                }

                fragmentsDictionary.Add(frag.Id, templateText);
            }
        }

        public void GenerateDocuments(string path, Project project)
        {
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
                    var filePath = fileFunctions.GetRootedFilePath(path, outputPath);

                    if (fileFunctions.FileExists(filePath)) fileFunctions.DeleteFile(filePath);
                    
                    fileFunctions.WriteTextFile(filePath, builder.ToString());
                }
            }
        }
    }
}
