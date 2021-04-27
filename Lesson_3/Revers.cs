using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_03
{
    public static class Revers
    {
        public static string GetReversString_1(string str)
        {
            StringBuilder builder = new StringBuilder(str.Length);
            for (int i = str.Length - 1; i >= 0; i--)
            {
                builder.Append(str[i]);
            }
            return builder.ToString();
        }

        public static string GetReversString_2(string str)
        {
            IEnumerable<char> array = str.Reverse();
            StringBuilder builder = new StringBuilder(str.Length);
            foreach (var s in array)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }
    }
}
