using System;
using System.IO;

namespace lesson_05
{
    public static class MyFile
    {

        // Task 1
        public static void WriteTo(string fileName)
        {
            Console.WriteLine("Напишите что-нибудь: ");
            File.WriteAllText(fileName, Console.ReadLine());
            Read(fileName);
        }

        // Task 3 
        public static void WriteBinaryTo(string fileName)
        {
            Console.WriteLine("Напишите набор чисел от 0 до 255: ");
            string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string tempStr = "";
            byte[] bytes;

            for (int i = 0; i < arr.Length; i++)
            {
                if (byte.TryParse(arr[i], out byte b))
                    tempStr += i + ",";
            }

            string[] itemsNum = tempStr.Split(',', StringSplitOptions.RemoveEmptyEntries);

            bytes = new byte[itemsNum.Length];

            for (int i = 0; i < itemsNum.Length; i++)
            {
                int n = int.Parse(itemsNum[i]);
                bytes[i] = byte.Parse(arr[n]);
            }

            File.WriteAllBytes(fileName, bytes);
            Read(fileName);
        }

        static void Read(string fileName)
        {
            Console.WriteLine();
            Console.Write($"{fileName} записан.{Environment.NewLine}Чтобы прочитать файл, нажмите \"Y\": ");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine();
                FileInfo fileInfo = new FileInfo(fileName);
                if (fileInfo.Extension.ToLower() == ".bin")
                {
                    byte[] bytes = File.ReadAllBytes(fileName);
                    foreach (var b in bytes)
                    {
                        Console.Write($"{(int)b} ");
                    }
                }
                else
                    Console.WriteLine(File.ReadAllText(fileName));
            }
        }
    }
}
