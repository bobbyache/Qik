using CygSoft.Qik.Console;
using NUnit.Framework;
using System.Linq;
using Moq;

namespace QikConsoleTests
{
    [TestFixture]
    class ProjectFileTests
    {
        [Test]
        public void Should_Write_To_Project_File()
        {
            var project = new Project();
            
            project.Fragments.Add(new Fragment { Id = "fragment_A", Path = "C:\\Users\\RobB\\Desktop\\fragment_A.txt", Processors = new string [2] {"simple_processor", "matrix_processor"} });
            project.Fragments.Add(new Fragment { Id = "fragment_B", Path = "C:\\Users\\RobB\\Desktop\\fragment_B.txt", Processors = new string [0] });

            project.Processors.Add(new Processor { Id = "simple_processor", ScriptFile = "kv_script_file.qik" });
            project.Processors.Add(new Processor { Id = "matrix_processor", ScriptFile = "csv_script_file.qik" });

            project.Documents.Add(new Document 
            { 
                OutputFilePaths = new string[2] { "/documents/document1.txt", "/desktop/document2.txt" },
                Structure = new string [1] { "fragment_A" }
            });

            project.Documents.Add(new Document 
            { 
                OutputFilePaths = new string[1] { "/documents/document2.txt" },
                Structure = new string [2] {"fragment_A", "fragment_B" }
            });

            var writer = new ProjectFile();
            writer.Write(project, FileHelpers.ResolvePath("project.json"));

            var writtenProject = writer.Read(FileHelpers.ResolvePath("project.json"));

            FileHelpers.DeleteFile("project.json");

            Assert.IsNotNull(writtenProject);
            Assert.IsTrue(writtenProject.Fragments.Count() == 2, "Unexpected number of fragments read from project file");

            var fragmentA = project.Fragments[0];
            var fragmentB = project.Fragments[1];

            Assert.IsTrue(fragmentA.Id == "fragment_A", "Unexpected fragment id read from project file");
            Assert.IsTrue(fragmentB.Id == "fragment_B", "Unexpected fragment id read from project file");

            Assert.IsTrue(fragmentA.Path == "C:\\Users\\RobB\\Desktop\\fragment_A.txt", "Unexpected fragment path read from project file");
            Assert.IsTrue(fragmentB.Path == "C:\\Users\\RobB\\Desktop\\fragment_B.txt", "Unexpected fragment path read from project file");


            Assert.IsTrue(fragmentA.Processors.Count() == 2, "Unexpected processor count read from project file");
            Assert.IsTrue(fragmentB.Processors.Count() == 0, "Unexpected processor count read from project file");

            Assert.IsTrue(fragmentA.Processors[0] == "simple_processor", "Unexpected processor id read from project file");
            Assert.IsTrue(fragmentA.Processors[1] == "matrix_processor", "Unexpected processor id read from project file");

            Assert.IsTrue(writtenProject.Processors.Count() == 2);

            var processorA = writtenProject.Processors[0];

            Assert.IsTrue(processorA.Id == "simple_processor", "Unexpected processor id read from project file");
            Assert.IsTrue(processorA.ScriptFile == "kv_script_file.qik", "Unexpected processor script file read from project file");

            var processorB = writtenProject.Processors[1];

            Assert.IsTrue(processorB.Id == "matrix_processor", "Unexpected processor id read from project file");
            Assert.IsTrue(processorB.ScriptFile == "csv_script_file.qik", "Unexpected processor script file read from project file");


            Assert.IsTrue(writtenProject.Documents.Count() == 2);

            var documentA = writtenProject.Documents[0];

            Assert.IsTrue(documentA.OutputFilePaths[0] == "/documents/document1.txt", "Unexpected document output file read from project file");
            Assert.IsTrue(documentA.OutputFilePaths[1] == "/desktop/document2.txt", "Unexpected output file read from project file");

            Assert.IsTrue(documentA.Structure[0] == "fragment_A", "Unexpected structure id read from project file");
            
            var documentB = writtenProject.Documents[1];

            Assert.IsTrue(documentB.OutputFilePaths[0] == "/documents/document2.txt", "Unexpected document output file read from project file");
            Assert.IsTrue(documentB.Structure[0] == "fragment_A", "Unexpected structure id read from project file");
            Assert.IsTrue(documentB.Structure[1] == "fragment_B", "Unexpected structure id read from project file");
        }   
    }
}