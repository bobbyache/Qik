using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qik.UiWidgets
{
    public class UiWidget
    {
        public string Symbol { get; }
        public string Title { get; internal set; }
        public string Type { get; internal set; }

        internal UiWidget(string symbol)
        {
            Symbol = symbol;
        }
    }
}