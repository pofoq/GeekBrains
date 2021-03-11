using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Lesson_04
{
    public class Finder
    {
        public int arrLength;
        public HashSet<string> arrHashSet;
        public string[] arrString;

        public Finder(int arrayLength)
        {
            arrLength = arrayLength;
        }

        public bool FindInArray(string toFind)
        {
            for (int i = 0; i < arrLength; i++)
            {
                if (arrString[i].ToString() == toFind)
                    return true;
            }
            return false;
        }

        public bool FindInHashSet(string toFind)
        {
            return arrHashSet.Contains(toFind);
        }

        public static Finder FillRandom(int arrayLength = 10_000)
        {
            Finder finder = new Finder(arrayLength);
            finder.arrHashSet = new HashSet<string>();
            finder.arrString = new string[finder.arrLength];
            for (int i = 0; i < finder.arrLength; i++)
            {
                string r = RandomString(10);
                finder.arrString[i] = r;
                finder.arrHashSet.Add(r);
            }
            return finder;
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] ch = new char[length];
            for (int i = 0; i < length; i++)
            {
                ch[i] = chars[random.Next(chars.Length)];
            }
            return new string(ch);
        }
    }
}
