using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public enum CommandType
    {
        Generate,
        SymbolUpdate
    }

    public interface ICommandFactory
    {
        public Command Create(CommandType commandType);
    }

    public class CommandFactory : ICommandFactory
    {
        private readonly NLog.ILogger logger;
        private readonly IProjectFile projectFile;
        private readonly IFileFunctions fileFunctions;
        private readonly IOutputGenerator outputGenerator;
        public CommandFactory(IProjectFile projectFile, IOutputGenerator outputGenerator, IFileFunctions fileFunctions, NLog.ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            this.projectFile = projectFile ?? throw new ArgumentNullException($"{nameof(projectFile)} cannot be null.");
            this.fileFunctions = fileFunctions ?? throw new ArgumentNullException($"{nameof(fileFunctions)} cannot be null.");
            this.outputGenerator = outputGenerator ?? throw new ArgumentNullException($"{nameof(outputGenerator)} cannot be null.");
        }

        public Command Create(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Generate:
                    return new SymbolCommand(projectFile, outputGenerator, fileFunctions, logger).Configure();

                case CommandType.SymbolUpdate:
                    return new GenerateCommand(projectFile, outputGenerator, fileFunctions, logger).Configure();
                
                default:
                    throw new NotImplementedException();
            }
        }
    }
}