﻿using System.IO;

namespace Qik.LanguageEngine.IntegrationTests.Helpers
{
    public class FileHelpers
    {
        public static string GetFolder() => "..\\..\\..\\..\\QikTests\\Files";
        public static string GetSubFolder(string appendedPath) => Path.Combine(GetFolder(), appendedPath);
        public static string ResolvePath(string fileName) => Path.Combine(GetFolder(), fileName);
        public static string ReadText(string fileName) => File.ReadAllText(ResolvePath(fileName));
        public static void DeleteFile(string fileName) => File.Delete(ResolvePath(fileName));
    }
}
