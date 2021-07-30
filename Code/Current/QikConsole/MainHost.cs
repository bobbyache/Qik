
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace CygSoft.Qik.Console
{
    public class MainHost : IAppHost
    {
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private Dictionary<string, string> fragmentsDictionary = new Dictionary<string, string>();

        public MainHost(IProjectFile projectFile, IFileFunctions fileFunctions)
        {
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
        }

        public void Generate(string path)
        {
            var project = projectFile.Read(path);
            
            GenerateFragments(path, project);
            GenerateDocuments(path, project);
        }

        public void GenerateFragments(string path, Project project)
        {
            var service = new TerminalService(fileFunctions, path, project);

            foreach (var frag in project.Fragments)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), frag.Path);
                var templateText = fileFunctions.ReadTextFile(fullPath);

                foreach (var processorId in frag.Processors)
                {
                    templateText = service.Execute(processorId, templateText);
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
                    fileFunctions.WriteTextFile(fileFunctions.GetRootedFilePath(path, outputPath), builder.ToString());
                }
            }
        }
    }
}
