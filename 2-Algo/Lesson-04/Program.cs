using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System;

namespace Lesson_04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2
            MyTree tree = new MyTree();
            tree.AddItem(50);
            tree.RemoveItem(50);
            Console.WriteLine(tree.GetRoot() is null ? "NULL" : tree.GetRoot().Value.ToString());
            Console.WriteLine($"Expected: NULL");
            tree.AddItem(50);
            tree.AddItem(25);
            tree.AddItem(15);
            tree.AddItem(10);
            tree.AddItem(20);
            tree.AddItem(40);
            tree.AddItem(35);
            tree.AddItem(45);
            tree.AddItem(75);
            tree.AddItem(65);
            tree.AddItem(60);
            tree.AddItem(70);
            tree.AddItem(90);
            tree.AddItem(80);
            tree.AddItem(95);
            TreeNode node;
            node = tree.GetNodeByValue(75);
            Console.WriteLine(node.Parent.Value);
            Console.WriteLine($"Expected: 50");
            node = tree.GetNodeByValue(65);
            Console.WriteLine(node.RightChild.Value);
            Console.WriteLine($"Expected: 70");
            tree.RemoveItem(75);
            Console.WriteLine(node.RightChild is null ? "NULL" : node.RightChild.Value.ToString());
            Console.WriteLine($"Expected: NULL");
            Console.WriteLine(tree.GetRoot().Value);
            Console.WriteLine($"Expected: 50");
            tree.RemoveItem(50);
            Console.WriteLine(tree.GetRoot().Value);
            Console.WriteLine($"Expected: 45");
            tree.AddItem(37);
            tree.AddItem(33);
            node = tree.GetNodeByValue(37);
            Console.WriteLine(node.Parent.Value);
            Console.WriteLine($"Expected: 35");
            node = tree.GetNodeByValue(33);
            Console.WriteLine(node.Parent.Value);
            Console.WriteLine($"Expected: 35");

            Console.ReadKey();
            tree.PrintTree();

            Console.ReadKey();

            // Task 1
            TestFinder();
            Console.ReadKey();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }

        static void TestFinder()
        {
            Finder finder = Finder.FillRandom();
            int num = finder.arrLength / 2;
            string toFind = finder.arrString[num];
            Console.WriteLine($"String to find: \"{toFind}\"");
            Console.WriteLine();
            Console.WriteLine(finder.FindInArray(toFind));
            Console.WriteLine($"\tExpected True");
            Console.WriteLine(finder.FindInHashSet(toFind));
            Console.WriteLine($"\tExpected True");
            Console.WriteLine(finder.FindInArray("wrong"));
            Console.WriteLine($"\tExpected False");
            Console.WriteLine(finder.FindInHashSet("wrong"));
            Console.WriteLine($"\tExpected False");
            Console.WriteLine();
        }
    }
}
