using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_08
{
    class Program
    {
        static void Main(string[] args)
        {
            // TASK 1
            WriteLine("Task 1 results check", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine();
            int[] startArray = new int[] { 17, 92, 67, 46, 9, 83, 71, 37, 48, 55, 32, 90, 66, 72, 25 };

            BucketSort.SortArray(startArray, out List<int[]> result);

            CheckResult(GetExpectedResultsTask1(), result);

            Console.ReadKey();

            // TASK 2
            WriteLine("Task 2 results check", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine();

            // create default file and get array from this file
            int[] res2 = ExternalSort.GetArrayFromFile(ExternalSort.Sort(null, 5)); 
            CheckResult(GetExpectedResultsTask2(), new List<int[]> { res2 });
            Console.WriteLine();
            Console.WriteLine();

            FileInfo file;
            while (true)
            {
                Console.WriteLine($"Enter Path to file for sorting: ");
                string filePath = Console.ReadLine();
                file = new FileInfo(filePath);
                if (file.Exists)
                    break;
            }
            file = ExternalSort.Sort(file.FullName, 1000);
            if (ExternalSort.IsSorted(file, out string status))
                WriteLine(status, ConsoleColor.Green);
            else
                WriteLine(status, ConsoleColor.Red);

            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            ConsoleColor current = Console.ForegroundColor;
            if (Console.ForegroundColor != color)
                Console.ForegroundColor = color;
            Console.Write(text);
            if (Console.ForegroundColor != current)
                Console.ForegroundColor = color;
            Console.ForegroundColor = current;
        }

        public static void Write(string text, ConsoleColor color)
        {
            ConsoleColor current = Console.ForegroundColor;
            if (Console.ForegroundColor != color)
                Console.ForegroundColor = color;
            Console.Write(text);
            if (Console.ForegroundColor != current)
                Console.ForegroundColor = color;
            Console.ForegroundColor = current;
        }

        static void CheckResult(List<int[]> expected, List<int[]> result)
        {
            ConsoleColor current = Console.ForegroundColor;
            for (int i = 0; i < expected.Count; i++)
            {
                foreach (var el in result[i])
                    Write($"{el} ", current);
                Console.WriteLine();

                foreach (var el in expected[i])
                    Write($"{el} ", ConsoleColor.Green);
                Console.WriteLine();

                bool check = true;
                for (int j = 0; j < expected[i].Length; j++)
                {
                    if (expected[i][j] != result[i][j])
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                    WriteLine("GOOD", ConsoleColor.Green);
                else
                    WriteLine("BAD", ConsoleColor.Red);

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static List<int[]> GetExpectedResultsTask1()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { 17, 9 });
            expected.Add(new int[] { 37, 32, 25 });
            expected.Add(new int[] { 46, 48, 55 });
            expected.Add(new int[] { 67, 71, 66, 72 });
            expected.Add(new int[] { 92, 83, 90 });
            expected.Add(new int[] { 9, 17 });
            expected.Add(new int[] { 25, 32, 37 });
            expected.Add(new int[] { 46, 48, 55 });
            expected.Add(new int[] { 66, 67, 71, 72 });
            expected.Add(new int[] { 83, 90, 92 });
            expected.Add(new int[] { 9, 17, 25, 32, 37, 46, 48, 55, 66, 67, 71, 72, 83, 90, 92 });
            return expected;
        }

        static List<int[]> GetExpectedResultsTask2()
        {
            List<int[]> expected = new List<int[]>();
            expected.Add(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 20, 22, 30, 33, 40, 44, 50, 55, 66, 70, 77, 80, 88, 90, 99 });
            return expected;
        }
    }
}
