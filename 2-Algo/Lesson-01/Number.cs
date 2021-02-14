using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01
{
    public static class Number
    {
        // TASK 1
        //Напишите на C# функцию согласно блок-схеме
        //Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
        //1.	Написать консольное приложение.
        //2.	Алгоритм реализовать отдельно в функции согласно блок-схеме.
        //3.	Написать проверочный код в main функции.
        //4.	Код выложить на GitHub.

        public static string IsPrimeNumber(int n)
        {
            int d = 0, i = 2, number = n;
            while (i < number)
            {
                if (number % i == 0)
                    d++;
                i++;
            }

            if (d == 0)
                return "Простое";
            else
                return "Не простое";
        }
    }
}
