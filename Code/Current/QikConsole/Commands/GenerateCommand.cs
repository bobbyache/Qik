using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public class GenerateCommand
    {
        private readonly NLog.ILogger logger;
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;

        private Dictionary<string, string> fragmentsDictionary = new Dictionary<string, string>();

        public GenerateCommand(IProjectFile projectFile, IFileFunctions fileFunctions, NLog.ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
        }

        public Command Configure()
        {
            var cmd = new Command("gen", "Generates from a project file.")
            {
                new Option<string>( new[] { "--file", "-f" }, "The path to a Qik project configuration file.")
            };

            cmd.Handler = CommandHandler.Create<string>((Action<string>)((file) =>
            {
                Generate(file);
            }));

            return cmd;
        }

        private void Generate(string filePath)
        {
            DisplayWelcomeHeader();

            if (string.IsNullOrWhiteSpace(filePath) || !fileFunctions.FileExists(filePath))
            {
                WriteLine("Please specify a valid path. See --help for more information.");
            }
            else
            {
                try
                {
                    WriteLine("Generating output files...");

                    fragmentsDictionary = new Dictionary<string, string>();
                    var project = projectFile.Read(filePath);
                    
                    GenerateFragments(filePath, project);
                    GenerateDocuments(filePath, project);

                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("...Success!");
                    ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "ooops and exception occurred.");
                    DisplayConsoleError(ex);
                }
            }
        }

        public void GenerateFragments(string path, Project project)
        {
            var scriptPath = Path.Combine(Path.GetDirectoryName(path), project.ScriptPath);
            var script = fileFunctions.ReadTextFile(scriptPath);
            var interpreter = new Interpreter();
            var symbolTerminal = interpreter.Interpret(new FunctionFactory(), script);
            var terminal = new PlaceholderTerminal(symbolTerminal, "@{", "}");

            foreach (var input in project.Inputs)
            {
                terminal.SetSymbolValue(input.Symbol, input.Value);
            }
            
            foreach (var frag in project.Fragments)
            {
                var fullPath = Path.Combine(Path.GetDirectoryName(path), frag.Path);
                var templateText = fileFunctions.ReadTextFile(fullPath);

                foreach (var placeholder in terminal.Placeholders)
                {
                    templateText = templateText.Replace(placeholder, terminal.GetPlaceholderValue(placeholder));
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

        private static void DisplayWelcomeHeader()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(new Resources().GetWelcomeHeader());
            ForegroundColor = ConsoleColor.White;
        }

        private static void DisplayConsoleError(Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("An error occurred!");
            WriteLine($"\t{ex.Message}");
            WriteLine("Please check the error logs");
            ForegroundColor = ConsoleColor.White;
        }
    }
}