using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public static class LoadCommand
    {
        public static Command Configure(string path)
        {
            var loadCommand = new Command("load", "Loads a Qik project file.")
            {
                new Option<string>( new[] { "--path", "-p" }, "The path to a Qik project configuration file.")
            };

            loadCommand.Handler = CommandHandler.Create<string>((Action<string>)((path) =>
            {
                WriteLine("Loading the project...");
                WriteLine(path);
            }));

            return loadCommand;
        }
    }
}