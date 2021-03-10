﻿using Microsoft.Extensions.Configuration;
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
            Settings settings = null;

            // TODO: Investigate why when you run after cd ~ with the *.exe fule path you get an error about a missing appsettings.json
            // TODO: Why, when executing with Powershell... does the program not end but remain running?
            var rootCommand = new RootCommand
            {
                new Option(new[] { "--inputs", "-i" }, "Do not process. Just provide input information"),
                new Option<string>( new[] { "--path", "-p" } , "The path (can be a qik file or a folder containining a qik file")
            };

            rootCommand.Description = "Qik Console Application";

            // Note that the parameters of the handler method are matched according to the names of the options
            rootCommand.Handler = CommandHandler.Create<bool, string>((Action<bool, string>)(
                (
                    inputs,
                    path
                ) =>
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(new Resources().GetWelcomeHeader());
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Please specify a path. See --help for more information.");
                }

                if (inputs && !string.IsNullOrWhiteSpace(path))
                {
                    try
                    {
                        Console.WriteLine("Generating inputs...");
                        Console.WriteLine(appHost.GetJsonInputInterface(path));
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
                else if (!string.IsNullOrWhiteSpace(path))
                {
                    try
                    {
                        Console.WriteLine("Generating output files...");
                        appHost.Generate(path, settings.BlueprintExtensions);
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
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            settings = config.GetSection("Settings").Get<Settings>();

            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            logger = LogManager.Setup()
                                .LoadConfigurationFromSection(config)
                                .GetCurrentClassLogger();
            
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IJsonFunctions, JsonFunctions>()
                .AddSingleton<IFileFunctions, FileFunctions>()
                .AddSingleton<IInterpreter, Interpreter>()
                .AddSingleton<IAppHost, AppHost>()
            .BuildServiceProvider();

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