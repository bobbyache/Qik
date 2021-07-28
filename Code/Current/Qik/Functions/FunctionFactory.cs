using System;
using System.Collections.Generic;

namespace CygSoft.Qik.Functions
{
    public interface IFunctionFactory
    {
        IFunction GetFunction(string name, List<IFunction> functionArguments);
    }

    public class FunctionFactory : IFunctionFactory
    {
        public IFunction GetFunction(string name, List<IFunction> functionArguments)
        {
            if (name is null) throw new ArgumentNullException($"{nameof(name)} cannot be null.");
            if (functionArguments is null) throw new ArgumentNullException($"{nameof(functionArguments)} cannot be null.");

            IFunction func;

            switch (name)
            {
                case "camelCase":
                    func = new CamelCaseFunction(name, functionArguments);
                    break;

                case "currentDate":
                    func = new CurrentDateFunction(name, functionArguments);
                    break;

                case "lowerCase":
                    func = new LowerCaseFunction(name, functionArguments);
                    break;

                case "upperCase":
                    func = new UpperCaseFunction(name, functionArguments);
                    break;

                case "properCase":
                    func = new ProperCaseFunction(name, functionArguments);
                    break;

                case "removeSpaces":
                    func = new RemoveSpacesFunction(name, functionArguments);
                    break;

                case "removePunctuation":
                    func = new RemovePunctuationFunction(name, functionArguments);
                    break;

                case "replace":
                    func = new ReplaceFunction(name, functionArguments);
                    break;

                case "indentLine":
                    func = new IndentFunction(name, functionArguments);
                    break;

                case "doubleQuote":
                    func = new DoubleQuoteFunction(name, functionArguments);
                    break;

                case "htmlEncode":
                    func = new HtmlEncodeFunction(name, functionArguments);
                    break;

                case "htmlDecode":
                    func = new HtmlDecodeFunction(name, functionArguments);
                    break;

                case "guid":
                    var guidFunction = new GuidFunction(name, functionArguments);
                    func = guidFunction;
                    break;
                case "padLeft":
                    func = new PadLeftFunction(name, functionArguments);
                    break;
                case "padRight":
                    func = new PadRightFunction(name, functionArguments);
                    break;
                case "abbreviate":
                    func = new AbbreviateFunction(name, functionArguments);
                    break;

                default:
                    func = null;
                    break;
            }

            if (func == null)
                throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", name));

            return func;
        }
    }
}
