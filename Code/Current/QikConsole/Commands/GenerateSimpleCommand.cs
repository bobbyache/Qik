using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using CygSoft.Qik.Functions;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public class GenerateSimpleCommand : BaseCommand
    {
        private Dictionary<string, string> fragmentsDictionary = new Dictionary<string, string>();

        public GenerateSimpleCommand(IProjectFile projectFile, IFileFunctions fileFunctions, NLog.ILogger logger): base (projectFile, fileFunctions, logger){}

        public override Command Configure()
        {
            var fileOption = new Option<string>( new[] { "--file", "-f" }, "The path to a Qik project configuration file.");
            fileOption.IsRequired = true;
            fileOption.Argument.Arity = ArgumentArity.ExactlyOne;

            var inputsOption =  new Option<string>(new[] { "--inputs", "-i" }, "Assign inputs to any input variables.");
            inputsOption.IsRequired = false;
            inputsOption.Argument.Arity = ArgumentArity.ExactlyOne; 


            var cmd = new Command("simple", "Generates from a single input set.")
            {
                fileOption,
                inputsOption
            };

            cmd.Handler = CommandHandler.Create<string, string>((Action<string, string>)((file, inputs) =>
            {
                ExcecuteAll(file, inputs);
            }));

            return cmd;
        }

        private void ExcecuteAll(string filePath, string inputs)
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
                    var inputList = inputs is not null ? SetInputs(inputs) : new Input[0];
                    Generate(filePath, inputList);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "ooops and exception occurred.");
                    DisplayConsoleError(ex);
                }
            }
        }

        private Input[] SetInputs(string inputs)
        {
            var keyValues = inputs.Split(";")
                .Select(a =>
                {
                    var parts = a.Split('=');
                    return new Input()
                    {
                        Symbol = "@" + parts[0],
                        Value = parts[1]   //maybe you need to check something here
                    };
                });

            return keyValues.ToArray();
        }


        private void Generate(string filePath, Input[] inputs)
        {
            WriteLine("Generating output files...");

            fragmentsDictionary = new Dictionary<string, string>();
            var project = projectFile.Read(filePath);
            
            GenerateFragments(filePath, inputs, project);
            GenerateDocuments(filePath, project);

            ForegroundColor = ConsoleColor.Green;
            WriteLine("...Success!");
            ForegroundColor = ConsoleColor.White;
        }

        private void GenerateFragments(string path, Input[] inputs, Project project)
        {
            var scriptPath = Path.Combine(Path.GetDirectoryName(path), project.ScriptPath);
            var script = fileFunctions.ReadTextFile(scriptPath);
            var interpreter = new Interpreter();
            var symbolTerminal = interpreter.Interpret(new FunctionFactory(new PluginLoader()), script);
            var terminal = new PlaceholderTerminal(symbolTerminal, "@{", "}");

            foreach(var input in inputs)
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

        private void GenerateDocuments(string path, Project project)
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