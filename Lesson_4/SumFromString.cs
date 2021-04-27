using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    public static class SumFromString
    {
        public static int GetSum(string stringToSum, out string errorMsg)
        {
            int sum = 0;
            bool hasError = false;
            string[] strArray = stringToSum.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(var s in strArray)
            {
                if (int.TryParse(s, out int res))
                {
                    sum += res;
                }
                else if (!hasError)
                    hasError = true;
            }

            if (hasError)
                errorMsg = "With Errors";
            else
                errorMsg = "With No Errors";

            return sum;
        }
    }
}
