using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;


    public class MenuOption
    {

    }
    
    public interface IRootMenu
    {
        void Enter(string filePath);
    }

    public class RootMenu : IRootMenu
    {
        private readonly NLog.ILogger logger;
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private readonly IAppHost appHost;

        public RootMenu(IProjectFile projectFile, IAppHost appHost, IFileFunctions fileFunctions, NLog.ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
            this.appHost = appHost ?? throw new ArgumentNullException($"{nameof(appHost)} cannot be null.");
        }

        public void Enter(string filePath)
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


        private void DisplayMenu()
        {
            var processors = new List<Processor>()
            {
                new Processor() { ScriptFile = "script_1.qik", Id = "Deployment Script" },
                new Processor() { ScriptFile = "script_2.qik", Id = "Process Script" },
            };

            var menu = new Menu<Processor>();
            menu.AddItems(processors);
            var menuText = menu.GetReadableMenu();

            foreach(var menuItem in menuText)
            {
                WriteLine(menuItem);
            }
        }

        private void EnterExecutionLoop(string filePath)
        {
            var choice = EnterChoice();

            while (choice != "q")
            {
                DisplayMenu();
                // OpenProject(filePath);

                choice = EnterChoice();
            }
        }

        private string EnterChoice()
        {
            Console.WriteLine("Please enter your choice:");
            return Console.ReadLine();
        }

        private void OpenProject(string filePath)
        {
            appHost.OpenProject(filePath);
            foreach (var terminalId in appHost.GetTerminalList())
            {
                WriteLine(terminalId);
            }
        }

        private void GenerateOutput(string filePath)
        {
            WriteLine("Generating output files...");
            // appHost.OpenProject(filePath);
            // appHost.GetTerminalList();
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