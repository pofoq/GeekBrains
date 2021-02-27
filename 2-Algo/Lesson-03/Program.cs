using BenchmarkDotNet.Running;
using System;
using BenchmarkDotNet.Attributes;

namespace lesson03
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
