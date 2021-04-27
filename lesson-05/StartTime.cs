using System;
using System.IO;

namespace lesson_05
{
    public static class StartTime
    {
        // Task 2

        static string fileName = "startup.txt";

        public static void Write()
        {
            ReadLast();
            File.AppendAllText(fileName, Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        // Прочитать последнюю строку и вывести на экран время последнего запуска программы (если останется время, сделаю)

        public static void ReadLast()
        {
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                Console.WriteLine($"Last Startup Time: {lines[lines.Length - 1]}");
            }
            else
                Console.WriteLine("Program is never used.");
        }
    }
}
