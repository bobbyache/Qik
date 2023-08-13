using System.IO;

namespace CygSoft.Qik.QikConsole
{
    public class Resources
    {
        public string GetWelcomeHeader(string version)
        {
            using Stream stream = this.GetType().Assembly.
                            GetManifestResourceStream($"QikConsole.welcome.txt");
            using StreamReader sr = new StreamReader(stream);

            var welcomeText = sr.ReadToEnd();

            return string.Format(welcomeText, version);
        }
    }
}
