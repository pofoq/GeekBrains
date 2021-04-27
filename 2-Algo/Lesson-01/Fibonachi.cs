using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01
{

    // TASK 3

    public static class Fibonachi
    {
        public static int GetRecure(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
            {
                // F(N) = F(N-1) + F(N-2)
                return GetRecure(n - 1) + GetRecure(n - 2);
            }
        }

        public static int GetCycle(int n)
        {
            if (n < 0)
                return -1;
            int res = 0;
            int middle = 1;
            int temp;

            for (int i = 0; i < n; i++)
            {
                temp = res;
                res = middle;
                middle += temp;
            }

            return res;
        }

    }
}
