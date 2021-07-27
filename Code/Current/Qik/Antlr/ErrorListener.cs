using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CygSoft.Qik.Antlr
{
    internal class ErrorListener : BaseErrorListener
    {
        public event EventHandler<InterpretErrorEventArgs> SyntaxErrorDetected;

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            // TODO: Implement below commented out when have time to check and test the impact

            // if (output is null) throw new ArgumentNullException($"{nameof(output)} cannot be null.");
            // if (recognizer is null) throw new ArgumentNullException($"{nameof(recognizer)} cannot be null.");
            // if (offendingSymbol is null) throw new ArgumentNullException($"{nameof(offendingSymbol)} cannot be null.");
            // if (e is null) throw new ArgumentNullException($"RecognitionException cannot be null.");

            var stack = ((Parser)recognizer).GetRuleInvocationStack();
            stack.Reverse();

            SyntaxErrorDetected?.Invoke(this, new InterpretErrorEventArgs(UserFriendlyContext(stack[0].ToString()), line, charPositionInLine, offendingSymbol.ToString(), msg));
        }

        private string UserFriendlyContext(string stackId)
        {
            //
            // TODO (Rob) You'll need to update this or find another strategy
            switch (stackId)
            {
                case "template":
                    return "Main Script";
                case "ctrlDecl":
                    return "Input Control";
                case "exprDecl":
                    return "Expression Declaration";
                case "ifOptExpr":
                    return "If Expression";
                case "declArgs":
                    return "Declaration Parameters";
                case "declArg":
                    return "Declaration Parameter";
                case "concatExpr":
                    return "Concatenation Expression";
                case "func":
                    return "Function Expression";
                case "funcArg":
                    return "Function Argument";
                default:
                    return stackId;
            }
        }
    }
}
