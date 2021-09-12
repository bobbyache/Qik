using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace CygSoft.Qik.QikConsole
{
    using static System.Console;

    public static class ProcessorCommand
    {
        public static Command Configure()
        {
            var processorsListCommand = new Command("ls", "List all processors");

            var processorsAddCommand = new Command("add", "Add a processor")
            {
                new Option<string>( new[] { "--id", "-i" } , "The unique text id for the processor."),
                new Option<string>( new[] { "--script", "-s" } , "The qik script file for the processor."),
            };

            var processorsUpdateCommand = new Command("update", "Update a processor (resets all input variables)")
            {
                new Option<string>( new[] { "--id", "-i" } , "The unique text id for the processor."),
            };

            var processorsRemoveCommand = new Command("remove", "Update a processor (resets all input variables)")
            {
                new Option<string>( new[] { "--id", "-i" } , "The unique text id for the processor."),
            };

            var processorsCommand = new Command("processors", "Handles processors. Processors parse Qik files and generate input and output expressions.");

            processorsCommand.Add(processorsListCommand);
            processorsCommand.Add(processorsAddCommand);
            processorsCommand.Add(processorsUpdateCommand);
            processorsCommand.Add(processorsRemoveCommand);

            processorsListCommand.Handler = CommandHandler.Create(() =>
            {
                WriteLine("Listing processes...");
            });

            processorsAddCommand.Handler = CommandHandler.Create<string, string>((Action<string, string>)((id, script) =>
            {
                WriteLine("Adding processor...");
                WriteLine(id);
                WriteLine(script);
            }));

            processorsUpdateCommand.Handler = CommandHandler.Create<string>((Action<string>)((id) =>
            {
                WriteLine("Updating processor...");
                WriteLine(id);
            }));

            processorsRemoveCommand.Handler = CommandHandler.Create<string>((Action<string>)((id) =>
            {
                WriteLine("Removing processor...");
                WriteLine(id);
            }));

            return processorsCommand;
        }
    }
}