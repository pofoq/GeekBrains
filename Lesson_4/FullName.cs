using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    public static class FullName
    {
        public static string GetString(string varName)
        {
            Console.Write($"Enter {varName}: ");
            return Console.ReadLine().Trim();
        }

        public static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {lastName} {patronymic}";
        }
    }
}
