using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_03
{
    public class Diagonal
    {
        int y;
        int x;

        int[,] arr1;

        public Diagonal(int _y, int _x)
        {
            x = _x;
            y = _y;
            arr1 = new int[y, x];
        }

        public void ShowArray()
        {
            Console.Clear();
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arr1[i, j] = i + j;
                }
            }

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    Console.Write(arr1[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0, j = 0; i < arr1.GetLength(0) && j < arr1.GetLength(1); i++, j++)
            {
                Console.SetCursorPosition(i, j + y + 2);
                Console.WriteLine();
                Console.WriteLine(arr1[i, j]);
            }
        }        
    }
}
