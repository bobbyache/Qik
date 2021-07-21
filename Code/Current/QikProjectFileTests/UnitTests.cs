using System.Linq;
using NUnit.Framework;
using QikProjectFile;
using QikProjectFileTests.Helpers;

namespace QikProjectFileTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Write_To_Project_File()
        {
            var project = new Project();
            project.PlaceholderPrefix = "{{";
            project.PlaceholderPostfix = "}}";
            
            project.Fragments.Add(new Fragment { Id = "fragment_A", Processors = new string [2] {"simple_processor", "matrix_processor"} });
            project.Fragments.Add(new Fragment { Id = "fragment_B", Processors = new string [0] });

            project.Processors.Add(new Processor { Id = "simple_processor", Type = "simple", InputFile = "key_value_pairs.txt", ScriptFile = "kv_script_file.qik" });
            project.Processors.Add(new Processor { Id = "matrix_processor", Type = "matrix", InputFile = "csv_data.csv", ScriptFile = "csv_script_file.qik" });

            project.Documents.Add(new Document { Id = "document_A", Strategy = "partial_overwrite", OutputFilePath = "/documents/document1.txt", Line = 26 });
            project.Documents.Add(new Document { Id = "document_B", Strategy = "full_replace", OutputFilePath = "/documents/document2.txt" });

            var writer = new ProjectFile();
            writer.Write(project, FileHelpers.ResolvePath("project.json"));

            var writtenProject = writer.Read(FileHelpers.ResolvePath("project.json"));

            FileHelpers.DeleteFile("project.json");

            Assert.IsNotNull(writtenProject);
            Assert.IsTrue(writtenProject.PlaceholderPrefix == "{{", "Unexpected prefix read from project file");
            Assert.IsTrue(writtenProject.PlaceholderPostfix == "}}", "Unexpected postfix read from project file");
            Assert.IsTrue(writtenProject.Fragments.Count() == 2, "Unexpected number of fragments read from project file");

            var fragmentA = project.Fragments[0];
            var fragmentB = project.Fragments[1];

            Assert.IsTrue(fragmentA.Id == "fragment_A", "Unexpected fragment id read from project file");
            Assert.IsTrue(fragmentB.Id == "fragment_B", "Unexpected fragment id read from project file");


            Assert.IsTrue(fragmentA.Processors.Count() == 2, "Unexpected processor count read from project file");
            Assert.IsTrue(fragmentB.Processors.Count() == 0, "Unexpected processor count read from project file");

            Assert.IsTrue(fragmentA.Processors[0] == "simple_processor", "Unexpected processor id read from project file");
            Assert.IsTrue(fragmentA.Processors[1] == "matrix_processor", "Unexpected processor id read from project file");

            Assert.IsTrue(writtenProject.Processors.Count() == 2);

            var processorA = writtenProject.Processors[0];

            Assert.IsTrue(processorA.Id == "simple_processor", "Unexpected processor id read from project file");
            Assert.IsTrue(processorA.Type == "simple", "Unexpected processor type read from project file");
            Assert.IsTrue(processorA.InputFile == "key_value_pairs.txt", "Unexpected processor input file read from project file");
            Assert.IsTrue(processorA.ScriptFile == "kv_script_file.qik", "Unexpected processor script file read from project file");

            var processorB = writtenProject.Processors[1];

            Assert.IsTrue(processorB.Id == "matrix_processor", "Unexpected processor id read from project file");
            Assert.IsTrue(processorB.Type == "matrix", "Unexpected processor type read from project file");
            Assert.IsTrue(processorB.InputFile == "csv_data.csv", "Unexpected processor input file read from project file");
            Assert.IsTrue(processorB.ScriptFile == "csv_script_file.qik", "Unexpected processor script file read from project file");


            Assert.IsTrue(writtenProject.Documents.Count() == 2);

            var documentA = writtenProject.Documents[0];

            Assert.IsTrue(documentA.Id == "document_A", "Unexpected document id read from project file");
            Assert.IsTrue(documentA.Strategy == "partial_overwrite", "Unexpected document strategy read from project file");
            Assert.IsTrue(documentA.OutputFilePath == "/documents/document1.txt", "Unexpected document output file read from project file");
            Assert.IsTrue(documentA.Line == 26, "Unexpected Line no. read from project file");

            var documentB = writtenProject.Documents[1];

            Assert.IsTrue(documentB.Id == "document_B", "Unexpected document id read from project file");
            Assert.IsTrue(documentB.Strategy == "full_replace", "Unexpected document strategy read from project file");
            Assert.IsTrue(documentB.OutputFilePath == "/documents/document2.txt", "Unexpected document output file read from project file");
            Assert.IsNull(documentB.Line, "Expected a null line number to be read from project file");
        }
    }
}