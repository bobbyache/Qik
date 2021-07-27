using System;
using System.Collections.Generic;

namespace CygSoft.Qik.Functions
{
    public class FunctionFactory
    {
        private readonly ISymbolTable symbolTable;

        public FunctionFactory(ISymbolTable symbolTable)
        {
            this.symbolTable= symbolTable?? throw new ArgumentNullException($"{nameof(symbolTable)} cannot be null.");
        }

        public IFunction GetFunction(string functionIdentifier, IFuncInfo funcInfo, List<IFunction> functionArguments)
        {
            if (functionIdentifier is null) throw new ArgumentNullException($"{nameof(functionIdentifier)} cannot be null.");
            if (funcInfo is null) throw new ArgumentNullException($"{nameof(funcInfo)} cannot be null.");
            if (functionArguments is null) throw new ArgumentNullException($"{nameof(functionArguments)} cannot be null.");

            IFunction func;

            switch (functionIdentifier)
            {
                case "camelCase":
                    func = new CamelCaseFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "currentDate":
                    func = new CurrentDateFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "lowerCase":
                    func = new LowerCaseFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "upperCase":
                    func = new UpperCaseFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "properCase":
                    func = new ProperCaseFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "removeSpaces":
                    func = new RemoveSpacesFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "removePunctuation":
                    func = new RemovePunctuationFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "replace":
                    func = new ReplaceFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "indentLine":
                    func = new IndentFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "doubleQuotes": // for backward compatibility...
                    func = new DoubleQuoteFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "doubleQuote":
                    func = new DoubleQuoteFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "htmlEncode":
                    func = new HtmlEncodeFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "htmlDecode":
                    func = new HtmlDecodeFunction(funcInfo, symbolTable, functionArguments);
                    break;

                case "guid":
                    var guidFunction = new GuidFunction(funcInfo, symbolTable, functionArguments);
                    func = guidFunction;
                    break;
                case "padLeft":
                    func = new PadLeftFunction(funcInfo, symbolTable, functionArguments);
                    break;
                case "padRight":
                    func = new PadRightFunction(funcInfo, symbolTable, functionArguments);
                    break;
                case "abbreviate":
                    func = new AbbreviateFunction(funcInfo, symbolTable, functionArguments);
                    break;

                default:
                    func = null;
                    break;
            }

            if (func == null)
                throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", functionIdentifier));

            return func;
        }
    }
}
