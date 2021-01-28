using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public static class Seasons
    {
        public static Season Show()
        {
            Console.Write("Введите номер месяца: ");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out int month);
                switch (month)
                {
                    case 12:
                    case 1:
                    case 2:
                        return Season.Winter;
                    case 3:
                    case 4:
                    case 5:
                        return Season.Spring;
                    case 6:
                    case 7:
                    case 8:
                        return Season.Summer;
                    case 9:
                    case 10:
                    case 11:
                        return Season.Autumn;
                    default:
                        Console.Write("Ошибка: введите число от 1 до 12 : ");
                        break;
                }
            }
        }
    }
}
