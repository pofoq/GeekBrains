using BenchmarkDotNet.Attributes;

namespace Lesson_04
{
    public class Bench
    {
        Finder finder;
        int toFind;

        public Bench()
        {
            finder = Finder.FillRandom();
            toFind = finder.arrLength / 2;
        }

        [Benchmark]
        public void FindExistInArray()
        {
            finder.FindInArray(finder.arrString[toFind]);
        }

        [Benchmark]
        public void FindExistInHashSet()
        {
            finder.FindInHashSet(finder.arrString[toFind]);
        }

        [Benchmark]
        public void FindNotExistInArray()
        {
            finder.FindInArray("wrongValue");
        }

        [Benchmark]
        public void FindNotExistInHashSet()
        {
            finder.FindInHashSet("wrongValue");
        }
    }
}
