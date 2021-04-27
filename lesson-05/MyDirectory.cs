using System;
using System.IO;

namespace lesson_05
{
    // task 4
    /// <summary>
    /// Любая попытка решить эту задачу методом без рекурсии, приводить меня к рекурсии ))
    /// </summary>
    public class MyDirectory
    {
        public string FileName { get { return fileName; } }
        string fileName;
        string folderPath;

        public MyDirectory(string folderPath, string fileName)
        {
            this.folderPath = Path.GetFullPath(folderPath);
            this.fileName = fileName;
        }

        public void Show()
        {
            Console.WriteLine(File.ReadAllText(fileName));
        }

        public void GetDirsRecurs()
        {
            File.WriteAllText(fileName, folderPath + Environment.NewLine);
            GetDirsRecurs(folderPath);
        }

        void GetDirsRecurs(string path, int level = 0)
        {
            string[] directories = Directory.GetDirectories(path);

            string indent = "";

            for (int i = 0; i < level; i++)
                indent += "   ";

            File.AppendAllText(fileName, indent + "|" + Environment.NewLine);
            File.AppendAllText(fileName, indent + "|");

            foreach (string dir in directories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dir);
                File.AppendAllText(fileName, "--" + directoryInfo.Name + Environment.NewLine);
                GetDirsRecurs(dir, level + 1);
            }
        }
    }
}
