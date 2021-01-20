using System;

namespace EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;

            while (true)
            {
                Console.WriteLine("Please, enter an Integer number: ");
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num % 2 == 0)
                        Console.WriteLine($"The number {num} is Even");
                    else
                        Console.WriteLine($"The number {num} is Odd");
                    break;
                }
            }

            Office office1 = new Office() { workDays = 0b_0011111 };
            Office office2 = new Office();
            office2.workDays = (sbyte)Week.Monday + (int)Week.Tuethday + (int)Week.Wednesday + (int)Week.Thirsday + (int)Week.Friday;

            Week week1 = (Week)office1.workDays;
            Console.WriteLine(week1);

            Week week2 = (Week)office2.workDays;
            Console.WriteLine(week2);

            if (office1.workDays == office2.workDays)
                Console.WriteLine("Office Work Days is equals");
            if (week1 == week2)
                Console.WriteLine("Weeks is equals");

            Console.ReadKey();
        }
    }
}
