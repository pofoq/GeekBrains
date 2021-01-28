using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    static public class Fibonachi
    {
        static public int Show(int n)
        {
            Console.WriteLine(n);
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Show(n - 1) + Show(n - 2);
            }
        }
    }
}
