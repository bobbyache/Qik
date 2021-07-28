using System;

namespace CygSoft.Qik
{
    public class SyntaxErrorEventArgs
    {
        public int Line { get; }
        public int Column { get; }
        public string Message { get; }
        public string OffendingSymbol { get; }
        public string Location { get; }

        public SyntaxErrorEventArgs(string location, int line, int column, string offendingSymbol, string message)
        {
            Line = line;
            Column = column;
            Message = message;
            OffendingSymbol = offendingSymbol;
            Location = location;
        }

        public SyntaxErrorEventArgs(Exception exception)
        {
            Line = 0;
            Column = 0;
            Message = exception.Message;
            OffendingSymbol = "";
            Location = "Main Template";
        }
    }
}
