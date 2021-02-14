using System;
using System.Diagnostics;

namespace Lesson_01
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                // Task 1
                int n = GetInt();
                Console.WriteLine(Number.IsPrimeNumber(n));
                Console.WriteLine();

                // Task 2
                int[] arr = new int[n];
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    arr[i] = random.Next(1, n);
                }
                Console.Write($"Strange Sum: {Task2.StrangeSum(arr)}");
                Console.WriteLine();
                Console.WriteLine();

                // Task 3
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                Console.WriteLine($"Фибоначчи Цикл:\t\t{Fibonachi.GetCycle(n)}");
                sw.Stop();
                Console.WriteLine("время выполнения: " + sw.ElapsedMilliseconds);
                Console.WriteLine();
                sw.Restart();
                Console.WriteLine($"Фибоначчи Рекурсия:\t{Fibonachi.GetRecure(n)}");
                sw.Stop();
                Console.WriteLine("время выполнения: " + sw.ElapsedMilliseconds);
                Console.WriteLine();
                Console.WriteLine("For exit press Q...");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    break;
                Console.Clear();
            }
        }

        static int GetInt()
        {
            int n;
            Console.Write("Введите целое число: ");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine();
                Console.Write("Ошибка, введите целое число: ");
            }
            Console.WriteLine();
            Console.Clear();
            return n;
        }
    }
}
