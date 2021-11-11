using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CygSoft.Qik.Functions
{
    public interface IFunctionFactory
    {
        IFunction GetFunction(string name, List<IFunction> functionArguments);
    }

    public class FunctionFactory : IFunctionFactory
    {
        // private string pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""); 
        // string[] files = Directory.GetFiles(addinFolder, "*.dll", SearchOption.TopDirectoryOnly);
        Dictionary<string, System.Type> functionTypes = new Dictionary<string, Type>();
        
        public FunctionFactory()
        {
            GetFunctionPlugins();
        }
        private void GetFunctionPlugins()
        {
            var pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins"); 

            if (!Directory.Exists(pluginFolder))
                return;

            var assembly = Assembly.LoadFile(Path.Combine(pluginFolder, "QikFunnyFunctions.dll"));
            // var assembly =  Assembly.GetExecutingAssembly();           

            foreach (var type in assembly.GetTypes())
            {
                if (type.BaseType == typeof(BaseFunction))
                {
                    var attrs = System.Attribute.GetCustomAttributes(type);
                    foreach (var attr in attrs)
                    {
                        if (attr is QikFunctionAttribute)
                        {
                            var functionAttribute = (QikFunctionAttribute)attr;
                            functionTypes.Add(functionAttribute.Symbol, type);
                        }
                    }
                }
            }
        }

        private IFunction GetPluginFunction(string name, List<IFunction> functionArguments)
        {
            var success = functionTypes.TryGetValue(name, out Type functionType);
            if (success)
            {
                var function = (IFunction)Activator.CreateInstance(functionType, new object[] { name, functionArguments });
                return function;
            }
            return null;
        }

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

                case "urlEncode":
                    func = new UrlEncodeFunction(name, functionArguments);
                    break;

                case "urlDecode":
                    func = new UrlDecodeFunction(name, functionArguments);
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
                    func = GetPluginFunction(name, functionArguments);
                    break;
            }

            if (func == null)
                throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", name));

            return func;
        }
    }
}
