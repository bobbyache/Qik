using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using CygSoft.Qik;
using CygSoft.Qik.QikConsole;

using NLog;
using NLog.Extensions.Logging;

//
// TODO: Find out how to dependency inject the logger in order to mock the interface for unit tests.
//  - Do we need these extensions? Check your QikConsole.csproj file. Remove them if you can't find a use for them.

// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.DependencyInjection.Extensions;

class Program
{
        public static int Main(string[] args)
        {
            IAppHost appHost = null;
            IRootMenu cmdLine = null;
            NLog.ILogger logger = null;
            // FileSettings settings = null;
            ServiceProvider serviceProvider = null;

            string projectPath = null;

            var rootCommand = new RootCommand("Qik Console Application");

            rootCommand.Add(LoadCommand.Configure(projectPath));
            rootCommand.Add(ProcessorCommand.Configure());

            //
            // Parameters of the handler method are matched according to the names of the options.
            // rootCommand.Handler = CommandHandler.Create<string>((Action<string>)((path) =>
            // {
            //     cmdLine.Enter(path);
            // }));

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
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
                .AddSingleton<ILogger>(logger)
                .AddSingleton<IFileFunctions>(ah => new FileFunctions())
                .AddSingleton<IProjectFile, ProjectFile>()
                .AddSingleton<IAppHost, MainHost>()
                .AddSingleton<IRootMenu, RootMenu>()
            ;

            serviceProvider = services.BuildServiceProvider();

            appHost = serviceProvider.GetService<IAppHost>();
            cmdLine = serviceProvider.GetService<IRootMenu>();
            

            //
            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }
}