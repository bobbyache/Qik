using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik
{
    // TODO: Turn on nullability per project - although this may not be necessary with .net 5?
    internal class ErrorReport : IErrorReport
    {
        public event EventHandler<InterpretErrorEventArgs> ExecutionErrorDetected;

        readonly List<CustomError> errors = new List<CustomError>();

        public bool HasErrors { get { return errors.Count() > 0; } }
        public bool Reporting { get; set; }
        
        public CustomError[] Errors
        {
            get { return errors.ToArray(); }
        }

        public void AddError(CustomError error)
        {
            if (!Reporting)
                return;

            errors.Add(error);
            ExecutionErrorDetected?.Invoke(this, new InterpretErrorEventArgs("Execution Error", error.Line, error.Column, "", error.Message));
        }

        public void Clear()
        {
            errors.Clear();
        }        
    }
}
