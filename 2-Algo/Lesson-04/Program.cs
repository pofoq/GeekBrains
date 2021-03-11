using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson_04
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.Clear();
            var arr = TreeHelper.GetTreeInLine(tree);
            foreach (var a in arr)
            {
                Console.Write(a.Node.Value + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"Expected: 45, 25, 70, 15, 40, 65, 90, 10, 20, 35, 60, 80, 95, 33, 37");
            Console.WriteLine();
            var res = tree.BFS(37).Value;
            Console.WriteLine();
            Console.WriteLine(res);
            Console.WriteLine($"Expected: 37");
            Console.WriteLine();
            res = tree.DFS(33).Value;
            Console.WriteLine();
            Console.WriteLine(res);
            Console.WriteLine($"Expected: 33");
            Console.ReadKey();
        }
    }
}
