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
            var fileOption = new Option<string>( new[] { "--file", "-f" }, "The path to a Qik project configuration file.");
            fileOption.IsRequired = false;
            fileOption.Argument.Arity = ArgumentArity.ExactlyOne;

            var inputsOption =  new Option<string>(new[] { "--terminal", "-t" }, "Assign inputs to any input variables.");
            inputsOption.IsRequired = false;
            inputsOption.Argument.Arity = ArgumentArity.ExactlyOne; 


            var cmd = new Command("terminal", "Interactive Terminal.")
            {
                fileOption,
                inputsOption
            };

            cmd.Handler = CommandHandler.Create<string, string>((Action<string, string>)((file, inputs) =>
            {
                Display();
            }));

            return cmd;
        }

        public void Display()
        {
            DisplayWelcomeHeader();
            Console.WriteLine("Welcome to the terminal!");
            Console.ReadLine();
        }
    }
}