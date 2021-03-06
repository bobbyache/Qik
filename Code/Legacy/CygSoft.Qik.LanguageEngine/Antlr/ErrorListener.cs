﻿using Antlr4.Runtime;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik.LanguageEngine.Antlr
{
    internal class ErrorListener : BaseErrorListener
    {
        public event EventHandler<CompileErrorEventArgs> SyntaxErrorDetected;

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IList<string> stack = ((Parser)recognizer).GetRuleInvocationStack();
            stack.Reverse();

            SyntaxErrorDetected?.Invoke(this, new CompileErrorEventArgs(UserFriendlyContext(stack[0].ToString()), line, charPositionInLine, offendingSymbol.ToString(), msg));
        }

        private string UserFriendlyContext(string stackId)
        {
            switch (stackId)
            {
                case "template":
                    return "Main Script";
                case "ctrlDecl":
                    return "Input Control";
                case "optExpr":
                    return "Option Expression";
                case "optionsBody":
                    return "Option Box";
                case "textBox":
                    return "Text Box";
                case "singleOption":
                    return "Single Option";
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
