using System;
using System.Collections.Generic;

namespace Lesson_06
{
    class Program
    {
//         1---2---3---4
//         |       |
//         5---6---7
        static void Main(string[] args)
        {

            GrafTree graf = GrafTree.GetDefault();

            Console.WriteLine(graf.Root.Value);
            Print(1);
            int f = 6;
            Console.WriteLine($"BFS({f})");
            Node node = graf.BFS(f);
            Print(node.Value);
            Console.WriteLine($"DFS({f})");
            node = graf.DFS(f);
            Print(node.Value);
            f = 4;
            Console.WriteLine($"BFS({f})");
            node = graf.BFS(f);
            Print(node.Value);
            Console.WriteLine($"DFS({f})");
            node = graf.DFS(f);
            Print(node.Value);
            f = 3;
            Console.WriteLine($"BFS({f})");
            node = graf.BFS(f);
            Print(node.Value);
            Console.WriteLine($"DFS({f})");
            node = graf.DFS(f);
            Print(node.Value);

            Console.ReadKey();
        }

        static void Print<T>(T toPrint)
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Expected: {toPrint}");
            Console.ForegroundColor = color;
        }
    }
}
