﻿using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikExpressions
{
    public class QikExpression : IQikExpression
    {
        private QikFunction func = null;
        public string Symbol { get; private set; }
        public string Title { get; private set; }
        private ScopeTable scopeTable;

        internal QikExpression(ScopeTable scopeTable, string symbol, string title, QikFunction func)
        {
            this.Symbol = symbol;
            this.func = func;
            this.Title = title;
            this.scopeTable = scopeTable;
            this.scopeTable.UpdateSymbol(title, symbol);
        }

        public string Execute()
        {
            string newValue = this.func.Execute();
            scopeTable.UpdateSymbol(this.Title, this.Symbol, newValue);
            return newValue;
        }
    }
}
