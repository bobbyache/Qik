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

        public CmdlineGenerator(NLog.ILogger logger)
        {
            this.logger = logger;
        }
        public void Start(string filePath)
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(new Resources().GetWelcomeHeader());
            ForegroundColor = ConsoleColor.White;

            if (string.IsNullOrWhiteSpace(filePath))
            {
                WriteLine("Please specify a path. See --help for more information.");
            }

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                try
                {
                    WriteLine("Generating output files...");
                    // appHost.Generate(filePath);
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("...Success!");
                    ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "ooops and exception occurred.");
                    LogConsoleError(ex);
                }
            }
            else
            {
                WriteLine("Invalid input. Please see --help for information.");
            }
        }

        private static void LogConsoleError(Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("An error occurred!");
            WriteLine($"\t{ex.Message}");
            WriteLine("Please check the error logs");
            ForegroundColor = ConsoleColor.White;
        }
    }
}