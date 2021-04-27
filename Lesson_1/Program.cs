using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя пользователя: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Привет, {userName}, сегодня {DateTime.Now:dd.MM.yyyy HH:mm:ss}{Environment.NewLine}");
        }
    }
}
