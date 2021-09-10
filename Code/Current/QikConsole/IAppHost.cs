
namespace CygSoft.Qik.QikConsole
{
    public interface IAppHost
    {
        string[] GetTerminalList();
        void OpenProject(string path);
    }
}
