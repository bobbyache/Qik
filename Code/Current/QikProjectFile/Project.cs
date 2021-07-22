using System;
using System.Collections.Generic;

namespace QikProjectFile
{
    public class Project
    {
        public string PlaceholderPrefix { get; set; }
        public string PlaceholderPostfix {get; set; }

        public List<Fragment> Fragments { get; set; } = new List<Fragment>();
        public List<Processor> Processors { get; set; } = new List<Processor>();
        public List<Document> Documents { get; set; } = new List<Document>();
    }

    public class Fragment
    {
        public string Id { get; set; }
        public string[] Processors { get; set; }
    }

    public class Processor
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string InputFile { get; set; }
        public string ScriptFile { get; set; }
    }

    public class Document
    {
        public string Id { get; set; }
        public string OutputFilePath { get; set; }
        public string Properties { get; set; }
    }
}
