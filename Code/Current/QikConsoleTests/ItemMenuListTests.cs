using CygSoft.Qik;
using CygSoft.Qik.QikConsole;
using CygSoft.Qik.Functions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace QikConsoleTests
{
    [TestFixture]
    class ItemMenuListTests
    {
        [Test]
        public void Should_Populate_The_Menu()
        {
            var processors = new List<Processor>()
            {
                new Processor() { ScriptFile = "script_1.qik", Id = "Deployment Script" },
                new Processor() { ScriptFile = "script_2.qik", Id = "Process Script" },
            };

            var menu = new Menu<Processor>();
            menu.AddItems(processors);
            var menuText = menu.GetReadableMenu();

            Assert.AreEqual(2, menuText.Count());
        }
    }
}