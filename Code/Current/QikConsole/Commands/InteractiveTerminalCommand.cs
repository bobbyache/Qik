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

    public class InteractiveTerminalCommand : BaseCommand
    {
        private Dictionary<string, string> fragmentsDictionary = new Dictionary<string, string>();

        public InteractiveTerminalCommand(IProjectFile projectFile, IFileFunctions fileFunctions, NLog.ILogger logger): base (projectFile, fileFunctions, logger){}

        public override Command Configure()
        {
            var cmd = new Command("terminal", "Interactive Terminal.");

            cmd.Handler = CommandHandler.Create(() =>
            {
                DisplayWelcomeHeader();
                Display();
                MainMenu();
                
            });

            return cmd;
        }

        private void Display()
        {
            // DisplayWelcomeHeader();
            Console.WriteLine($"Current Library folder is: {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Library")}");
            Console.WriteLine("Welcome to the terminal!");
        }

        private void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(" X.\tView Projects");
            Console.WriteLine(" X.\tOpen Project");
            Console.WriteLine(" X.\tCreate Project");
            Console.WriteLine();
            Console.ReadLine();
        }


    }
}