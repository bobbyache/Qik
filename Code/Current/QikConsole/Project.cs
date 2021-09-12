using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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

        public override string ToString() => Id;
    }

    public class Document
    {
        public string[] OutputFilePaths { get; set; }
        public string[] Structure { get; set; }
    }

    public class Menu<T>
    {
        private List<T> menuItems = new List<T>();

        public string[] GetReadableMenu()
        {
            var menuItemText = new List<string>();
            
            for (var i  = 0; i < menuItems.Count(); i++)
            {
                menuItemText.Add($"{i.ToString().PadLeft(3)}\t{menuItems[i].ToString()}");
            }
            return menuItemText.ToArray();
        }

        public void AddItems(IEnumerable<T> newItems)
        {
            menuItems.AddRange(newItems);
        }

        public T ItemAt(int menuNumber)
        {
            return menuItems.ElementAtOrDefault(menuNumber - 1);
        }
    }
}
