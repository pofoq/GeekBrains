using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace FileReader
{
    public class Catalog
    {
        public string folderPath { get; }
        List<MyFile> filesDone;

        public Catalog(string path)
        {
            folderPath = path;
            filesDone = new List<MyFile>();
        }

        public void CheckDoneFiles(string fileNamesPath)
        {
            if (File.Exists(fileNamesPath))
                foreach (var line in File.ReadAllLines(fileNamesPath))
                {
                    try
                    {
                        MyFile file = MyFile.GetFromJson(line);
                        if ((DateTime.Today - file.CreateDate).TotalDays > 10)
                            continue;
                        filesDone.Add(file);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Error!!! {ex.Message}");
                        Console.WriteLine();
                    }
                }
        }

        public void StartRead()
        {
            foreach (var filePath in Directory.GetFiles(folderPath, "*.txt"))
            {
                MyFile file;
                if (IsDone(filePath, out file))
                    continue;
                if (file.Read())
                    filesDone.Add(file);
            }
            Wait(3);
            foreach (MyFile myFile in filesDone)
            {
                if ((DateTime.Today - myFile.CreateDate).TotalDays > 10)
                    filesDone.Remove(myFile);
            }
        }

        void Wait(int seconds)
        {
            Console.Write("Waiting");
            for (int i = 0; i < seconds; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            int len = Console.CursorLeft;
            Console.CursorLeft = 0;
            for (int i = 0; i <= len; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft = 0;
        }

        bool IsDone(string filePath, out MyFile file)
        {
            filePath = Path.GetFullPath(filePath);
            file = null;
            if (File.Exists(filePath))
            {
                file = new MyFile(filePath);
                foreach (var f in filesDone)
                {
                    if (f.FullName == file.FullName && f.CreateDate == file.CreateDate)
                        return true;
                }
                return false;
            }
            Program.log.Add($"Файл не найден: {filePath}");
            return true;
        }

        public static string GetDirPath()
        {
            string path;
            Console.WriteLine("Укажите путь к папке: ");
            while (true)
            {
                path = Path.GetFullPath(Console.ReadLine());
                if (Directory.Exists(path))
                    break;
                else if (Directory.Exists(Directory.GetParent(path).FullName))
                {
                    Directory.CreateDirectory(path);
                    break;
                }
                else
                    Console.WriteLine("Указан не существующий путь. Попробуйте еще раз: ");
            }
            return path;
        }

    }
}
