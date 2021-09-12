using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public class GenerateCommand
    {
        private readonly NLog.ILogger logger;
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private readonly IOutputGenerator outputGenerator;

        public GenerateCommand(IProjectFile projectFile, IOutputGenerator outputGenerator, IFileFunctions fileFunctions, NLog.ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
            this.outputGenerator = outputGenerator ?? throw new ArgumentNullException($"{nameof(outputGenerator)} cannot be null.");
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
                    GenerateOutputFiles(filePath);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "ooops and exception occurred.");
                    DisplayConsoleError(ex);
                }
            }
        }

        private void GenerateOutputFiles(string filePath)
        {
            WriteLine("Generating output files...");
            outputGenerator.Generate(filePath);
            ForegroundColor = ConsoleColor.Green;
            WriteLine("...Success!");
            ForegroundColor = ConsoleColor.White;
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