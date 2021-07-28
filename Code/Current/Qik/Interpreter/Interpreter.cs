using Antlr4.Runtime;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    public class Interpreter : IInterpreter
    {
        public ISymbolTerminal Interpret(string scriptText)
        {
            var symbolTable = new SymbolTable();
            symbolTable.Clear();

            InterpretInputs(symbolTable, scriptText);
            InterpretExpressions(symbolTable, scriptText);

            return symbolTable;
        }

        private void InterpretExpressions(ISymbolTable symbolTable, string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var expressionVisitor = new ExpressionVisitor(symbolTable);
            expressionVisitor.Visit(tree);
        }

        private void InterpretInputs(ISymbolTable symbolTable, string scriptText)
        {
            var inputStream = new AntlrInputStream(scriptText);
            var lexer = new QikTemplateLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new QikTemplateParser(tokens);

            var tree = parser.template();

            var controlVisitor = new UserInputVisitor(symbolTable);
            controlVisitor.Visit(tree);
        }
    }
}
