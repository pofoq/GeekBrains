using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02
{
    public static class Finder
    {
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;    // O(1)
            int max = inputArray.Length - 1;    // O(1)
            while (min <= max)  // O(не знаю)
            {
                int mid = (min + max) / 2;  // O(1)
                if (searchValue == inputArray[mid])
                {
                    return mid; // O(1)
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;  // O(1)
                }
                else
                {
                    min = mid + 1;  // O(1)
                }
            }
            return -1;  // O(1)
        }
    }
}
