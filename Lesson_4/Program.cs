using System;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1 - FullName.cs
            Console.WriteLine("FULL NAME");
            Console.WriteLine();
            string fullName = FullName.GetFullName(FullName.GetString("First Name"), FullName.GetString("Last Name"), FullName.GetString("Patronymic"));
            string fullName2 = FullName.GetFullName(FullName.GetString("First Name"), FullName.GetString("Last Name"), FullName.GetString("Patronymic"));
            string fullName3 = FullName.GetFullName(FullName.GetString("First Name"), FullName.GetString("Last Name"), FullName.GetString("Patronymic"));

            Console.WriteLine();
            Console.WriteLine(fullName);
            Console.WriteLine(fullName2);
            Console.WriteLine(fullName3);

            Next();

            // Task 2 - SumFromString.cs
            Console.WriteLine("SUM FROM STRING");
            Console.WriteLine();
            Console.Write("Enter numbers for SUM with space between: ");
            int sum = SumFromString.GetSum(Console.ReadLine(), out string error);
            Console.WriteLine($"Sum = {sum}; {error}");

            Next();

            // Task 3 - Seasons.cs
            Console.WriteLine("SEASONS");
            Console.WriteLine();
            Console.WriteLine(Seasons.Show());

            Next();

            // Task 4 - Fibonach.cs
            while (true)
            {
                Console.WriteLine("FIBONACHI");
                Console.WriteLine();
                Console.Write("Please enter a number: ");
                int n;
                while (!int.TryParse(Console.ReadLine(), out n))
                    Console.Write("Error. Please enter a number: ");

                Fibonachi.Show(n);

                Console.WriteLine("Press \"Q\" to exit.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();
                if (keyInfo.Key == ConsoleKey.Q)
                    break;
            }
        }

        static void Next()
        {
            Console.WriteLine();
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
