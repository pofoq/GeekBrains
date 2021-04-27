using System;
using System.Diagnostics;

namespace Lesson_01
{
    class Program
    {
        public static void Answer(int res)
        {
            Answer(res.ToString());
        }

        public static void Answer(string res)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\t{res}");
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            bool autoTest = true; // Чтобы вводить значения в ручном режиме, установи значение false
            int n;
            int[] arrInput = { 1, 6, 17, 28, 31, -1, -17, 0 };
            string[] ans1 = { "Простое", "Не простое", "Простое", "Не простое", "Простое", "Простое", "Простое", "Простое" };
            string[] ans2 = { "1", "random", "random", "random", "random", "0", "random", "0" };
            string[] ans3 = { "1", "8", "1597", "317811", "1346269", "Ошибка", "Ошибка", "0" };

            Random rnd = new Random();

            for (int num = 0; num < arrInput.Length; num++)
            {
                // Task 1
                if (autoTest)
                    n = arrInput[num];
                //n = rnd.Next(-17, 37); // Диапазон автоматических значений
                else
                    n = GetInt();

                Console.WriteLine($"Введено число {n}");
                Console.WriteLine();
                Console.Write(Number.IsPrimeNumber(n));
                Answer(ans1[num]);

                // Task 2
                int[] arr = new int[Math.Abs(n)];
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    arr[i] = random.Next(1, n);
                }
                Console.Write($"Strange Sum: {Task2.StrangeSum(arr)}");
                Answer(ans2[num]);
                Console.WriteLine();
                Console.WriteLine();

                // Task 3
                Stopwatch sw = new Stopwatch();
                sw.Restart();
                Console.Write($"Фибоначчи Цикл:\t\t{Fibonachi.GetCycle(n)}");
                Answer(ans3[num]);
                sw.Stop();
                Console.WriteLine("время выполнения: " + sw.ElapsedMilliseconds);
                Console.WriteLine();
                sw.Restart();
                Console.Write($"Фибоначчи Рекурсия:\t");
                if (n >= 0)
                    Console.Write($"{Fibonachi.GetRecure(n)}");
                else
                    Console.Write($"Ошибка. Переполнение памяти.");
                Answer(ans3[num]);
                sw.Stop();
                Console.WriteLine("время выполнения: " + sw.ElapsedMilliseconds);
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
