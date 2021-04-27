using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01
{
    public class Task2
    {
        // TASK 2
        //Посчитайте сложность функции
        //Вычислите асимптотическую сложность функции из примера ниже.

        /*
         O(N * N * 4N) = O(4N^3) = O(N^3)

        ОТВЕТ: 
            асимптотическая сложность функции = O(N^3)
         */

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;    // 0(1)
            for (int i = 0; i < inputArray.Length; i++)         // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)     // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(4N)
                    {
                        int y = 0;      // O(1)

                        if (j != 0)     // O(1)
                        {
                            y = k / j;  // O(1)
                        }

                        sum += inputArray[i] + i + k + j + y;   // O(1)
                    }
                }
            }

            return sum;
        }
    }
}
