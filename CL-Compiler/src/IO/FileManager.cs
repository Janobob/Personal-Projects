using System;
using System.IO;

namespace CLCompiler.IO
{
    public class FileManager
    {
        public string ReadContentFromFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();

            return File.ReadAllText(path);
        }

        public void WriteContentToFile(string content, string path)
        {
            if (File.Exists(path)) ConsoleManager.Warning("Overriding existing File!");

            File.WriteAllText(path, content);
        }
    }
}