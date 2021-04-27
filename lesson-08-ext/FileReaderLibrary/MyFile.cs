using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FileReadesLibrary
{
    public class MyFile
    {
        public string FullName { get; set; }
        //public bool IsProcessed { get; private set; }
        public DateTime CreateDate { get; set; }

        public MyFile(string path)
        {
            FullName = Path.GetFullPath(path);
            //IsProcessed = false;
            CreateDate = File.GetCreationTime(FullName);
        }

        public MyFile()
        {

        }

        public bool Read(Log log = null)
        {
            try
            {
                if (File.Exists(FullName))
                {
                    Console.WriteLine();
                    foreach (string line in File.ReadAllLines(FullName))
                        Console.WriteLine(line);
                    //IsProcessed = true;
                    if (log != null) log.Add(this);
                    Console.WriteLine();
                    Console.WriteLine($"Файл прочитан ({(new FileInfo(FullName)).Name})");
                    Console.WriteLine();
                    return true;
                }
                if (log != null) log.Add($"Файл не найден: {FullName}");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }

        static public MyFile GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<MyFile>(json);
        }
    }
}
