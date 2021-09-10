using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public interface ICmdlineGenerator
    {
        void Start(string filePath);
    }

    public class CmdlineGenerator : ICmdlineGenerator
    {
        private readonly NLog.ILogger logger;
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private readonly IAppHost appHost;

        public CmdlineGenerator(IProjectFile projectFile, IAppHost appHost, IFileFunctions fileFunctions, NLog.ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
            this.appHost = appHost ?? throw new ArgumentNullException($"{nameof(appHost)} cannot be null.");
        }

        public void Start(string filePath)
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
                    EnterExecutionLoop(filePath);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "ooops and exception occurred.");
                    DisplayConsoleError(ex);
                }
            }
        }

        private void EnterExecutionLoop(string filePath)
        {
            Console.WriteLine("Please enter your choice:");
            string choice = Console.ReadLine();
            GenerateOutputFiles(filePath);

            while (choice.ToLower() != "q")
            {
                Console.WriteLine("Please enter your choice:");
                choice = Console.ReadLine();
                GenerateOutputFiles(filePath);
            }
        }

        private void GenerateOutputFiles(string filePath)
        {
            WriteLine("Generating output files...");
            appHost.Generate(filePath);
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