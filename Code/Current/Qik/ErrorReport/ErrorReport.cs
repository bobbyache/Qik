﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CygSoft.Qik
{
    internal class ErrorReport : IErrorReport
    {
        public event EventHandler<CompileErrorEventArgs> ExecutionErrorDetected;

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
            ExecutionErrorDetected?.Invoke(this, new CompileErrorEventArgs("Execution Error", error.Line, error.Column, "", error.Message));
        }

        public void Clear()
        {
            errors.Clear();
        }        
    }
}
