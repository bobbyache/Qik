using CygSoft.Qik.QikConsole;
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
            
            project.ScriptPath = "kv_script_file.qik";

            project.Inputs.Add(new Input() { Symbol = "@Input1", Value = "Input 1" });
            project.Inputs.Add(new Input() { Symbol = "@Input2", Value = "Input 2" });

            project.Fragments.Add(new Fragment { Id = "fragment_A", Path = "C:\\Users\\RobB\\Desktop\\fragment_A.txt"});
            project.Fragments.Add(new Fragment { Id = "fragment_B", Path = "C:\\Users\\RobB\\Desktop\\fragment_B.txt" });

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

            Assert.IsTrue(writtenProject.Inputs.Count() == 2, "Unexpected number of fragments read from project file");
            var inputA = project.Inputs[0];
            var inputB = project.Inputs[1];
            Assert.IsTrue(inputA.Symbol == "@Input1", "Unexpected input symbol read from project file");
            Assert.IsTrue(inputA.Value == "Input 1", "Unexpected input value read from project file");
            Assert.IsTrue(inputB.Symbol == "@Input2", "Unexpected input symbol read from project file");
            Assert.IsTrue(inputB.Value == "Input 2", "Unexpected input value read from project file");

            Assert.IsTrue(writtenProject.Fragments.Count() == 2, "Unexpected number of fragments read from project file");

            var fragmentA = project.Fragments[0];
            var fragmentB = project.Fragments[1];

            Assert.IsTrue(fragmentA.Id == "fragment_A", "Unexpected fragment id read from project file");
            Assert.IsTrue(fragmentB.Id == "fragment_B", "Unexpected fragment id read from project file");

            Assert.IsTrue(fragmentA.Path == "C:\\Users\\RobB\\Desktop\\fragment_A.txt", "Unexpected fragment path read from project file");
            Assert.IsTrue(fragmentB.Path == "C:\\Users\\RobB\\Desktop\\fragment_B.txt", "Unexpected fragment path read from project file");

            Assert.IsTrue(project.ScriptPath == "kv_script_file.qik", "Unexpected processor script path read from project file");

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