using System.Collections.Generic;

namespace CygSoft.Qik.QikConsole
{
    public class Project
    {
        public List<Fragment> Fragments { get; set; } = new List<Fragment>();
        public List<Processor> Processors { get; set; } = new List<Processor>();
        public List<Document> Documents { get; set; } = new List<Document>();
    }

    public class Fragment
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public string[] Processors { get; set; }
    }

    public class Processor
    {
        public string Id { get; set; }
        public string ScriptFile { get; set; }
    }

    public class Document
    {
        public string[] OutputFilePaths { get; set; }
        public string[] Structure { get; set; }
    }
}
