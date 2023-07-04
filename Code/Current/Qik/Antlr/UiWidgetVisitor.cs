using Antlr4.Runtime.Misc;
using Qik.UiWidgets;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.Antlr
{
    public class UiWidgetVisitor : QikTemplateBaseVisitor<string>
    {
        private List<UiWidget> widgets;

        internal UiWidgetVisitor(List<UiWidget> widgets)
        {
            this.widgets = widgets;    
        }

        public override string VisitInputDecl([NotNull] QikTemplateParser.InputDeclContext context)
        {
            var widget = new UiWidget(context.VARIABLE().GetText());            

            foreach (var dude in context.uiWidget().uiWidgetProperty())
            {
                var key = dude.uiWidgetKey().GetText();
                var val = dude.STRING().GetText().StripOuterQuotes();

                switch (key)
                {
                    case "title":
                        widget.Title = val;
                        break;
                    case "type":
                        widget.Type = val;
                        break;
                    default:
                        throw new ArgumentException($"UI Widget property ({key}) is not supported");
                }
            }
            widgets.Add(widget);

            return base.VisitInputDecl(context);
        }
    }
}