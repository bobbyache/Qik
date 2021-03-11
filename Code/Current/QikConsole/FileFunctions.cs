using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CygSoft.Qik.Console
{
    public interface IFileFunctions
    {
        bool FileExists(string filePath);
        bool DirectoryExists(string directoryPath);
        void CreateDirectory(string directoryPath);
        string GetFileDirectory(string filePath);
        string ReadTextFile(string filePath);
        void WriteTextFile(string path, string contents);
        bool FindScriptInFolder(string directoryPath, out string scriptPath);
        bool FindBlueprintFilesInFolder(string directoryPath, out IEnumerable<string> blueprintPaths);
        bool FindInputsFileInFolder(string directoryPath, out string jsonInputFile);
        bool IsInputsFile(string path);
        bool IsFolder(string path);
        bool IsScript(string path);
        bool IsBlueprint(string path);
        string GeneratOutputPath(string blueprintFilePath);
    }

    public class FileFunctions : IFileFunctions
    {
        private readonly FileSettings fileSettings;

        public FileFunctions(FileSettings fileSettings) => this.fileSettings = fileSettings;

        public bool FileExists(string filePath) => File.Exists(filePath);
        public string GetFileDirectory(string filePath) => Path.GetDirectoryName(filePath);

        public string ReadTextFile(string filePath)
        {
            string contents = null;
            // Specify file, instructions, and priveledges
            using (var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                // Create a new stream to read from a file
                using (StreamReader sr = new StreamReader(file))
                {
                    contents = sr.ReadToEnd();
                }
            }
            return contents;
        }

        public void WriteTextFile(string path, string contents)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.Write(contents);
                streamWriter.Flush();
            }
        }

        public bool DirectoryExists(string directoryPath) => Directory.Exists(directoryPath);

        public void CreateDirectory(string directoryPath) => Directory.CreateDirectory(directoryPath);

        public bool FindInputsFileInFolder(string directoryPath, out string inputFile)
        {
            inputFile = Path.Combine(directoryPath, fileSettings.InputsFileName);
            return File.Exists(inputFile);
        }

        public bool FindScriptInFolder(string directoryPath, out string scriptPath)
        {
            scriptPath = Path.Combine(directoryPath, fileSettings.ScriptFileName);
            return File.Exists(scriptPath);
        }

        public bool FindBlueprintFilesInFolder(string directoryPath, out IEnumerable<string> blueprintPaths)
        {
            var result = new List<string>();

            foreach (string file in Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                .Where(s => fileSettings.BlueprintExtensions.Any(ext => ext == Path.GetExtension(s))))
            {
                result.Add(file);
            }
            blueprintPaths = result;

            return blueprintPaths is not null && blueprintPaths.Count() > 0;
        }

        public bool IsFolder(string path)
        {
            // TODO: To generate an error here you can pass a path with a trailing "\" in the --path prompt
            // You can use this to start some form of error handling in the app
            var fileSystemInfo = new DirectoryInfo(path);
            return fileSystemInfo.IsDirectory();
        }

        public bool IsScript(string path)
        {
            // TODO: Definitely look specifically for a file called script.qik (even if it is read out of settings)
            if (!IsFolder(path))
            {
                if (Path.GetFileName(path) == fileSettings.ScriptFileName && File.Exists(path))
                    return true;
            }
            return false;
        }

        public bool IsInputsFile(string path)
        {
            // TODO: Definitely look specifically for a file called inputs.json  (even if it is read out of settings)
            if (!IsFolder(path))
            {
                if (Path.GetFileName(path) == fileSettings.InputsFileName && File.Exists(path))
                    return true;
            }
            return false;
        }

        public bool IsBlueprint(string path)
        {
            if (!IsFolder(path))
            {
                if (Path.GetExtension(path) == ".blu" && File.Exists(path))
                    return true;
            }
            return false;
        }

        public string GeneratOutputPath(string blueprintFilePath)
        {
            var directory = Path.GetDirectoryName(blueprintFilePath);
            var fileName = Path.GetFileName(blueprintFilePath);

            return Path.Combine(directory, "output", $"{fileName}");
        }
    }
}