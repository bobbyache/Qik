using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using CygSoft.Qik;
using CygSoft.Qik.Console;

using NLog;
using NLog.Extensions.Logging;

// TODO: Find out how to dependency inject the logger in order to mock the interface for unit tests.
// Do we need these extensions? Check your QikConsole.csproj file. Remove them if you can't find a use for them.

// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.DependencyInjection.Extensions;

class Program
{
        public static int Main(string[] args)
        {
            IAppHost appHost = null;
            NLog.ILogger logger = null;
            // FileSettings settings = null;
            ServiceProvider serviceProvider = null;

            // TODO: Why, when executing with Powershell... does the program not end but remain running?
            var rootCommand = new RootCommand
            {
                new Option<string>( new[] { "--path", "-p" } , "The path to a Qik project configuration file.")
            };

            rootCommand.Description = "Qik Console Application";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<string>((Action<string>)((path) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(new Resources().GetWelcomeHeader());
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Please specify a path. See --help for more information.");
                }

                if (!string.IsNullOrWhiteSpace(path))
                {
                    try
                    {
                        Console.WriteLine("Generating output files...");
                        appHost.Generate(path);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("...Success!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "ooops and exception occurred.");
                        LogConsoleError(ex);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please see --help for information.");
                }
            }));

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory /* Directory.GetCurrentDirectory() */)
                .AddJsonFile("appsettings.json").Build();

            //
            // Keep for now, since we may want to use configuration settings again!
            // settings = config.GetSection(nameof(FileSettings)).Get<FileSettings>();

            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            logger = LogManager.Setup()
                                .LoadConfigurationFromSection(config)
                                .GetCurrentClassLogger();
            
            var services = new ServiceCollection()
                .AddSingleton<IInterpreter, Interpreter>()
                .AddSingleton<IFileFunctions>(ah => new FileFunctions())
                .AddSingleton<IProjectFile, ProjectFile>()
                .AddSingleton<IAppHost, MainHost>()
            ;

            serviceProvider = services.BuildServiceProvider();

            appHost = serviceProvider.GetService<IAppHost>();

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }

        private static void LogConsoleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred!");
            Console.WriteLine($"\t{ex.Message}");
            Console.WriteLine("Please check the error logs");
            Console.ForegroundColor = ConsoleColor.White;
        }
}