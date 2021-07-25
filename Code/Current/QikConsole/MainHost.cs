
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CygSoft.Qik.Console
{
    //TODO: Implement the new QikProjectFile structure and start thinking
    // about how it can be implemented.
    public class MainHost : IAppHost
    {
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;

        private Dictionary<string, KeyValuePair<string, string>[]> interpreterDictionary = new Dictionary<string, KeyValuePair<string, string>[]>();
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
            var project = projectFile.Read(path);
            
            foreach(var processor in project.Processors)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), processor.ScriptFile);
                interpreterDictionary.Add(processor.Id, new ScriptInterpreter().GetPlaceholderLookups(fileFunctions.ReadTextFile(fullPath)));
            }

            foreach (var frag in project.Fragments)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), frag.Path);
                var templateText = fileFunctions.ReadTextFile(fullPath);

                foreach (var prroc in frag.Processors)
                {
                    if (frag.Processors.Contains(prroc) && interpreterDictionary.ContainsKey(prroc))
                    {
                        var interpreter = interpreterDictionary[prroc];
                        foreach (var val in interpreterDictionary[prroc])
                        {
                            templateText = templateText.Replace(val.Key, val.Value);
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

        private string GetInferredFilePath(string projectFilePath, string filePath)
        {
            if (Path.IsPathRooted(filePath))
                return filePath;
            else
                return Path.Combine(Path.GetDirectoryName(projectFilePath), filePath);
        }
    }
}
