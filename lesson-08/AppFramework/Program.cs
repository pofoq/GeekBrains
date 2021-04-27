using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                Console.Write("Введите своё имя: ");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.Clear();
            }
            string userName = Properties.Settings.Default.UserName;
            string greeting = Properties.Settings.Default.Greeting;
            Console.WriteLine($"{greeting}, {userName}");
            Console.WriteLine();
            if (Properties.Settings.Default.Age == 0)
            {
                while (true)
                {
                    Console.Write("Укажите свой возраст: ");
                    if (int.TryParse(Console.ReadLine(), out age))
                    {
                        Properties.Settings.Default.Age = age;
                        Properties.Settings.Default.Save();
                        break;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                age = Properties.Settings.Default.Age;
                Console.WriteLine($"Ваш возраст: {age}");
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Work))
            {
                Console.Write("Укажите свой род деятельности: ");
                Properties.Settings.Default.Work = Console.ReadLine();
                Properties.Settings.Default.Save();
                Console.Clear();
                Main(null);
            }
            else
                Console.WriteLine($"Ваш род деятельности: {Properties.Settings.Default.Work}");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
