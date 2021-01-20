using System;

namespace CurrentMonth
{
    public class Program
    {
        public enum Month : sbyte
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public static int Main(string[] args)
        {
            int month;
            ConsoleColor defaultColor = Console.ForegroundColor;
            Month currentMonth = (Month)DateTime.Now.Month;

            Console.Write("Enter number of current month: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out month);

                if (month == (int)currentMonth)
                {
                    ShowMsg($"Current month is {currentMonth}", ConsoleColor.Green);
                    break;
                }
                else if (month > 0 && month < 13)
                    ShowMsg("Wrong! Try again! Enter number of current month: ", ConsoleColor.Red);
                else
                    ShowMsg($"Please, enter correct month number: ", ConsoleColor.Yellow);
            }

            //Console.ReadKey();
            Console.WriteLine();
            return month;

            void ShowMsg(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine();
                Console.Write(text);
                if (color != defaultColor)
                    Console.ForegroundColor = defaultColor;
            }
        }
    }
}
