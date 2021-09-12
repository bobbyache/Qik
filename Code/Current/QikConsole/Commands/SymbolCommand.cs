using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public class SymbolCommand
    {
        private readonly NLog.ILogger logger;
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private readonly IOutputGenerator outputGenerator;
        public SymbolCommand(IProjectFile projectFile, IOutputGenerator outputGenerator, IFileFunctions fileFunctions, NLog.ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
            this.outputGenerator = outputGenerator ?? throw new ArgumentNullException($"{nameof(outputGenerator)} cannot be null.");
        }

        public Command Configure()
        {
            var cmd = new Command("sym", "Modifies a symbol value.")
            {
                new Option<string>( new[] { "--file", "-f" }, "The path to a Qik project configuration file."),
                new Option<string>( new[] { "--key", "-k" }, "The key or symbol for the input (leave out the @ symbol or the call will fail)."),
                new Option<string>( new[] { "--value", "-v" }, "The value of the input.")
            };

            cmd.Handler = CommandHandler.Create<string, string, string>((Action<string, string, string>)((file, key, value) =>
            {
                SetInputValue(file, key, value);
            }));

            return cmd;
        }

        private void SetInputValue(string filePath, string key, string value)
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
                    SetSymbol(filePath, key, value);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "ooops and exception occurred.");
                    DisplayConsoleError(ex);
                }
            }
        }

        private void SetSymbol(string filePath, string key, string value)
        {
            string symbol = "@" + key;

            var project = projectFile.Read(filePath);
            var input = project.Inputs.Where(i => i.Symbol == symbol).SingleOrDefault();
            if (input is not null)
            {
                input.Value = value;
            }
            else
            {
                project.Inputs.Add(new Input() { Symbol = symbol, Value = value });
            }
            projectFile.Write(project, filePath);
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